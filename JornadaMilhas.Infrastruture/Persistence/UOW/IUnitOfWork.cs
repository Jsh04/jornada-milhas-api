using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Indices;
using JornadaMilhas.Core.Repositories;
using JornadaMilhas.Core.Repositories.Interfaces;

namespace JornadaMilhas.Infrastruture.Persistence.UOW;

public interface IUnitOfWork : IDisposable
{
    IRepositoryDestino DestinoRepository { get; }
    IRepositoryDepoimento DepoimentoRepository { get; }
    IRepositoryUsuario UserRepository { get; }

    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task<int> CompleteAsync(CancellationToken cancellationToken);

}
