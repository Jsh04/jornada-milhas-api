using JornadaMilhas.Common.DomainEvent;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Persistence.Queue;
using JornadaMilhas.Core.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace JornadaMilhas.Infrastruture.Interceptors;

public class DatabaseInterceptor : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;

        if (context is null)
            return await base.SavingChangesAsync(eventData, result, cancellationToken);

        var entriesEntities = context.ChangeTracker.Entries().Where(entityEntry => 
        entityEntry.Entity is Customer && entityEntry.State == EntityState.Added);

        if (!entriesEntities.Any())
            return await base.SavingChangesAsync(eventData, result, cancellationToken);

        var listEntitiesEntry = entriesEntities.Cast<EntityEntry<Customer>>();

        var outBoxMessages = GetOutBoxMessages(listEntitiesEntry);

        await context.Set<OutboxMessage>().AddRangeAsync(outBoxMessages, cancellationToken);

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static List<OutboxMessage> GetOutBoxMessages(IEnumerable<EntityEntry<Customer>> entryCustomerAdded)
    {
        var queueEmailsObjs = entryCustomerAdded
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var listDomainsEventReturned = new List<IDomainEvent>(entity.GetAllDomainsEvent());

                entity.ClearAllDomainEvents();

                return listDomainsEventReturned;
            })
            .Select(domainEvent => new OutboxMessage
            {
                Id = Guid.NewGuid(),
                TimeCreated = DateTime.Now,
                Type = domainEvent.GetType().Name,
                Content = JsonConvert.SerializeObject(domainEvent, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                })
            }).ToList();

        return queueEmailsObjs;
    }
}