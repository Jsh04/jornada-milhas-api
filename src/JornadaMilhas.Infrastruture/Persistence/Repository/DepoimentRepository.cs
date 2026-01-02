using System.Linq.Expressions;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Extensions;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class DepoimentRepository : IDepoimentRepository
{
    private readonly JornadaMilhasDbContext _context;

    public DepoimentRepository(JornadaMilhasDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Depoiment obj)
    {
        await _context.Testimonials.AddAsync(obj);
    }

    public Task<PaginationResult<Depoiment>> GetAllAsync(int page = 1, int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var depoiments = _context.Testimonials.AsQueryable().Where(depoiment => !depoiment.IsDeleted);

        return depoiments.ToPaginationResultAsync(page, pageSize, cancellationToken);
    }

    public async Task<Depoiment?> GetByIdAsync(long id, CancellationToken cancellation = default)
    {
        return await _context.Testimonials
            .SingleOrDefaultAsync(depoiment => depoiment.Id == id, cancellation);
    }

    public bool Update(Depoiment entity)
    {
        var updated = _context.Testimonials.Update(entity);

        return updated.State == EntityState.Modified;
    }

    public Task<Depoiment?> GetSingleByAsync(Expression<Func<Depoiment, bool>> expression,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Depoiment> GetAllBy(Expression<Func<Depoiment, bool>> predicate)
    {
        return _context.Testimonials.AsQueryable().Where(predicate);
    }
}