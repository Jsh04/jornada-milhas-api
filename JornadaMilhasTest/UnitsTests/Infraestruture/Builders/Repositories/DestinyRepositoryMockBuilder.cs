using AutoFixture;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhasTest.UnitsTests.Seeds;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Builders;

public class DestinyRepositoryMockBuilder : BaseMockBuilder<IDestinyRepository>
{
    private readonly Fixture _fixture;

    private DestinyRepositoryMockBuilder(Fixture fixture)
    {
        _fixture = fixture;
    }

    public static DestinyRepositoryMockBuilder Create(Fixture fixture)
    {
        return new DestinyRepositoryMockBuilder(fixture);
    }

    public DestinyRepositoryMockBuilder AddGetDestinyById(long id)
    {
        _mock.Setup(x => x.GetByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(DestinySeed.GetDestinyTest(_fixture));
        return this;
    }

    public override Mock<IDestinyRepository> Build()
    {
        return _mock;
    }
}