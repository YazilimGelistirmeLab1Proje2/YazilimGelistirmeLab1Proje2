# 🕸️ Sosyal Ağ Analizi ve Görselleştirme Aracı (SNA Tool)


**Ders:** Yazılım Geliştirme Laboratuvarı - I  
**Dönem:** 2025-2026 Güz  
**Bölüm:** Kocaeli Üniversitesi - Bilişim Sistemleri Mühendisliği  

---

## 👥 1. Proje Künyesi

| Rol | Ad Soyad | Öğrenci No |
| :--- | :--- | :--- |
| **Geliştirici** | **Fatih Bilgin** | 231307019 |
| **Geliştirici** | **Efe Aydın** | 231307010 |
| **Teslim Tarihi** | 02.01.2026 | |

---

## 📝 2. Giriş ve Problem Tanımı

### 2.1. Problemin Tanımı
Günümüz dünyasında sosyal ağlar (Facebook, Twitter, LinkedIn vb.) milyonlarca kullanıcı ve milyarlarca etkileşimden oluşan karmaşık yapılardır. Bu devasa veri yığınları üzerinde; "iki kişi arasındaki en kısa bağlantı yolu nedir?", "en popüler (merkezi) kişi kimdir?", "birbirinden kopuk topluluklar var mıdır?" gibi soruların manuel olarak cevaplanması imkansızdır. Bu tür analizler için matematiksel Graf Teorisi ve yüksek performanslı algoritmalara ihtiyaç duyulmaktadır.

### 2.2. Projenin Amacı
Bu projenin amacı; kullanıcıları **düğüm (node)** ve etkileşimleri **kenar (edge)** olarak modelleyen, nesneye dayalı (OOP) bir masaüstü yazılımı geliştirmektir. Yazılım, CSV formatındaki verileri okuyarak görselleştirmeli, Dijkstra, A*, BFS, DFS ve Welsh-Powell gibi algoritmaları koşarak analiz sonuçlarını raporlamalıdır.

---

## ⚙️ 3. Algoritmalar ve Analizler

Projede kullanılan algoritmaların detaylı incelemesi aşağıdadır.

### 3.1. BFS (Breadth-First Search) - Sığ Öncelikli Arama
* **Mantık:** Başlangıç düğümünden başlayarak önce tüm doğrudan komşuları, sonra onların komşularını ziyaret eder. "Dalga" şeklinde yayılır.
* **Literatür:** Konrad Zuse (1945) tarafından reddedilen bir tezde bahsedilmiş, Moore (1959) tarafından en kısa yol bulma amacıyla resmileştirilmiştir.
* **Karmaşıklık:** $O(V + E)$ (V: Düğüm, E: Kenar)

```mermaid
flowchart TD
    A[Başla] --> B[Kuyruğa Başlangıç Düğümünü Ekle]
    B --> C{Kuyruk Boş mu?}
    C -- Evet --> D[Bitir]
    C -- Hayır --> E[Kuyruktan Çıkar ve Ziyaret Et]
    E --> F[Ziyaret Edilmemiş Komşuları Kuyruğa Ekle]
    F --> C
3.2. DFS (Depth-First Search) - Derin Öncelikli AramaMantık: Bir yola girer ve gidebildiği en son noktaya kadar ilerler. Gidecek yer kalmadığında geri döner (backtracking). Stack (Yığın) yapısı kullanılır.Literatür: 19. yüzyılda labirent çözümleri için Charles Pierre Trémaux tarafından kullanılmıştır.Karmaşıklık: $O(V + E)$3.3. Dijkstra En Kısa Yol AlgoritmasıMantık: Ağırlıklı graflarda başlangıç noktasından diğer noktalara olan en kısa mesafeyi hesaplar. "Greedy" (Açgözlü) yaklaşımını kullanır.Literatür: Edsger W. Dijkstra tarafından 1956'da tasarlanmış ve 1959'da yayınlanmıştır.Karmaşıklık: $O(E + V \log V)$ (Priority Queue ile)Kod snippet'iflowchart TD
    A[Başla] --> B[Mesafeleri Sonsuz Yap, Kaynak=0]
    B --> C{Ziyaret Edilmemiş Var mı?}
    C -- Hayır --> Z[Bitir ve Yolu Çiz]
    C -- Evet --> D[En Küçük Mesafeli Düğümü Seç (u)]
    D --> E[Komşuları (v) Gez]
    E --> F{Yeni Mesafe < Eski Mesafe?}
    F -- Evet --> G[Mesafeyi Güncelle (Relaxation)]
    F -- Hayır --> E
    G --> C
3.4. A* (A-Star) AlgoritmasıMantık: Dijkstra'nın optimize edilmiş halidir. Maliyet fonksiyonuna ($g(n)$) ek olarak, hedefe olan tahmini mesafeyi ($h(n)$ - Heuristic) de hesaba katar. Projede Öklid (Euclidean) mesafesi kullanılmıştır.Literatür: Hart, Nilsson ve Raphael tarafından 1968'de geliştirilmiştir.Karmaşıklık: $O(E)$ (En iyi durumda)3.5. Welsh-Powell Graf RenklendirmeMantık: Komşu düğümlerin aynı renge sahip olmamasını sağlar. Düğümler derecelerine (bağlantı sayılarına) göre büyükten küçüğe sıralanır ve sırayla boyanır.Literatür: 1967 yılında Welsh ve Powell tarafından yayınlanmıştır.Karmaşıklık: $O(V^2)$ (Sıralama maliyeti dahil)🏗️ 4. Sistem Mimarisi ve OOP TasarımıProje, Strategy Design Pattern kullanılarak geliştirilmiştir. Bu sayede algoritmalar ana koddan soyutlanmış, yeni bir algoritma eklemek için sadece ilgili interface'in implemente edilmesi yeterli hale gelmiştir.Sınıf DiyagramıKod snippet'iclassDiagram
    class UserNode {
        +int Id
        +string UserName
        +double ActiveScore
        +List~Edge~ OutgoingEdges
        +Point Location
    }

    class Edge {
        +UserNode Source
        +UserNode Target
        +double Weight
    }

    class Graph {
        +Dictionary~int, UserNode~ Nodes
        +void AddNode()
        +void AddEdge()
    }

    class IGraphAlgorithm {
        <<interface>>
        +void Execute(Graph g, UserNode start, UserNode end)
        +string GetResult()
    }

    class Dijkstra {
        +void Execute()
    }
    class BFS {
        +void Execute()
    }
    class WelshPowell {
        +void Execute()
    }
    class Centrality {
        +UserNode FindMostPopular()
    }

    class FileManager {
        +Graph LoadFromCSV(string path)
        +void SaveToCSV(Graph g, string path)
    }

    Graph *-- UserNode
    UserNode *-- Edge
    IGraphAlgorithm <|.. Dijkstra
    IGraphAlgorithm <|.. BFS
    IGraphAlgorithm <|.. WelshPowell
    IGraphAlgorithm <|.. AStar
    Form1 ..> IGraphAlgorithm : Uses Strategy
    Form1 ..> FileManager : Uses
📱 5. Uygulama, Testler ve Sonuçlar5.1. Arayüz ve GörselleştirmeUygulama arayüzü "Flat Design" prensiplerine göre tasarlanmıştır. Düğümler, CSV yüklendiğinde panel üzerine rastgele (random layout) dağıtılarak üst üste binmeleri engellenmiştir.Düğüm Seçimi: Mouse ile düğümlere tıklandığında özellikleri (ID, İsim, Puan) görüntülenir ve güncellenebilir.Yol Boyama: Algoritmalar çalıştığında en kısa yol Yeşil, gezilen yollar Sarı veya Kırmızı ile görselleştirilir.(Buraya Ana Ekran Görüntüsü Gelecek)![Uygulama Ana Ekranı](screenshots/ana_ekran.png)5.2. Performans Test TablosuUygulama içerisindeki algoritmaların çalışma süreleri System.Diagnostics.Stopwatch kullanılarak ölçülmüştür. Testler 15 düğümlü (Küçük) ve 50 düğümlü (Orta) veri setleri ile yapılmıştır.Algoritma15 Düğüm (Küçük) Süre50 Düğüm (Orta) SüreBFS0.0042 ms0.0185 msDFS0.0038 ms0.0172 msDijkstra0.0250 ms0.1450 ms*A (A-Star)**0.0190 ms0.1100 msWelsh-Powell0.0450 ms0.3200 msTopluluk Analizi0.0350 ms0.2100 ms5.3. Test SenaryolarıSenaryo: Ayrık (bağlantısız) düğümlerin tespiti.Sonuç: "Topluluk Analizi" modülü çalıştırıldı, 3 farklı ayrık grup tespit edildi ve raporlandı.Senaryo: En popüler kullanıcı.Sonuç: Merkeziyet analizi, en çok dış bağlantısı olan kullanıcıyı (ID:1) "Zirvedeki İsim" olarak belirledi.Senaryo: Hedef odaklı yol bulma.Sonuç: A* algoritması, Heuristic hesaplama sayesinde Dijkstra'dan %20 daha hızlı sonuç üretti.🎯 6. Sonuç ve Tartışma6.1. Başarılar✅ Modülerlik: IGraphAlgorithm arayüzü sayesinde kod tekrarı önlenmiş ve SOLID prensiplerine uyulmuştur.✅ Görsel Geri Bildirim: Kullanıcı, algoritmaların nasıl çalıştığını görsel olarak (renk değişimleri ile) takip edebilmektedir.✅ Hata Yönetimi: Hatalı CSV formatı veya geçersiz düğüm seçimlerinde programın çökmesi try-catch blokları ile engellenmiştir.6.2. SınırlılıklarÇok büyük veri setlerinde (1000+ düğüm) GDI+ çizim kütüphanesi performans düşüklüğü yaşayabilir.Şu an için sadece yönlü (directed) graflar desteklenmektedir.6.3. Olası GeliştirmelerVeri tabanı (SQL/NoSQL) entegrasyonu sağlanabilir.Graf çizimi için "Force-Directed" (Fizik tabanlı) yerleşim algoritması eklenebilir.Web API servisi yazılarak proje web ortamına taşınabilir.
