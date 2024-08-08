using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.DomainEventConsumer;

namespace JornadaMilhas.Common.EventHandler
{
    public interface IDomainEventHandler<in TDomainEvent> where TDomainEvent : DomainEventConsumeBase
    {
        Task Handle(TDomainEvent @event);

    }
}
