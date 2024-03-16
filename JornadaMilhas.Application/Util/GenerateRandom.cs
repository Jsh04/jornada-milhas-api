using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Application.Util;

public static class GenerateRandom
{

    public static long GenerateIdLongRandom()
    {
        Random random = new Random();

        byte[] buffer = new byte[8];
        random.NextBytes(buffer);

        // Convertendo os bytes para um número long
        return BitConverter.ToInt64(buffer, 0);

    }

    public static string GenerateRandomBase64()
    {
        int length = 32;

        byte[] buffer = new byte[length];

        Random random = new Random();

        random.NextBytes(buffer);

        // Convertendo o array de bytes para uma string Base64
        return Convert.ToBase64String(buffer);

    }
}

