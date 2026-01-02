using JornadaMilhas.Application.Authentication.Shared;
using JornadaMilhas.Core.Entities.Users;

namespace JornadaMilhas.Application.Interfaces.Services;

public interface ITokenService
{
    TokenInfoDto GenerateToken(User user);
}