using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Commands.DepoimentsCommands.DeleteDepoiment;

public class DeleteDepoimentCommandHandler : IRequestHandler<DeleteDepoimentCommand, Result>
{

    private readonly IUnitOfWork _unitOfWork;

    public DeleteDepoimentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteDepoimentCommand request, CancellationToken cancellationToken)
    {
        var depoimet = await _unitOfWork.DepoimentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (depoimet is null)
            return Result.Fail(DepoimentErrors.NotFound);

        depoimet.Delete();

        _unitOfWork.DepoimentRepository.Update(depoimet);

        var deleted = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

        if (!deleted)
            return Result.Fail(DestinyErrors.CannotBeDeleted);

        return Result.Ok();
    }
}
