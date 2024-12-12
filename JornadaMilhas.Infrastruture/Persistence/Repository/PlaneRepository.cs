using System.Linq.Expressions;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Planes;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class PlaneRepository : IPlaneRepository
{
    private readonly JornadaMilhasDbContext _context;

    public PlaneRepository(JornadaMilhasDbContext context)
    {
        _context = context;
    }
    public Task<PaginationResult<Plane>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Plane?> GetByIdAsync(long id, CancellationToken cancellation = default)
    {
        return await _context.Planes.SingleOrDefaultAsync(flight => flight.Id == id, cancellation);
    }

    public Task<Plane> GetSingleByAsync(Expression<Func<Plane, bool>> expression, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Plane> GetAllBy(Expression<Func<Plane, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}