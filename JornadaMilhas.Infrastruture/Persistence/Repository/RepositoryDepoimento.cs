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

public class RepositoryDepoimento : IRepositoryDepoimento
{
    private readonly JornadaMilhasDbContext _context;

    public RepositoryDepoimento(JornadaMilhasDbContext context) => _context = context;


    public async Task<Depoimento> CreateAsync(Depoimento depoimento, CancellationToken cancellationToken = default)
    {
        var depoimentoCreated = await _context.Depoimentos.AddAsync(depoimento);
        return depoimentoCreated.Entity;
    }

    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var destino = await _context.Destinos.FirstOrDefaultAsync(usuario => usuario.Id == id, cancellationToken);
        if (destino == null)
            return false;

        destino.IsDeleted = true;

        _context.Destinos.Update(destino);

        return true;

    }

    public async Task<IEnumerable<Depoimento>> GetAllAsync(int page, int size, CancellationToken cancellationToken)
    {
        return await _context.Depoimentos.Skip(page).Take(size).Where(depoimento => !depoimento.IsDeleted).ToListAsync(cancellationToken);
    }

    public async Task<Depoimento> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var depoimento = await _context.Depoimentos.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        return depoimento ?? throw new NullReferenceException("Depoimento não encontrado");

    }

    public async Task<bool> Update(Depoimento obj, long id, CancellationToken cancellationToken = default)
    {
        var depoimento = await GetByIdAsync(id, cancellationToken);
        obj.Id = depoimento.Id;

        var depoimentoUpdated = _context.Depoimentos.Update(obj);

        return true;

    }
}

