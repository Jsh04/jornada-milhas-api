using System.Text.Json;

namespace JornadaMilhasTest.IntegrationsTest.Helper;

public static class TestHelper
{
    public static readonly string ConnectionString = Environment.GetEnvironmentVariable("DATA_BASE_CONNECTION");

    public static readonly string ContentTypeJson = "application/json";

    public static string SerializerObjToJson(object obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}