# 🕸️ Sosyal Ağ Analizi ve Görselleştirme Aracı (SNA Tool)

![License](https://img.shields.io/badge/License-MIT-blue.svg)
![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey)
![Language](https://img.shields.io/badge/Language-C%23-purple)
![IDE](https://img.shields.io/badge/IDE-Visual%20Studio-blue)

**Ders:** Yazılım Geliştirme Laboratuvarı - I  
**Dönem:** 2025-2026 Güz  
**Bölüm:** Kocaeli Üniversitesi - Bilişim Sistemleri Mühendisliği

---

## 📖 İçindekiler
- [Proje Hakkında](#-proje-hakkında)
- [Özellikler](#-özellikler)
- [Sistem Mimarisi (UML)](#-sistem-mimarisi-ve-oop-tasarımı)
- [Kullanılan Algoritmalar](#-algoritmalar-ve-analizler)
- [Performans Testleri](#-performans-testleri)
- [Kurulum ve Kullanım](#-kurulum-ve-kullanım)
- [Geliştiriciler](#-geliştiriciler)

---

## 📝 Proje Hakkında

Günümüz dünyasında sosyal ağlar (Facebook, Twitter, LinkedIn vb.) milyonlarca kullanıcı ve milyarlarca etkileşimden oluşan karmaşık yapılardır. Bu proje, bu devasa veri yığınlarını anlamlandırmak amacıyla geliştirilmiş **Nesneye Dayalı (OOP)** bir masaüstü analiz aracıdır.

**Temel Amaç:**
Kullanıcıları düğüm (node) ve aralarındaki etkileşimleri kenar (edge) olarak modelleyerek; en kısa yol analizi, merkeziyet ölçümü ve topluluk tespiti gibi Graf Teorisi problemlerini görselleştirerek çözmektir.

---

## ✨ Özellikler

* **Veri Görselleştirme:** CSV formatındaki verileri okuyarak düğüm ve kenarları dinamik olarak çizer.
* **Algoritma Simülasyonu:** Dijkstra, BFS, DFS, A* ve Welsh-Powell algoritmalarının çalışmasını renk kodlarıyla (Yeşil: En Kısa Yol, Sarı: Gezilen) canlı olarak gösterir.
* **İnteraktif Arayüz:** Düğümlere tıklayarak detaylı bilgi (ID, İsim, Puan) görüntüleme.
* **Hata Yönetimi:** Hatalı veri setlerine karşı validasyon ve try-catch mekanizmaları.
* **Genişletilebilir Mimari:** Strategy Design Pattern kullanımı sayesinde yeni algoritmalar kolayca eklenebilir.

---

## 🏗️ Sistem Mimarisi ve OOP Tasarımı

Proje, **Strategy Design Pattern** kullanılarak geliştirilmiştir. Bu sayede algoritma mantığı arayüzden soyutlanmıştır.

```mermaid
classDiagram
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
    class Dijkstra { +void Execute() }
    class BFS { +void Execute() }
    class WelshPowell { +void Execute() }
    class AStar { +void Execute() }
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

1. BFS (Sığ Öncelikli Arama) & DFS (Derin Öncelikli Arama)
BFS: Ağırlıksız graflarda en kısa yolu bulur. Dalga şeklinde yayılır. Karmaşıklık: O(V+E)
DFS: Bir yolda gidebildiği en son noktaya kadar gider (Backtracking).

flowchart TD
    A[Başla] --> B[Kuyruğa Başlangıç Düğümünü Ekle]
    B --> C{Kuyruk Boş mu?}
    C -- Evet --> D[Bitir]
    C -- Hayır --> E[Kuyruktan Çıkar ve Ziyaret Et]
    E --> F[Ziyaret Edilmemiş Komşuları Kuyruğa Ekle]
    F --> C

2. Dijkstra En Kısa Yol Algoritması
Ağırlıklı graflarda başlangıç noktasından diğer tüm noktalara olan en kısa mesafeyi hesaplar. "Greedy" (Açgözlü) yaklaşımını kullanır.Karmaşıklık: $O(E + V \log V)$
flowchart TD
    A[Başla] --> B[Mesafeleri Sonsuz Yap, Kaynak=0]
    B --> C{Ziyaret Edilmemiş Var mı?}
    C -- Hayır --> Z[Bitir ve Yolu Çiz]
    C -- Evet --> D[En Küçük Mesafeli Düğümü Seç (u)]
    D --> E[Komşuları (v) Gez]
    E --> F{Yeni Mesafe < Eski Mesafe?}
    F -- Evet --> G[Mesafeyi Güncelle]
    F -- Hayır --> E
    G --> C

3. A* (A-Star) Algoritması
Dijkstra'nın optimize edilmiş halidir. Maliyet fonksiyonuna ($g(n)$) ek olarak, hedefe olan tahmini kuş uçuşu mesafeyi ($h(n)$ - Heuristic) de hesaba katar.

4. Welsh-Powell Renklendirme
Komşu düğümlerin aynı renge sahip olmamasını sağlar (Kromatik Sayı). Kaynak yönetimi problemlerinde kullanılır.
