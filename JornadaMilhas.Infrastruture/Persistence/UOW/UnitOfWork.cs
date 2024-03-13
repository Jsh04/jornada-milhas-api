


using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.Context;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using Microsoft.EntityFrameworkCore.Storage;

namespace JornadaMilhas.Infrastruture.Persistence.UOW;

public class UnitOfWork : IUnitOfWork
{

    private IDbContextTransaction _transaction;

    public IRepositoryDestino DestinoRepository { get; set; }

    public IRepositoryDepoimento DepoimentoRepository { get; set; }

    public IRepositoryUsuario UsuarioRepository { get; set; }

    private readonly JornadaMilhasDbContext _context;

    public UnitOfWork(
        IRepositoryUsuario usuarioRepository, 
        IRepositoryDestino destinoRepository, 
        IRepositoryDepoimento depoimentoRepository, 
        JornadaMilhasDbContext context
        )
    {
        UsuarioRepository = usuarioRepository;
        DestinoRepository = destinoRepository;
        DepoimentoRepository = depoimentoRepository;
        _context = context;
    }


    public async Task BeginTransactionAsync() => _transaction = await _context.Database.BeginTransactionAsync();


    public async Task CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch (Exception)
        {
            await _transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
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
