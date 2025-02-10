using JornadaMilhas.Application.Interfaces.UOW;
using JornadaMilhas.Application.Querys.Dtos.DepoimentsDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Repositories.Interfaces;
using MediatR;

namespace JornadaMilhas.Application.Querys.DepoimentQuerys.GetByIdDepoiment;

public sealed class GetByIdDepoimentQueryHandler : IRequestHandler<GetByIdDepoimentQuery, Result<DepoimentDto>>
{
    private readonly IDepoimentRepository _depoimentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdDepoimentQueryHandler(IUnitOfWork unitOfWork, IDepoimentRepository depoimentRepository)
    {
        _unitOfWork = unitOfWork;
        _depoimentRepository = depoimentRepository;
    }

    public async Task<Result<DepoimentDto>> Handle(GetByIdDepoimentQuery request, CancellationToken cancellationToken)
    {
        var depoiment = await _depoimentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (depoiment is null)
            return Result.Fail<DepoimentDto>(DepoimentErrors.NotFound);

        var depoimentDto = DtoExtensions<Depoiment, DepoimentDto>.ToDto(depoiment);

        return Result.Ok(depoimentDto);
    }
}