using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Commands.DepoimentsCommands.DeleteDepoiment;

public class DeleteDepoimentCommandHandler : IRequestHandler<DeleteDepoimentCommand, Result>
{

    private readonly IUnitOfWork _unitOfWork;

    private readonly IDepoimentRepository _depoimentRepository;

    public DeleteDepoimentCommandHandler(IUnitOfWork unitOfWork, IDepoimentRepository depoimentRepository) 
    {
        _unitOfWork = unitOfWork;
        _depoimentRepository = depoimentRepository;
    }
    

    public async Task<Result> Handle(DeleteDepoimentCommand request, CancellationToken cancellationToken)
    {
        var depoimet = await _depoimentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (depoimet is null)
            return Result.Fail(DepoimentErrors.NotFound);

        depoimet.Delete();

        _depoimentRepository.Update(depoimet);

        var deleted = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

        return !deleted ? Result.Fail(DestinyErrors.CannotBeDeleted) : Result.Ok();
    }
}
