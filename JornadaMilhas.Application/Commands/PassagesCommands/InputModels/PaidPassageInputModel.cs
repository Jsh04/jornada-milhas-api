using JornadaMilhas.Core.Entities.Passages.Enums;

namespace JornadaMilhas.Application.Commands.PassagesCommands.InputModels;

public class PaidPassageInputModel
{
    public EnumTypeSeat TypeSeat { get; set; }

    public int  SeatNumber { get; set; }

    public EnumTypeClassPlane  TypeClassPlane  { get; set; }

    public long FlightId { get; set; }
}