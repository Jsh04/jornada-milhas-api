using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Commands.DestinyCommands.DeleteDestiny;

public record DeleteDestinyCommand(int Id) : IRequest<Result>
{
}

