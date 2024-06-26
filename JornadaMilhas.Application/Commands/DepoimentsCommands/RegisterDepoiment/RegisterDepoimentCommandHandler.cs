﻿using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Util;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Entities.Users;
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
    public sealed class RegisterDepoimentCommandHandler : IRequestHandler<RegisterDepoimentCommand, Result<Depoiment>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public RegisterDepoimentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Result<Depoiment>> Handle(RegisterDepoimentCommand request, CancellationToken cancellationToken)
        {
            var userLimited = await _unitOfWork.UserLimitedRepository.GetByIdAsync(request.UserId, cancellationToken);

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

            _unitOfWork.DepoimentRepository.Create(depoiment);

            var created = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

            await _unitOfWork.CommitAsync(cancellationToken);

           return !created ? Result.Fail<Depoiment>(DepoimentErrors.CannotBeCreated) : Result.Ok(depoiment);

        }
    }
}
