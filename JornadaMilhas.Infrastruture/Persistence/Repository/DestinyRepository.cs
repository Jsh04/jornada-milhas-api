using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Destinys;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class DestinyRepository : IDestinyRepository
{
    private readonly JornadaMilhasDbContext _context;

    public DestinyRepository(JornadaMilhasDbContext context) => _context = context;

    public async Task CreateAsync(Destiny destino) => await _context.Destinos.AddAsync(destino);
    
    public Task<PaginationResult<Destiny>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var destinys = _context.Destinos.AsQueryable()
            .Where(destiny => !destiny.IsDeleted).Include(destiny => destiny.Imagens);
        return destinys.ToPaginationResultAsync(page, pageSize, cancellationToken);
    }

    public IQueryable<Destiny> GetAllBy(Expression<Func<Destiny, bool>> predicate)
    {
        return _context.Destinos.AsQueryable().Where(predicate);
    }

    public async Task<Destiny> GetByIdAsync(long id, CancellationToken cancellationToken = default) => 
        await _context.Destinos
            .Include(destiny => destiny.Imagens)
            .SingleOrDefaultAsync(destiny => destiny.Id == id, cancellationToken);

    public Task<Destiny> GetSingleByAsync(Expression<Func<Destiny, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public bool Update(Destiny obj)
    {
        var updted = _context.Destinos.Update(obj);

        return updted.State is EntityState.Modified;
    }

   
}

