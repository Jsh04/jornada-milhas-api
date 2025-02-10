using JornadaMilhas.Application.Interfaces.MessageBus;
using JornadaMilhas.Common.EventHandler;
using JornadaMilhas.Core.Events;

namespace JornadaMilhas.Application.EventHandlers;

public class SendEmailEventHandler : IDomainEventHandler<EmailCreateUserEvent>
{
    private readonly IMessageBusProducerService _messageBusProducerService;

    public SendEmailEventHandler(IMessageBusProducerService messageBusProducerService)
    {
        _messageBusProducerService = messageBusProducerService;
    }

    public Task Handle(EmailCreateUserEvent notification, CancellationToken cancellationToken)
    {
        _messageBusProducerService.Publish(nameof(EmailCreateUserEvent), notification);

        return Task.CompletedTask;
    }
}