using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Commands.DepoimentsCommands.UpdateDepoiment;

public sealed record UpdateDepoimentCommand(
    long Id,
    string Name,
    string DepoimentDescription,
    int UserId,
    string Picture) : IRequest<Result>
{
}