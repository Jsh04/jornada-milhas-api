using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.PaginationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.Data.Repository;

//Exemplos de I do SOLID
public interface IReadableRepository<TEntity> where TEntity : BaseEntity
{
    Task<PaginationResult<TEntity>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default);

    Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellation = default);

    Task<TEntity> GetSingleByAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);

    IQueryable<TEntity> GetAllBy(Expression<Func<TEntity, bool>> predicate);
}
