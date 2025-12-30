using SocialNetworkAnalysis.Model;
using System.Collections.Generic;
using System.Drawing; // Renkler için
using System.Text;
using System.Diagnostics; // Stopwatch için

namespace SocialNetworkAnalysis.Algorithms
{
    public class Dijkstra : IGraphAlgorithm
    {
        public string Name => "Dijkstra En Kısa Yol";
        private StringBuilder _resultLog = new StringBuilder();

        public void Execute(Graph graph, UserNode startNode, UserNode endNode = null)
        {
            _resultLog.Clear();

            // 1. KONTROLLER
            if (startNode == null || endNode == null)
            {
                _resultLog.AppendLine("Hata: Dijkstra için hem Başlangıç hem Bitiş düğümü seçilmelidir.");
                return;
            }

            // 2. KRONOMETRE BAŞLAT ⏱️
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // 3. GÖRSEL TEMİZLİK (Herkesi Mavi Yap)
            foreach (var node in graph.Nodes.Values)
            {
                node.UserNodeColor = Color.CornflowerBlue;
            }

            // --- ALGORİTMA MOTORU (Senin Kodun) ---
            var distances = new Dictionary<int, double>();
            var previous = new Dictionary<int, UserNode>();
            var unvisited = new List<UserNode>();

            foreach (var node in graph.Nodes.Values)
            {
                distances[node.Id] = double.MaxValue;
                unvisited.Add(node);
            }

            distances[startNode.Id] = 0;

            while (unvisited.Count > 0)
            {
                // En kısa mesafeli düğümü seç
                unvisited.Sort((x, y) => distances[x.Id].CompareTo(distances[y.Id]));
                UserNode current = unvisited[0];
                unvisited.Remove(current);

                if (current.Id == endNode.Id) break; // Hedefe vardık
                if (distances[current.Id] == double.MaxValue) break; // Geri kalanı erişilemez

                if (current.OutgoingEdges != null)
                {
                    foreach (var edge in current.OutgoingEdges)
                    {
                        UserNode neighbor = edge.Target;

                        // Sadece ziyaret edilmemişleri güncelle
                        if (unvisited.Contains(neighbor))
                        {
                            double newDist = distances[current.Id] + edge.Weight;

                            if (newDist < distances[neighbor.Id])
                            {
                                distances[neighbor.Id] = newDist;
                                previous[neighbor.Id] = current;
                            }
                        }
                    }
                }
            }

            // 4. YOLU OLUŞTUR VE BOYAMA YAP 🎨
            var path = new List<UserNode>();
            UserNode curr = endNode;

            if (distances[endNode.Id] != double.MaxValue)
            {
                while (curr != null && previous.ContainsKey(curr.Id))
                {
                    path.Add(curr);
                    curr = previous[curr.Id];
                }
                path.Add(startNode);
                path.Reverse();

                // Yolu Yeşil Boya ve Rapora Ekle
                _resultLog.AppendLine($"En Kısa Yol Bulundu! Maliyet: {distances[endNode.Id]:F2}");
                _resultLog.AppendLine("Güzergah:");

                foreach (var node in path)
                {
                    node.UserNodeColor = Color.LimeGreen; // Yolu Parlak Yeşil Yap
                    _resultLog.Append($"{node.UserName} -> ");
                }
                _resultLog.AppendLine("BİTİŞ");
            }
            else
            {
                _resultLog.AppendLine("Hedefe ulaşılabilir bir yol yok.");
            }

            // 5. KRONOMETRE DURDUR 🛑
            sw.Stop();
            _resultLog.AppendLine($"--------------------------");
            _resultLog.AppendLine($"Çalışma Süresi: {sw.Elapsed.TotalMilliseconds} ms");
        }

        public string GetResult()
        {
            return _resultLog.ToString();
        }
    }
}