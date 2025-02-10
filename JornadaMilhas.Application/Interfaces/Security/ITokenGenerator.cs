using System.Security.Claims;

namespace JornadaMilhas.Application.Interfaces.Security;

public interface ITokenGenerator
{
    string GenerateToken(IEnumerable<Claim> claims);
}