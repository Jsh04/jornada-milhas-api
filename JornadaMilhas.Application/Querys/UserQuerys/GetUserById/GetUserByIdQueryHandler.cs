using JornadaMilhas.Application.Querys.Dtos.UsersDto;
using JornadaMilhas.Common.DTO;
using JornadaMilhas.Common.Entities;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Querys.UserQuerys.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)  
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
                
        }
        
        public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userById = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (userById is null)
                return Result.Fail<UserDto>(UserErrors.NotFound);

            var userDtoMapped = DtoExtensions<User, UserDto>.ToDto(userById);

            return Result.Ok(userDtoMapped);
        }
    }
}
