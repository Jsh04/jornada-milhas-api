using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.ValueObjects.Locales;
using MediatR;

namespace JornadaMilhas.Application.Commands.FlightCommands.RegisterFlight;

public sealed record RegisterFlightCommand(
    Locale Source,
    DateTime DepartureDate,
    DateTime LandingDate,
    long PlaneId,
    long DestinationId
) : IRequest<Result<Flight>>{}