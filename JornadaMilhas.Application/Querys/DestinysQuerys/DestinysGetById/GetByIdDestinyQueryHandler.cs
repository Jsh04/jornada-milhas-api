using JornadaMilhas.Application.Querys.Dtos.DestinysDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Core.ValueObjects.Locales;
using MediatR;

namespace JornadaMilhas.Application.Querys.DestinysQuerys.DestinysGetById;

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
            return Result.Fail<DestinyDto>(LocaleErrors.NotFound);

        var destinyDto = DtoExtensions<Locale, DestinyDto>.ToDto(destiny);

        return Result.Ok(destinyDto);
    }
}