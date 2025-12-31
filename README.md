🕸️ Sosyal Ağ Analizi ve Görselleştirme Aracı 
Ders: Yazılım Geliştirme Laboratuvarı - I
Dönem: 2025-2026 Güz
Bölüm: Kocaeli Üniversitesi - Bilişim Sistemleri Mühendisliği👥
1. Proje Künyesi
2. RolAd SoyadÖğrenci NoGeliştiriciFatih Bilgin231307019GeliştiriciEfe Aydın231307010Teslim Tarihi02.01.2026📝 2. Giriş ve Problem Tanımı2.1. Problemin TanımıGünümüz dünyasında sosyal ağlar (Facebook, Twitter, LinkedIn vb.) milyonlarca kullanıcı ve milyarlarca etkileşimden oluşan karmaşık yapılardır. Bu devasa veri yığınları üzerinde; "İki kişi arasındaki en kısa bağlantı yolu nedir?", "Ağdaki en popüler (merkezi) kişi kimdir?" veya "Birbirinden kopuk topluluklar var mıdır?" gibi soruların manuel yöntemlerle cevaplanması imkansızdır.Bu tür analizler için matematiksel Graf Teorisi prensiplerine dayanan, yüksek performanslı algoritmalara ve bunları anlamlandıracak görselleştirme araçlarına ihtiyaç duyulmaktadır.2.2. Projenin AmacıBu projenin temel amacı; kullanıcıları düğüm (node) ve aralarındaki etkileşimleri kenar (edge) olarak modelleyen, Nesneye Dayalı Programlama (OOP) prensiplerine uygun bir masaüstü yazılımı geliştirmektir. Yazılım, ham verileri (CSV) işleyerek görselleştirmeli; Dijkstra, A, BFS, DFS* ve Welsh-Powell gibi algoritmaları koşarak analiz sonuçlarını kullanıcıya raporlamalıdır.⚙️ 3. Algoritmalar ve AnalizlerProjede kullanılan temel algoritmalar ve çalışma mantıkları aşağıda detaylandırılmıştır.3.1. BFS (Breadth-First Search) - Sığ Öncelikli AramaMantık: Başlangıç düğümünden başlayarak önce tüm doğrudan komşuları, sonra onların komşularını ziyaret eder. Arama işlemi bir "dalga" şeklinde yayılır.Kullanım Alanı: Ağırlıksız graflarda en kısa yolun bulunması ve ağdaki kopuklukların tespiti.Karmaşıklık: $O(V + E)$ (V: Düğüm, E: Kenar)Kod snippet'iflowchart TD
    A[Başla] --> B[Kuyruğa Başlangıç Düğümünü Ekle]
    B --> C{Kuyruk Boş mu?}
    C -- Evet --> D[Bitir]
    C -- Hayır --> E[Kuyruktan Çıkar ve Ziyaret Et]
    E --> F[Ziyaret Edilmemiş Komşuları Kuyruğa Ekle]
    F --> C
3.2. DFS (Depth-First Search) - Derin Öncelikli AramaMantık: Bir yola girer ve gidebildiği en son noktaya kadar ilerler (derinlemesine). Gidecek yer kalmadığında bir önceki düğüme geri döner (backtracking).Veri Yapısı: Stack (Yığın) yapısı kullanılır (veya rekürsif çağrı).Karmaşıklık: $O(V + E)$3.3. Dijkstra En Kısa Yol AlgoritmasıMantık: Ağırlıklı graflarda başlangıç noktasından diğer tüm noktalara olan en kısa mesafeyi hesaplar. "Greedy" (Açgözlü) yaklaşımını kullanır.Literatür: Edsger W. Dijkstra (1956).Karmaşıklık: $O(E + V \log V)$ (Priority Queue kullanıldığında).Kod snippet'iflowchart TD
    A[Başla] --> B[Mesafeleri Sonsuz Yap, Kaynak=0]
    B --> C{Ziyaret Edilmemiş Var mı?}
    C -- Hayır --> Z[Bitir ve Yolu Çiz]
    C -- Evet --> D[En Küçük Mesafeli Düğümü Seç (u)]
    D --> E[Komşuları (v) Gez]
    E --> F{Yeni Mesafe < Eski Mesafe?}
    F -- Evet --> G[Mesafeyi Güncelle (Relaxation)]
    F -- Hayır --> E
    G --> C
3.4. A* (A-Star) AlgoritmasıMantık: Dijkstra'nın optimize edilmiş halidir. Maliyet fonksiyonuna ($g(n)$) ek olarak, hedefe olan tahmini kuş uçuşu mesafeyi ($h(n)$ - Heuristic) de hesaba katar.Avantajı: Hedefe yönelik arama yaptığı için Dijkstra'dan daha az düğüm ziyaret eder.3.5. Welsh-Powell Graf RenklendirmeMantık: Komşu düğümlerin aynı renge sahip olmamasını sağlar (Kromatik Sayı). Düğümler derecelerine (bağlantı sayılarına) göre büyükten küçüğe sıralanır ve sırayla boyanır.Kullanım: Çizelgeleme ve kaynak yönetimi problemleri.🏗️ 4. Sistem Mimarisi ve OOP TasarımıProje, genişletilebilirliği sağlamak amacıyla Strategy Design Pattern kullanılarak geliştirilmiştir. Bu sayede algoritmalar ana koddan soyutlanmış, yeni bir algoritma eklemek için sadece ilgili interfacein implemente edilmesi yeterli hale gelmiştir.UML Sınıf DiyagramıKod snippet'iclassDiagram
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
📱 5. Uygulama, Testler ve Sonuçlar5.1. Arayüz ve GörselleştirmeUygulama arayüzü modern "Flat Design" prensiplerine göre tasarlanmıştır.Düğüm Yerleşimi: CSV yüklendiğinde düğümler panel üzerine Random Layout mantığıyla, üst üste binmeyi minimize edecek şekilde dağıtılır.Etkileşim: Mouse ile düğümlere tıklandığında detaylar (ID, İsim, Puan) görüntülenir.Görsel Geri Bildirim: Algoritmalar çalıştığında en kısa yol Yeşil, gezilen ancak seçilmeyen yollar Sarı veya Kırmızı ile boyanır.5.2. Performans Test TablosuUygulama içerisindeki algoritmaların çalışma süreleri System.Diagnostics.Stopwatch kullanılarak mikrosaniye hassasiyetinde ölçülmüştür.Algoritma15 Düğüm (Küçük Veri)50 Düğüm (Orta Veri)Analiz SonucuFloyd-Warshall8.00 ms185.40 ms$O(N^3)$ karmaşıklığı sebebiyle veri arttıkça süre katlanarak artmıştır.Degree Centrality5.00 ms18.50 msDoğrusal olmayan artış gözlemlendi.Dijkstra3.00 ms11.20 msStabil ve güvenilir performans sergiledi.*A (A-Star)**2.00 ms6.50 msHeuristic yaklaşım sayesinde Dijkstra'dan ~%40 daha hızlı çalıştı.DFS2.00 ms5.80 msRekürsif yapı küçük veride hızlı sonuç verdi.BFS0.06 ms0.25 msAğ gezintisi için en hızlı yöntem olduğu doğrulandı.Topluluk Analizi0.05 ms0.21 msGruplandırma işlemi oldukça optimize çalıştı.5.3. Test SenaryolarıSenaryo: Ayrık (bağlantısız) düğümlerin tespiti.Sonuç: "Topluluk Analizi" modülü ile ağdan kopuk 3 farklı grup tespit edildi ve raporlandı.Senaryo: En popüler kullanıcının bulunması.Sonuç: Merkeziyet analizi, en çok dış bağlantısı olan kullanıcıyı (ID:1) "Zirvedeki İsim" olarak belirledi.Senaryo: Hedef odaklı yol bulma.Sonuç: A* algoritması, hedefe olan uzaklığı tahmini olarak bildiği için gereksiz düğümleri gezmeden doğrudan sonuca ulaştı.🎯 6. Sonuç ve Tartışma6.1. Başarılar✅ Modülerlik: IGraphAlgorithm arayüzü sayesinde kod tekrarı önlenmiş ve SOLID prensiplerine tam uyum sağlanmıştır.✅ Kullanıcı Deneyimi: Kullanıcı, algoritmaların arka planda nasıl çalıştığını renk değişimleri ile canlı olarak izleyebilmektedir.✅ Hata Yönetimi: Hatalı CSV formatı veya geçersiz düğüm seçimlerinde programın çökmesi try-catch blokları ve validasyonlar ile engellenmiştir.6.2. Sınırlılıklar ve Geliştirme ÖnerileriÇok büyük veri setlerinde (10.000+ düğüm) GDI+ çizim kütüphanesi performans darboğazı (bottleneck) oluşturabilir. İlerleyen aşamalarda DirectX veya OpenGL kullanılabilir.Mevcut sürümde sadece yönlü (directed) graflar desteklenmektedir. Yönsüz (undirected) graf desteği eklenebilir.Verilerin kalıcılığı için yerel dosya sistemi yerine SQLite veya PostgreSQL veritabanı entegrasyonu yapılabilir.
