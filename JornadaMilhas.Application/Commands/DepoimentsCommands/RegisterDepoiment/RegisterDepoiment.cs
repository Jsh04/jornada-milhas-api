using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Depoiments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Commands.DepoimentsCommands.RegisterDepoiment
{
    public sealed record RegisterDepoiment(string Name, string DepoimentDescription, string Picture, long UserId) : IRequest<Result<Depoiment>>
    {}
}
