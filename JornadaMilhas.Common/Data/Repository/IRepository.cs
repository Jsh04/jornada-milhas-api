using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.PaginationResult;


namespace JornadaMilhas.Common.Data.Repository;

public interface IRepository<TEntity> : 
    ICreatableRepository<TEntity>, 
    IUpdatableRepository<TEntity>,
    IReadableRepository<TEntity>,
    IDeletableRepository<TEntity> where TEntity : BaseEntity
{
}
