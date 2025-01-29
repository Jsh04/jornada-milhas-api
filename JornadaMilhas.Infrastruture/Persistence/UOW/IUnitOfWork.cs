namespace JornadaMilhas.Infrastruture.Persistence.UOW;

public interface IUnitOfWork : IDisposable
{
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task<int> CompleteAsync(CancellationToken cancellationToken);
}