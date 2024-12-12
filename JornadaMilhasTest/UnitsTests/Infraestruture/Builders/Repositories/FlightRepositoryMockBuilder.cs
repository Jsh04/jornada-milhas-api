using AutoFixture;
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

    public FlightRepositoryMockBuilder AddGetDestinyById(long id)
    {
        _mock.Setup(x => x.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(FlightSeed.GetFlightTest(_fixture));
        return this;
    }

    public override Mock<IFlightRepository> Build()
    {
        return _mock;
    }
}