
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Depoiments;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class DepoimentRepository : IDepoimentRepository
{
    private readonly JornadaMilhasDbContext _context;

    public DepoimentRepository(JornadaMilhasDbContext context) => _context = context;

    public void Create(Depoiment obj) => _context.Depoimentos.Add(obj);

    public Task<PaginationResult<Depoiment>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var depoiments = _context.Depoimentos.AsQueryable();
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


}

