using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Passages.Enums;
using JornadaMilhas.Core.Entities.Users;

namespace JornadaMilhas.Core.Entities.Passages;

public class Passage : BaseEntity
{
    public decimal Value { get; private set; }

    public EnumTypeSeat EnumTypeSeat { get; private set; }

    public int SeatNumber { get; private set; }

    public EnumTypeClassPlane EnumTypeClass { get; private set; }

    public virtual Flight Flight { get; }

    public long FlightId { get; }

    private Passage(PassageBuilder builder)
    {
        EnumTypeClass = builder.TypeClassPlane;
        EnumTypeSeat = builder.TypeSeat;
        SeatNumber = builder.SeatNumber;
    }

    private Passage()
    {
    }

    public void SetValuePassage(decimal value)
    {
        Value = value;
    }

    public static Passage Create(PassageBuilder passageBuilder)
    {
        return new Passage(passageBuilder);
    }
}