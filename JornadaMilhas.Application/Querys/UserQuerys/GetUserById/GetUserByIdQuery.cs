using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Querys.UserQuerys.GetUserById;

public record GetUserByIdQuery(long Id) : IRequest<Result<UserDto>>
{}
