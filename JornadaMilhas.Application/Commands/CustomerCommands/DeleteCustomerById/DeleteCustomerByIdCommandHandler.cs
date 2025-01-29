using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Repositories.Interfaces;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Commands.CustomerCommands.DeleteCustomerById;

public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerByIdCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
    }

    public async Task<Result> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
    {
        var deletedUserById = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);

        if (deletedUserById is null)
            return Result.Fail(UserErrors.NotFound);
        
        await _unitOfWork.BeginTransactionAsync(cancellationToken);
        
        deletedUserById.Delete();

        await _unitOfWork.CommitAsync(cancellationToken);

        var isCompleted = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

        return isCompleted ? Result.Ok() : Result.Fail(UserErrors.UserCannotBeDeleted);
    }
}