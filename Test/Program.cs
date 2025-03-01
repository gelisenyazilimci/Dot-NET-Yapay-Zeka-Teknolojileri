using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;

namespace Test;

internal static class Program
{
    // Deneysel API işaretçisi; bu özellik gelecekte değişiklik gösterebilir.
    [Experimental("SKEXP0010")]
    private static async Task Main()
    {
        // 1. Konfigürasyon ayarlarını yükle
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var promptJson = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("./SystemPromptArgument.json", optional: false, reloadOnChange: true)
            .Build();
        
        var deepSeekApiKey = configuration["DeepSeek:ApiKey"];
        var modelId = configuration["DeepSeek:ModelId"];

        var argument = promptJson["prompt"]; //Burası değişitirilebilir!
        
        // 2. API Key ve Model ID'nin boş olmadığını kontrol et
        if (string.IsNullOrWhiteSpace(deepSeekApiKey))
            // ReSharper disable once NotResolvedInText
            throw new ArgumentNullException("DeepSeek:ApiKey", "API key bulunamadı.");
        if (string.IsNullOrWhiteSpace(modelId))
            // ReSharper disable once NotResolvedInText
            throw new ArgumentNullException("DeepSeek:ModelId", "Model ID bulunamadı.");

        if (string.IsNullOrEmpty(argument))
            // ReSharper disable once NotResolvedInText
            // Sistem Promptu bulunamadığı zaman kullanıcıya sadece ERROR hatası atılır.
            throw new ArgumentNullException("Prompt", "ERROR!");  
            

        // 3. Kernel oluşturmak için yeni API: Kernel.CreateBuilder() kullanılıyor
        var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion(
            modelId: modelId,
            endpoint: new Uri("https://api.deepseek.com"),
            apiKey: deepSeekApiKey);

        var kernel = builder.Build();

        // 6. Eğer deepseek-reasoner modeli kullanılıyorsa, düşünme süresi ölçümü yapılacak
        bool isDeepSeekReasoner = modelId.Equals("deepseek-reasoner", StringComparison.OrdinalIgnoreCase);

        while (!string.IsNullOrEmpty(argument))
        {
            Console.Write("Prompt Giriniz: ");
            var inputPrompt = Console.ReadLine();
            var combinedPrompt = argument + inputPrompt;

            if (string.IsNullOrEmpty(inputPrompt))
            {
                Console.WriteLine("Çıkış Yapıldı!");
                break;
            }

            if (isDeepSeekReasoner)
            {
				Console.WriteLine("Düşünmeye başlıyorum");
                // Düşünme süresini ölçmek için Stopwatch başlatılıyor
                var stopWatch = Stopwatch.StartNew();
                var result = await kernel.InvokePromptAsync(combinedPrompt);
                stopWatch.Stop();

                var milliSeconds = stopWatch.ElapsedMilliseconds;
                var resultTime = milliSeconds >= 60000 ?
                    $"{milliSeconds / 60000} Dakika {(milliSeconds % 60000) / 1000} Saniye düşündüm \n" :
                    milliSeconds >= 1000 ?
                        $"{milliSeconds / 1000} Saniye düşündüm \n" :
                        $"{milliSeconds} Milisaniye düşündüm \n";

                Console.WriteLine(resultTime);
                Console.WriteLine(result);
            }
            else
            {
                // Normal mod: Sadece modelin yanıtını göster
                var result = await kernel.InvokePromptAsync(combinedPrompt);
                Console.WriteLine(result);
            }
        }
    }
}