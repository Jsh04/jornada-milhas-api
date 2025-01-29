using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Depoiments;
using MediatR;

namespace JornadaMilhas.Application.Commands.DepoimentsCommands.RegisterDepoiment;

public sealed record RegisterDepoimentCommand(string Name, string DepoimentDescription, string Picture, long UserId)
    : IRequest<Result<Depoiment>>
{
}