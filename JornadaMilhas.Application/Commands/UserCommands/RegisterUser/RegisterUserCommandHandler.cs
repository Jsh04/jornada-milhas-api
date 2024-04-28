using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users;

using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;


namespace JornadaMilhas.Application.Commands.UserCommands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<User>>
{
    private IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    
    
    public async Task<Result<User>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var hasUser = await _unitOfWork.UserRepository.IsUniqueAsync(request.Cpf, request.Mail, cancellationToken);
        if (hasUser) 
            return Result.Fail<User>(UserErrors.UserIsNotUnique);

        var userResult = User
            .CreateBuilder
            .WithName(request.Name)
            .WithAddress(request.Address.Address, request.Address.City, request.Address.State, request.Address.District,
                request.Address.ZipCode)
            .WithGenre(request.Genre)
            .WithMail(request.Mail)
            .WithPhone(request.Phone)
            .WithPassword(request.Password)
            .WithDocumentation(request.Cpf)
            .WithCodeEmployee(request.CodeEmployee)
            .WithUserRole(request.UserRole)
            .WithConfirmMail(request.ConfirmMail)
            .WithDtOfBirth(request.DtBirth)
            .Build();

        if (!userResult.Success)
            return Result.Fail<User>(userResult.Errors);

        var user = userResult.Value;
        
        _unitOfWork.UserRepository.Create(user);
        
        var created = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

        if (!created) 
            return Result.Fail<User>(UserErrors.CannotBeCreated);
        
        return Result.Ok(user);
    }
    
}
