using JornadaMilhas.Application.Commands.PassagesCommands.InputModels;
using JornadaMilhas.Application.Querys.Dtos.OrdersDto;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Passages;
using MediatR;

namespace JornadaMilhas.Application.Commands.PassagesCommands.PaidPassage;

public record PaidPassageCommand(long CustomerId, List<PaidPassageInputModel> PaidPassages) : IRequest<Result<OrderDto>>;

    
