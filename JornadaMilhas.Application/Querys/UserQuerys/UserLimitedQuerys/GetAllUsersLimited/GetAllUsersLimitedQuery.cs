using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Common.PaginationResult;
using MediatR;

namespace JornadaMilhas.Application.Querys.UserQuerys.UserLimitedQuerys.GetAllUsersLimited
{
    public record GetAllUsersLimitedQuery(int Page, int Size) : IRequest<PaginationResult<UserLimitedDto>> { }

}
