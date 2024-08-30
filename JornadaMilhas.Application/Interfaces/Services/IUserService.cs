using JornadaMilhas.Application.Commands.UserCommands.DeleteUserById;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Core.Interfaces.Services;

public interface IUserService<TUserDto> where TUserDto : UserDto 
{
    Task<PaginationResult<TUserDto>> GetAllUsersAsync(int size, int page, CancellationToken cancellationToken = default);

    
    
    Task<Result> DeleteUserbyId(DeleteUserByIdCommand deleteUserByIdCommands, CancellationToken cancellation = default);
}
