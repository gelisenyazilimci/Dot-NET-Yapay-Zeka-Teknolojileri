# `Context` ve `Memory`

---

Semantic Kernel, uygulamalarınızda diyalog veya senaryoya dayalı bir bellek/memory kavramı getirir. Bir LLM ile etkileşim halindeyken veya ardışık sorgular gerçekleştirirken, önceki adımlardan elde edilen bilgilerin saklanması ve bu bilgilerin gelecekteki sorgularda kullanılması son derece kritik öneme sahiptir.

Semantic Kernel, iki ana bellek türünü destekler:

- **Kısa Vadeli Hafıza (Short Term Memory):**
    - O anki istek veya konuşma akışına göre gerekli bilgilerin geçici olarak saklandığı bellek türüdür.
    - Diyalog sırasında mevcut bağlamın korunması, ilgili verilerin hızlıca erişilebilir olması ve anlık etkileşimlerin yönetimi için kullanılır.
    - Kısa süreli etkileşimlerde, veriler dinamik olarak güncellenir, gerektiğinde silinir ve sistemin hızlı tepki vermesine olanak tanır.

- **Uzun Vadeli Hafıza (Long Term Memory):**
    - Kullanıcının geçmiş etkileşimleri, veritabanı bilgileri veya önceki sorgulardan türetilmiş sonuçların saklandığı kalıcı bellek türüdür.
    - Daha önceki etkileşimlere dayanarak daha zengin, kişiselleştirilmiş ve tutarlı yanıtlar üretmek için kullanılır.
    - Geçmiş verilerin referans alınması, sistemin uzun dönemli bağlamı hatırlamasını ve gelecekteki sorgulara bu doğrultuda yanıt vermesini sağlar.

---

- Bu iki bellek türü sayesinde Semantic Kernel, dinamik ve uyarlanabilir bir etkileşim yönetimi sunar. Kısa vadeli hafıza, anlık diyalogların yönetilmesinde kritik rol oynarken; uzun vadeli hafıza, kullanıcıya özgü geçmiş bilgileri entegre ederek daha tutarlı ve derinlemesine yanıtlar oluşturulmasına olanak tanır. Böylece sistem, hem esnek hem de bağlamı koruyarak etkili bir iletişim sağlar.
