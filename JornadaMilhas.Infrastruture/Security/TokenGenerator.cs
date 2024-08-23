using JornadaMilhas.Common.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JornadaMilhas.Infrastruture.Security;

public class TokenGenerator : ITokenGenerator
{
    private readonly string SecretKey;

    private readonly JwtSecurityTokenHandler _tokenHandler;

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
            SigningCredentials = //Assinatura do token, serve para identificar que mandou o token e garantir que o token não foi alterado no meio do caminho.
            new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
        };
    }
}
