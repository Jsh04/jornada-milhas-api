
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using JornadaMilhas.Core.Entities.Users;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace JornadaMilhas.Application.Messagings.Senders;

public class SendEmailMessage
{
    private readonly IConfiguration _configuration;
    private readonly IConnection _connection;

    public SendEmailMessage(IConfiguration configuration)
    {
         _configuration = configuration;
         _connection = new ConnectionFactory
             { HostName = _configuration["RabbitMq:Host"], Port = int.Parse(_configuration["RabbitMq:Port"]) }.CreateConnection();

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

