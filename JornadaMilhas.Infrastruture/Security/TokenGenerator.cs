using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JornadaMilhas.Common.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JornadaMilhas.Infrastruture.Security;

public class TokenGenerator : ITokenGenerator
{
    private readonly JwtSecurityTokenHandler _tokenHandler;
    private readonly string SecretKey;

    public TokenGenerator(IOptions<TokenOptions> tokenOptions, JwtSecurityTokenHandler jwtSecurityTokenHandler)
    {
        SecretKey = tokenOptions.Value.SecretKey;
        _tokenHandler = jwtSecurityTokenHandler;
    }

    public string GenerateToken(IEnumerable<Claim> claims)
    {
        var tokenDescriptor = GetSecurityTokenDescriptor(claims);

        var token = _tokenHandler.CreateToken(tokenDescriptor);

        return _tokenHandler.WriteToken(token);
    }

    private SecurityTokenDescriptor GetSecurityTokenDescriptor(IEnumerable<Claim> claims)
    {
        var key = Encoding.ASCII.GetBytes(SecretKey);

        return new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
        };
    }
}