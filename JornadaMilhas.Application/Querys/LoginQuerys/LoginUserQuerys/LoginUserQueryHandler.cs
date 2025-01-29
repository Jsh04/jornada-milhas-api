using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Application.Querys.Dtos.LoginResponseDto;
using JornadaMilhas.Application.Util;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Repositories.Interfaces;
using MediatR;

namespace JornadaMilhas.Application.Querys.LoginQuerys.LoginUserQuerys;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, Result<LoginOutputModel>>
{
    private readonly ITokenService _tokenService;

    private readonly IUserRepository _userRepository;

    public LoginUserQueryHandler(ITokenService tokenService, IUserRepository userRepository)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
    }

    public async Task<Result<LoginOutputModel>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var userResult = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (userResult is null)
            return Result.Fail<LoginOutputModel>(UserErrors.UserWithThisEmailNotFound);

        if (!VerifiyPasswordIsEquals(request.Password, userResult.Password))
            return Result.Fail<LoginOutputModel>(UserErrors.PasswordNotEqual);

        var tokenGenerated = _tokenService.GenerateToken(userResult);

        var loginResponse = LoginOutputModel.CreateResponseLogin(userResult, tokenGenerated);

        return Result<LoginOutputModel>.Ok(loginResponse);
    }

    private static bool VerifiyPasswordIsEquals(string requestPassword, string databasePassword)
    {
        var passwordEncripted = EncriptarSenha.CriptografarSenha(requestPassword);

        return passwordEncripted.Equals(databasePassword);
    }
}