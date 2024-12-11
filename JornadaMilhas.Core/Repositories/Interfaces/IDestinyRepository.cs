using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Core.ValueObjects.Locales;

namespace JornadaMilhas.Core.Repositories.Interfaces;

public interface IDestinyRepository : ICreatableRepository<Locale>, IUpdatableRepository<Locale>,
    IReadableRepository<Locale>
{
}