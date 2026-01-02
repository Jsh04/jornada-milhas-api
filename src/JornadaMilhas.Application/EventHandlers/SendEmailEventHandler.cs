using JornadaMilhas.Application.Interfaces.MessageBus;
using JornadaMilhas.Common.EventHandler;
using JornadaMilhas.Core.Events;

namespace JornadaMilhas.Application.EventHandlers;

public class SendEmailEventHandler : IDomainEventHandler<CustomerRegisteredEvent>
{
    private readonly IMessageBusProducerService _messageBusProducerService;

    public SendEmailEventHandler(IMessageBusProducerService messageBusProducerService)
    {
        _messageBusProducerService = messageBusProducerService;
    }

    public Task Handle(CustomerRegisteredEvent notification, CancellationToken cancellationToken)
    {
        _messageBusProducerService.Publish(nameof(CustomerRegisteredEvent), notification);

        return Task.CompletedTask;
    }
}