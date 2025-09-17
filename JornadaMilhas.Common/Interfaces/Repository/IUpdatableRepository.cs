using JornadaMilhas.Common.Entity;

namespace JornadaMilhas.Common.Interfaces.Repository;

public interface IUpdatableRepository<TEntity> where TEntity : BaseEntity
{
    bool Update(TEntity entity);
}