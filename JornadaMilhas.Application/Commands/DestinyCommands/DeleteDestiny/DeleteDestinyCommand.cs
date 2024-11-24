using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Commands.DestinyCommands.DeleteDestiny;

public record DeleteDestinyCommand(long Id) : IRequest<Result>
{
}