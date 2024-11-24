using JornadaMilhas.Common.DomainEventConsumer;
using JornadaMilhas.Common.EventHandler;

namespace JornadaMilhas.Infrastruture.MessageBus;

public interface IMessageBusProducerService
{
    void Publish<T>(string queue, T dataToSend);

    void Subscribe<TDomainEvent>(IDomainEventConsumeHandler<TDomainEvent> eventHandler, string queue)
        where TDomainEvent : DomainEventConsumeBase;
}