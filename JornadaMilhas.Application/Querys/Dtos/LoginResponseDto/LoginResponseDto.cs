using JornadaMilhas.Common.Entities;

namespace JornadaMilhas.Application.Querys.Dtos.LoginResponseDto;

public record LoginResponseDto
{
    public string Token { get; private set; }
    public User User { get; private set; }

    private LoginResponseDto(User user, string token)
    {
        User = user;
        Token = token;
    }

    public static LoginResponseDto CreateResponseLogin(User user, string token) => new LoginResponseDto(user, token);

    

}
