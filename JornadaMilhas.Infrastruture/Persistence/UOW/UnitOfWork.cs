


using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using Microsoft.EntityFrameworkCore.Storage;

namespace JornadaMilhas.Infrastruture.Persistence.UOW;

public class UnitOfWork : IUnitOfWork
{

    private IDbContextTransaction _transaction;

    public IRepositoryDestino DestinoRepository { get; init; }

    public IDepoimentRepository DepoimentRepository { get; init; }

    public IUserRepository UserRepository { get; init; }
    public IUserLimitedRepository UserLimitedRepository { get; init; }

    private readonly JornadaMilhasDbContext _context;

    public UnitOfWork(
        IUserLimitedRepository userLimitedRepository, 
        IRepositoryDestino destinoRepository,
        IDepoimentRepository depoimentRepository,
        IUserRepository userRepository,
        JornadaMilhasDbContext context
        )
    {
        UserLimitedRepository = userLimitedRepository;
        DestinoRepository = destinoRepository;
        DepoimentRepository = depoimentRepository;
        UserRepository = userRepository;
        _context = context;
    }


    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default) => _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);


    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if(disposing) _context.Dispose();
    }
}
