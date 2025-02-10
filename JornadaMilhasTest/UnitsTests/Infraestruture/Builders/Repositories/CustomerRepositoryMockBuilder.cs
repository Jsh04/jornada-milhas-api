using AutoFixture;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhasTest.UnitsTests.Builders;
using JornadaMilhasTest.UnitsTests.Helper;
using JornadaMilhasTest.UnitsTests.Seeds;
using Moq;

namespace JornadaMilhasTest.UnitsTests.Infraestruture.Builders.Repositories;

public class CustomerRepositoryMockBuilder : BaseMockBuilder<ICustomerRepository>
{
    private IQueryable<Customer> _customers;

    private CustomerRepositoryMockBuilder(IQueryable<Customer> customers)
    {
        _customers = customers;
    }

    public static CustomerRepositoryMockBuilder CreateBuilder(IQueryable<Customer> customers) => new(customers);
    
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

    public CustomerRepositoryMockBuilder WithGetAllCustomersAsync(int page, int size)
    {
        var paginationResult = GetPaginationResultObject(page, size);
        _mock.Setup(x => x.GetAllAsync(page, size, It.IsAny<CancellationToken>()))
            .ReturnsAsync(paginationResult);
        return this;
    }

    private PaginationResult<Customer> GetPaginationResultObject(int page, int size)
    {
        var customerList = _customers.Skip((page - 1) * size).Take(size).ToList();
        var pagination = new PaginationResult<Customer>(page, size, customerList.Count);
        pagination.SetData(customerList);
        return pagination;
    }

    public override Mock<ICustomerRepository> Build()
    {
        return _mock;
    }
}