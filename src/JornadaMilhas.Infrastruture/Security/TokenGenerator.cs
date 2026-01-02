using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JornadaMilhas.Application.Authentication.Shared;
using JornadaMilhas.Application.Interfaces.Security;
using JornadaMilhas.Common.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JornadaMilhas.Infrastruture.Security;

public class TokenGenerator : ITokenGenerator
{
    private readonly JwtSecurityTokenHandler _tokenHandler;
    private readonly string _secretKey;

    public TokenGenerator(IOptions<TokenOptions> tokenOptions, JwtSecurityTokenHandler jwtSecurityTokenHandler)
    {
        _secretKey = tokenOptions.Value.SecretKey;
        _tokenHandler = jwtSecurityTokenHandler;
    }

    public TokenInfoDto GenerateToken(IEnumerable<Claim> claims)
    {
        var dateExpiration = DateTime.UtcNow.AddHours(3);
        
        var tokenDescriptor = GetSecurityTokenDescriptor(claims, dateExpiration);

        var token = _tokenHandler.CreateToken(tokenDescriptor);

        return new TokenInfoDto(_tokenHandler.WriteToken(token), dateExpiration);
    }

    private SecurityTokenDescriptor GetSecurityTokenDescriptor(IEnumerable<Claim> claims, DateTime dateExpiration)
    {
        var key = Encoding.ASCII.GetBytes(_secretKey);

        return new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = dateExpiration,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
    }
}