using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Persistence.Queue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JornadaMilhas.Infrastruture.Interceptors
{
    public class PublishEventSendEmailToQueueObj : SaveChangesInterceptor
    {
        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            if (eventData.Context is null)
                return await base.SavingChangesAsync(eventData, result, cancellationToken);


            if (eventData.Context is not null)
                await InsertSendEmailQueueAsync(eventData.Context);


            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private static async Task InsertSendEmailQueueAsync(DbContext context)
        {
            var queueEmailsObjs = context.ChangeTracker.
                Entries<BaseEntity>()
                .Select(entry => entry.Entity)
                .SelectMany(entity =>
                {
                    var domainsEvent = entity.GetAllDomainsEvent();

                    entity.ClearAllDomainEvents();

                    return domainsEvent;
                })
                .Select(domainEvent => new QueueGeneric
                {
                    Id = Guid.NewGuid(),
                    TimeCreated = DateTime.Now,
                    Type = domainEvent.GetType().Name,
                    Content = JsonConvert.SerializeObject(domainEvent),
                }).ToList();

            await context.Set<QueueGeneric>().AddRangeAsync(queueEmailsObjs);
        }
    }
}
