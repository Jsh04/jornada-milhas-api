using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using JornadaMilhas.Application.Commands.PassagesCommands.InputModels;
using JornadaMilhas.Application.Commands.PassagesCommands.PaidPassage;
using JornadaMilhas.Application.Interfaces.UOW;
using JornadaMilhas.Common.Results.Errors;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Orders;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Repositories;
using JornadaMilhasTest.UnitsTests.Seeds;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Application.CommandsTests.PassageCommandTests;

[TestFixture]
public class PaidPassageCommandTest
{
    private readonly Fixture _fixture;
    
    private Mock<IUnitOfWork> _unitOfWorkMock = new();
    
    private Mock<ICustomerRepository> _customerRepositoryMock = new();
    
    private Mock<IFlightRepository> _flightRepositoryMock = new();
    
    private Mock<IOrderRepository> _orderRepositoryMock = new();
    
    public PaidPassageCommandTest()
    {
        _fixture = SharingResources.AutoFixture;
    }

    [Test]
    public async Task PaidPassageCommandHandler_ShouldBeFail_WhenCustomerIdIsInvalid()
    {
        //arrange
        var command = new PaidPassageCommand(0, It.IsAny<List<PaidPassageInputModel>>());
        
        var handler = CreateHandlerToTest();
        
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
        
        var handler = CreateHandlerToTest();
        
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
        var handler = CreateHandlerToTest(customerTest, flightTest);
        
        //act
        var result = await handler.Handle(command, CancellationToken.None);

        //assert
        result.Success.Should().BeTrue();
        result.Errors.Should().HaveCount(0);
        _orderRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<Order>()), Times.Once);
    }
    
    [Test]
    public async Task PaidPassageCommandHandler_ShouldBeError_WhenPassedFlightIsInvalid()
    {
        //arrange
        var listInputModels = _fixture.CreateMany<PaidPassageInputModel>(10).ToList();
        var command = new PaidPassageCommand(5, listInputModels);
        var customerTest = CustomerSeed.GetCustomerTest(_fixture);
        var handler = CreateHandlerToTest(customerTest);
        
        //act
        var result = await handler.Handle(command, CancellationToken.None);

        //assert
        result.Success.Should().BeFalse();
        result.Errors[0].Code.Should().Be("FlightErrors.NotFound");
        _orderRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<Order>()), Times.Never);
    }

    private PaidPassageCommandHandler CreateHandlerToTest(Customer customerReturn = null, Flight flightReturn = null)
    {
        _unitOfWorkMock = UnitOfWorkBuilder.CreateBuilder()
            .Build();

        _customerRepositoryMock = CustomerRepositoryMockBuilder.CreateBuilder(It.IsAny<IQueryable<Customer>>())
            .AddGetByIdAsync(customerReturn)
            .Build();
        
        _flightRepositoryMock = FlightRepositoryMockBuilder.Create(_fixture)
            .AddGetFlightById(flightReturn)
            .Build();
        
        _orderRepositoryMock = OrderRepositoryMockBuilder.Create()
            .Build();
        
        var passagePaidHandler = new PaidPassageCommandHandler(
            _unitOfWorkMock.Object, 
            _flightRepositoryMock.Object, 
            _customerRepositoryMock.Object, 
            _orderRepositoryMock.Object);
        
        return passagePaidHandler;
    }
    
}