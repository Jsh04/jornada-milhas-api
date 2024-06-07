
using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class RepositoryDestino : IRepositoryDestino
{
    private readonly JornadaMilhasDbContext _context;

    public RepositoryDestino(JornadaMilhasDbContext context) => _context = context;

    public void Create(Destiny destino) => _context.Destinos.Add(destino);
    
    public Task<PaginationResult<Destiny>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var destinys = _context.Destinos.AsQueryable()
            .Where(destiny => !destiny.IsDeleted).Include(destiny => destiny.Imagens);
        return destinys.ToPaginationResultAsync(page, pageSize, cancellationToken);
    }

    public async Task<Destiny> GetByIdAsync(long id, CancellationToken cancellationToken = default) => 
        await _context.Destinos
            .Include(destiny => destiny.Imagens)
            .SingleOrDefaultAsync(destiny => destiny.Id == id, cancellationToken);


    public bool Update(Destiny obj)
    {
        var updted = _context.Destinos.Update(obj);

        return updted.State == EntityState.Modified;
    }

   
}

