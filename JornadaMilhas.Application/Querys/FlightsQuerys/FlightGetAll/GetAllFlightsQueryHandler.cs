using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Core.ValueObjects.Locales;
using MediatR;

namespace JornadaMilhas.Application.Querys.DestinysQuerys.DestinyGetAll;

public class GetAllFlightsQueryHandler : IRequestHandler<GetAllFlightsQuery, PaginationResult<FlightsDto>>
{
    private readonly IFlightRepository _flightRepository;

    public GetAllFlightsQueryHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<PaginationResult<FlightsDto>> Handle(GetAllFlightsQuery request,
        CancellationToken cancellationToken)
    {
        var paginationResultDestinies =
            await _flightRepository.GetAllAsync(request.Page, request.Size, cancellationToken);

        var destiniesDto = DtoExtensions<Flight, FlightsDto>.ToDto(paginationResultDestinies.Data);

        var paginationResultDestiniesDto = new PaginationResult<FlightsDto>
        (
            paginationResultDestinies.Page,
            paginationResultDestinies.PageSize,
            paginationResultDestinies.TotalCount,
            paginationResultDestinies.TotalPages,
            destiniesDto.ToList()
        );

        return paginationResultDestiniesDto;
    }
}