using JornadaMilhas.Application.Authentication.Shared;

namespace JornadaMilhas.Application.Authentication.Queries.Login;

public sealed record LoginQueryResult(string Token, UserSessionInfoDto User, DateTime DateExpiration);

    
