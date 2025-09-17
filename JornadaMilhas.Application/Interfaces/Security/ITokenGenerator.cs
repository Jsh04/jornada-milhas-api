using System.Security.Claims;
using JornadaMilhas.Application.Authentication.Shared;

namespace JornadaMilhas.Application.Interfaces.Security;

public interface ITokenGenerator
{
    TokenInfoDto GenerateToken(IEnumerable<Claim> claims);
}