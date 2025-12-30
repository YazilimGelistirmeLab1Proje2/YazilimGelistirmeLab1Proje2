using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SocialNetworkAnalysis.Model
{
    public class Graph
    {
        public Dictionary<int, UserNode> Nodes { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph()
        {
            Nodes = new Dictionary<int, UserNode>();
            Edges = new List<Edge>();
        }
        public void AddNode(UserNode node)
        {
            if (!Nodes.ContainsKey(node.Id))
            {
                Nodes[node.Id] = node;
            }
        }
        public void AddEdge(int sourceId, int targetId)
        {
            // SelfLoop kontrolü
            if (sourceId == targetId) return;

            // Kaynak ve hedef düğümlerin varlığını kontrol et
            if (Nodes.ContainsKey(sourceId) && Nodes.ContainsKey(targetId))
            {
                UserNode source = Nodes[sourceId];
                UserNode target = Nodes[targetId];

                // 2. KONTROL: Zaten böyle bir bağ var mı? (Duplicate Check)
                // Eğer kaynak düğümün giden kenarları arasında bu hedef varsa, işlem yapma çık.
                // (System.Linq kütüphanesi gereklidir: using System.Linq;)
                if (source.OutgoingEdges.Any(e => e.Target.Id == targetId))
                {
                    return;
                }

                // 1. Edge nesnelerini oluştur (Ağırlık otomatik hesaplanır)
                Edge edgeForward = new Edge(source, target);
                Edge edgeBackward = new Edge(target, source);

                // Ana listeye sadece birini eklemek yeterli (Çizim yaparken üst üste 2 çizgi olmasın diye
                Edges.Add(edgeForward);

                // 2. Düğümlerin KENDİ listelerine ekle (Burası algoritma için şart)
                source.OutgoingEdges.Add(edgeForward);
                target.OutgoingEdges.Add(edgeBackward);
            }
        }
    }
}
