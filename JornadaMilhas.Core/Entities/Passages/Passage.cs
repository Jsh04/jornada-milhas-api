using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Users;

namespace JornadaMilhas.Core.Entities.Passages;

public class Passage : BaseEntity
{
    public User User { get; }

    public int SeatNumber { get; }

    public decimal Price { get; }

    public Flight Flight { get; }

    public long FlightId { get; }
}