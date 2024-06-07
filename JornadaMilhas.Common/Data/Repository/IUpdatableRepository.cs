using JornadaMilhas.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Common.Data.Repository;

public interface IUpdatableRepository<TEntity> where TEntity : BaseEntity
{
    bool Update(TEntity entity);
}
