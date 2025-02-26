using System.Diagnostics.CodeAnalysis;

namespace Test;

using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using System;

internal static class Program
{
    [Experimental("SKEXP0010")]
    private static async Task Main()
    { 
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var deepSeekApiKey = configuration["DeepSeek:ApiKey"];
        var modelId = configuration["DeepSeek:ModelId"];

        if (string.IsNullOrWhiteSpace(deepSeekApiKey)) 
            throw new ArgumentNullException(deepSeekApiKey, "API key bulunamadı.");
        
        if (string.IsNullOrWhiteSpace(modelId))
            throw new ArgumentNullException(modelId, "Model ID bulunamadı.");
        

        var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(
                modelId: modelId, 
                endpoint: new Uri("https://api.deepseek.com"),
                apiKey: deepSeekApiKey);
        var kernel = builder.Build();
        while (true)
        {
            Console.WriteLine("Prompt Giriniz: ");
            var prompt = Console.ReadLine()!;
            if (string.IsNullOrEmpty(prompt))
            {
                Console.WriteLine("Çıkış Yapıldı!");
                break;
            }
            var result = await kernel.InvokePromptAsync(prompt) ;
            Console.WriteLine(result);
        }
    }
}