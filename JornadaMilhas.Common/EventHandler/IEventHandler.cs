using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.DomainEvent;

namespace JornadaMilhas.Common.EventHandler
{
    public interface IEventHandler<in TDomainEvent> where TDomainEvent : DomainEventBase
    {
        Task Handle(TDomainEvent @event);
    }
}
