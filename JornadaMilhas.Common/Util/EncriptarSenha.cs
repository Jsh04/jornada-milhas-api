using JornadaMilhas.Application.Util;

namespace JornadaMilhas.Common.Util;

public static class EncriptarSenha
{
    public static string CriptografarSenha(string senha)
    {
        Hash hash = new(HashProvider.SHA1);
        var senhaComHash = hash.GetHash(senha);
        return senhaComHash;
    }
}