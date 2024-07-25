
using System.Text;
using System.Text.Json;
using JornadaMilhas.Common.DomainEvent;
using JornadaMilhas.Common.EventHandler;
using JornadaMilhas.Common.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

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
        
        private static void ExchangeDeclareDynamicType(IModel channel, string exchangeName) 
            => channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Direct);

        private static void QueueDeclareDynamicType(IModel channel, string queue) => 
            channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: true, arguments: null);

        private static byte[] GetBodyMessage<T>(T dataToSend)
            {
                var eventMessageJsonString = JsonSerializer.Serialize(dataToSend);
                var body = Encoding.UTF8.GetBytes(eventMessageJsonString);

                return body;
            }

        public void Subscribe<TDomainEvent>(IEventHandler<TDomainEvent> eventHandler) where TDomainEvent : DomainEventBase
        {
            
        }
}

