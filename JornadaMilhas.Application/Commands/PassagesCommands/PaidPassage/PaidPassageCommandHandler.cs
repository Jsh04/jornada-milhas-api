using JornadaMilhas.Application.Interfaces.UOW;
using JornadaMilhas.Application.Querys.Dtos.OrdersDto;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Orders;
using JornadaMilhas.Core.Entities.Passages;
using JornadaMilhas.Core.Repositories.Interfaces;
using MediatR;

namespace JornadaMilhas.Application.Commands.PassagesCommands.PaidPassage;

public class PaidPassageCommandHandler : IRequestHandler<PaidPassageCommand, Result<OrderDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFlightRepository _flightRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IPassageRepository _passageRepository;
    private readonly IOrderRepository _orderRepository;

    public PaidPassageCommandHandler(
        IUnitOfWork unitOfWork, 
        IFlightRepository flightRepository,
        ICustomerRepository customerRepository, 
        IPassageRepository passageRepository, 
        IOrderRepository orderRepository)
    {
        _unitOfWork = unitOfWork;
        _flightRepository = flightRepository;
        _customerRepository = customerRepository;
        _passageRepository = passageRepository;
        _orderRepository = orderRepository;
    }

    public async Task<Result<OrderDto>> Handle(PaidPassageCommand request, CancellationToken cancellationToken)
    {
        if (request.CustomerId == 0)
            return Result.Fail<OrderDto>(CustomerErrors.CustomerUnauthenticated);

        var customer = await _customerRepository.GetByIdAsync(request.CustomerId, cancellationToken);
        
        if (customer is null)
            return Result.Fail<OrderDto>(CustomerErrors.CustomerNotFound);

        var passagesCreated = await CreatePassagesFromRequest(request, cancellationToken);

        if (!passagesCreated.Success)
            return Result.Fail<OrderDto>(passagesCreated.Errors);
        
        var order = new Order(passagesCreated.Value);
        
        return Result.Ok<OrderDto>(default);
    }

    private async Task<Result<List<Passage>>> CreatePassagesFromRequest(PaidPassageCommand request, CancellationToken cancellationToken = default)
    {
        List<IError> listErrors = new(request.PaidPassages.Count);
        foreach (var passageInputModel in request.PaidPassages)
        {
            var flight = await _flightRepository.GetByIdAsync(passageInputModel.FlightId, cancellationToken);

            if (flight is null)
                listErrors.Add(FlightErrors.NotFound);

            var passageCreate = PassageBuilder.Create()
                .WithEnumTypePassage(passageInputModel.TypeClassPlane)
                .WithNumberSeat(passageInputModel.SeatNumber)
                .Build();

            var passageCreated = flight.BuyPassageInFlight(passageCreate.Value);

        }
        
    }
}