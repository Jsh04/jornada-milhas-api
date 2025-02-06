using AutoFixture;
using AutoFixture.Kernel;
using JornadaMilhas.Application.Commands.PassagesCommands.InputModels;
using JornadaMilhas.Application.Commands.PassagesCommands.PaidPassage;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Repositories;
using JornadaMilhasTest.UnitsTests.Seeds;

namespace JornadaMilhasTest.UnitsTests.Application.CommandsTests.PassageCommandTests;

public static class PaidPassageTestHelper
{

    public static PaidPassageCommandHandler CreateHandlerToTest(
        Fixture fixture, 
        Customer customerReturn = null, 
        Flight flightReturn = null)
    {
        var mockUnitOfWork = UnitOfWorkBuilder.CreateBuilder()
            .Build();

        var customerRepository = CustomerRepositoryMockBuilder.CreateBuilder(fixture)
            .AddGetByIdAsync(customerReturn)
            .Build();
        
        var flightRepository = FlightRepositoryMockBuilder.Create(fixture)
            .AddGetFlightById(flightReturn)
            .Build();
        
        var passageRepository = PassageRepositoryMockBuilder.Create()
            .Build();
        var orderRepository = OrderRepositoryMockBuilder.Create()
            .Build();
        
        var passagePaidHandler = new PaidPassageCommandHandler(
            mockUnitOfWork.Object, 
            flightRepository.Object, 
            customerRepository.Object, 
            passageRepository.Object,
            orderRepository.Object);
        
        return passagePaidHandler;
    }
}