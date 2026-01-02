using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.PaginationResult;
using MediatR;

namespace JornadaMilhas.Application.Querys.FlightsQuerys.FlightGetAll;

public record GetAllFlightsQuery(int Page = 1, int Size = 10) : IRequest<PaginationResult<FlightsDto>>
{
}