using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Repositories;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class RepositoryUsuario : IRepositoryUsuario
{

    private readonly JornadaMilhasDbContext _context;

    public RepositoryUsuario(JornadaMilhasDbContext context) => _context = context;
    

    public async Task<Usuario> CreateAsync(Usuario usuario, CancellationToken cancellationToken)
    {
        var usuarioCreated = await _context.Usuarios.AddAsync(usuario, cancellationToken);
        return usuarioCreated.Entity;
    }

    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id, cancellationToken);

        if (usuario is null)
            return false;

        usuario.IsDeleted = true;

        _context.Usuarios.Update(usuario);

        return true;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync(int page, int size, CancellationToken cancellationToken)
    {
        return await _context.Usuarios.Skip(page).Take(size).Where(usuario => !usuario.IsDeleted).ToListAsync(cancellationToken);
    }

    public async Task<Usuario> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id, cancellationToken);
        return usuario ?? throw new NullReferenceException("Usuário não encontrado");
    }

    public async Task<Usuario> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email.Equals(email), cancellationToken);
        return usuario ?? throw new NullReferenceException("Usuário não encontrado");
    }

    public async Task<bool> Update(Usuario obj, long id, CancellationToken cancellationToken = default)
    {
        var usuario = await GetByIdAsync(id, cancellationToken);
        obj.Id = usuario.Id;

        var usuarioUpdated = _context.Usuarios.Update(obj);

        return usuarioUpdated.Entity is not null;

    }
}