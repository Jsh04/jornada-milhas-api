
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository.UserRepository;

public class UserLimitedRepository : IUserLimitedRepository
{
    private readonly JornadaMilhasDbContext _context;

    public UserLimitedRepository(JornadaMilhasDbContext context) => _context = context;

    public void Create(UserLimited obj) => _context.UsersLimited.Add(obj);

    public Task<PaginationResult<UserLimited>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<UserLimited?> GetByIdAsync(long id, CancellationToken cancellation = default) => await _context.UsersLimited.SingleOrDefaultAsync(user => user.Id == id, cancellation);
    

    public async Task<UserLimited?> GetUserByEmail(string email, CancellationToken cancellationToken = default)
    {
        var user = await _context.UsersLimited.SingleOrDefaultAsync(user => user.Email.Address == email, cancellationToken);
        return user;
    }

    public async Task<bool> IsUniqueAsync(string cpf, string mail, CancellationToken cancellationToken = default)
    {
        var hasUser = await _context.UsersLimited.AnyAsync(user => user.Email.Address == mail || user.Cpf.Number == cpf, cancellationToken);

        return hasUser;
    }

    public bool Update(UserLimited entity)
    {
        var result = _context.UsersLimited.Update(entity);

        return result.State == EntityState.Modified;
    }
}