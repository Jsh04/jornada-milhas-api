using System.Text.Json.Serialization;
using JornadaMilhas.Common.DomainEvent;

namespace JornadaMilhas.Common.Entity;

public abstract class BaseEntity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    [JsonPropertyName("id")] 
    public long Id { get; protected set; }

    [JsonPropertyName("dtCreated")] public DateTime DtCreated { get; protected set; }

    public DateTime DtUpdated { get; protected set; }

    [JsonPropertyName("isDeleted")] public bool IsDeleted { get; protected set; }

    public virtual void Delete()
    {
        IsDeleted = true;
    }

    public IReadOnlyList<IDomainEvent> GetAllDomainsEvent()
    {
        return _domainEvents.AsReadOnly();
    }

    public void ClearAllDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}