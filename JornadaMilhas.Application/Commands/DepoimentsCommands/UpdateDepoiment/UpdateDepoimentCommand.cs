using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Depoiments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Commands.DepoimentsCommands.UpdateDepoiment
{
    public sealed record UpdateDepoimentCommand(
               long Id,
               string Name,
               string DepoimentDescription,
               int UserId,
               string Picture) : IRequest<Result>
    {}
}
