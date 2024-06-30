using JornadaMilhas.Application.Querys.Dtos.LoginResponseDto;
using JornadaMilhas.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Querys.LoginQuerys.LoginUserQuerys
{
    public record LoginUserQuery(string Email, string Password) : IRequest<Result<LoginResponseDto>>
    {
    }
}
