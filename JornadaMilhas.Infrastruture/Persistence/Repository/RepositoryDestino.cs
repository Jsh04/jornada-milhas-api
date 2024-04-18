
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class RepositoryDestino : IRepositoryDestino
{
    private readonly JornadaMilhasDbContext _context;

    public RepositoryDestino(JornadaMilhasDbContext context) => _context = context;


    public async Task<Destiny> CreateAsync(Destiny destino, CancellationToken cancellationToken)
    {
        var destinoCreated = await _context.Destinos.AddAsync(destino, cancellationToken);
        return destinoCreated.Entity;
    }

    public async Task<bool> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        var destino = await _context.Destinos.FirstOrDefaultAsync(usuario => usuario.Id == id, cancellationToken);
        if (destino == null)
            return false;

        destino.IsDeleted = true;

        _context.Destinos.Update(destino);

        return true;

    }

    public async Task<IEnumerable<Destiny>> GetAllAsync(int page, int size, CancellationToken cancellationToken = default)
    {
        return await _context.Destinos.Skip(page).Take(size).Where(destiny => !destiny.IsDeleted).ToListAsync(cancellationToken);
    }

    public async Task<Destiny> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        var destino = await _context.Destinos.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        return destino ?? throw new NullReferenceException("Destino não encontrado");

    }

    public async Task<bool> Update(Destiny obj, long id, CancellationToken cancellationToken = default)
    {
        var destino = await GetByIdAsync(id, cancellationToken);
        obj.Id = destino.Id;

        var destinoUpdated = _context.Destinos.Update(obj);

        return true;

    }
}

