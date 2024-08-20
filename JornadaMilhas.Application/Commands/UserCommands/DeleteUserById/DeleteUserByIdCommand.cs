using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Commands.UserCommands.DeleteUserById;

public record DeleteUserByIdCommand(long Id) : IRequest<Result>
{
}
