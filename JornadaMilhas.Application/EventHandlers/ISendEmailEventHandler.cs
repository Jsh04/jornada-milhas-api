using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.DomainEvent;
using JornadaMilhas.Common.EventHandler;

namespace JornadaMilhas.Application.EventHandlers
{
    public class SendEmailEventHandler : IDomainEventHandler<EmailCreateUserEvent>
    {
        public Task Handle(EmailCreateUserEvent notification, CancellationToken cancellationToken)
        {
                
        }
    }
}
