﻿using JornadaMilhas.Application.Querys.Dtos.DepoimentsDto;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Querys.DepoimentQuerys.GetAllDepoiments
{
    public sealed record GetAllDepoimentQuery(int Page, int Size) : IRequest<Result<PaginationResult<DepoimentDto>>>
    {
    }
}
