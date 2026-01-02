namespace JornadaMilhas.Common.Util;

public static class FileHelper
{
    public static string GetPathFileSaveInCloud(string flightCode, string extensionFile)
    {
        return $"jornadamilhas/voo-{flightCode}.{extensionFile}";
    }
}