using System.Linq.Expressions;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly JornadaMilhasDbContext _context;

    public CustomerRepository(JornadaMilhasDbContext context)
    {
        _context = context;
    }
    
    public Task<PaginationResult<Customer>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Customer?> GetByIdAsync(long id, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> GetSingleByAsync(Expression<Func<Customer, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Customer> GetAllBy(Expression<Func<Customer, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(Customer entity)
    {
        await _context.Customers.AddAsync(entity);
    }

    public bool Update(Customer entity)
    {
        var result = _context.Customers.Update(entity);

        return result.State == EntityState.Modified;
    }

    public bool Delete(Customer entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsUniqueAsync(string email, string cpf, CancellationToken cancellationToken)
    {
        return await _context.Customers.AnyAsync(customer => customer.Email.Address == email || customer.Cpf.Number == cpf, cancellationToken);
    }
}