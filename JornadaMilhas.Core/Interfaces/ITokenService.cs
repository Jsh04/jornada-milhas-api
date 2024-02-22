

using JornadaMilhas.Core.Indices;

namespace JornadaMilhas.Core.Interfaces;

    public interface ITokenService
    {
        string GerarToken(UsuarioIndex usuario);
    }

