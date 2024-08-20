

using JornadaMilhas.Application.Commands.UserCommands.DeleteUserById;
using JornadaMilhas.Application.Commands.UserCommands.UserLimitedCommands.RegisterUserLimited;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Application.Querys.UserQuerys.GetUserById;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Interfaces.Services;

namespace JornadaMilhas.Application.Services
{
    public class UserService : IUserService
    {
        public Task<Result> DeleteUserbyId(DeleteUserByIdCommand deleteUserByIdCommands, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public Task<PaginationResult<User>> GetAllUsers(int size, int page, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<PaginationResult<UserDto>> GetAllUsersAsync(int size, int page, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Result<UserDto>> GetUserById(GetUserByIdQuery query, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public Task PostUserLimited(RegisterUserLimitedCommand registerUserLimitedCommand)
        {
            throw new NotImplementedException();
        }
    }
}
