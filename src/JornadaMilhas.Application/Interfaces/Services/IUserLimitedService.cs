using JornadaMilhas.Application.Commands.UserCommands.UserLimitedCommands.RegisterUserLimited;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Application.Querys.UserQuerys.UserLimitedQuerys.GetUserById;
using JornadaMilhas.Common.Results;

namespace JornadaMilhas.Application.Interfaces.Services;

public interface IUserLimitedService : IUserService<UserLimitedDto>
{
   
}