using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Configuration.Utils;

public class ApiResponse
{
    public int StatusCode { get; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; }

    public ApiResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }

    private static string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            401 => "Não autorizado (não autenticado)",
            404 => "Recurso não encontrado",
            405 => "Método não permitido",
            500 => "Um erro não tratado ocorreu no request",
            _ => string.Empty,
        };
    }
}