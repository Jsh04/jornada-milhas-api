using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users;

using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;


namespace JornadaMilhas.Application.Commands.UserCommands.RegisterUserLimited;

public class RegisterUserLimitedCommandHandler : IRequestHandler<RegisterUserLimitedCommand, Result<User>>
{
    private IUnitOfWork _unitOfWork;

    public RegisterUserLimitedCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    
    
    public async Task<Result<User>> Handle(RegisterUserLimitedCommand request, CancellationToken cancellationToken)
    {
        var hasUser = await _unitOfWork.UserRepository.IsUniqueAsync(request.Cpf, request.Mail, cancellationToken);
        if (hasUser) 
            return Result.Fail<User>(UserErrors.UserIsNotUnique);

        var userResult = UserLimited
            .CreateBuilder
            .WithName(request.Name)
            .WithAddress(city:request.Address.City, state:request.Address.State, district:null, zipCode:null, street:null)
            .WithGenre(request.Genre)
            .WithMail(request.Mail)
            .WithPhone(request.Phone)
            .WithPassword(request.Password)
            .WithDocumentation(request.Cpf)
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
