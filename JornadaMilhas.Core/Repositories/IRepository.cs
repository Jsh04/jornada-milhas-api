using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Entities.Destinys;

namespace JornadaMilhas.Core.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    PaginationResult<TEntity> GetAll(int page, int size);
    void Create(TEntity obj);
    void Update(TEntity obj);
    Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken);
}
