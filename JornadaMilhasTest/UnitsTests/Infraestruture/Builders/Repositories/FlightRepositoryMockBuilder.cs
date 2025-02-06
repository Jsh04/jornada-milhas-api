using AutoFixture;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhasTest.UnitsTests.Seeds;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Repositories;

public class FlightRepositoryMockBuilder : BaseMockBuilder<IFlightRepository>
{
    private readonly Fixture _fixture;

    private FlightRepositoryMockBuilder(Fixture fixture)
    {
        _fixture = fixture;
    }

    public static FlightRepositoryMockBuilder Create(Fixture fixture)
    {
        return new FlightRepositoryMockBuilder(fixture);
    }

    public FlightRepositoryMockBuilder AddGetFlightById(Flight flightReturn)
    {
        _mock.Setup(x => x.GetByIdAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(flightReturn);
        return this;
    }

    public override Mock<IFlightRepository> Build()
    {
        return _mock;
    }
}