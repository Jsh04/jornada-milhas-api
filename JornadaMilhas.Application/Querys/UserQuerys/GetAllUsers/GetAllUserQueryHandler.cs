using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
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


        }
    }
}
