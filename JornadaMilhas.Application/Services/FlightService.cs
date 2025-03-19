using JornadaMilhas.Application.Commands.FlightCommands.DeleteFlight;
using JornadaMilhas.Application.Commands.FlightCommands.RegisterFlight;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Application.Querys.FlightsQuerys.FlightGetAll;
using JornadaMilhas.Application.Querys.FlightsQuerys.FlightsGetById;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.ValueObjects.Locales;
using MediatR;

namespace JornadaMilhas.Application.Services;

public class FlightService : IFlightService
{
    private readonly ISender _sender;

    public FlightService(ISender sender)
    {
        _sender = sender;
    }

    public async Task<Result> DeleteDestinyById(long id)
    {
        var deleteDestinyCommand = new DeleteFlightCommand(id);
        return await _sender.Send(deleteDestinyCommand);
    }

    public async Task<PaginationResult<FlightsDto>> GetAllFlights(int size, int page)
    {
        var getAllDestiniesQuery = new GetAllFlightsQuery(page, size);
        return await _sender.Send(getAllDestiniesQuery);
    }

    public async Task<Result<FlightsDto>> GetFlightById(long id)
    {
        var getDestinyById = new GetFlightsByIdQuery(id);
        return await _sender.Send(getDestinyById);
    }

    public async Task<Result<Flight>> RegisterDestiny(RegisterFlightCommand command)
    {
        return await _sender.Send(command);
    }
}