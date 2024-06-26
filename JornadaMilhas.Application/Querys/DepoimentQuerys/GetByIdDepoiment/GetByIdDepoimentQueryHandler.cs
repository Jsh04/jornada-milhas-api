﻿using JornadaMilhas.Application.Querys.Dtos.DepoimentsDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Querys.DepoimentQuerys.GetByIdDepoiment;

public sealed class GetByIdDepoimentQueryHandler : IRequestHandler<GetByIdDepoimentQuery, Result<DepoimentDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdDepoimentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DepoimentDto>> Handle(GetByIdDepoimentQuery request, CancellationToken cancellationToken)
    {
        var depoiment = await _unitOfWork.DepoimentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (depoiment is null)
            return Result.Fail<DepoimentDto>(DepoimentErrors.NotFound);

        var depoimentDto = DtoExtensions<Depoiment, DepoimentDto>.ToDto(depoiment);

        return Result.Ok(depoimentDto);

    }
}
