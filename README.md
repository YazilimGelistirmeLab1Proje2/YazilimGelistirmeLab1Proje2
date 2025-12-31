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
| **Teslim Tarihi** | 02.01.2026 | — |

---

## 📝 2. Giriş ve Problem Tanımı

### 2.1 Problemin Tanımı

Günümüz dünyasında sosyal ağlar, ulaşım ağları ve iletişim altyapıları milyonlarca düğüm (node) ve milyarlarca bağlantıdan (edge) oluşan karmaşık graf yapılarıdır. Bu büyüklükteki veri yapıları üzerinde;

- İki nokta arasındaki en kısa yol nedir?
- Ağdaki en merkezi / etkili düğüm hangisidir?
- Hangi düğümler bir topluluk oluşturmaktadır?

gibi soruların manuel yöntemlerle cevaplanması mümkün değildir. Bu tür problemlerin çözümü için **Graf Teorisi** tabanlı algoritmalara ihtiyaç duyulmaktadır.

---

### 2.2 Projenin Amacı

Bu projenin amacı, kullanıcılar arasındaki ilişkileri **Graf Modeli** üzerinde simüle eden ve analiz eden bir masaüstü uygulaması geliştirmektir.  

Uygulama;

- CSV / JSON veri okuma
- Graf görselleştirme
- BFS, DFS, Dijkstra, A*, Welsh-Powell algoritmalarını çalıştırma
- Analiz sonuçlarını raporlama

özelliklerini desteklemektedir.

---

## ⚙️ 3. Algoritmalar ve Analizler

### 3.1 BFS (Breadth-First Search) – Sığ Öncelikli Arama

**Çalışma Mantığı:**  
Başlangıç düğümünden itibaren tüm komşular katman katman ziyaret edilir. Kuyruk (Queue) veri yapısı kullanılır.

**Literatür:**  
Konrad Zuse (1945), E. F. Moore (1959)

**Zaman Karmaşıklığı:**  
\[
O(V + E)
\]

```mermaid
flowchart TD
    A[Başla] --> B[Kuyruğa başlangıç düğümünü ekle]
    B --> C{Kuyruk boş mu?}
    C -- Evet --> D[Bitir]
    C -- Hayır --> E[Kuyruktan çıkar ve ziyaret et]
    E --> F[Ziyaret edilmemiş komşuları kuyruğa ekle]
    F --> C
3.2 DFS (Depth-First Search) – Derin Öncelikli Arama
Çalışma Mantığı:
Bir yol boyunca en derine gidilir, gidilecek yer kalmayınca geri dönülür (backtracking). Stack veri yapısı kullanılır.

Literatür:
Charles Pierre Trémaux – 19. yüzyıl

Zaman Karmaşıklığı:

𝑂
(
𝑉
+
𝐸
)
O(V+E)
3.3 Dijkstra En Kısa Yol Algoritması
Çalışma Mantığı:
Ağırlıklı graflarda en kısa yolu bulur. Greedy yaklaşımı kullanır.

Literatür:
Edsger W. Dijkstra (1956)

Zaman Karmaşıklığı:

𝑂
(
𝐸
+
𝑉
log
⁡
𝑉
)
O(E+VlogV)
mermaid
Kodu kopyala
flowchart TD
    A[Başla] --> B[Mesafeleri sonsuz yap, kaynak = 0]
    B --> C{Ziyaret edilmemiş düğüm var mı?}
    C -- Hayır --> Z[Bitir]
    C -- Evet --> D[En küçük mesafeli düğümü seç]
    D --> E[Komşuları gez]
    E --> F{Yeni mesafe < eski mesafe?}
    F -- Evet --> G[Mesafeyi güncelle]
    F -- Hayır --> E
    G --> C
3.4 A* (A-Star) Algoritması
Çalışma Mantığı:
Dijkstra algoritmasına ek olarak sezgisel (heuristic) fonksiyon kullanır.

𝑓
(
𝑛
)
=
𝑔
(
𝑛
)
+
ℎ
(
𝑛
)
f(n)=g(n)+h(n)
Projede Öklid Mesafesi heuristic olarak kullanılmıştır.

Literatür:
Hart, Nilsson, Raphael (1968)

3.5 Welsh-Powell Graf Renklendirme
Çalışma Mantığı:
Komşu düğümlerin aynı renkte olmamasını sağlar. Düğümler dereceye göre sıralanır.

Zaman Karmaşıklığı:

𝑂
(
𝑉
2
)
O(V 
2
 )
🏗️ 4. Sistem Mimarisi ve OOP Tasarımı
Proje SOLID prensiplerine uygun olarak geliştirilmiştir.
Yeni algoritmaların kolay eklenebilmesi için Strategy Design Pattern kullanılmıştır.

Temel Sınıflar
UserNode: Kullanıcı bilgileri

Edge: İki düğüm arası bağlantı

Graph: Graf yapısı

IGraphAlgorithm: Algoritma arayüzü

FileManager: Dosya işlemleri

Dinamik Ağırlık Hesaplama
𝑊
𝑒
𝑖
𝑔
ℎ
𝑡
𝑖
,
𝑗
=
1
1
+
Δ
𝐴
𝑘
𝑡
𝑖
𝑓
𝑙
𝑖
𝑘
2
+
Δ
𝐸
𝑡
𝑘
𝑖
𝑙
𝑒
𝑠
\c
𝑖
𝑚
2
+
Δ
𝐵
𝑎
𝑔
˘
𝑙
𝑎
𝑛
𝑡
ı
2
Weight 
i,j
​
 = 
1+ 
ΔAktiflik 
2
 +ΔEtkile 
s
\c
​
 im 
2
 +ΔBa 
g
˘
​
 lantı 
2
 
​
 
1
​
 
mermaid
Kodu kopyala
classDiagram
    class UserNode {
        int Id
        string UserName
        double ActiveScore
        Point Location
    }

    class Edge {
        UserNode Source
        UserNode Target
        double Weight
    }

    class Graph {
        Dictionary Nodes
        AddNode()
        AddEdge()
    }

    class IGraphAlgorithm {
        <<interface>>
        Execute()
        GetResult()
    }

    IGraphAlgorithm <|.. BFS
    IGraphAlgorithm <|.. DFS
    IGraphAlgorithm <|.. Dijkstra
    IGraphAlgorithm <|.. WelshPowell
📱 5. Uygulama, Testler ve Sonuçlar
5.1 Uygulama Arayüzü
Uygulama modern ve kullanıcı dostu bir arayüz ile tasarlanmıştır.
Ekran görüntüleri screenshots/ klasöründe yer almaktadır.

5.2 Test Sonuçları
Test Ortamı: Intel i7 – 16GB RAM

Algoritma	15 Düğüm	50 Düğüm	Açıklama
BFS	0.06 ms	0.25 ms	En hızlı gezinme
DFS	2.00 ms	5.80 ms	Rekürsif yapı
Dijkstra	3.00 ms	11.20 ms	Stabil
A*	2.00 ms	6.50 ms	%40 daha hızlı
Welsh-Powell	0.08 ms	0.35 ms	Optimize

5.3 Örnek Senaryo – En Kısa Yol
Kaynak: ID 1
Hedef: ID 15

Sonuç Yol:

Kodu kopyala
1 → 4 → 9 → 15
Toplam Maliyet: 24 birim

🎯 6. Sonuç ve Tartışma
6.1 Başarılar
✅ Graf görselleştirme

✅ Genişletilebilir OOP mimarisi

✅ Yüksek performans

6.2 Sınırlılıklar
Çok büyük veri setlerinde çizim yavaşlayabilmektedir

Şu an sadece yönlü graflar desteklenmektedir

6.3 Olası Geliştirmeler
PostgreSQL / Neo4j entegrasyonu

Force-Directed Layout

Web tabanlı versiyon
