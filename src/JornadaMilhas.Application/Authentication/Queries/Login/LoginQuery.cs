using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Authentication.Queries.Login;

public record LoginQuery(string EmailOrCpf, string Password) : IRequest<Result<LoginQueryResult>>
{
}