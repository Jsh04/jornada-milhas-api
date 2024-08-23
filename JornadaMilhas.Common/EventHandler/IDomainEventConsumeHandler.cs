using JornadaMilhas.Common.DomainEventConsumer;

namespace JornadaMilhas.Common.EventHandler
{
    public interface IDomainEventConsumeHandler<in TDomainEvent> where TDomainEvent : DomainEventConsumeBase
    {
        Task Handle(TDomainEvent @event);

    }
}
