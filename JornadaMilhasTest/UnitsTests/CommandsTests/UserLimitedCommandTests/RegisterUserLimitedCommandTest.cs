using AutoFixture;
using JornadaMilhas.Application.Commands.DepoimentsCommands.RegisterDepoiment;
using JornadaMilhas.Application.Commands.UserCommands.RegisterUserLimited;
using JornadaMilhasTest.UnitsTests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.UnitsTests.CommandsTests.UserCommandTests
{
    [TestFixture]
    public class RegisterUserLimitedCommandTest
    {
        private readonly Fixture _fixture;
        public RegisterUserLimitedCommandTest()
        {
            _fixture = SharingResources.AutoFixture;
        }

        [Test]
        public async Task DeveraRetornarFailPassandoOsDadosCorretosQuandoJaExistirUmRegistro()
        {
            //arrange
            var mockObjectUnitOfWork = UnitOfWorkBuilder.CreateBuilder().Build();
            var mockObjectUserLimited = UserLimitedRepositoryMockBuilder.CreateBuilder(_fixture).AddIsUniqueAsync(true).Build();
            var resgisterUserLimitedHandler = new RegisterUserLimitedCommandHandler(mockObjectUnitOfWork, mockObjectUserLimited);

            var requestUserLimitedRegisterCommand = _fixture.Build<RegisterUserLimitedCommand>()
                .Without(user => user.Address)
                .Create();
            //act
            var result = await resgisterUserLimitedHandler.Handle(requestUserLimitedRegisterCommand, CancellationToken.None);
            
            //assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Success, Is.False);
                Assert.That(result.Errors, Is.Not.Empty);
            });
        }


    }
}
