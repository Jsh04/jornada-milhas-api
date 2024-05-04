using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Core.Repositories;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository.UserRepository;

public class UserLimitedRepository : IUserLimitedRepository
{

    private readonly JornadaMilhasDbContext _context;

    public UserLimitedRepository(JornadaMilhasDbContext context) => _context = context;

    public void Create(UserLimited obj) => _context.UsersLimited.Add(obj);

    public PaginationResult<UserLimited> GetAll(int page, int size)
    {
        var usersLimited = _context.UsersLimited.AsQueryable();
        return usersLimited.ToPaginationResult(page, size);
    }

    public Task<UserLimited> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserLimited> GetUserByEmail(string email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsUniqueAsync(string cpf, string mail, CancellationToken cancellationToken = default)
    {
        var hasUser = await _context.UsersLimited.AnyAsync(user => user.Cpf.Number == cpf || user.Email.Address == mail);
        return hasUser;
    }

    public void Update(UserLimited obj)
    {
        throw new NotImplementedException();
    }
}