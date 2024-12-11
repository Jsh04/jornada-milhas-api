using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.Dtos.FilesDto;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;
using JornadaMilhas.Common.Util;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Core.ValueObjects.Locales;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny;

public class RegisterDestinyCommandHandler : IRequestHandler<RegisterDestinyCommand, Result<Locale>>
{
    private readonly IDestinyRepository _repositoryDestiny;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUploadService _uploadService;

    public RegisterDestinyCommandHandler(IUnitOfWork unitOfWork, IDestinyRepository repositoryDestino,
        IUploadService uploadService)
    {
        _unitOfWork = unitOfWork;
        _repositoryDestiny = repositoryDestino;
        _uploadService = uploadService;
    }

    public async Task<Result<Locale>> Handle(RegisterDestinyCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        var destinyResult =
            Locale.CreateBuilder()
                .AddName(request.Name)
                .AddPrice(request.Price)
                .AddSubtitle(request.Subtitle)
                .AddDescriptionEnglish(request.DescriptionEnglish)
                .AddDescriptionPortuguese(request.DescriptionPortuguese)
                .Build();

        if (!destinyResult.Success)
            return Result.Fail<Locale>(destinyResult.Errors);

        var destiny = destinyResult.Value;

        var resultListFilesDto = GetFilesConverted(request.Images, destiny.Name);

        if (!resultListFilesDto.Success)
            return Result.Fail<Locale>(resultListFilesDto.Errors);

        var pictures = resultListFilesDto.Value.Select(fileDto => Picture.Create(fileDto.path));

        await UploadFilesToCloud(resultListFilesDto.Value);

        destiny.AddImagesDestiny(pictures);

        await _repositoryDestiny.CreateAsync(destiny);

        var created = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

        await _unitOfWork.CommitAsync(cancellationToken);

        return !created ? Result.Fail<Locale>(LocaleErrors.CannotBeCreated) : Result.Ok(destiny);
    }

    private async Task UploadFilesToCloud(List<FileDto> listFilesDto)
    {
        var listTasks = listFilesDto
            .Select(fileDto => _uploadService.UploadAsync(fileDto.byteArray, fileDto.path))
            .Cast<Task>()
            .ToList();

        await Task.WhenAll(listTasks);
    }

    private static Result<List<FileDto>> GetFilesConverted(List<string> picturesBase64, string destinyName)
    {
        var listFileDtos = new List<FileDto>();

        foreach (var picture in picturesBase64)
        {
            var resultByteArray = GetByteArrayFromBase64(picture);

            if (!resultByteArray.Success)
                return Result.Fail<List<FileDto>>(resultByteArray.Errors);

            var extension = picture.Split("/")[1].Split(";")[0];

            var path = FileHelper.GetPathFileSaveInCloud(destinyName, extension);

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