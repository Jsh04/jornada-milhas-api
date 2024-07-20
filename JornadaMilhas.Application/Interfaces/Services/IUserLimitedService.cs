using JornadaMilhas.Application.Commands.UserCommands.RegisterUserLimited;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Interfaces.Services
{
    public interface IUserLimitedService : IUserService
    {
        Task<Result<UserLimited>> RegisterUserLimited(RegisterUserLimitedCommand command);
    }
}
