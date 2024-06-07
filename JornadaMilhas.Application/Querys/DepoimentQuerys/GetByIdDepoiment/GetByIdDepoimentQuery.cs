using JornadaMilhas.Application.Querys.Dtos.DepoimentsDto;
using JornadaMilhas.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Querys.DepoimentQuerys.GetByIdDepoiment
{
    public sealed record GetByIdDepoimentQuery(long Id) : IRequest<Result<DepoimentDto>>
    {
    }
}
