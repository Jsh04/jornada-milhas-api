﻿using JornadaMilhas.Common.DomainEvent;
using System.Text.Json.Serialization;


namespace JornadaMilhas.Common.Entity;

public abstract class BaseEntity
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("dtCreated")]
    public DateTime DtCreated { get; protected set; }

    public DateTime DtUpdated { get; protected set; }

    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; protected set; }

    public virtual void Delete() => IsDeleted = true;

    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyList<IDomainEvent> GetAllDomainsEvent() => _domainEvents.AsReadOnly();
    public void ClearAllDomainEvents()
    => _domainEvents.Clear();

    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
  
}