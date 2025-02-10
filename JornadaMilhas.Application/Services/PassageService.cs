using JornadaMilhas.Application.Commands.PassagesCommands.InputModels;
using JornadaMilhas.Application.Commands.PassagesCommands.PaidPassage;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.Dtos.OrdersDto;
using JornadaMilhas.Common.Results;
using MediatR;

namespace JornadaMilhas.Application.Services;

public class PassageService : IPassageService
{
    private readonly ISender _mediator;

    public PassageService(ISender mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<Result<CreateOrderDto>> PayPassagesAsync(long customerId, List<PaidPassageInputModel> passageInputModels)
    {
        var payPassagesCommands = new PaidPassageCommand(customerId, passageInputModels);
        return await _mediator.Send(payPassagesCommands);
    }
}