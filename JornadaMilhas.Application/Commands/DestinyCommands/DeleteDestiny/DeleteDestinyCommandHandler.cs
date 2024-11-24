using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinies;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Commands.DestinyCommands.DeleteDestiny;

public class DeleteDestinyCommandHandler : IRequestHandler<DeleteDestinyCommand, Result>
{
    private readonly IDestinyRepository _destinyRepository;

    private readonly IUnitOfWork _unitWork;

    public DeleteDestinyCommandHandler(IUnitOfWork unitWork, IDestinyRepository destinyRepository)
    {
        _unitWork = unitWork;
        _destinyRepository = destinyRepository;
    }

    public async Task<Result> Handle(DeleteDestinyCommand request, CancellationToken cancellationToken)
    {
        var destiny = await _destinyRepository.GetByIdAsync(request.Id, cancellationToken);

        if (destiny is null)
            return Result.Fail(DestinyErrors.NotFound);

        destiny.Delete();

        _destinyRepository.Update(destiny);

        var deleted = await _unitWork.CompleteAsync(cancellationToken) > 0;

        if (!deleted)
            return Result.Fail(DestinyErrors.CannotBeDeleted);

        return Result.Ok();
    }
}