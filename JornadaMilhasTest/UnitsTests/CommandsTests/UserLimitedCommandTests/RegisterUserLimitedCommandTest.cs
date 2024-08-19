using AutoFixture;
using JornadaMilhas.Application.Commands.DepoimentsCommands.RegisterDepoiment;
using JornadaMilhas.Application.Commands.UserCommands.RegisterUserLimited;
using JornadaMilhasTest.UnitsTests.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.InputDto;
using JornadaMilhas.Common.ValueObjects;
using JornadaMilhas.Application.Commands.UserCommands.UserLimitedCommands.RegisterUserLimited;

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
            var mockObjectUserLimited = UserLimitedRepositoryMockBuilder.CreateBuilder(_fixture).AddNotUniqueAsync(true).Build();
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

        [Test]
        public async Task DeveraRetornarOkPassandoOsDadosCorretosQuandoNaoExistirUmRegistro()
        {
            var mockObjectUnitOfWork = UnitOfWorkBuilder.CreateBuilder().AddCompleteAsync(1).Build();
            var mockObjectUserLimited = UserLimitedRepositoryMockBuilder.CreateBuilder(_fixture).AddNotUniqueAsync(false).Build();
            var resgisterUserLimitedHandler = new RegisterUserLimitedCommandHandler(mockObjectUnitOfWork, mockObjectUserLimited);

            var requestUserLimitedRegisterCommand = _fixture.Build<RegisterUserLimitedCommand>()
                .Without(user => user.Address)
                .With(user => user.Cpf, "76135350021")
                .With(user => user.Mail, "josesilvio.bs@gmail.com")
                .With(user => user.ConfirmMail, "josesilvio.bs@gmail.com")
                .With(user => user.Phone, "(28) 97968-4227")
                .With(user => user.Address, new AddressInputDto("Recife", "PE"))
                .With(user => user.DtBirth, DateTime.Parse("04-02-2004"))
                .Create();
            //act
            var result = await resgisterUserLimitedHandler.Handle(requestUserLimitedRegisterCommand, CancellationToken.None);

            //assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Success, Is.True);
                Assert.That(result.Errors, Is.Empty);
            });
        }




    }
}
