using AutoFixture;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhasTest.UnitsTests.Helper;
using JornadaMilhasTest.UnitsTests.Seeds;

namespace JornadaMilhasTest.UnitsTests.Infraestruture.Services;

[TestFixture]
public class TokenGeneratorTest
{
    private readonly Fixture _fixture;

    public TokenGeneratorTest()
    {
        _fixture = SharingResources.AutoFixture;
    }

    [Test]
    public void GenerateToken_DeveraRetornarToken_PassandoOsClaims()
    {
        //assert
        var tokenGenerate = TokenGeneratorBuilder.CreateInstance().Build();
        var customer = CustomerSeed.GetCustomerTest(_fixture);

        var claims = UnitTestHelper.GetClaimsToTest(customer);

        //act
        var token = tokenGenerate.GenerateToken(claims);

        //assert
        Assert.That(token, Is.Not.Null);
        Assert.That(token, Is.TypeOf<string>());
    }
}