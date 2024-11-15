using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class DepoimentRepository : IDepoimentRepository
{
    private readonly JornadaMilhasDbContext _context;

    public DepoimentRepository(JornadaMilhasDbContext context) => _context = context;

    public async Task CreateAsync(Depoiment obj) => await _context.Depoimentos.AddAsync(obj);

    public Task<PaginationResult<Depoiment>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var depoiments = _context.Depoimentos.AsQueryable().Where(depoiment => !depoiment.IsDeleted);

        return  depoiments.ToPaginationResultAsync(page, pageSize, cancellationToken);
    }

    public async Task<Depoiment?> GetByIdAsync(long id, CancellationToken cancellation = default) => 
        await _context.Depoimentos
            .SingleOrDefaultAsync(depoiment => depoiment.Id == id, cancellation);

    public bool Update(Depoiment entity)
    {
        var updated = _context.Depoimentos.Update(entity);

        return updated.State == EntityState.Modified;
    }

    public Task<Depoiment> GetSingleByAsync(Expression<Func<Depoiment, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Depoiment> GetAllBy(Expression<Func<Depoiment, bool>> predicate) =>
        _context.Depoimentos.AsQueryable().Where(predicate);
}

