using JornadaMilhas.Application.Querys.Dtos.LoginResponseDto;
using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Querys.LoginQuerys.LoginUserQuerys
{
    public record LoginUserQuery(string Email, string Password) : IRequest<Result<LoginResponseDto>>
    {
    }
}
