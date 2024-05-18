using JornadaMilhas.Application.Querys.Dtos.DepoimentsDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Querys.DepoimentQuerys.GetAllDepoimentsQuery;



public class GetAllDepoimentQueryHandler : IRequestHandler<GetAllDepoimentQuery, Result<PaginationResult<DepoimentDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDepoimentQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    

    public async Task<Result<PaginationResult<DepoimentDto>>> Handle(GetAllDepoimentQuery request, CancellationToken cancellationToken)
    {
        var paginationResultDepoiments = await _unitOfWork.DepoimentRepository.GetAllAsync(request.Page, request.Size, cancellationToken);

        var depoimentsDto = DtoExtensions<Depoiment>.ToDto<DepoimentDto>(paginationResultDepoiments.Data);

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
