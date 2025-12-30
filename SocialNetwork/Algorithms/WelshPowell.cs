using SocialNetworkAnalysis.Model;
using System;
using System.Collections.Generic;
using System.Drawing; // Renkler için
using System.Linq;
using System.Text;

namespace SocialNetworkAnalysis.Algorithms
{
    public class WelshPowell : IGraphAlgorithm
    {
        public string Name => "Welsh-Powell Renklendirme";
        private StringBuilder _resultLog = new StringBuilder();

        // Renk Paleti
        private readonly List<Color> _palette = new List<Color>
        {
            Color.Red, Color.Blue, Color.Green, Color.Orange,
            Color.Purple, Color.Cyan, Color.Magenta, Color.Brown,
            Color.Teal, Color.Lime, Color.Pink, Color.Gold
        };

        // Interface gereği Execute, ama startNode/endNode kullanmayacağız.
        public void Execute(Graph graph, UserNode startNode = null, UserNode endNode = null)
        {
            _resultLog.Clear();
            _resultLog.AppendLine("🎨 WELSH-POWELL RENKLENDİRME RAPORU");
            _resultLog.AppendLine("------------------------------------");

            if (graph == null || graph.Nodes.Count == 0)
            {
                _resultLog.AppendLine("Graf boş, boyama yapılamadı.");
                return;
            }

            // 1. SIRALAMA: Derecesi (Komşu Sayısı) en yüksekten düşüğe
            var sortedNodes = graph.Nodes.Values
                                   .OrderByDescending(n => n.OutgoingEdges.Count)
                                   .ToList();

            // Önce herkesi renksiz (Beyaz) yap
            foreach (var node in sortedNodes) node.UserNodeColor = Color.White;

            int colorIndex = 0;
            int totalColorsUsed = 0;

            // 2. RENKLENDİRME DÖNGÜSÜ
            while (sortedNodes.Any(n => n.UserNodeColor == Color.White))
            {
                // Rengi seç
                Color currentColor = (colorIndex < _palette.Count) ? _palette[colorIndex] : GetRandomColor();
                string colorName = GetColorName(currentColor); // Rengin adını bul (Rapor için)

                List<string> dyedUsers = new List<string>(); // Bu turda boyananları listele

                foreach (var node in sortedNodes)
                {
                    // Zaten boyandıysa geç
                    if (node.UserNodeColor != Color.White) continue;

                    // Komşularda bu renk var mı? (Çatışma Kontrolü)
                    bool isSafe = true;
                    foreach (var edge in node.OutgoingEdges)
                    {
                        if (edge.Target.UserNodeColor == currentColor)
                        {
                            isSafe = false;
                            break;
                        }
                    }

                    // Güvenliyse boya
                    if (isSafe)
                    {
                        node.UserNodeColor = currentColor;
                        dyedUsers.Add(node.UserName);
                    }
                }

                // Rapora Ekle (İster 3.2'deki "Tablo" maddesi)
                if (dyedUsers.Count > 0)
                {
                    totalColorsUsed++;
                    _resultLog.AppendLine($"🖌️ {colorName}: {string.Join(", ", dyedUsers)}");
                }

                colorIndex++;
            }

            _resultLog.AppendLine("------------------------------------");
            _resultLog.AppendLine($"Toplam Kullanılan Renk Sayısı (Kromatik Sayı): {totalColorsUsed}");
        }

        public string GetResult()
        {
            return _resultLog.ToString();
        }

        // --- YARDIMCI METOTLAR ---

        private Color GetRandomColor()
        {
            Random rnd = new Random();
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        // Rengin adını bulmak için basit bir yardımcı
        private string GetColorName(Color c)
        {
            if (c == Color.Red) return "Kırmızı";
            if (c == Color.Blue) return "Mavi";
            if (c == Color.Green) return "Yeşil";
            if (c == Color.Orange) return "Turuncu";
            if (c == Color.Purple) return "Mor";
            return c.ToString(); // Bilinmeyen renkse kodunu yaz
        }
    }
}