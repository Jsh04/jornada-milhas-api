using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class RepositoryDestino : IRepositoryDestino
{
    private readonly JornadaMilhasDbContext _context;

    public RepositoryDestino(JornadaMilhasDbContext context) => _context = context;


    public async Task<Destino> Create(Destino destino)
    {
        var destinoCreated = await _context.Destinos.AddAsync(destino);
        return destinoCreated.Entity;
    }

    public async Task<bool> Delete(long id)
    {
        var destino = await _context.Destinos.FirstOrDefaultAsync(usuario => usuario.Id == id);
        if (destino == null)
            return false;

        destino.IsDeleted = true;

        _context.Destinos.Update(destino);

        return true;

    }

    public async Task<IEnumerable<Destino>> GetAllAsync(int page, int size)
    {
        return await _context.Destinos.Skip(page).Take(size).Where(usuario => !usuario.IsDeleted).ToListAsync();
    }

    public async Task<Destino> GetById(long id)
    {
        var destino = await _context.Destinos.FirstOrDefaultAsync(d => d.Id == id);
        return destino ?? throw new NullReferenceException("Destino não encontrado");

    }

    public async Task<bool> Update(Destino obj, long id)
    {
        var destino = await GetById(id);
        obj.Id = destino.Id;

        var destinoUpdated = _context.Destinos.Update(obj);

        return true;

    }
}

