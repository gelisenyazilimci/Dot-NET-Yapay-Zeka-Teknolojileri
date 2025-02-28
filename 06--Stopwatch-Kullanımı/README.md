# Stopwatch Kullanımı

---

Semantic Kernel ile LLM'lerin derin düşünce modundayken cevap üretme süresini ölçmek için pratik ve etkili bir yöntem olarak Stopwatch kullanımı öne çıkar. Bu yöntemde, işlem süresi milisaniye cinsinden net olarak ölçülür ve performans analizlerinde önemli veriler sunar.

- **Zamanlayıcıyı Başlatma:**
    - `Stopwatch.StartNew()` çağrısı ile anında zamanlayıcı devreye alınır. Bu metot, zaman ölçümüne hızlı bir başlangıç sağlar.

- **İşlem Süresinin Ölçülmesi:**
    - `await kernel.InvokePromptAsync(prompt)` çağrısı ile model, verilen prompt doğrultusunda cevabı üretmeye başlar.
    - İşlem tamamlandığında, `stopwatch.Stop()` metodu çağrılarak zamanlayıcı durdurulur. Bu sayede, modelin cevabı üretme süresi milisaniye cinsinden elde edilir.

- **Ek Notlar:**
    - Örnek olarak DeepSeek API’si eğer yanıt içerisinde dahili olarak işlem süresini (örneğin, "processing_time" gibi bir alan) sağlıyorsa, bu bilgiyi doğrudan `result` veya yanıtın metadata’sından çekme imkanı bulunur.
    - Varsayılan durumda, API yanıtında böyle bir bilgi yer almadığından, yukarıda belirtilen yöntemle toplam geçen sürenin ölçülmesi en pratik ve evrensel çözümdür.

Bu yöntemin kullanımı, modelin performansını değerlendirirken, işlem süresindeki dalgalanmaları ve darboğazları tespit etmek adına oldukça yararlıdır. Özellikle, gerçek zamanlı uygulamalarda ve performansın kritik olduğu senaryolarda, işlem süresinin doğru ölçülmesi, sistem optimizasyonu ve kullanıcı deneyiminin iyileştirilmesi açısından büyük önem taşır.
