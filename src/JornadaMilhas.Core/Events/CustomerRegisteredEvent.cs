using JornadaMilhas.Common.DomainEvent;


namespace JornadaMilhas.Core.Events;

public sealed record CustomerRegisteredEvent(string Name, string Email, DateTime DtCreated) : IDomainEvent
{
}