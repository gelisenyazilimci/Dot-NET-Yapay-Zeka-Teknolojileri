# Templates Şablonlarının Düzgün Kullanımı

---

Semantic Kernel, dinamik prompt şablonları ile yapay zeka uygulamalarının esnekliğini artırır. Bu şablonlar, uygulamanın farklı bağlamlarına veya kullanıcı girdilerine göre özelleştirilebilen, modüler ve yeniden kullanılabilir yapılar sunar. Şablonlar, yer tutucular (placeholder) ve parametreler aracılığıyla çalışır; böylece sabit metinler yerine, uygulamanın ihtiyaç duyduğu dinamik içerikler oluşturulabilir.

## Şablonların Temel Bileşenleri

- **Şablon Metni:** Sabit ifadeler ile dinamik yer tutucuların bir araya gelmesinden oluşur. Örneğin, İşlemi hesapla: `{{$input}}`" ifadesinde, "İşlemi hesapla:" sabit metin, "{{$input}}" ise dinamik olarak değişecek veriyi temsil eder.
- **Yer Tutucular (Placeholders):** Şablon içerisinde, sonradan sağlanacak değerlerin yerini belirleyen ifadelerdir. Bu sayede, aynı şablon farklı verilerle çalıştırılabilir.
- **Parametreler:** Şablon çalıştırılırken kullanıcı veya sistem tarafından sağlanan değerlerdir. Yer tutucular, bu parametreler aracılığıyla güncellenir.

## Şablon Kullanımının Avantajları

- **Dinamik İçerik Üretimi:** Uygulama bağlamına göre, şablon içerisindeki yer tutucular farklı değerlerle değiştirilir. Böylece her seferinde özelleştirilmiş metinler elde edilir.
- **Merkezi Yönetim:** İçeriklerin merkezi bir şablon üzerinden yönetilmesi, bakım ve güncelleme süreçlerini kolaylaştırır.
- **Modülerlik:** Şablonlar, farklı modüller veya uygulama bölümleri arasında tekrar kullanılabilir; bu, kod tekrarını azaltır ve uygulamanın sürdürülebilirliğini artırır.
- **Performans ve Esneklik:** Şablonların dinamik yapısı, API çağrıları veya kullanıcı etkileşimleri sırasında, ihtiyaç duyulan anlık bilgilerin entegre edilmesini sağlar.

## Örnek Kullanımlar

### Örnek 1: Basit Hesaplama Şablonu

Bu örnekte, kullanıcı tarafından sağlanan matematiksel ifade, şablon içerisindeki yer tutucu sayesinde işlenmek üzere Semantic Kernel üzerinden çalıştırılır.

```csharp
var kernel = builder.Build(); 
var promptTemplate = "İşlemi hesapla: {{$input}}";
var function = kernel.CreateFunctionFromPrompt(promptTemplate);
var arguments = new KernelArguments { ["input"] = "1 + 2 + 5 * 3" };
var result = await function.InvokeAsync(kernel, arguments);
Console.WriteLine(result);
```

**Detaylar:**
- [Stopwatch](../06--Stopwatch-Kullanımı/README.md) gibi ek araçlar kullanılarak işlem süresi ölçülebilir.
- `{{$input}}` yer tutucusu, dinamik olarak "1 + 2 + 5 * 3" ifadesi ile değiştirilir.
- Sonuç, hesaplama işleminin çıktısını doğrudan kullanıcıya sunar.

### Örnek 2: JSON ile Şablon Çekme ve Kullanma

Bu örnekte, şablon tanımı JSON formatında saklanır ve çalışma sırasında JSON'dan çekilerek kullanılır. Bu yöntem, şablonların merkezi bir veri kaynağından yönetilmesi için idealdir.

```csharp
// Örnek JSON formatında tanımlı şablon
string jsonTemplate = @"{
    ""template"": ""Ürünün fiyatı: {{$price}} TL, stok durumu: {{$stock}}""
}";

// JSON içeriğinden şablonu çekme işlemi
var templateObj = JsonConvert.DeserializeObject<JObject>(jsonTemplate);
string promptTemplate = templateObj["template"].ToString();

// Şablonun Semantic Kernel ile kullanımı
var kernel = builder.Build(); 
var function = kernel.CreateFunctionFromPrompt(promptTemplate);
var arguments = new KernelArguments { ["price"] = "150", ["stock"] = "Mevcut" };
var result = await function.InvokeAsync(kernel, arguments);
Console.WriteLine(result);
```

**Detaylar:**
- Şablon, JSON içerisinde saklanır ve `template` anahtarı aracılığıyla okunur.
- `{{$price}}` ve `{{$stock}}` yer tutucuları, sırasıyla "150" ve "Mevcut" değerleri ile değiştirilir.
- Bu yapı, şablonun dinamik olarak güncellenmesini ve merkezi olarak yönetilmesini sağlar.

---