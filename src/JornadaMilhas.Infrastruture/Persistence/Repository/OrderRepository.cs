using JornadaMilhas.Core.Entities.Orders;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;

namespace JornadaMilhas.Infrastruture.Persistence.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly JornadaMilhasDbContext _context;

    public OrderRepository(JornadaMilhasDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Order entity)
    {
        await _context.AddAsync(entity);
    }
}