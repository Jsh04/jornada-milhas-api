using JornadaMilhasTest.IntegrationsTest.WebApplicationFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

