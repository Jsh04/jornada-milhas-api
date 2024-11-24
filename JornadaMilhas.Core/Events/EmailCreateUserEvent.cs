using JornadaMilhas.Common.DomainEvent;
using JornadaMilhas.Core.Events.Shareds;

namespace JornadaMilhas.Core.Events;

public sealed record EmailCreateUserEvent(UserEvent User) : IDomainEvent
{
}