using System.Linq.Expressions;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Core.ValueObjects.Locales;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class DestinyRepository : IDestinyRepository
{
    private readonly JornadaMilhasDbContext _context;

    public DestinyRepository(JornadaMilhasDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Locale destino)
    {
        await _context.Destinos.AddAsync(destino);
    }

    public Task<PaginationResult<Locale>> GetAllAsync(int page = 1, int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var destinies = _context.Destinos.AsQueryable()
            .Where(destiny => !destiny.IsDeleted).Include(destiny => destiny.Pictures);
        return destinies.ToPaginationResultAsync(page, pageSize, cancellationToken);
    }

    public IQueryable<Locale> GetAllBy(Expression<Func<Locale, bool>> predicate)
    {
        return _context.Destinos.AsQueryable().Where(predicate);
    }

    public async Task<Locale> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _context.Destinos
            .Include(destiny => destiny.Pictures)
            .SingleOrDefaultAsync(destiny => destiny.Id == id, cancellationToken);
    }

    public Task<Locale> GetSingleByAsync(Expression<Func<Locale, bool>> expression,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public bool Update(Locale obj)
    {
        var updted = _context.Destinos.Update(obj);

        return updted.State is EntityState.Modified;
    }
}