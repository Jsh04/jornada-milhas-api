using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Util;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Commands.DepoimentsCommands.RegisterDepoiment
{
    public sealed class RegisterDepoimentHandler : IRequestHandler<RegisterDepoiment, Result<Depoiment>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public RegisterDepoimentHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Result<Depoiment>> Handle(RegisterDepoiment request, CancellationToken cancellationToken)
        {
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

            _unitOfWork.DepoimentRepository.Create(depoiment);

            var created = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

            await _unitOfWork.CommitAsync(cancellationToken);

           return !created ? Result.Fail<Depoiment>(DepoimentErrors.CannotBeCreated) : Result.Ok(depoiment);

        }
    }
}
