using System.IdentityModel.Tokens.Jwt;
using JornadaMilhas.Application.Interfaces.Security;
using JornadaMilhas.Common.Options;
using JornadaMilhas.Infrastruture.Security;
using JornadaMilhasTest.UnitsTests.Helper;
using Microsoft.Extensions.Options;

namespace JornadaMilhasTest.UnitsTests.Builders;

public class TokenGeneratorBuilder
{
    private readonly TokenOptions _tokenOptions;

    public TokenGeneratorBuilder()
    {
        _tokenOptions = Options.Create(new TokenOptions { SecretKey = UnitTestHelper.GenerateSecretKey() }).Value;
    }

    public static TokenGeneratorBuilder CreateInstance()
    {
        return new TokenGeneratorBuilder();
    }

    public ITokenGenerator Build()
    {
        return new TokenGenerator(Options.Create(_tokenOptions), new JwtSecurityTokenHandler());
    }
}