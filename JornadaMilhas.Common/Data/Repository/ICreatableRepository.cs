using JornadaMilhas.Common.Entity;

namespace JornadaMilhas.Common.Data.Repository
{
    public interface ICreatableRepository<TEntity> where TEntity : BaseEntity
    {
        Task CreateAsync(TEntity entity);
    }
}
