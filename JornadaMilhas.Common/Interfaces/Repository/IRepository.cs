using JornadaMilhas.Common.Entity;

namespace JornadaMilhas.Common.Interfaces.Repository;

public interface IRepository<TEntity> :
    ICreatableRepository<TEntity>,
    IUpdatableRepository<TEntity>,
    IReadableRepository<TEntity>,
    IDeletableRepository<TEntity> where TEntity : BaseEntity
{
}