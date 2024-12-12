using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.ValueObjects.Locales;
using MediatR;

namespace JornadaMilhas.Application.Commands.FlightCommands.RegisterFlight;

public sealed record RegisterFlightCommand(
    
    Locale Destiny,
    Locale Source,
    DateTime DepartureDate,
    DateTime LandingDate,
    long PlaneId,
    List<string> Images) : IRequest<Result<Flight>>
{
}