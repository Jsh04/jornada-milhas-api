using AutoFixture;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.LoginQuerys.LoginUserQuerys;
using JornadaMilhas.Application.Services;
using JornadaMilhas.Application.Util;
using JornadaMilhas.Common.Options;
using JornadaMilhas.Infrastruture.Security;
using JornadaMilhasTest.UnitsTests.Builders;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.Application.QuerysTests.LoginQueryTests
{
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
            var email = "josesilvio.bs@gmail.com";
            var tokenGenerator = TokenGeneratorBuilder.CreateInstance().Build();

            var tokenService = new TokenService(tokenGenerator);

            var userRepositoryMock = UserRepositoryMockBuilder
                .CreateBuilder(_fixture)
                .AddGetByEmailAsync(email).Build();

            var loginQueryHandler = new LoginUserQueryHandler(tokenService, userRepositoryMock.Object);

            var loginQuery = new LoginUserQuery(email, ConstantsUnitTest.PasswordTest);

            //act
            var result = await loginQueryHandler.Handle(loginQuery, CancellationToken.None);

            //assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Success, Is.True);
                Assert.That(result.Value, Is.Not.Null);
            });

            userRepositoryMock.Verify(x => x.GetByEmailAsync(email, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
