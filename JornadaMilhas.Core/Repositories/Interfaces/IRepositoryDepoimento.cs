using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Core.Entities.Depoiments;

namespace JornadaMilhas.Core.Repositories.Interfaces;

public interface IDepoimentRepository : ICreatableRepository<Depoiment>, IReadableRepository<Depoiment>, IUpdatableRepository<Depoiment>
{ }

