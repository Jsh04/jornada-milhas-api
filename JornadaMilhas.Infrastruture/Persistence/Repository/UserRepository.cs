using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Repositories;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class UserRepository 
{

    private readonly JornadaMilhasDbContext _context;

    public UserRepository(JornadaMilhasDbContext context) => _context = context;
    

   
    
    public async Task<IEnumerable<User>> GetAllAsync(int page, int size, CancellationToken cancellationToken)
    {
        return await _context.Users.Skip(page).Take(size).Where(usuario => !usuario.IsDeleted).ToListAsync(cancellationToken);
    }

   

    public async Task<bool> IsUniqueAsync(string cpf, string mail, CancellationToken cancellationToken = default)
    {
        var hasUser = await _context.Users.AnyAsync(user => user.Cpf.Number == cpf || user.Email == mail);
        return hasUser;
    }

   

    
}