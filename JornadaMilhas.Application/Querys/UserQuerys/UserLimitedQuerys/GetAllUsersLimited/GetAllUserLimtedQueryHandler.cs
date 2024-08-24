using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Application.Querys.UserQuerys.UserLimitedQuerys.GetAllUsersLimited;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Core.Repositories.Interfaces;
using MediatR;

namespace JornadaMilhas.Application.Querys.UserQuerys.UserLimitedQuerys.GetAllUsers
{
    public class GetAllUserLimtedQueryHandler : IRequestHandler<GetAllUsersLimitedQuery, PaginationResult<UserLimitedDto>>
    {

        private readonly IUserLimitedRepository _userLimitedRepository;

        public GetAllUserLimtedQueryHandler(IUserLimitedRepository userLimitedRepository)
        {
            _userLimitedRepository = userLimitedRepository;
        }
        public async Task<PaginationResult<UserLimitedDto>> Handle(GetAllUsersLimitedQuery request, CancellationToken cancellationToken)
        {
            var usersFromDatabase = await _userLimitedRepository.GetAllAsync(request.Page, request.Size, cancellationToken);

            var usersDtoToReturn = DtoExtensions<UserLimited, UserLimitedDto>.ToDto(usersFromDatabase.Data);

            var paginationResult = new PaginationResult<UserLimitedDto>(usersFromDatabase.Page,
                usersFromDatabase.PageSize,
                usersFromDatabase.TotalCount,
                usersFromDatabase.TotalPages,
                usersDtoToReturn.ToList());

            return paginationResult;
        }
    }
}
