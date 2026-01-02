namespace JornadaMilhas.Common.Util;

public static class JornadaMilhasHelper
{
    public static byte[] ConvertBase64ToByteArray(string base64)
    {
        return Convert.FromBase64String(base64);
    }
}