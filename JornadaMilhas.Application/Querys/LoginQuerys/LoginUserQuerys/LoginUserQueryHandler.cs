﻿using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.Dtos.LoginResponseDto;
using JornadaMilhas.Application.Util;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Interfaces.Services;
using JornadaMilhas.Infrastruture.Persistence.UOW;
using MediatR;

namespace JornadaMilhas.Application.Querys.LoginQuerys.LoginUserQuerys;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, Result<LoginResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly ITokenService _tokenService;

    public LoginUserQueryHandler(IUnitOfWork unitOfWork, ITokenService tokenService) 
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
    }
    
    public async Task<Result<LoginResponseDto>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var userResult = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (userResult is null)
            return Result.Fail<LoginResponseDto>(UserErrors.UserWithThisEmailNotFound);

        if (!VerifiyPasswordIsEquals(request.Password, userResult.Password))
            return Result.Fail<LoginResponseDto>(UserErrors.PasswordNotEqual);
            
        var tokenGenerated = _tokenService.GenerateToken(userResult);

        var loginResponse = LoginResponseDto.CreateResponseLogin(userResult, tokenGenerated);
        
        return Result<LoginResponseDto>.Ok(loginResponse);
    }

    private static bool VerifiyPasswordIsEquals(string requestPassword, string databasePassword)
    {
        var passwordEncripted = EncriptarSenha.CriptografarSenha(requestPassword);

        return passwordEncripted.Equals(databasePassword);
    }
}
