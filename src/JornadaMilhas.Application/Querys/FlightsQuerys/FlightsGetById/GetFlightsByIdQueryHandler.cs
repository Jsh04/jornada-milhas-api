using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Core.ValueObjects.Locales;
using MediatR;

namespace JornadaMilhas.Application.Querys.FlightsQuerys.FlightsGetById;

public class GetFlightsByIdQueryHandler : IRequestHandler<GetFlightsByIdQuery, Result<FlightsDto>>
{
    private readonly IFlightRepository _flightRepository;

    public GetFlightsByIdQueryHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<Result<FlightsDto>> Handle(GetFlightsByIdQuery request, CancellationToken cancellationToken)
    {
        var destiny = await _flightRepository.GetByIdAsync(request.Id, cancellationToken);

        if (destiny is null)
            return Result.Fail<FlightsDto>(FlightErrors.NotFound);

        var destinyDto = DtoExtensions<Flight, FlightsDto>.ToDto(destiny);

        return Result.Ok(destinyDto);
    }
}