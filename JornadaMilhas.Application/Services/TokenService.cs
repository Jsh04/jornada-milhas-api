using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Core.Entities.Users.UserAdmin;
using JornadaMilhas.Core.Interfaces.Services;
using JornadaMilhas.Infrastruture.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Services;

public class TokenService : ITokenService
{
    private readonly ITokenGenerator _tokenGenerator;
    private const string UserAdmin = "UserAdmin";
    private const string UserLimited = "UserLimited";

    public TokenService(ITokenGenerator tokenGenerator) => _tokenGenerator = tokenGenerator;
   
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
            new Claim(ClaimTypes.Role, GetRoleUser(user)),
        };

        return claims;
    }

    private static string GetRoleUser(User user) =>  user is UserAdmin ? UserAdmin : UserLimited;
     
}
