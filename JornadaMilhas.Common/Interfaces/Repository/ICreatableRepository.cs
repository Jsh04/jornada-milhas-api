using JornadaMilhas.Common.Entity;

namespace JornadaMilhas.Common.Interfaces.Repository;

public interface ICreatableRepository<TEntity> where TEntity : BaseEntity
{
    Task CreateAsync(TEntity entity);
}