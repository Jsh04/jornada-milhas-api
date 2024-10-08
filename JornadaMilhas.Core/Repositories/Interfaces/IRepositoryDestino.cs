
using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Core.Entities.Destinys;

namespace JornadaMilhas.Core.Repositories.Interfaces;

public interface IDestinyRepository : ICreatableRepository<Destiny>, IUpdatableRepository<Destiny>, IReadableRepository<Destiny>
{
}

