﻿using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Entities.Users.UserLimited;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;


namespace JornadaMilhas.Application.Commands.UserCommands.RegisterUserLimited;

public class RegisterUserLimitedCommandHandler : IRequestHandler<RegisterUserLimitedCommand, Result<UserLimited>>
{
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserLimitedCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    
    
    public async Task<Result<UserLimited>> Handle(RegisterUserLimitedCommand request, CancellationToken cancellationToken)
    {
        var hasUser = await _unitOfWork.UserLimitedRepository.IsUniqueAsync(request.Cpf, request.Mail, cancellationToken);
        if (hasUser) 
            return Result.Fail<UserLimited>(UserErrors.UserIsNotUnique);

        var userResult = UserLimited
            .CreateBuilder
            .WithName(request.Name)
            .WithAddress(city:request.Address.City, state:request.Address.State, district:null, zipCode:null, street:null)
            .WithGenre(request.Genre)
            .WithEmail(request.Mail)
            .WithPhone(request.Phone)
            .WithPassword(request.Password)
            .WithDocumentation(request.Cpf)
            .WithConfirmMail(request.ConfirmMail)
            .WithDtOfBirth(request.DtBirth)
            .Build();

        if (!userResult.Success)
            return Result.Fail<UserLimited>(userResult.Errors);

        var user = userResult.Value;
        
        _unitOfWork.UserLimitedRepository.Create(user);
        
        var created = await _unitOfWork.CompleteAsync(cancellationToken) > 0;

        if (!created) 
            return Result.Fail<UserLimited>(UserErrors.CannotBeCreated);
        
        return Result.Ok(user);
    }
    
}
