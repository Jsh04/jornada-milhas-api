namespace JornadaMilhas.Common.Util;

public static class GenerateRandom
{
    public static long GenerateIdLongRandom()
    {
        Random random = new();

        var buffer = new byte[8];
        random.NextBytes(buffer);
        
        return BitConverter.ToInt64(buffer, 0);
    }

    public static string GenerateRandomBase64()
    {
        const int length = 32;

        var buffer = new byte[length];

        Random random = new();

        random.NextBytes(buffer);
        
        return Convert.ToBase64String(buffer);
    }
}