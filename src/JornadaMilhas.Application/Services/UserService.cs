using JornadaMilhas.Application.Commands.CustomerCommands.RegisterCustomer;
using JornadaMilhas.Application.Commands.UserCommands.DeleteUserById;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Application.Querys.UserQuerys.GetAllUsers;
using JornadaMilhas.Application.Querys.UserQuerys.GetUserById;
using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users;
using MediatR;

namespace JornadaMilhas.Application.Services;

public class UserService : IUserService
{
    private readonly ISender _sender;

    public UserService(ISender sender)
    {
        _sender = sender;
    }

    Task<PaginationResult<UserDto>> IUserService.GetAllUsersAsync(int size, int page, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<CustomerDto>> RegisterCustomer(RegisterCustomerCommand command)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> DeleteUserbyId(DeleteUserByIdCommand deleteUserByIdCommands,
        CancellationToken cancellation = default)
    {
        return await _sender.Send(deleteUserByIdCommands, cancellation);
    }


    public async Task<PaginationResult<UserDto>> GetAllCustomersAsync(int size, int page,
        CancellationToken cancellationToken = default)
    {
        var getAllQuery = new GetAllUsersQuery(page, size);
        return await _sender.Send(getAllQuery, cancellationToken);
    }

    public async Task<Result<UserDto>> GetUserById(GetUserByIdQuery query, CancellationToken cancellation = default)
    {
        return await _sender.Send(query, cancellation);
    }
    
    public Task<Result<User>> RegisterUser(RegisterUserCommand command)
    {
        return _sender.Send(command);
    }
}