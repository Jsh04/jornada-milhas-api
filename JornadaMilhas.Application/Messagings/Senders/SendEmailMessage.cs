using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JornadaMilhas.Core.DTO.Usuario;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace JornadaMilhas.Application.Messagings.Senders;

public class SendEmailMessage
{
    private readonly IConfiguration _configuration;
    private readonly IModel _channel;
    private readonly IConnection _connection;

    public SendEmailMessage(IConfiguration configuration)
    {
         _configuration = configuration;
         _connection = new ConnectionFactory
             { HostName = _configuration["RabbitMq:Host"], Port = int.Parse(_configuration["RabbitMq:Port"]) }.CreateConnection();

         _channel = _connection.CreateModel();

         ConfigurationOfQueueEmail();


    }

    public void SendConfirmMmail(string email)
    {
        string message = JsonSerializer.Serialize(email);
        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: "dataUser", routingKey: "email", basicProperties: null, body: body);
    }

    private void ConfigurationOfQueueEmail()
    {
        _channel.ExchangeDeclare(exchange: "dataUser", type: ExchangeType.Direct);
        _channel.QueueDeclare(queue: "email", durable: false, exclusive: false, autoDelete: false, arguments: null);
        _channel.QueueBind(queue: "email", exchange: "dataUser", routingKey:"email");

        
    }

}

