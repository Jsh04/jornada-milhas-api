

using JornadaMilhas.Application.Commands.UserCommands.RegisterUserLimited;
using JornadaMilhas.Core.Interfaces.Services;

namespace JornadaMilhas.Application.Services
{
    public class UserService : IUserService
    {
        public Task PostUserLimited(RegisterUserLimitedCommand registerUserLimitedCommand)
        {
            throw new NotImplementedException();
        }
    }
}
