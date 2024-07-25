using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Commands.DestinyCommands.DeleteDestiny;

public class DeleteDestinyCommandHandler : IRequestHandler<DeleteDestinyCommand, Result>
{

    private readonly IUnitOfWork _unitWork;

    public DeleteDestinyCommandHandler(IUnitOfWork unitWork)
    {
        _unitWork = unitWork;
    }

    public async Task<Result> Handle(DeleteDestinyCommand request, CancellationToken cancellationToken)
    {
        var destiny = await _unitWork.DestinoRepository.GetByIdAsync(request.Id, cancellationToken);

        if (destiny is null)
            return Result.Fail(DestinyErrors.NotFound);

        destiny.Delete();

        _unitWork.DestinoRepository.Update(destiny);

        var deleted = await _unitWork.CompleteAsync(cancellationToken) > 0;

        if (!deleted)
            return Result.Fail(DestinyErrors.CannotBeDeleted);

        return Result.Ok();

    }
}

