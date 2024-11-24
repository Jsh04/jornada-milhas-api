using JornadaMilhas.Application.Querys.Dtos.DepoimentsDto;
using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Querys.DepoimentQuerys.GetByIdDepoiment;

public sealed record GetByIdDepoimentQuery(long Id) : IRequest<Result<DepoimentDto>>
{
}