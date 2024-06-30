using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Repositories;
using JornadaMilhas.Core.Repositories.Interfaces;

namespace JornadaMilhas.Infrastruture.Persistence.UOW;

public interface IUnitOfWork : IDisposable
{
    IRepositoryDestino DestinoRepository { get; init; }
    IUserLimitedRepository UserLimitedRepository { get; init; }
    IDepoimentRepository DepoimentRepository { get; init; }
    IUserRepository UserRepository { get; init; }
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task<int> CompleteAsync(CancellationToken cancellationToken);

}
