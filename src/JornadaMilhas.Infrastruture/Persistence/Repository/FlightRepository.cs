using System.Linq.Expressions;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Core.ValueObjects.Locales;
using JornadaMilhas.Infrastruture.Extensions;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class FlightRepository : IFlightRepository
{
    private readonly JornadaMilhasDbContext _context;

    public FlightRepository(JornadaMilhasDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Flight destino)
    {
        await _context.Flights.AddAsync(destino);
    }

    public Task<PaginationResult<Flight>> GetAllAsync(int page = 1, int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var destinies = _context.Flights.AsQueryable()
            .Where(flight => !flight.IsDeleted);
        return destinies.ToPaginationResultAsync(page, pageSize, cancellationToken);
    }

    public IQueryable<Flight> GetAllBy(Expression<Func<Flight, bool>> predicate)
    {
        return _context.Flights.AsQueryable().Where(predicate);
    }

    public async Task<Flight?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _context.Flights
            .SingleOrDefaultAsync(flight => flight.Id == id, cancellationToken);
    }

    public async Task<Flight?> GetSingleByAsync(Expression<Func<Flight, bool>> expression,
        CancellationToken cancellationToken = default)
    {
        return await _context.Flights.AsQueryable().SingleOrDefaultAsync(expression, cancellationToken);
    }

    public bool Update(Flight obj)
    {
        var updted = _context.Flights.Update(obj);

        return updted.State is EntityState.Modified;
    }
}