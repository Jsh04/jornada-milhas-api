using API_Domains.Interfaces;
using OpenAI_API;
using OpenAI_API.Completions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Domains.Services;

public class ChatGPTService : IChatGPTService
{
    public async Task<string> ChatGPTConsult(string query)
    {
        string outputResult = "";
        var openIA = new OpenAIAPI("");
        CompletionRequest completionRequest = new()
        {
            Prompt = query,
            Model = OpenAI_API.Models.Model.Davinci,
            MaxTokens = 200
        };
        var completions = await openIA.Completions.CreateCompletionAsync(completionRequest);
        foreach (var completion in completions.Completions)
        {
            outputResult += completion.Text;
        }
        return outputResult;
    }
}
