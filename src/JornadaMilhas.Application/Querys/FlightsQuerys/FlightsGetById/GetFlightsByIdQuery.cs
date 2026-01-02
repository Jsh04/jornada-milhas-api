using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Querys.FlightsQuerys.FlightsGetById;

public record GetFlightsByIdQuery(long Id) : IRequest<Result<FlightsDto>>
{
};