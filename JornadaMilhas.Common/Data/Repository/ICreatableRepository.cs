using JornadaMilhas.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.Data.Repository
{
    public interface ICreatableRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity entity);
    }
}
