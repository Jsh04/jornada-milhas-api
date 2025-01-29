using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Commands.FlightCommands.DeleteFlight;

public record DeleteFlightCommand(long Id) : IRequest<Result>
{
}