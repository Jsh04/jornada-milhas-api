﻿namespace JornadaMilhas.Application.Util;

public static class GenerateRandom
{
    public static long GenerateIdLongRandom()
    {
        Random random = new();

        var buffer = new byte[8];
        random.NextBytes(buffer);

        // Convertendo os bytes para um número long
        return BitConverter.ToInt64(buffer, 0);
    }

    public static string GenerateRandomBase64()
    {
        var length = 32;

        var buffer = new byte[length];

        Random random = new();

        random.NextBytes(buffer);

        // Convertendo o array de bytes para uma string Base64
        return Convert.ToBase64String(buffer);
    }
}