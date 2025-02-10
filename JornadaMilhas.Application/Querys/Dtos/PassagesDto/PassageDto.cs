using JornadaMilhas.Core.Entities.Passages.Enums;

namespace JornadaMilhas.Application.Querys.Dtos.PassagesDto;

public record PassageDto(EnumTypeSeat TypeSeat, EnumTypeClassPlane TypeClass, int SeatNumber, decimal Value);
