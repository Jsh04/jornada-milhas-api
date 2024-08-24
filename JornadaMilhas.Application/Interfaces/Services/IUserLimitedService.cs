using JornadaMilhas.Application.Commands.UserCommands.UserLimitedCommands.RegisterUserLimited;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Application.Querys.UserQuerys.UserLimitedQuerys.GetUserById;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Core.Interfaces.Services;

namespace JornadaMilhas.Application.Interfaces.Services
{
    public interface IUserLimitedService : IUserService<UserLimitedDto>
    {
        Task<Result<UserLimited>> RegisterUserLimited(RegisterUserLimitedCommand command);

        Task<Result<UserLimitedDto>> GetUserById(GetUserLimitedByIdQuery query, CancellationToken cancellation = default);
    }
}
