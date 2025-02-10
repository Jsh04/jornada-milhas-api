using AutoFixture;
using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhasTest.UnitsTests.Helper;
using JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Repositories;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Application.CommandsTests.UserLimitedCommandTests;

[TestFixture]
public class RegisterCustomerCommandTest
{
    private readonly Fixture _fixture;

    public RegisterCustomerCommandTest()
    {
        _fixture = SharingResources.AutoFixture;
    }

    [Test]
    public async Task DeveraRetornarFailPassandoOsDadosCorretosQuandoJaExistirUmRegistro()
    {
        //arrange
        var mockObjectUnitOfWork = UnitOfWorkBuilder.CreateBuilder().Build();
        var mockObjectUserLimited =
            CustomerRepositoryMockBuilder.CreateBuilder(It.IsAny<IQueryable<Customer>>()).AddNotUniqueAsync(true).Build();
        var resgisterUserLimitedHandler =
            new RegisterCustomerCommandHandler(mockObjectUnitOfWork.Object, mockObjectUserLimited.Object);

        var requestUserLimitedRegisterCommand = _fixture.Build<RegisterCustomerCommand>()
            .Without(user => user.Address)
            .Create();
        //act
        var result =
            await resgisterUserLimitedHandler.Handle(requestUserLimitedRegisterCommand, CancellationToken.None);

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
        var mockObjectUserLimited =
            CustomerRepositoryMockBuilder.CreateBuilder(It.IsAny<IQueryable<Customer>>()).AddNotUniqueAsync(false).Build();
        var resgisterUserLimitedHandler =
            new RegisterCustomerCommandHandler(mockObjectUnitOfWork.Object, mockObjectUserLimited.Object);

        var requestUserLimitedRegisterCommand = UnitTestHelper.GetUserCorrectDataTest(_fixture);
        //act
        var result =
            await resgisterUserLimitedHandler.Handle(requestUserLimitedRegisterCommand, CancellationToken.None);

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
        var mockObjectCustomer =
            CustomerRepositoryMockBuilder.CreateBuilder(It.IsAny<IQueryable<Customer>>()).AddNotUniqueAsync(false).Build();

        var resgisterUserLimitedHandler =
            new RegisterCustomerCommandHandler(mockObjectUnitOfWork.Object, mockObjectCustomer.Object);

        var requestUserLimitedRegisterCommand = UnitTestHelper.GetUserCorrectDataTest(_fixture);
        var result =
            await resgisterUserLimitedHandler.Handle(requestUserLimitedRegisterCommand, CancellationToken.None);

        //act
        var userCreated = result.ValueOrDefault;

        //assert
        Assert.That(userCreated.GetAllDomainsEvent(), Is.Not.Empty);
    }

    [Test]
    public async Task DeveraRetornarErroPassandoOsDadosCorretosQuandoUsuarioNaoConseguirSerCriado()
    {
        var mockObjectUnitOfWork = UnitOfWorkBuilder.CreateBuilder().AddCompleteAsync(0).Build();
        var mockObjectUserLimited =
            CustomerRepositoryMockBuilder.CreateBuilder(It.IsAny<IQueryable<Customer>>()).AddNotUniqueAsync(false).Build();

        var resgisterUserLimitedHandler =
            new RegisterCustomerCommandHandler(mockObjectUnitOfWork.Object, mockObjectUserLimited.Object);

        var requestUserLimitedRegisterCommand = UnitTestHelper.GetUserCorrectDataTest(_fixture);

        //act
        var result =
            await resgisterUserLimitedHandler.Handle(requestUserLimitedRegisterCommand, CancellationToken.None);
        Assert.Multiple(() =>
        {
            //assert
            Assert.That(result.Success, Is.False);
            Assert.That(result.Errors, Is.Not.Empty);
            Assert.That(result.Errors, Has.Count.EqualTo(1));
        });
    }
}