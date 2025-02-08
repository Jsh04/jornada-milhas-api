using JornadaMilhas.Application.Commands.PassagesCommands.InputModels;
using JornadaMilhas.Application.Interfaces.UOW;
using JornadaMilhas.Application.Querys.Dtos.OrdersDto;
using JornadaMilhas.Application.Querys.Dtos.PassagesDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Flights;
using JornadaMilhas.Core.Entities.Orders;
using JornadaMilhas.Core.Entities.Passages;
using JornadaMilhas.Core.Repositories.Interfaces;
using MediatR;

namespace JornadaMilhas.Application.Commands.PassagesCommands.PaidPassage;

public class PaidPassageCommandHandler : IRequestHandler<PaidPassageCommand, Result<CreateOrderDto>>
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

    public async Task<Result<CreateOrderDto>> Handle(PaidPassageCommand request, CancellationToken cancellationToken)
    {
        if (request.CustomerId == 0)
            return Result.Fail<CreateOrderDto>(CustomerErrors.CustomerUnauthenticated);

        var customer = await _customerRepository.GetByIdAsync(request.CustomerId, cancellationToken);
        
        if (customer is null)
            return Result.Fail<CreateOrderDto>(CustomerErrors.CustomerNotFound);

        var order = new Order(customer);
        
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        
        var passagesCreated = await CreateOrderByPassagesFromRequest(request, customer, cancellationToken);

        if (!passagesCreated.Success)
            return Result.Fail<CreateOrderDto>(passagesCreated.Errors);

        var passagesCreatedList = passagesCreated.Value;
        
        order.AddPassagesInOrder(passagesCreatedList);
        
        await _orderRepository.CreateAsync(order);
        
        await _unitOfWork.CommitAsync(cancellationToken);

        var orderDto = new CreateOrderDto(passagesCreatedList.Select(MappingPassageEntityToDto), order.TotalValue, DateTime.Now);
        
        return Result.Ok<CreateOrderDto>(orderDto);
    }

    private async Task<Result<List<Passage>>> CreateOrderByPassagesFromRequest(PaidPassageCommand request, Customer customer, CancellationToken cancellationToken = default)
    {
        var passages = new List<Passage>(request.PaidPassages.Count);
        
        foreach (var passageInputModel in request.PaidPassages)
        {
            var flight = await _flightRepository.GetByIdAsync(passageInputModel.FlightId, cancellationToken);

            if (flight is null)
                return Result<List<Passage>>.Fail<List<Passage>>(FlightErrors.NotFound);

            var passageCreate = CreatePassageByInputModel(passageInputModel);

            if (!passageCreate.Success)
                return Result<List<Passage>>.Fail<List<Passage>>(passageCreate.Errors);
            
            var buyPassageResult = flight.BuyPassageInFlight(passageCreate.Value);

            if (!buyPassageResult.Success)
                return Result<List<Passage>>.Fail<List<Passage>>(buyPassageResult.Errors);
            
            passages.Add(passageCreate.Value);
        }

        return Result.Ok(passages);
    }

    private static Result<Passage> CreatePassageByInputModel(PaidPassageInputModel passageInputModel)
    {
        return PassageBuilder.Create()
            .WithEnumTypePassage(passageInputModel.TypeClassPlane)
            .WithNumberSeat(passageInputModel.SeatNumber)
            .WithEnumTypeSeat(passageInputModel.TypeSeat)
            .Build();
    }

    private PassageDto MappingPassageEntityToDto(Passage passage) => 
        new PassageDto(passage.EnumTypeSeat, passage.EnumTypeClass, passage.SeatNumber, passage.Value);
    
}