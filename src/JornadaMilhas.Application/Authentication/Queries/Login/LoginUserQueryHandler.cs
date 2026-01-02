using JornadaMilhas.Application.Authentication.Shared;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Security;
using JornadaMilhas.Common.Util;
using JornadaMilhas.Core.Entities.Users;
using JornadaMilhas.Core.Repositories.Interfaces;
using MediatR;

namespace JornadaMilhas.Application.Authentication.Queries.Login;

public class LoginUserQueryHandler : IRequestHandler<LoginQuery, Result<LoginQueryResult>>
{
    private readonly ITokenService _tokenService;

    private readonly IUserRepository _userRepository;

    public LoginUserQueryHandler(ITokenService tokenService, IUserRepository userRepository)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
    }

    public async Task<Result<LoginQueryResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var userResult = await _userRepository.GetByEmailOrCpfAsync(request.EmailOrCpf, cancellationToken);

        if (userResult is null)
            return Result.Fail<LoginQueryResult>(UserErrors.UserWithThisEmailNotFound);

        if (!VerifyPasswordIsEquals(request.Password, userResult.Password))
            return Result.Fail<LoginQueryResult>(UserErrors.PasswordNotEqual);

        var tokenGeneratedInfoDto = _tokenService.GenerateToken(userResult);

        var userSession = new UserSessionInfoDto(userResult.Id, userResult.Name, userResult.Email.Address);
        
        var loginResponse = new LoginQueryResult(tokenGeneratedInfoDto.Token, userSession, tokenGeneratedInfoDto.DateExpiration);
        
        return Result<LoginQueryResult>.Ok(loginResponse);
    }

    private static bool VerifyPasswordIsEquals(string requestPassword, string databasePassword)
    {
        return PasswordHasher.VerifyPassword(requestPassword, databasePassword);
    }
}