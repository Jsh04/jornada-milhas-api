using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Core.Entities.Depoiments;

namespace JornadaMilhas.Core.Repositories.Interfaces;

public interface IDepoimentRepository : ICreatableRepository<Depoiment>, IReadableRepository<Depoiment>, IUpdatableRepository<Depoiment>
{ }

