using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Querys.DestinysQuerys.DestinysGetById
{
    public class GetByIdDestinyQueryHandler : IRequestHandler<GetByIdDestinyQuery, Result<Destiny>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositoryDestino _destinyRepository;

        public GetByIdDestinyQueryHandler(IUnitOfWork unitOfWork, IRepositoryDestino destinyRepository)
        {
            _unitOfWork = unitOfWork;
            _destinyRepository = destinyRepository;
        }

        public async Task<Result<Destiny>> Handle(GetByIdDestinyQuery request, CancellationToken cancellationToken)
        {
            var destiny = await _destinyRepository.GetByIdAsync(request.id, cancellationToken);

            if (destiny is null)
                return Result.Fail<Destiny>(DestinyErrors.NotFound);

            return Result.Ok(destiny);
        }
    }
}
