using System.Security.Claims;
using JornadaMilhas.Application.Interfaces.Services;
using JornadaMilhas.Common.Results;
using JornadaMilhas.Common.Results.Errors;
using Microsoft.AspNetCore.Http;

namespace JornadaMilhas.Infrastruture.Services;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public Result<long> GetCustomerId()
    {
        var userIdString = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value;

        if (string.IsNullOrEmpty(userIdString))
            return Result.Fail<long>(UserServiceErrors.UserNotAuthorized);
        
        var userId = long.Parse(userIdString);
        
        return Result.Ok(userId);
    }
    
}

public static class UserServiceErrors
{
    public static IError UserNotAuthorized => new Error("UserServiceErrors.UserNotAuthorized", "Usuário não logado, por favor faça o login e tente novamente.", ErrorType.Unauthorized);
}