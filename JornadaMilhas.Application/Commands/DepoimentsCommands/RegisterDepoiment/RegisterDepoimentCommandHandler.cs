using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Commands.DepoimentsCommands.RegisterDepoiment
{
    public sealed class RegisterDepoimentCommandHandler : IRequestHandler<RegisterDepoimentCommand, Result<Depoiment>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepoimentRepository _depoimentRepository;
        private readonly IUserLimitedRepository _userLimitedRepository;

        public RegisterDepoimentCommandHandler(IUnitOfWork unitOfWork, IDepoimentRepository depoimentRepository, IUserLimitedRepository userLimitedRepository)
        {
            _depoimentRepository = depoimentRepository;
            _unitOfWork = unitOfWork;
            _userLimitedRepository = userLimitedRepository;
        }

        public async Task<Result<Depoiment>> Handle(RegisterDepoimentCommand request, CancellationToken cancellationToken)
        {
            var userLimited = await _userLimitedRepository.GetByIdAsync(request.UserId, cancellationToken);

            if (userLimited is null)
                return Result.Fail<Depoiment>(UserErrors.NotFound);
                
            var depoimentResult = Depoiment
                .CreateBuilder()
                .WithName(request.Name)
                .WithDepoimentDescription(request.DepoimentDescription)
                .WithPicture(request.Picture)
                .WithUserId(request.UserId)
                .Build();

            if (!depoimentResult.Success)
                return Result.Fail<Depoiment>(depoimentResult.Errors);

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            var depoiment = depoimentResult.Value;

            await _depoimentRepository.CreateAsync(depoiment);

            var created = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

            await _unitOfWork.CommitAsync(cancellationToken);

           return !created ? Result.Fail<Depoiment>(DepoimentErrors.CannotBeCreated) : Result.Ok(depoiment);

        }
    }
}
