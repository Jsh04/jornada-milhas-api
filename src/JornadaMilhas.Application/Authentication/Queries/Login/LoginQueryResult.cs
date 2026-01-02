using JornadaMilhas.Application.Authentication.Shared;
using JornadaMilhas.Common.Entity.Users;

namespace JornadaMilhas.Application.Authentication.Queries.Login;

public sealed record LoginQueryResult(string Token, UserSessionInfoDto User, DateTime DateExpiration);

    
