using JornadaMilhas.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.Data.Repository
{
    public interface IReadableByRepositoty<TEntity>  where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<TEntity?> GetSingleByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
