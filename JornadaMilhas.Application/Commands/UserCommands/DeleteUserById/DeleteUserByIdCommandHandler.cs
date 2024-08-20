using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Commands.UserCommands.DeleteUserById
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public DeleteUserByIdCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)  
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        
        public async Task<Result> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            var deletedUserById = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (deletedUserById is null)
                return Result.Fail(UserErrors.NotFound);
            
            deletedUserById.Delete();

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            _userRepository.Delete(deletedUserById);

            await _unitOfWork.CommitAsync(cancellationToken);

            var isCompleted = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

            return isCompleted ? Result.Ok() : Result.Fail(UserErrors.UserCannotBeDeleted);
        }
    }
}
