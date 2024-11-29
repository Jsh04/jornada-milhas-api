using JornadaMilhas.Application.Commands.CustomerCommands.DeleteCustomerById;
using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Application.Querys.UserQuerys.GetCustomerById;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Customers;
using MediatR;

namespace JornadaMilhas.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ISender _sender;

    public CustomerService(ISender sender)
    {
        _sender = sender;
    }
    
    public Task<PaginationResult<CustomerDto>> GetAllCustomersAsync(int size, int page, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Customer>> RegisterCustomer(RegisterCustomerCommand command)
    {
        return await _sender.Send(command);
    }

    public async Task<Result<CustomerDto>> GetCustomerById(GetCustomerByIdQuery query, CancellationToken cancellation = default)
    {
        return await _sender.Send(query, cancellation);
    }

    public Task<Result> DeleteCustomerById(DeleteCustomerByIdCommand deleteUserByIdCommands, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }
}