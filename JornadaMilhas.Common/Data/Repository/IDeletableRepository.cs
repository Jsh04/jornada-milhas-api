using JornadaMilhas.Common.Entity;

namespace JornadaMilhas.Common.Data.Repository;

public interface IDeletableRepository<TEntity> where TEntity : BaseEntity
{
    bool Delete(TEntity entity);
}
