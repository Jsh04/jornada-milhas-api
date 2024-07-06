using JornadaMilhas.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
