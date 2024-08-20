using JornadaMilhas.Application.Commands.UserCommands.UserLimitedCommands.RegisterUserLimited;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Core.Interfaces.Services;

namespace JornadaMilhas.Application.Interfaces.Services
{
    public interface IUserLimitedService : IUserService
    {
        Task<Result<UserLimited>> RegisterUserLimited(RegisterUserLimitedCommand command);
    }
}
