using System.Security.Claims;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Infrastruture.Security;

namespace JornadaMilhas.Application.Services;

public class TokenService : ITokenService
{
    private const string Employee = "Employee";
    private const string Customer = "Customer";
    private readonly ITokenGenerator _tokenGenerator;

    public TokenService(ITokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    public string GenerateToken(User user)
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
            new Claim(ClaimTypes.Role, GetRoleUser(user))
        };

        return claims;
    }

    private static string GetRoleUser(User user)
    {
        return user is Customer ? Customer : Employee;
    }
}