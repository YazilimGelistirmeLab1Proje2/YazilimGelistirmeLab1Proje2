using SocialNetworkAnalysis.Model;
using System.Collections.Generic;
using System.Drawing; // Renkler için bunu eklemeyi unutma!
using System.Text;

namespace SocialNetworkAnalysis.Algorithms
{
    public class BFS : IGraphAlgorithm
    {
        // Interface özelliği
        public string Name => "Breadth-First Search (BFS)";

        // Sonuçları tutan değişken
        private StringBuilder _resultLog = new StringBuilder();

        public void Execute(Graph graph, UserNode startNode, UserNode endNode = null)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            _resultLog.Clear();

            if (startNode == null)
            {
                _resultLog.AppendLine("Hata: Başlangıç düğümü seçilmedi.");
                return;
            }

           
            if (graph != null)
            {
                foreach (var node in graph.Nodes.Values)
                {
                    node.UserNodeColor = Color.CornflowerBlue;
                }
            }
            Queue<UserNode> queue = new Queue<UserNode>();
            HashSet<int> visited = new HashSet<int>();

            startNode.UserNodeColor = Color.DarkOrange;

            queue.Enqueue(startNode);
            visited.Add(startNode.Id);

            _resultLog.AppendLine($"BFS Başlatıldı. Kök Düğüm: {startNode.UserName} (ID: {startNode.Id})");

            while (queue.Count > 0)
            {
                UserNode currentUser = queue.Dequeue();

                _resultLog.AppendLine($"-> Ziyaret Edildi: {currentUser.UserName}");

                if (currentUser.OutgoingEdges != null)
                {
                    foreach (var edge in currentUser.OutgoingEdges)
                    {
                        UserNode neighbor = edge.Target;

                        if (!visited.Contains(neighbor.Id))
                        {
                            visited.Add(neighbor.Id);
                            queue.Enqueue(neighbor);

                            neighbor.UserNodeColor = Color.Orange;
                        }
                    }
                }
            }
            sw.Stop();
            _resultLog.AppendLine($"--------------------------");
            _resultLog.AppendLine($"Çalışma Süresi: {sw.Elapsed.TotalMilliseconds} ms");
            _resultLog.AppendLine($"Adım Sayısı (Gezilen): {visited.Count}");

            _resultLog.AppendLine("Arama tamamlandı.");
        }

        public string GetResult()
        {
            return _resultLog.ToString();
        }
    }
}