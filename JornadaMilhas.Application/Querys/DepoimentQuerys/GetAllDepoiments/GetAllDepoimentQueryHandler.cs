using JornadaMilhas.Application.Querys.Dtos.DepoimentsDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Querys.DepoimentQuerys.GetAllDepoiments;



public class GetAllDepoimentQueryHandler : IRequestHandler<GetAllDepoimentQuery, Result<PaginationResult<DepoimentDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IDepoimentRepository _depoimentRepository;


    public GetAllDepoimentQueryHandler(IUnitOfWork unitOfWork, IDepoimentRepository depoimentRepository) 
    {
        _unitOfWork = unitOfWork;
        _depoimentRepository = depoimentRepository;
    }

    public async Task<Result<PaginationResult<DepoimentDto>>> Handle(GetAllDepoimentQuery request, CancellationToken cancellationToken)
    {
        var paginationResultDepoiments = await _depoimentRepository.GetAllAsync(request.Page, request.Size, cancellationToken);

        var depoimentsDto = DtoExtensions<Depoiment, DepoimentDto>.ToDto(paginationResultDepoiments.Data);

        var paginationResultDepoimentsDto = new PaginationResult<DepoimentDto>
        (
            paginationResultDepoiments.Page,
            paginationResultDepoiments.PageSize,
            paginationResultDepoiments.TotalCount,
            paginationResultDepoiments.TotalPages,
            depoimentsDto.ToList()
        );

        return Result.Ok(paginationResultDepoimentsDto);

    }
}
