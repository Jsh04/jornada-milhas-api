using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Core.Events.Shareds
{
    public sealed record UserEvent(string Name, string Email, DateTime DtCreated)
    {
    }
}
