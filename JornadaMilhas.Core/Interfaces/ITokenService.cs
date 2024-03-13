

using JornadaMilhas.Core.Entities;
using JornadaMilhas.Core.Indices;

namespace JornadaMilhas.Core.Interfaces;

    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }

