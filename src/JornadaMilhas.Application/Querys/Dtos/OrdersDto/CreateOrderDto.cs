using JornadaMilhas.Application.Querys.Dtos.PassagesDto;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Passages;

namespace JornadaMilhas.Application.Querys.Dtos.OrdersDto;

public record CreateOrderDto(IEnumerable<PassageDto> Passages, decimal TotalValue, DateTime TimeStamp);
