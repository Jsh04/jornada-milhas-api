using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Core.ValueObjects.Locales;
using MediatR;

namespace JornadaMilhas.Application.Querys.DestinysQuerys.DestinyGetAll;

public class GetAllDestinysQueryHandler : IRequestHandler<GetAllDestinysQuery, PaginationResult<DestinyDto>>
{
    private readonly IDestinyRepository _destinyRepository;

    public GetAllDestinysQueryHandler(IDestinyRepository destinyRepository)
    {
        _destinyRepository = destinyRepository;
    }

    public async Task<PaginationResult<DestinyDto>> Handle(GetAllDestinysQuery request,
        CancellationToken cancellationToken)
    {
        var paginationResultDestinies =
            await _destinyRepository.GetAllAsync(request.Page, request.Size, cancellationToken);

        var destiniesDto = DtoExtensions<Locale, DestinyDto>.ToDto(paginationResultDestinies.Data);

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