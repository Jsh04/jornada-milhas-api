
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using JornadaMilhas.Common.DomainEventConsumer;
using JornadaMilhas.Common.EventHandler;
using JornadaMilhas.Common.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace JornadaMilhas.Infrastruture.MessageBus;

public class MessageBusProducerService : IMessageBusProducerService
{
    private readonly RabbitMqOptions _rabbitMqOptions;
    private readonly ConnectionFactory _connectionFactory;
    public MessageBusProducerService(IOptions<RabbitMqOptions> rabbitMqOptions)
    {
        _rabbitMqOptions = rabbitMqOptions.Value;

        _connectionFactory = new ConnectionFactory
        {
            HostName = _rabbitMqOptions.HostName,
            Port = _rabbitMqOptions.Port
        };
    }

    public void Publish<T>(string queue, T dataToSend)
    {
        using var connection = _connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();


        var bodyData = GetBodyMessage(dataToSend);

        var nameExchange = typeof(T).Name;

        ExchangeDeclareDynamicType(channel, nameExchange);

        QueueDeclareDynamicType(channel, queue);

        QueueBindDynamicType(channel, nameExchange, queue);

        channel.BasicPublish(
            exchange: nameExchange,
            queue,
            basicProperties: null,
            body: bodyData);
    }

    private static void QueueBindDynamicType(IModel channel, string nameExchange, string queue) =>
        channel.QueueBind(queue: queue, exchange: nameExchange, queue);

    private static void ExchangeDeclareDynamicType(IModel channel, string exchangeName) => 
        channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Direct);

    private static void QueueDeclareDynamicType(IModel channel, string queue) =>
        channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: true, arguments: null);

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

    public void Subscribe<TDomainEvent>(IDomainEventHandler<TDomainEvent> eventHandler, string queue) where TDomainEvent : DomainEventConsumeBase
    {
        using var connection = _connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();

        var eventName = typeof(TDomainEvent).Name;

        ExchangeDeclareDynamicType(channel, eventName);

        QueueDeclareDynamicType(channel, queue);

        QueueBindDynamicType(channel, eventName, queue);

        var consumer = new EventingBasicConsumer(channel);
         consumer.Received += async (model, ea) =>
         {

             var objDeserialized = GetDataOfBodyQueue<TDomainEvent>(ea);

             await eventHandler.Handle(objDeserialized);
         };

        channel.BasicConsume(queue: queue, autoAck: true, consumer: consumer);
    }
}

