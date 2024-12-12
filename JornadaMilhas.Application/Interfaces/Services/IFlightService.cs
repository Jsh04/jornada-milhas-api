using JornadaMilhas.Application.Commands.FlightCommands.RegisterFlight;
using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhas.Application.Interfaces.Services;

public interface IFlightService
{
    Task<Result> DeleteDestinyById(long id);

    Task<Result<FlightsDto>> GetFlightById(long id);

    Task<PaginationResult<FlightsDto>> GetAllFlights(int size, int page);

    Task<Result<Flight>> RegisterDestiny(RegisterFlightCommand command);
}