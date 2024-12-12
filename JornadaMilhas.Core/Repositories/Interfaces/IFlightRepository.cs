using JornadaMilhas.Common.Data.Repository;
using JornadaMilhas.Core.Entities.Flights;

namespace JornadaMilhas.Core.Repositories.Interfaces;

public interface IFlightRepository : ICreatableRepository<Flight>, IUpdatableRepository<Flight>,
    IReadableRepository<Flight>
{
}