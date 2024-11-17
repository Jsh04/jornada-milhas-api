using JornadaMilhas.Application.Querys.Dtos.DepoimentsDto;
using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Entities.Destinies;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Repository;
using MediatR;

namespace JornadaMilhas.Application.Querys.DestinysQuerys.DestinyGetAll;

public class GetAllDestinysQueryHandler : IRequestHandler<GetAllDestinysQuery, PaginationResult<DestinyDto>> {

    private readonly IDestinyRepository _destinyRepository;

    public GetAllDestinysQueryHandler(IDestinyRepository destinyRepository)
    {
        _destinyRepository = destinyRepository;
    }

    public async Task<PaginationResult<DestinyDto>> Handle(GetAllDestinysQuery request, CancellationToken cancellationToken)
    {
        var paginationResultDestinies = await _destinyRepository.GetAllAsync(request.Page, request.Size, cancellationToken);

        var destiniesDto = DtoExtensions<Destiny, DestinyDto>.ToDto(paginationResultDestinies.Data);

        var paginationResultDestiniesDto = new PaginationResult<DestinyDto>
        (
            paginationResultDestinies.Page,
            paginationResultDestinies.PageSize,
            paginationResultDestinies.TotalCount,
            paginationResultDestinies.TotalPages,
            destiniesDto.ToList()
        );

        return paginationResultDestiniesDto;
    }
}
