using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Entities.Destinies;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny
{
    public class RegisterDestinyCommandHandler : IRequestHandler<RegisterDestinyCommand, Result<Destiny>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDestinyRepository _repositoryDestiny;
        public RegisterDestinyCommandHandler(IUnitOfWork unitOfWork, IDestinyRepository repositoryDestino)
        {
            _unitOfWork = unitOfWork;
            _repositoryDestiny = repositoryDestino;
        }

        public async Task<Result<Destiny>> Handle(RegisterDestinyCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            var destinyResult = 
                Destiny.CreateBuilder()
                .AddName(request.Name)
                .AddPrice(request.Price)
                .AddSubtitle(request.Subtitle)
                .AddDescriptionEnglish(request.DescriptionEnglish)
                .AddDescriptionPortuguese(request.DescriptionPortuguese)
                .Build();

            if (!destinyResult.Success)
                return Result.Fail<Destiny>(destinyResult.Errors);

            var destiny = destinyResult.Value;

            var pictures = ReturnListByteArray(request.Images);

            if (!pictures.Success)
                return Result.Fail<Destiny>(DestinyErrors.MustHavePictures);
            
            destiny.AddImagesDestiny(pictures.Value);

            await _repositoryDestiny.CreateAsync(destiny);

            var created = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

            await _unitOfWork.CommitAsync(cancellationToken);

            return !created ? Result.Fail<Destiny>(DestinyErrors.CannotBeCreated) : Result.Ok(destiny);
        }
        private static Result<List<Picture>> ReturnListByteArray(List<string> pictures)
        {
            try
            {
                var listPictures = pictures
                    .Select(stringBase64Image => Picture.Create(Convert.FromBase64String(stringBase64Image))).ToList();
        
                return Result.Ok(listPictures);
            }
            catch (Exception e)
            {
                return Result.Fail<List<Picture>>(new Error("RegisterDestinyCommandHandler.ReturnListByteArray", e.Message, ErrorType.Failure));
            }
        }
    }
}
