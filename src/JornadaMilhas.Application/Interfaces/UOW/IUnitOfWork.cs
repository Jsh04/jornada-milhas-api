namespace JornadaMilhas.Application.Interfaces.UOW;

public interface IUnitOfWork : IDisposable
{
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task<int> CompleteAsync(CancellationToken cancellationToken);
}