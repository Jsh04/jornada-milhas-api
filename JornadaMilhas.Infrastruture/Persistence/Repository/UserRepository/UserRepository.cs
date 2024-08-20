using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JornadaMilhas.Infrastruture.Persistence.Repository.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly JornadaMilhasDbContext _context;

    public UserRepository(JornadaMilhasDbContext context) => _context = context;

    public bool Delete(User entity)
    {
        var objUpdated = _context.Update(entity);
        return objUpdated.State == EntityState.Modified;
    }

    public Task<PaginationResult<User>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<User> GetAllBy(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default) => 
        await _context.Users.SingleOrDefaultAsync(user => user.Email.Address.Equals(email), cancellationToken);

    public Task<User?> GetByIdAsync(long id, CancellationToken cancellation = default) => _context.Users.SingleOrDefaultAsync(user => user.Id == id,cancellation);
        
    public async Task<User?> GetSingleByAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken = default) =>
        await _context.Users.SingleOrDefaultAsync(predicate, cancellationToken);
}
