using JornadaMilhas.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.DomainEvent
{
    public sealed record EmailCreateUserEvent(User User) : IDomainEvent
    {}
}
