using System.Linq.Expressions;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly JornadaMilhasDbContext _context;

    public UserRepository(JornadaMilhasDbContext context)
    {
        _context = context;
    }

    public bool Delete(User entity)
    {
        var objUpdated = _context.Update(entity);
        return objUpdated.State == EntityState.Modified;
    }
    
    public async Task<User?> GetByEmailOrCpfAsync(string emailOrCpf, CancellationToken cancellationToken = default)
    {
        return await _context.Users.SingleOrDefaultAsync(user => user.Email.Address.Equals(emailOrCpf) || user.Cpf.Number.Equals(emailOrCpf), cancellationToken);
    }
    
}