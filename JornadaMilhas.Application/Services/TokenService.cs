using System.Security.Claims;
using JornadaMilhas.Application.Authentication.Shared;
using JornadaMilhas.Application.Interfaces.Security;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Users;

namespace JornadaMilhas.Application.Services;

public class TokenService : ITokenService
{
    private readonly ITokenGenerator _tokenGenerator;

    public TokenService(ITokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    public TokenInfoDto GenerateToken(User user)
    {
        var claimsToken = GetClaimsOfToken(user);
        return _tokenGenerator.GenerateToken(claimsToken);
    }

    private static IEnumerable<Claim> GetClaimsOfToken(User user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Email, user.Email.Address),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            
        };

        return claims;
    }

    
}