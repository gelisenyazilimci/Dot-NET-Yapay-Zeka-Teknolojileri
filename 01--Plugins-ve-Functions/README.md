# `Plugins` ve `Functions`

---

- Semantic Kernel, `Plugins` ve `Functions` gibi yapıları tanımlayarak yeniden kullanılabilir yapay zeka işlevsellikleri yaratmamızı sağlar. Bu yaklaşım, katmanlı ve modüler bir mimari kurmamızı mümkün kılar.

---

## **Plugins**

- Semantic Kernel'da belirli bir görevi yerine getiren modüler bileşene `Plugin` denir. Başka bir deyişle, LLM'lere çeşitli görevler ve uygulamalara belirli yetenekler kazandırır.
- Örnek olarak:
    - **Matematik Plugin’i:** Toplama, çıkarma, çarpma gibi işlemleri gerçekleştiren fonksiyonları barındırır.
    - **Metin Analizi Plugin’i:** Duygu analizi, özetleme gibi işlemler yapan fonksiyonlar içerir.

---

## **Functions**

- Function, tek bir amacı ve belirli bir görevi gerçekleştirmeye odaklı olan bağımsız bir işlemdir. Genelde bir LLM çağrısı veya belirli bir iş mantığını yürütmekten sorumludur.
- Bir plugin içerisinde bir veya birden fazla fonksiyon bulunabilir. Yapısal olarak, fonksiyonlar genellikle bir girdi alır, iş mantığı doğrultusunda operatif işlemler yapar ve sonuç olarak bir çıktı üretir.
- Örnek olarak:
    - **`SummarizeText():`** Bir metni özetleyen fonksiyondur.
    - **`ExtractKeywords():`** Metinden anahtar kelimeleri ayıklayan fonksiyondur.
    - **`TranslateText():`** Metni farklı bir dile çeviren fonksiyondur.

---

## **Kısacası / Özetle**

Semantic Kernel, modüler yapısı sayesinde yapay zeka işlevlerini yeniden kullanılabilir hale getirir. `Plugin` yapısı, belirli görevleri yerine getiren modüler bileşenleri ifade ederken; `Function` ise bu bileşenler içerisindeki spesifik işlemleri gerçekleştirir. Böylece, LLM'lere çeşitli görevler ve uygulamalar için özel yetenekler kazandırmak mümkün olur.
