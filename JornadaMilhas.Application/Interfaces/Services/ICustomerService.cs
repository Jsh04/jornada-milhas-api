using JornadaMilhas.Application.Commands.CustomerCommands.DeleteCustomerById;
using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Application.Querys.UserQuerys.GetCustomerById;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Customers;
using JornadaMilhas.Core.Entities.Users;

namespace JornadaMilhas.Application.Interfaces.Services;

public interface ICustomerService
{
    Task<PaginationResult<UserDto>> GetAllCustomersAsync(int size, int page, CancellationToken cancellationToken = default);
    
    Task<Result<Customer>> RegisterCustomer(RegisterCustomerCommand command);

    Task<Result<CustomerDto>> GetCustomerById(GetCustomerByIdQuery query, CancellationToken cancellation = default);
    
    Task<Result> DeleteCustomerById(DeleteCustomerByIdCommand deleteUserByIdCommand, CancellationToken cancellation = default);
}