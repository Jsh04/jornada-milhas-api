using JornadaMilhas.Common.Result;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Commands.DestinyCommands.RegisterDestiny
{
    public class RegisterDestinyCommandHandler : IRequestHandler<RegisterDestinyCommand, Result<Destiny>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterDestinyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Destiny>> Handle(RegisterDestinyCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            var destinyResult = Destiny.CreateBuilder()
                .AddName(request.Name)
                .AddPrice(request.Price)
                .AddSubtitle(request.Subtitle)
                .AddDescriptionEnglish(request.DescriptionEnglish)
                .AddDescriptionPortuguese(request.DescriptionPortuguese)
                .AddImages(request.Images)
                .Build();

            if (!destinyResult.Success)
                return Result.Fail<Destiny>(destinyResult.Errors);

            var destiny = destinyResult.Value;

            await _unitOfWork.DestinoRepository.CreateAsync(destiny, cancellationToken);

            var created = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

            await _unitOfWork.CommitAsync(cancellationToken);

            return !created ? Result.Fail<Destiny>(DestinyErrors.CannotBeCreated) : Result.Ok(destiny);
        }
    }
}
