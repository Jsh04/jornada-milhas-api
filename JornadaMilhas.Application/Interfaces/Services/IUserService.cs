using JornadaMilhas.Application.Commands.UserCommands.DeleteUserById;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Application.Querys.UserQuerys.GetUserById;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Core.Interfaces.Services;

public interface IUserService 
{
    Task<PaginationResult<UserDto>> GetAllUsersAsync(int size, int page, CancellationToken cancellationToken = default);

    Task<Result<UserDto>> GetUserById(GetUserByIdQuery query, CancellationToken cancellation = default);
    Task<Result> DeleteUserbyId(DeleteUserByIdCommand deleteUserByIdCommands, CancellationToken cancellation = default);
}
