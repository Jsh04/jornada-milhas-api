using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Passages.Enums;
using JornadaMilhas.Core.Entities.Users;

namespace JornadaMilhas.Core.Entities.Passages;

public class Passage : BaseEntity
{
    public EnumTypeSeat EnumTypeSeat { get; private set; }

    public int SeatNumber { get; }
 
    public decimal Price { get; }

    public virtual Flight Flight { get; }

    public long FlightId { get; }

    private Passage(PassageBuilder builder)
    {

    }

    internal static Passage Create(PassageBuilder passageBuilder)
    {
        throw new NotImplementedException();
    }
}