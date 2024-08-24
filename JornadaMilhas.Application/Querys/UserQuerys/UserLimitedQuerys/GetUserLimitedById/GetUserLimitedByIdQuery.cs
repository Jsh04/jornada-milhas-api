using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Querys.UserQuerys.UserLimitedQuerys.GetUserById;

public record GetUserLimitedByIdQuery(long Id) : IRequest<Result<UserLimitedDto>>
{ }
