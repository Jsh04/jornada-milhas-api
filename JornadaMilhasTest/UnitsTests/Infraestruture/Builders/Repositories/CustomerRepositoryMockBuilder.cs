using AutoFixture;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhasTest.UnitsTests.Helper;
using JornadaMilhasTest.UnitsTests.Seeds;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Repositories;

public class CustomerRepositoryMockBuilder : BaseMockBuilder<ICustomerRepository>
{
    private readonly Fixture _fixture;

    private CustomerRepositoryMockBuilder(Fixture fixture)
    {
        _fixture = fixture;
    }

    public static CustomerRepositoryMockBuilder CreateBuilder(Fixture fixture) => new (fixture);
    
    public CustomerRepositoryMockBuilder AddGetByIdAsync(Customer userToReturn)
    {
        _mock.Setup(repository => repository.GetByIdAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(userToReturn);

        return this;
    }

    public CustomerRepositoryMockBuilder AddNotUniqueAsync(bool isExists)
    {
        _mock.Setup(repository =>
                repository.IsUniqueAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(isExists);

        return this;
    }

    public CustomerRepositoryMockBuilder WithGetAllCustomersAsync(int numberToCreate, int size = 10, int page = 1)
    {
        _mock.Setup(x => x.GetAllAsync(page, size, It.IsAny<CancellationToken>()))
            .ReturnsAsync(CustomerSeed.GetAllCustomersFakeData(_fixture, numberToCreate, page, size));
        return this;
    }

    public override Mock<ICustomerRepository> Build()
    {
        return _mock;
    }
}