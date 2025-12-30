using SocialNetworkAnalysis.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SocialNetworkAnalysis.Algorithms
{
    public class DFS : IGraphAlgorithm
    {
        // Interface özelliği
        public string Name => "Depth-First Search (DFS)";

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

            // DFS için Stack kullanılır (Son giren ilk çıkar - LIFO)
            Stack<UserNode> stack = new Stack<UserNode>();
            HashSet<int> visited = new HashSet<int>();

            stack.Push(startNode);

            _resultLog.AppendLine($"DFS Başlatıldı. Kök: {startNode.UserName}");

            while (stack.Count > 0)
            {
                UserNode currentUser = stack.Pop();

                // Stack yapısında aynı düğüm birden fazla kez stack'e girebilir.
                // Bu yüzden pop ettikten sonra "Daha önce geldik mi?" diye bakmak şarttır.
                if (!visited.Contains(currentUser.Id))
                {
                    visited.Add(currentUser.Id);

                   
                    if (currentUser.Id == startNode.Id)
                        currentUser.UserNodeColor = Color.DarkViolet;
                    else
                        currentUser.UserNodeColor = Color.MediumPurple;

                    _resultLog.AppendLine($"-> Ziyaret Edildi: {currentUser.UserName}");

                    
                    foreach (var edge in currentUser.OutgoingEdges)
                    {
                        if (!visited.Contains(edge.Target.Id))
                        {
                            stack.Push(edge.Target);
                        }
                    }
                }
            }
            sw.Stop();
            _resultLog.AppendLine($"--------------------------");
            _resultLog.AppendLine($"Çalışma Süresi: {sw.Elapsed.TotalMilliseconds} ms");
            _resultLog.AppendLine($"Adım Sayısı (Gezilen): {visited.Count}");

            _resultLog.AppendLine("Derinlemesine arama tamamlandı.");
        }

        public string GetResult()
        {
            return _resultLog.ToString();
        }
    }
}