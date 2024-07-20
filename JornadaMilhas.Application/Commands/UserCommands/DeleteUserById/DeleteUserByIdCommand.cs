using JornadaMilhas.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Commands.UserCommands.DeleteUserById;

public record DeleteUserByIdCommand(long Id) : IRequest<Result>
{
}
