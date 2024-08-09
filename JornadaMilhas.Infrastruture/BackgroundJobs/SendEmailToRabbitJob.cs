
using JornadaMilhas.Common.DomainEvent;
using JornadaMilhas.Common.Persistence.Queue;
using JornadaMilhas.Infrastruture.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static System.Formats.Asn1.AsnWriter;

namespace JornadaMilhas.Infrastruture.BackgroundJobs
{
    public class SendEmailToRabbitJob : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<SendEmailToRabbitJob> _loggerSendMailRabbitJob;

        public SendEmailToRabbitJob(IServiceProvider service, ILogger<SendEmailToRabbitJob> loggerSendMailRabbitJob)
        {
            _serviceProvider = service;
            _loggerSendMailRabbitJob = loggerSendMailRabbitJob;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var (context, publish) = ReturnTupleOfServicesRequired();

            var queueObjs = await context.Set<QueueGeneric>().Where(queue => queue.ProcessedAt == null).Take(20)
                .ToListAsync(stoppingToken);

            await PublishToHandlerSendEmail(queueObjs, publish, stoppingToken);
        }

        private async Task PublishToHandlerSendEmail(List<QueueGeneric> queues, IPublisher publisher, CancellationToken stoppingToken)
        {
            foreach (var queue in queues)
            {
                try
                {
                    var domainEvent =
                        JsonConvert.DeserializeObject<IDomainEvent>(
                            queue.Content,
                            new JsonSerializerSettings
                            {
                                TypeNameHandling = TypeNameHandling.All,
                            });

                    if (domainEvent is null)
                    {
                        _loggerSendMailRabbitJob.LogError($"Domain event {queue.Type} cannot deserialize");
                        continue;
                    }

                    await publisher.Publish(domainEvent, stoppingToken);

                    queue.ProcessedAt = DateTime.Now;
                }
                catch (Exception ex)
                {
                    _loggerSendMailRabbitJob.LogError(ex, ex.Message);

                    queue.Error = ex.Message;
                }
            }
        }

        private  (JornadaMilhasDbContext context, IPublisher publish)
            ReturnTupleOfServicesRequired()
        {
            using var scope = _serviceProvider.CreateAsyncScope();
            return (scope.ServiceProvider.GetRequiredService<JornadaMilhasDbContext>(),
                scope.ServiceProvider.GetRequiredService<IPublisher>());
        } 
    }
}
