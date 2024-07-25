using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.DomainEvent;
using JornadaMilhas.Common.EventHandler;

namespace JornadaMilhas.Infrastruture.MessageBus;

    public interface IMessageBusProducerService
    {
        void Publish<T>(string queue, T dataToSend);
        void Subscribe<TDomainEvent>(IEventHandler<TDomainEvent> eventHandler) where TDomainEvent : DomainEventBase;
    }

