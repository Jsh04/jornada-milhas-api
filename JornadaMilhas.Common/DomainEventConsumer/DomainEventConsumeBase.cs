using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.DomainEventConsumer
{
    public abstract class DomainEventConsumeBase
    {
        public Guid Id { get; protected set; }

        public TimeSpan Time { get; protected set; }

        public DateTime DtEvent { get; protected set; }
    }
}
