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
    private readonly IUploadService _uploadService;
    private readonly IPlaneRepository _planeRepository;

    public RegisterFlightCommandHandler(
        IUnitOfWork unitOfWork, 
        IFlightRepository repositoryDestino,
        IUploadService uploadService,
        IPlaneRepository planeRepository )
    {
        _unitOfWork = unitOfWork;
        _repositoryFlight = repositoryDestino;
        _uploadService = uploadService;
        _planeRepository = planeRepository;
    }

    public async Task<Result<Flight>> Handle(RegisterFlightCommand request, CancellationToken cancellationToken)
    {
        var plane = await _planeRepository.GetByIdAsync(request.PlaneId, cancellationToken);

        if (plane is null)
            return Result.Fail<Flight>(PlaneErrors.PlaneNotFound);
        
        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        var flightResult =
            FlightBuilder.Create()
                .AddPlane(plane)
                .AddLandingDate(request.LandingDate)
                .AddDepartureDate(request.DepartureDate)
                .AddDestiny(request.Destiny.Country, request.Destiny.City, request.Destiny.Latitude, request.Destiny.Longitude)
                .AddFlightCode(Guid.NewGuid().ToString())
                .Build();

        if (!flightResult.Success)
            return Result.Fail<Flight>(flightResult.Errors);

        var flight = flightResult.Value;

        var resultListFilesDto = GetFilesConverted(request.Images, flight.FlightCode);

        if (!resultListFilesDto.Success)
            return Result.Fail<Flight>(resultListFilesDto.Errors);

        var pictures = resultListFilesDto.Value.Select(fileDto => Picture.Create(fileDto.Path));

        await UploadFilesToCloud(resultListFilesDto.Value);

        flight.AddImagesLocaleDestiny(pictures.ToList());

        await _repositoryFlight.CreateAsync(flight);

        var created = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

        await _unitOfWork.CommitAsync(cancellationToken);

        return !created ? Result.Fail<Flight>(FlightErrors.CannotBeCreated) : Result.Ok(flight);
    }

    private async Task UploadFilesToCloud(List<FileDto> listFilesDto)
    {
        var listTasks = listFilesDto
            .Select(fileDto => _uploadService.UploadAsync(fileDto.ByteArray, fileDto.Path))
            .Cast<Task>()
            .ToList();

        await Task.WhenAll(listTasks);
    }

    private static Result<List<FileDto>> GetFilesConverted(List<string> picturesBase64, string flightCode)
    {
        var listFileDtos = new List<FileDto>();

        foreach (var picture in picturesBase64)
        {
            var resultByteArray = GetByteArrayFromBase64(picture);

            if (!resultByteArray.Success)
                return Result.Fail<List<FileDto>>(resultByteArray.Errors);

            var extension = picture.Split("/")[1].Split(";")[0];

            var path = FileHelper.GetPathFileSaveInCloud(flightCode, extension);

            listFileDtos.Add(new FileDto(resultByteArray.Value, path));
        }

        return Result.Ok(listFileDtos);
    }

    private static Result<byte[]> GetByteArrayFromBase64(string base64)
    {
        try
        {
            return Result.Ok(Convert.FromBase64String(base64));
        }
        catch (Exception e)
        {
            return Result.Fail<byte[]>(new Error("RegisterDestinyCommandHandler.GetByteArrayFromBase64", e.Message,
                ErrorType.Failure));
        }
    }
}