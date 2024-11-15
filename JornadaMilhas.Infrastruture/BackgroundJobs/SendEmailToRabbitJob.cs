
using JornadaMilhas.Common.DomainEvent;
using JornadaMilhas.Common.Persistence.Queue;
using JornadaMilhas.Infrastruture.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
            while (!stoppingToken.IsCancellationRequested)
            {
                await using var scope = _serviceProvider.CreateAsyncScope();
                var context = scope.ServiceProvider.GetRequiredService<JornadaMilhasDbContext>();
                var publish = scope.ServiceProvider.GetRequiredService<IPublisher>();

                var queueObjs = await context.Set<OutboxMessage>().Where(queue => queue.ProcessedAt == null).Take(20)
                    .ToListAsync(stoppingToken);

                await PublishToHandlerSendEmail(queueObjs, publish, stoppingToken);

                if (queueObjs.Count > 0)
                    await context.SaveChangesAsync(stoppingToken);

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }

        private async Task PublishToHandlerSendEmail(List<OutboxMessage> queues, IPublisher publisher, CancellationToken stoppingToken)
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
    }
}
