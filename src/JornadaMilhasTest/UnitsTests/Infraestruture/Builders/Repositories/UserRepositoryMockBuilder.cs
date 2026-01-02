using AutoFixture;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhasTest.UnitsTests.Seeds;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Repositories;

public class UserRepositoryMockBuilder : BaseMockBuilder<IUserRepository>
{
    private readonly Fixture _fixture;

    private UserRepositoryMockBuilder(Fixture fixture)
    {
        _fixture = fixture;
    }

    public static UserRepositoryMockBuilder CreateBuilder(Fixture fixture)
    {
        return new UserRepositoryMockBuilder(fixture);
    }
    
    public UserRepositoryMockBuilder AddGetByEmailAsync(string emailOrCpf)
    {
        _mock.Setup(x => x.GetByEmailOrCpfAsync(emailOrCpf, CancellationToken.None))
            .ReturnsAsync(CustomerSeed.GetCustomerTest(_fixture));

        return this;
    }

    public override Mock<IUserRepository> Build()
    {
        return _mock;
    }
}