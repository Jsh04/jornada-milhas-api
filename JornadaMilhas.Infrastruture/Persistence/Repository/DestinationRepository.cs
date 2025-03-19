using System.Linq.Expressions;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Destinies;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class DestinationRepository : IDestinationRepository
{
    private readonly JornadaMilhasDbContext _context;

    public DestinationRepository(JornadaMilhasDbContext context)
    {
        _context = context;
    }
    
    public async Task<PaginationResult<Destination>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var result = _context.Destinations.AsQueryable()
            .Where(destination => !destination.IsDeleted);
        return await result.ToPaginationResultAsync(page, pageSize, cancellationToken);
    }

    public Task<Destination?> GetByIdAsync(long id, CancellationToken cancellation = default)
    {
        return _context.Destinations.FirstOrDefaultAsync(destination => destination.Id == id, cancellation);
    }

    public Task<Destination?> GetSingleByAsync(Expression<Func<Destination, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Destination> GetAllBy(Expression<Func<Destination, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}