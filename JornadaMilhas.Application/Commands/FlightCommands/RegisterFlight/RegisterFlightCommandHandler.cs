using JornadaMilhas.Application.Interfaces.Gateways;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Interfaces.UOW;
using JornadaMilhas.Application.Querys.Dtos.FilesDto;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;
using JornadaMilhas.Common.Util;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Planes;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Core.ValueObjects.Locales;
using MediatR;

namespace JornadaMilhas.Application.Commands.FlightCommands.RegisterFlight;

public class RegisterFlightCommandHandler : IRequestHandler<RegisterFlightCommand, Result<Flight>>
{
    private readonly IFlightRepository _repositoryFlight;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPlaneRepository _planeRepository;
    private readonly IDestinationRepository _destinationRepository;

    public RegisterFlightCommandHandler(
        IUnitOfWork unitOfWork, 
        IFlightRepository repositoryFlight,
        IPlaneRepository planeRepository, IDestinationRepository destinationRepository)
    {
        _unitOfWork = unitOfWork;
        _repositoryFlight = repositoryFlight;
        _planeRepository = planeRepository;
        _destinationRepository = destinationRepository;
    }

    public async Task<Result<Flight>> Handle(RegisterFlightCommand request, CancellationToken cancellationToken)
    {
        var plane = await _planeRepository.GetByIdAsync(request.PlaneId, cancellationToken);

        if (plane is null)
            return Result.Fail<Flight>(PlaneErrors.PlaneNotFound);
        
        var destination = await _destinationRepository.GetByIdAsync(request.DestinationId, cancellationToken);

        if (destination is null)
            return Result.Fail<Flight>(PlaneErrors.PlaneNotFound);
        
        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        var flightResult =
            FlightBuilder.Create()
                .AddPlane(plane)
                .AddLandingDate(request.LandingDate)
                .AddDepartureDate(request.DepartureDate)
                .AddDestiny(destination)
                .AddFlightCode(Guid.NewGuid().ToString())
                .Build();

        if (!flightResult.Success)
            return Result.Fail<Flight>(flightResult.Errors);

        var flight = flightResult.Value;
        
        await _repositoryFlight.CreateAsync(flight);

        var created = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

        await _unitOfWork.CommitAsync(cancellationToken);

        return !created ? Result.Fail<Flight>(FlightErrors.CannotBeCreated) : Result.Ok(flight);
    }
    
}