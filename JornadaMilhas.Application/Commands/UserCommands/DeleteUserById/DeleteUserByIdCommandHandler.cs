using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Commands.UserCommands.DeleteUserById
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserByIdCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        
        public async Task<Result> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            var deletedUserById = await _unitOfWork.UserRepository.GetByIdAsync(request.Id, cancellationToken);

            if (deletedUserById is null)
                return Result.Fail(UserErrors.NotFound);
            
            deletedUserById.Delete();

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            _unitOfWork.UserRepository.Delete(deletedUserById);

            await _unitOfWork.CommitAsync(cancellationToken);

            var isCompleted = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

            return isCompleted ? Result.Ok() : Result.Fail(UserErrors.UserCannotBeDeleted);
        }
    }
}
