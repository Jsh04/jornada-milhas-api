namespace JornadaMilhas.Application.Util;

public static class EncriptarSenha
{
    public static string CriptografarSenha(string senha)
    {
        Hash hash = new(HashProvider.SHA1);
        var senhaComHash = hash.GetHash(senha);
        return senhaComHash;
    }
}