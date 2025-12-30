using SocialNetworkAnalysis.Model;
using System;
using System.Collections.Generic;
using System.Drawing; // Renkler için (System.Drawing referansı ekli olmalı)
using System.Text;
using System.Diagnostics; // Kronometre için

namespace SocialNetworkAnalysis.Algorithms
{
    public class AStar : IGraphAlgorithm
    {
        public string Name => "A* (A-Star) Algoritması";
        private StringBuilder _resultLog = new StringBuilder();

        public void Execute(Graph graph, UserNode startNode, UserNode endNode = null)
        {
            _resultLog.Clear();

            if (startNode == null || endNode == null)
            {
                _resultLog.AppendLine("Hata: A* için hem Başlangıç hem Bitiş düğümü gereklidir.");
                return;
            }

            // 1. KRONOMETRE BAŞLAT ⏱️
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // 2. GÖRSEL TEMİZLİK (Herkesi Maviye Döndür)
            foreach (var node in graph.Nodes.Values)
            {
                node.UserNodeColor = Color.CornflowerBlue;
            }

            // --- SENİN ALGORİTMA MANTIĞIN ---
            var openSet = new List<UserNode> { startNode };
            var cameFrom = new Dictionary<int, UserNode>();
            var gScore = new Dictionary<int, double>();
            var fScore = new Dictionary<int, double>();

            // Başlangıç değerleri (Sonsuz)
            foreach (var node in graph.Nodes.Values)
            {
                gScore[node.Id] = double.MaxValue;
                fScore[node.Id] = double.MaxValue;
            }

            gScore[startNode.Id] = 0;
            fScore[startNode.Id] = Heuristic(startNode, endNode);

            while (openSet.Count > 0)
            {
                // fScore en düşük olanı seç
                openSet.Sort((a, b) => fScore[a.Id].CompareTo(fScore[b.Id]));
                UserNode current = openSet[0];

                // HEDEFE ULAŞILDI MI? 🎉
                if (current.Id == endNode.Id)
                {
                    ReconstructPath(cameFrom, current, startNode);

                    sw.Stop(); // Süreyi durdur
                    _resultLog.AppendLine($"--------------------------");
                    _resultLog.AppendLine($"Toplam Maliyet: {gScore[current.Id]:F2}");
                    _resultLog.AppendLine($"Çalışma Süresi: {sw.Elapsed.TotalMilliseconds} ms");
                    return;
                }

                openSet.Remove(current);

                if (current.OutgoingEdges != null)
                {
                    foreach (var edge in current.OutgoingEdges)
                    {
                        UserNode neighbor = edge.Target;
                        double tentativeGScore = gScore[current.Id] + edge.Weight;

                        if (tentativeGScore < gScore[neighbor.Id])
                        {
                            cameFrom[neighbor.Id] = current;
                            gScore[neighbor.Id] = tentativeGScore;
                            fScore[neighbor.Id] = gScore[neighbor.Id] + Heuristic(neighbor, endNode);

                            if (!openSet.Contains(neighbor))
                                openSet.Add(neighbor);
                        }
                    }
                }
            }

            // Yol bulunamadıysa
            sw.Stop();
            _resultLog.AppendLine("Hedefe giden bir yol bulunamadı.");
        }

        // --- YARDIMCI METOTLAR ---

        // Senin yazdığın Heuristic (Pisagor) mantığı aynen korundu
        private double Heuristic(UserNode a, UserNode b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        // Yolu Geriye Doğru Oluşturma ve BOYAMA 🎨
        private void ReconstructPath(Dictionary<int, UserNode> cameFrom, UserNode current, UserNode startNode)
        {
            var path = new List<UserNode>();
            path.Add(current);

            while (cameFrom.ContainsKey(current.Id))
            {
                current = cameFrom[current.Id];
                path.Add(current);
            }
            path.Reverse(); // Başlangıçtan bitişe sırala

            _resultLog.AppendLine("En Kısa Yol (A*):");
            foreach (var node in path)
            {
                // Görselleştirme: Yolu KIRMIZI yap
                node.UserNodeColor = Color.Red;
                _resultLog.Append($"{node.UserName} -> ");
            }
            _resultLog.AppendLine("BİTİŞ");
        }

        public string GetResult()
        {
            return _resultLog.ToString();
        }
    }
}