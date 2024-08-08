using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.DomainEventConsumer;
using JornadaMilhas.Common.EventHandler;

namespace JornadaMilhas.Infrastruture.MessageBus;

public interface IMessageBusProducerService
    {
        void Publish<T>(string queue, T dataToSend);
        void Subscribe<TDomainEvent>(IDomainEventHandler<TDomainEvent> eventHandler, string queue) where TDomainEvent : DomainEventConsumeBase;
    }

