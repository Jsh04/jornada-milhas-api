using System.Text;
using System.Text.Json;
using JornadaMilhas.Common.DomainEventConsumer;
using JornadaMilhas.Common.EventHandler;
using JornadaMilhas.Common.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace JornadaMilhas.Infrastruture.MessageBus;

public class MessageBusProducerService : IMessageBusProducerService, IDisposable
{
    private readonly IModel _channelConsume;
    private readonly IModel _channelPublisher;
    private readonly IConnection _connection;
    private readonly RabbitMqOptions _rabbitMqOptions;

    public MessageBusProducerService(IOptions<RabbitMqOptions> rabbitMqOptions)
    {
        _rabbitMqOptions = rabbitMqOptions.Value;

        var connectionFactory = new ConnectionFactory
        {
            HostName = _rabbitMqOptions.HostName,
            Port = _rabbitMqOptions.Port
        };

        _connection = connectionFactory.CreateConnection();

        _channelPublisher = _connection.CreateModel();
        _channelConsume = _connection.CreateModel();
    }

    public void Dispose()
    {
        _connection?.Dispose();
        _channelPublisher?.Dispose();
        _channelConsume?.Dispose();

        GC.SuppressFinalize(this);
    }

    public void Publish<T>(string queue, T dataToSend)
    {
        var bodyData = GetBodyMessage(dataToSend);

        var nameExchange = typeof(T).Name;

        ExchangeDeclareDynamicType(_channelPublisher, nameExchange);

        QueueDeclareDynamicType(_channelPublisher, queue);

        QueueBindDynamicType(_channelPublisher, nameExchange, queue);

        _channelPublisher.BasicPublish(
            nameExchange,
            queue,
            null,
            bodyData);
    }

    public void Subscribe<TDomainEvent>(IDomainEventConsumeHandler<TDomainEvent> eventHandler, string queue)
        where TDomainEvent : DomainEventConsumeBase
    {
        var eventName = typeof(TDomainEvent).Name;

        ExchangeDeclareDynamicType(_channelConsume, eventName);

        QueueDeclareDynamicType(_channelConsume, queue);

        QueueBindDynamicType(_channelConsume, eventName, queue);

        var consumer = new EventingBasicConsumer(_channelConsume);

        consumer.Received += async (model, ea) =>
        {
            var objDeserialized = GetDataOfBodyQueue<TDomainEvent>(ea);

            if (objDeserialized is not null)
                await eventHandler.Handle(objDeserialized);
        };

        _channelConsume.BasicConsume(queue, true, consumer);
    }

    private static void QueueBindDynamicType(IModel channel, string nameExchange, string queue)
    {
        channel.QueueBind(queue, nameExchange, queue);
    }

    private static void ExchangeDeclareDynamicType(IModel channel, string exchangeName)
    {
        channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
    }

    private static void QueueDeclareDynamicType(IModel channel, string queue)
    {
        channel.QueueDeclare(queue, false, false, true, null);
    }

    private static byte[] GetBodyMessage<T>(T dataToSend)
    {
        var eventMessageJsonString = JsonSerializer.Serialize(dataToSend);
        var body = Encoding.UTF8.GetBytes(eventMessageJsonString);

        return body;
    }

    private static TDomainEvent? GetDataOfBodyQueue<TDomainEvent>(BasicDeliverEventArgs ea)
    {
        var byteArrayData = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(byteArrayData);
        return JsonSerializer.Deserialize<TDomainEvent>(message);
    }
}