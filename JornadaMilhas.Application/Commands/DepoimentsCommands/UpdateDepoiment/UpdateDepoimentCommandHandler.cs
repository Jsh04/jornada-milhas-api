using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Commands.DepoimentsCommands.UpdateDepoiment;

public sealed class UpdateDepoimentCommandHandler : IRequestHandler<UpdateDepoimentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateDepoimentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    

    public async Task<Result> Handle(UpdateDepoimentCommand request, CancellationToken cancellationToken)
    {
        var depoiment = await _unitOfWork.DepoimentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (depoiment is null)
            return Result.Fail(DepoimentErrors.NotFound);

        var depoimentResult = Depoiment.CreateBuilder()
            .WithName(request.Name)
            .WithDepoimentDescription(request.DepoimentDescription)
            .WithPicture(request.Picture)
            .WithUserId(request.UserId)
            .Build();

        if (!depoimentResult.Success)
            return Result.Fail(depoimentResult.Errors);

        var depoimentUpdate = depoimentResult.Value;

        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        depoiment.Update(depoimentUpdate);

        _unitOfWork.DepoimentRepository.Update(depoiment);

        var updated = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

        await _unitOfWork.CommitAsync(cancellationToken);

        return !updated ? Result.Fail(DepoimentErrors.CannotBeUpdate) : Result.Ok();

    }
}
