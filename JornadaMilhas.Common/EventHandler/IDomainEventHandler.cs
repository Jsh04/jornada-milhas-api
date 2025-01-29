using MediatR;

namespace JornadaMilhas.Common.EventHandler;

public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : INotification
{
}