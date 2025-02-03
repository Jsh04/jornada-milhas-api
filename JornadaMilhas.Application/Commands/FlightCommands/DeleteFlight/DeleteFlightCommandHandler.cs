using JornadaMilhas.Application.Interfaces.UOW;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Repositories.Interfaces;
using MediatR;

namespace JornadaMilhas.Application.Commands.FlightCommands.DeleteFlight;

public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand, Result>
{
    private readonly IFlightRepository _flightRepository;

    private readonly IUnitOfWork _unitWork;

    public DeleteFlightCommandHandler(IUnitOfWork unitWork, IFlightRepository flightRepository)
    {
        _unitWork = unitWork;
        _flightRepository = flightRepository;
    }

    public async Task<Result> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        var destiny = await _flightRepository.GetByIdAsync(request.Id, cancellationToken);

        if (destiny is null)
            return Result.Fail(FlightErrors.NotFound);

        destiny.Delete();

        _flightRepository.Update(destiny);

        var deleted = await _unitWork.CompleteAsync(cancellationToken) > 0;

        return !deleted ? Result.Fail(FlightErrors.CannotBeDeleted) : Result.Ok();
    }
}