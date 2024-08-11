using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.DomainEvent;
using JornadaMilhas.Common.EventHandler;
using JornadaMilhas.Core.Events;
using JornadaMilhas.Infrastruture.MessageBus;

namespace JornadaMilhas.Application.EventHandlers
{
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
}
