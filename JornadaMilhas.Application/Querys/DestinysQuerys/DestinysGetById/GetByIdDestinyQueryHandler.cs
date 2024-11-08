using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Querys.DestinysQuerys.DestinysGetById
{
    public class GetByIdDestinyQueryHandler : IRequestHandler<GetByIdDestinyQuery, Result<DestinyDto>>
    {
        private readonly IDestinyRepository _destinyRepository;

        public GetByIdDestinyQueryHandler(IDestinyRepository destinyRepository)
        {
            _destinyRepository = destinyRepository;
        }

        public async Task<Result<DestinyDto>> Handle(GetByIdDestinyQuery request, CancellationToken cancellationToken)
        {
            var destiny = await _destinyRepository.GetByIdAsync(request.id, cancellationToken);

            if (destiny is null)
                return Result.Fail<DestinyDto>(DestinyErrors.NotFound);

            var destinyDto = DtoExtensions<Destiny, DestinyDto>.ToDto(destiny);

            return Result.Ok(destinyDto);
        }
    }
}
