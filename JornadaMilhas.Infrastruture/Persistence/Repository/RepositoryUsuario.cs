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
    

    public async Task<Usuario> Create(Usuario usuario)
    {
        var usuarioCreated = await _context.Usuarios.AddAsync(usuario);
        return usuarioCreated.Entity;
    }

    public async Task<bool> Delete(long id)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);
        if (usuario == null)
            return false;

        usuario.IsDeleted = true;

        _context.Usuarios.Update(usuario);

        return true;

    }

    public async Task<IEnumerable<Usuario>> GetAllAsync(int page, int size)
    {
        return await _context.Usuarios.Skip(page).Take(size).Where(usuario => !usuario.IsDeleted).ToListAsync();
    }

    public async Task<Usuario> GetById(long id)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);
        return usuario ?? throw new NullReferenceException("Usuário não encontrado");
         
    }

    public async Task<Usuario> GetUserByEmail(string email)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Email.Equals(email));
        return usuario ?? throw new NullReferenceException("Usuário não encontrado");
    }

    public async Task<bool> Update(Usuario obj, long id)
    {
        var usuario = await GetById(id);
        obj.Id = usuario.Id;

        var usuarioUpdated = _context.Usuarios.Update(obj);

        if (usuarioUpdated.Entity != null)
            return true;
        return false;

    }
}