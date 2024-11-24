namespace JornadaMilhas.Common.Util;

public static class FileHelper
{
    public static string GetPathFileSaveInCloud(string destinyName, string extensionFile)
    {
        return $"jornadamilhas/destino-{destinyName}/{Guid.NewGuid().ToString()}.{extensionFile}";
    }
}