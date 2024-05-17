using JornadaMilhas.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Commands.DepoimentsCommands.DeleteDepoiment;

public sealed record DeleteDepoimentCommand(long Id) : IRequest<Result>
{
}
