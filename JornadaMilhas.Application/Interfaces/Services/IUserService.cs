using JornadaMilhas.Application.Commands.UserCommands.DeleteUserById;
using JornadaMilhas.Application.Commands.UserCommands.RegisterUserLimited;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Application.Querys.UserQuerys.GetUserById;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Core.Interfaces.Services;

public interface IUserService
{
    Task<PaginationResult<User>> GetAllUsers(int size, int page, CancellationToken cancellationToken = default);

    Task<Result<UserDto>> GetUserById(GetUserByIdQuery query, CancellationToken cancellation = default);
    Task<Result> DeleteUserbyId(DeleteUserByIdCommand deleteUserByIdCommands, CancellationToken cancellation = default);
}
