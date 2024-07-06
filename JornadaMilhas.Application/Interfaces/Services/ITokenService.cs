using JornadaMilhas.Common.Entities;

namespace JornadaMilhas.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}

