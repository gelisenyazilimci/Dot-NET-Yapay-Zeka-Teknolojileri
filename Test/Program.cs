<<<<<<< HEAD
﻿using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
=======
﻿using System.Diagnostics.CodeAnalysis;
>>>>>>> 40a19a0a80ec6324a568232596773198129cd972

namespace Test;

using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using System;

internal static class Program
{
    [Experimental("SKEXP0010")]
    private static async Task Main()
    { 
<<<<<<< HEAD
        // Konfigürasyon ayarlarını yükler
=======
>>>>>>> 40a19a0a80ec6324a568232596773198129cd972
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var deepSeekApiKey = configuration["DeepSeek:ApiKey"];
        var modelId = configuration["DeepSeek:ModelId"];
<<<<<<< HEAD
        
        // API key ve Model ID kontrolü
        if (string.IsNullOrWhiteSpace(deepSeekApiKey)) 
            // ReSharper disable once NotResolvedInText
            throw new ArgumentNullException("DeepSeek:ApiKey", "API key bulunamadı.");
        
        if (string.IsNullOrWhiteSpace(modelId))
            // ReSharper disable once NotResolvedInText
            throw new ArgumentNullException("DeepSeek:ModelId", "Model ID bulunamadı.");
=======

        if (string.IsNullOrWhiteSpace(deepSeekApiKey)) 
            throw new ArgumentNullException(deepSeekApiKey, "API key bulunamadı.");
        
        if (string.IsNullOrWhiteSpace(modelId))
            throw new ArgumentNullException(modelId, "Model ID bulunamadı.");
>>>>>>> 40a19a0a80ec6324a568232596773198129cd972
        

        var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(
                modelId: modelId, 
                endpoint: new Uri("https://api.deepseek.com"),
                apiKey: deepSeekApiKey);
        var kernel = builder.Build();
<<<<<<< HEAD

        // deepseek-reasoner modeli kullanılıyorsa düşünme süresi gösterilsin
        bool isDeepSeekReasoner = modelId.Equals("deepseek-reasoner", StringComparison.OrdinalIgnoreCase);
        
=======
>>>>>>> 40a19a0a80ec6324a568232596773198129cd972
        while (true)
        {
            Console.WriteLine("Prompt Giriniz: ");
            var prompt = Console.ReadLine()!;
            if (string.IsNullOrEmpty(prompt))
            {
                Console.WriteLine("Çıkış Yapıldı!");
                break;
            }
<<<<<<< HEAD

            if (isDeepSeekReasoner)
            {
                // Düşünme süresini ölçmek için Stopwatch başlatılıyor
                var stopWatch = Stopwatch.StartNew();
                var result = await kernel.InvokePromptAsync(prompt);
                stopWatch.Stop();
                
                var milliSeconds = stopWatch.ElapsedMilliseconds;
                var resultTime =  milliSeconds >= 60000 ?
                    $"{milliSeconds / 60000} Dakika {(milliSeconds % 60000) / 1000 } Saniye düşündüm \n" :
                    milliSeconds >= 1000 ? $"{(milliSeconds % 60000) / 1000 } Saniye düşündüm \n" :
                $"{milliSeconds} Milisaniye düşündüm \n";
                Console.WriteLine(resultTime);
                Console.WriteLine(result);
            }
            else Console.WriteLine(await kernel.InvokePromptAsync(prompt)); // Result
            
=======
            var result = await kernel.InvokePromptAsync(prompt) ;
            Console.WriteLine(result);
>>>>>>> 40a19a0a80ec6324a568232596773198129cd972
        }
    }
}