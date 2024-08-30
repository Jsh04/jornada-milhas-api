using JornadaMilhas.Application.Commands.UserCommands.DeleteUserById;
using JornadaMilhas.Application.Commands.UserCommands.UserLimitedCommands.RegisterUserLimited;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Application.Querys.UserQuerys.UserLimitedQuerys.GetAllUsersLimited;
using JornadaMilhas.Application.Querys.UserQuerys.UserLimitedQuerys.GetUserById;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.PaginationResult;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Core.Interfaces.Services;
using MediatR;

namespace JornadaMilhas.Application.Services
{
    public class UserLimitedService : IUserLimitedService
    {
        private readonly ISender _sender;
        public UserLimitedService(ISender sender)
        {
            _sender = sender;
        }

        public async Task<Result> DeleteUserbyId(DeleteUserByIdCommand deleteUserByIdCommands, CancellationToken cancellation = default) => await _sender.Send(deleteUserByIdCommands, cancellation);


        public async Task<PaginationResult<UserLimitedDto>> GetAllUsersAsync(int size, int page, CancellationToken cancellationToken = default)
        {
            var getAllQuery = new GetAllUsersLimitedQuery(page, size);
            return await _sender.Send(getAllQuery, cancellationToken);
        }

        public async Task<Result<UserLimitedDto>> GetUserById(GetUserLimitedByIdQuery query, CancellationToken cancellation = default) 
            => await _sender.Send(query, cancellation);


        public Task<Result<UserLimited>> RegisterUserLimited(RegisterUserLimitedCommand command) => _sender.Send(command);
    }
}
