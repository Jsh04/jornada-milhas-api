using AutoFixture;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhas.Application.Commands.UserCommands.UserLimitedCommands.RegisterUserLimited;
using JornadaMilhasTest.UnitsTests.Helper;

namespace JornadaMilhasTest.UnitsTests.Application.CommandsTests.UserLimitedCommandTests
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
            var resgisterUserLimitedHandler = new RegisterUserLimitedCommandHandler(mockObjectUnitOfWork.Object, mockObjectUserLimited.Object);

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
            var resgisterUserLimitedHandler = new RegisterUserLimitedCommandHandler(mockObjectUnitOfWork.Object, mockObjectUserLimited.Object);

            var requestUserLimitedRegisterCommand = UnitTestHelper.GetUserCorrectDataTest(_fixture);
            //act
            var result = await resgisterUserLimitedHandler.Handle(requestUserLimitedRegisterCommand, CancellationToken.None);

            //assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Success, Is.True);
                Assert.That(result.Errors, Is.Empty);
            });
        }

        [Test]
        public async Task DeveraRetornarEventoPassandoOsDadosCorretosQuandoUsuarioForCadastrado()
        {
            var mockObjectUnitOfWork = UnitOfWorkBuilder.CreateBuilder().AddCompleteAsync(1).Build();
            var mockObjectUserLimited = UserLimitedRepositoryMockBuilder.CreateBuilder(_fixture).AddNotUniqueAsync(false).Build();

            var resgisterUserLimitedHandler = new RegisterUserLimitedCommandHandler(mockObjectUnitOfWork.Object, mockObjectUserLimited.Object);

            var requestUserLimitedRegisterCommand = UnitTestHelper.GetUserCorrectDataTest(_fixture);
            var result = await resgisterUserLimitedHandler.Handle(requestUserLimitedRegisterCommand, CancellationToken.None);

            //act
            var userCreated = result.ValueOrDefault;

            //assert
            Assert.That(userCreated.GetAllDomainsEvent(), Is.Not.Empty);
        }

        [Test]
        public async Task DeveraRetornarErroPassandoOsDadosCorretosQuandoUsuarioNaoConseguirSerCriado()
        {
            var mockObjectUnitOfWork = UnitOfWorkBuilder.CreateBuilder().AddCompleteAsync(0).Build();
            var mockObjectUserLimited = UserLimitedRepositoryMockBuilder.CreateBuilder(_fixture).AddNotUniqueAsync(false).Build();

            var resgisterUserLimitedHandler = new RegisterUserLimitedCommandHandler(mockObjectUnitOfWork.Object, mockObjectUserLimited.Object);

            var requestUserLimitedRegisterCommand = UnitTestHelper.GetUserCorrectDataTest(_fixture);

            //act
            var result = await resgisterUserLimitedHandler.Handle(requestUserLimitedRegisterCommand, CancellationToken.None);
            Assert.Multiple(() =>
            {
                //assert
                Assert.That(result.Success, Is.False);
                Assert.That(result.Errors, Is.Not.Empty);
                Assert.That(result.Errors, Has.Count.EqualTo(1));
            });

            ;
        }
    }
}
