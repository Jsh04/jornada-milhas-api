using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Querys.UserQuerys.UserLimitedQuerys.GetUserById
{
    public class GetUserLimitedByIdQueryHandler : IRequestHandler<GetUserLimitedByIdQuery, Result<UserLimitedDto>>
    {

        private readonly IUserLimitedRepository _userLimitedRepository;

        public GetUserLimitedByIdQueryHandler(IUserLimitedRepository userLimitedRepository)
        {
            _userLimitedRepository = userLimitedRepository;
        }

        public async Task<Result<UserLimitedDto>> Handle(GetUserLimitedByIdQuery request, CancellationToken cancellationToken)
        {
            var userById = await _userLimitedRepository.GetByIdAsync(request.Id, cancellationToken);

            if (userById is null)
                return Result.Fail<UserLimitedDto>(UserErrors.NotFound);

            var userDtoMapped = DtoExtensions<UserLimited, UserLimitedDto>.ToDto(userById);

            return Result.Ok(userDtoMapped);
        }
    }
}
