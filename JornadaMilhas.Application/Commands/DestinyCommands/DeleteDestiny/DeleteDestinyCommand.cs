using JornadaMilhas.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Commands.DestinyCommands.DeleteDestiny;

public record DeleteDestinyCommand(int Id) : IRequest<Result>
{
}

