using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Repositories;
using JornadaMilhas.Core.Repositories.Interfaces;

namespace JornadaMilhas.Infrastruture.Persistence.UOW;

public interface IUnitOfWork : IDisposable
{
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task<int> CompleteAsync(CancellationToken cancellationToken);

}
