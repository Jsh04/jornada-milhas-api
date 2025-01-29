using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Users;

namespace JornadaMilhas.Application.Querys.Dtos.LoginResponseDto;

public record LoginOutputModel
{
    private LoginOutputModel(User user, string token)
    {
        User = user;
        Token = token;
    }

    public string Token { get; private set; }
    public User User { get; private set; }

    public static LoginOutputModel CreateResponseLogin(User user, string token)
    {
        return new LoginOutputModel(user, token);
    }
}