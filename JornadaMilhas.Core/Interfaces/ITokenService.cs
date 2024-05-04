using JornadaMilhas.Common.Entities;
using JornadaMilhas.Core.Entities.Users;

namespace JornadaMilhas.Core.Interfaces;

public interface ITokenService
{
    string GerarToken(User usuario);
}

