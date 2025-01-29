using System.Security.Claims;

namespace JornadaMilhas.Infrastruture.Security;

public interface ITokenGenerator
{
    string GenerateToken(IEnumerable<Claim> claims);
}