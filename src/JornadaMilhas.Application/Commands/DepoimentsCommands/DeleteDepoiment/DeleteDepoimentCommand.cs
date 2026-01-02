using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Commands.DepoimentsCommands.DeleteDepoiment;

public sealed record DeleteDepoimentCommand(long Id) : IRequest<Result>
{
}