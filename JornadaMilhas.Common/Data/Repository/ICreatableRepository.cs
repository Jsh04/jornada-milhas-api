using JornadaMilhas.Common.Entity;

namespace JornadaMilhas.Common.Data.Repository
{
    public interface ICreatableRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity entity);
    }
}
