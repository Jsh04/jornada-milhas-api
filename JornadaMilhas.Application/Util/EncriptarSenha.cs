using System.Security.Cryptography;

namespace JornadaMilhas.Application.Util;

public static class EncriptarSenha
{
    public static string CriptografarSenha(string senha)
    {
        Hash hash = new(HashProvider.SHA1);
        string senhaComHash = hash.GetHash(senha);
        return senhaComHash;
    }

    private static byte[] GerarSalt()
    {
        // Gera um salt aleatório usando RNGCryptoServiceProvider
        byte[] salt = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }
}
