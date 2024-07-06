using JornadaMilhas.Application.Commands.UserCommands.RegisterUserLimited;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Core.Interfaces.Services;

public interface IUserService
{
    Task PostUserLimited(RegisterUserLimitedCommand registerUserLimitedCommand);
}
