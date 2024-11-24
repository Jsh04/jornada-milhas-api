using JornadaMilhas.Common.Entity;
using JornadaMilhas.Common.Entity.Users;
using JornadaMilhas.Core.Entities.Users;

namespace JornadaMilhas.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}