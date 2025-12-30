using SocialNetworkAnalysis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Algorithms
{
    public class WelshPowell
    {
        private readonly List<Color> _palette = new List<Color>
        {
            Color.Red, Color.Blue, Color.Green, Color.Orange,
            Color.Purple, Color.Cyan, Color.Magenta, Color.Brown,
            Color.Teal, Color.Lime, Color.Pink, Color.Gold
        };

        public void ColorGraph(Graph graph)
        {
            // Welsh-Powell'ın kuralı budur: En çok komşusu olandan başla.
            var sortedNodes = graph.Nodes.Values
                                   .OrderByDescending(n => n.OutgoingEdges.Count)
                                   .ToList();

            // Tüm düğümlerin rengini sıfirla

            foreach (var node in sortedNodes) node.UserNodeColor = Color.White;

            int colorIndex = 0;

            // 2. Renklendirme Döngüsü
            // Hala renksiz (beyaz) düğüm olduğu sürece devam et
            while (sortedNodes.Any(n => n.UserNodeColor == Color.White))
            {
                // Paletten sıradaki rengi seç (Eğer renk biterse başa dön veya Rastgele üret)
                Color currentColor;
                if (colorIndex < _palette.Count)
                    currentColor = _palette[colorIndex];
                else
                    currentColor = GetRandomColor(); // Yedek plan

                // Bu turda boyayacağımız düğümleri tutan liste
                List<UserNode> coloredInThisRound = new List<UserNode>();

                // Sıralı listedeki her düğümü kontrol et
                foreach (var node in sortedNodes)
                {
                    // Eğer düğüm zaten boyanmışsa geç
                    if (node.UserNodeColor != Color.White) continue;

                    // KRİTİK KONTROL:
                    // Bu düğümün, ŞU ANKİ RENGE boyanmış bir komşusu var mı?
                    bool isSafe = true;

                    // Hem mevcut komşularına bak, hem de bu turda boyadıklarımıza bak
                    foreach (var edge in node.OutgoingEdges)
                    {
                        if (edge.Target.UserNodeColor == currentColor)
                        {
                            isSafe = false;
                            break;
                        }
                    }

                    // Eğer komşularda bu renk yoksa, boya gitsin!
                    if (isSafe)
                    {
                        node.UserNodeColor = currentColor;
                        coloredInThisRound.Add(node);
                    }
                }

                // Bir sonraki renge geç
                colorIndex++;
            }
        }

        // Renk yetmezse rastgele renk üreten yardımcı metot
        private Color GetRandomColor()
        {
            System.Random rnd = new System.Random();
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }
    }
}