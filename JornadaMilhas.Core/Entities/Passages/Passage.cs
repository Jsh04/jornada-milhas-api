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

    public EnumTypeClassPlane EnumTypeClass { get; private set; }

    public virtual Flight Flight { get; }

    public long FlightId { get; }

    private Passage(PassageBuilder builder)
    {
        EnumTypeClass = builder.TypeClassPlane;
    }
    private Passage(){}
    

    public static Passage Create(PassageBuilder passageBuilder)
    {
        return new Passage(passageBuilder);
    }
}