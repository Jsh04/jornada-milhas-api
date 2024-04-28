
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class RepositoryDestino : IRepositoryDestino
{
    private readonly JornadaMilhasDbContext _context;

    public RepositoryDestino(JornadaMilhasDbContext context) => _context = context;

    public void Create(Destiny destino) => _context.Destinos.Add(destino);
    

    public PaginationResult<Destiny> GetAll(int page, int size)
    {
        var destinys = _context.Destinos.AsQueryable();
        return destinys.ToPaginationResult(page, size);
    }

    public async Task<Destiny> GetByIdAsync(long id, CancellationToken cancellationToken = default) => 
        await _context.Destinos
            .Include(destiny => destiny.Imagens)
            .SingleOrDefaultAsync(destiny => destiny.Id == id, cancellationToken);
    

    public void Update(Destiny obj) => _context.Destinos.Update(obj);

}

