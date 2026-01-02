using System.Linq.Expressions;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Repositories.Interfaces;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class CustomerRepositoryMongoDb : ICustomerRepository
{
    public Task<PaginationResult<Customer>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> GetByIdAsync(long id, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> GetSingleByAsync(Expression<Func<Customer, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Customer> GetAllBy(Expression<Func<Customer, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(Customer entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Customer entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsUniqueAsync(string email, string cpf, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}