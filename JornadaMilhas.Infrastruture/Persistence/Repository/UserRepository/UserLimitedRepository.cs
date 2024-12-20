﻿
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JornadaMilhas.Infrastruture.Persistence.Repository.UserRepository;

public class UserLimitedRepository : IUserLimitedRepository
{
    private readonly JornadaMilhasDbContext _context;

    public UserLimitedRepository(JornadaMilhasDbContext context) => _context = context;

    public async Task CreateAsync(UserLimited obj) => await _context.UsersLimited.AddAsync(obj);

    public Task<PaginationResult<UserLimited>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var query = _context.UsersLimited.AsQueryable();

        return query.ToPaginationResultAsync(page, pageSize, cancellationToken);
    }

    public IQueryable<UserLimited> GetAllBy(Expression<Func<UserLimited, bool>> predicate)
    {
        var resultQueryUsers = _context.UsersLimited.AsQueryable().Where(predicate);
        return resultQueryUsers;
    }

    public async Task<UserLimited?> GetByIdAsync(long id, CancellationToken cancellation = default) => 
        await _context.UsersLimited.SingleOrDefaultAsync(user => user.Id == id, cancellation);

    public Task<UserLimited> GetSingleByAsync(Expression<Func<UserLimited, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
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