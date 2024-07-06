
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.Options;
using JornadaMilhas.Core.Entities.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace JornadaMilhas.Infrastruture.Messagings.Senders;

public class SendEmailMessage
{
    private readonly IConnection _connection;
    private readonly RabbitMqOptions _rabbitMqOptions;

    public SendEmailMessage(IOptions<RabbitMqOptions> optionsRabbitMq)
    {
        _rabbitMqOptions = optionsRabbitMq.Value;

         _connection = new ConnectionFactory
             { HostName = _rabbitMqOptions.HostName, Port = _rabbitMqOptions.Port }.CreateConnection();

    }

    public void SendConfirmMmail(User usuario)
    {
        using var channel = _connection.CreateModel();
        ConfigurationOfQueueEmail(channel);

        var message = JsonSerializer.Serialize(usuario);

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: "dataUser", routingKey: "email", basicProperties: null, body: body);

    }

    private static void ConfigurationOfQueueEmail(IModel channel)
    {
        channel.ExchangeDeclare(exchange: "dataUser", type: ExchangeType.Direct);

        channel.QueueDeclare(queue: "email", durable: false, exclusive: false, autoDelete: false, arguments: null);

        channel.QueueBind(queue: "email", exchange: "dataUser", routingKey:"email");

    }

}

