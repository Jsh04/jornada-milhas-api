using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using JornadaMilhas.Application.Commands.PassagesCommands.InputModels;
using JornadaMilhas.Application.Commands.PassagesCommands.PaidPassage;
using JornadaMilhas.Common.Results.Errors;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Repositories;
using JornadaMilhasTest.UnitsTests.Seeds;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Application.CommandsTests.PassageCommandTests;

[TestFixture]
public class PaidPassageCommandTest
{

    private readonly Fixture _fixture;

    public PaidPassageCommandTest()
    {
        _fixture = SharingResources.AutoFixture;
    }

    [Test]
    public async Task PaidPassageCommandHandler_ShouldBeFail_WhenCustomerIdIsInvalid()
    {
        //arrange
        var command = new PaidPassageCommand(0, It.IsAny<List<PaidPassageInputModel>>());
        
        var handler = PaidPassageTestHelper.CreateHandlerToTest(_fixture);
        
        //act
        var result = await handler.Handle(command, CancellationToken.None);

        //assert
        result.Success.Should().BeFalse();
        result.Errors[0].Type.Should().Be(ErrorType.Unauthorized);
    }
    
    [Test]
    public async Task PaidPassageCommandHandler_ShouldBeFail_WhenCustomerNotFound()
    {
        //arrange
        var command = new PaidPassageCommand(5, It.IsAny<List<PaidPassageInputModel>>());
        
        var handler = PaidPassageTestHelper.CreateHandlerToTest(_fixture);
        
        //act
        var result = await handler.Handle(command, CancellationToken.None);

        //assert
        result.Success.Should().BeFalse();
        result.Errors.Should().HaveCount(1);
        result.Errors[0].Type.Should().Be(ErrorType.NotFound);
    }
    
    [Test]
    public async Task PaidPassageCommandHandler_ShouldBeCreatedOrder_WhenPassedPassageInputModelIsValid()
    {
        //arrange
        var listInputModels = _fixture.CreateMany<PaidPassageInputModel>(10).ToList();
        var command = new PaidPassageCommand(5, listInputModels);
        var customerTest = CustomerSeed.GetCustomerTest(_fixture);
        var flightTest = FlightSeed.GetFlightTest(_fixture);
        var handler = PaidPassageTestHelper.CreateHandlerToTest(_fixture, customerTest, flightTest);
        
        //act
        var result = await handler.Handle(command, CancellationToken.None);

        //assert
        result.Success.Should().BeTrue();
        result.Errors.Should().HaveCount(0);
    }
    
}