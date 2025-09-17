using AutoFixture;
using JornadaMilhas.Application.Authentication.Queries.Login;
using JornadaMilhas.Application.Services;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Repositories;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Application.QuerysTests.LoginQueryTests;

[TestFixture]
public class LoginQueryTest
{
    private readonly Fixture _fixture;

    public LoginQueryTest()
    {
        _fixture = SharingResources.AutoFixture;
    }

    [Test]
    public async Task DeveraRetornarOkPassandoAsCredenciasCorretasQuandoConsultadoHandlerDeLogin()
    {
        const string email = "josesilvio.bs@gmail.com";
        var tokenGenerator = TokenGeneratorBuilder.CreateInstance().Build();

        var tokenService = new TokenService(tokenGenerator);

        var userRepositoryMock = UserRepositoryMockBuilder
            .CreateBuilder(_fixture)
            .AddGetByEmailAsync(email).Build();

        var loginQueryHandler = new LoginUserQueryHandler(tokenService, userRepositoryMock.Object);

        var loginQuery = new LoginQuery(email, ConstantsUnitTest.PasswordTest);

        //act
        var result = await loginQueryHandler.Handle(loginQuery, CancellationToken.None);

        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Success, Is.True);
            Assert.That(result.Value, Is.Not.Null);
        });

        userRepositoryMock.Verify(x => x.GetByEmailOrCpfAsync(email, It.IsAny<CancellationToken>()), Times.Once);
    }
}