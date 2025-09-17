using JornadaMilhas.Application.Authentication.Shared;
using JornadaMilhas.Core.Users;

namespace JornadaMilhas.Application.Interfaces.Services;

public interface ITokenService
{
    TokenInfoDto GenerateToken(User user);
}