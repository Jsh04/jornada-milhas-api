using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Repositories.Interfaces;
using MediatR;

namespace JornadaMilhas.Application.Querys.UserQuerys.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, PaginationResult<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<PaginationResult<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var usersFromDatabase = await _userRepository.GetAllAsync(request.Page, request.Size, cancellationToken);

            var usersDtoToReturn = DtoExtensions<User, UserDto>.ToDto(usersFromDatabase.Data);

            var paginationResult = new PaginationResult<UserDto>(usersFromDatabase.Page, 
                usersFromDatabase.PageSize, 
                usersFromDatabase.TotalCount,
                usersFromDatabase.TotalPages, 
                usersDtoToReturn.ToList());

            return paginationResult;
        }
    }
}
