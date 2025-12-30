using SocialNetwork.Algorithms;
using SocialNetworkAnalysis.Algorithms;
using SocialNetworkAnalysis.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace SocialNetwork
{
    public partial class Form1 : Form
    {
        Graph graph;
        UserNode selectedNodeForUpdate = null;

        // En kısa yolu tutacak liste
        List<UserNode> shortestPath = null;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            pnlGraph.MouseClick += new MouseEventHandler(pnlGraph_MouseClick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // --- CSV YÜKLE ---
        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Dosyaları|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileManager fm = new FileManager();
                    graph = fm.LoadGraphFromCSV(ofd.FileName);
                    if (graph != null)
                    {
                        MessageBox.Show($"Yüklendi: {graph.Nodes.Count} Kişi");
                        shortestPath = null;
                        pnlGraph.Invalidate();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            }
        }

       
        private void btnCentrality_Click(object sender, EventArgs e)
        {
            if (graph == null)
            {
                MessageBox.Show("Önce CSV yükle!");
                return;
            }

            Centrality c = new Centrality();

            
            var best = c.FindMostPopularUser(graph);
            if (best != null)
            {
                MessageBox.Show($"👑 Zirvedeki İsim: {best.UserName}\n🔗 Bağlantı Sayısı: {best.ConnectionCount}");
            }

            
            var top5List = graph.Nodes.Values
                                .OrderByDescending(node => node.ConnectionCount) 
                                .Take(5) 
                                .Select(node => new
                                {
                                    ID = node.Id,
                                    İsim = node.UserName,
                                    BağlantıSayısı = node.ConnectionCount,
                                    AktiflikPuanı = node.ActiveScore
                                })
                                .ToList();

            
            gridTop5.DataSource = top5List;
        }

        
        private void btnDijkstra_Click(object sender, EventArgs e)
        {
            if (graph == null) return;

            
            bool startOk = int.TryParse(txtStart.Text, out int startId);
            bool endOk = int.TryParse(txtEnd.Text, out int endId);

            if (startOk && endOk && graph.Nodes.ContainsKey(startId) && graph.Nodes.ContainsKey(endId))
            {
                UserNode startNode = graph.Nodes[startId];
                UserNode endNode = graph.Nodes[endId];

                
                IGraphAlgorithm dijkstra = new Dijkstra();
                dijkstra.Execute(graph, startNode, endNode);

                
                pnlGraph.Invalidate();

               
                MessageBox.Show(dijkstra.GetResult(), dijkstra.Name);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir Başlangıç ve Bitiş ID'si girin.");
            }
        }

        
        private void pnlGraph_Paint(object sender, PaintEventArgs e)
        {
            if (graph == null) return;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            
            using (Pen edgePen = new Pen(Color.LightGray, 2))
            {
                foreach (var edge in graph.Edges)
                {
                    Point p1 = new Point(edge.Source.X, edge.Source.Y);
                    Point p2 = new Point(edge.Target.X, edge.Target.Y);
                    g.DrawLine(edgePen, p1, p2);
                }
            }

           
            if (shortestPath != null && shortestPath.Count > 1)
            {
                using (Pen pathPen = new Pen(Color.Red, 4))
                {
                    for (int i = 0; i < shortestPath.Count - 1; i++)
                    {
                        UserNode u1 = shortestPath[i];
                        UserNode u2 = shortestPath[i + 1];
                        g.DrawLine(pathPen, new Point(u1.X, u1.Y), new Point(u2.X, u2.Y));
                    }
                }
            }

            
            int r = 15;
            foreach (var node in graph.Nodes.Values)
            {
                Rectangle rect = new Rectangle(node.X - r, node.Y - r, 2 * r, 2 * r);

             
                Color nodeColor = (shortestPath != null && shortestPath.Contains(node)) ? Color.Red : node.UserNodeColor;

                using (Brush brush = new SolidBrush(nodeColor)) g.FillEllipse(brush, rect);
                g.DrawEllipse(Pens.Black, rect);

                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(node.Id.ToString(), new Font("Arial", 8, FontStyle.Bold), Brushes.White, rect, sf);
                g.DrawString(node.UserName, SystemFonts.DefaultFont, Brushes.Black, node.X - 20, node.Y + r + 2);
            }
        }

        
        private void txtStart_TextChanged(object sender, EventArgs e) { }
        private void txtEnd_TextChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void pnlGraph_MouseClick(object sender, MouseEventArgs e)
        {
            if (graph == null) return;

            // Tıklanan koordinat
            int mouseX = e.X;
            int mouseY = e.Y;
            int radius = 15; 

            
            selectedNodeForUpdate = null;

            foreach (var node in graph.Nodes.Values)
            {
               
                double distance = Math.Sqrt(Math.Pow(mouseX - node.X, 2) + Math.Pow(mouseY - node.Y, 2));

                if (distance <= radius) 
                {
                    
                    selectedNodeForUpdate = node; 

                   
                    txtUpdateName.Text = node.UserName;
                    txtUpdateActive.Text = node.ActiveScore.ToString();

                   
                    string info = $"🆔 ID: {node.Id}\n" +
                                  $"👤 İsim: {node.UserName}\n" +
                                  $"🔥 Aktiflik: {node.ActiveScore}\n" +
                                  $"💬 Etkileşim: {node.InteractionCount}\n" +
                                  $"🔗 Bağlantı Skoru: {node.ConnectionCount}\n" +
                                  $"🌐 Komşu Sayısı: {node.OutgoingEdges.Count}";

                    
                    MessageBox.Show(info, "Düğüm Detayları", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return; 
                }
            }
        }

        private void btnAStar_Click(object sender, EventArgs e)
        {
            if (graph == null) return;

           
            bool startOk = int.TryParse(txtStart.Text, out int startId);
            bool endOk = int.TryParse(txtEnd.Text, out int endId);

            if (startOk && endOk && graph.Nodes.ContainsKey(startId) && graph.Nodes.ContainsKey(endId))
            {
               
                IGraphAlgorithm astar = new AStar();
                astar.Execute(graph, graph.Nodes[startId], graph.Nodes[endId]);

               
                pnlGraph.Invalidate();

              
                MessageBox.Show(astar.GetResult(), "A* Algoritması Sonucu");
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir Başlangıç ve Bitiş ID'si girin.");
            }
        }

        private void btnBFS_Click(object sender, EventArgs e)
        {
            if (graph == null)
            {
                MessageBox.Show("Lütfen önce bir CSV yükleyin veya düğüm ekleyin.");
                return;
            }

            if (int.TryParse(txtStart.Text, out int startId) && graph.Nodes.ContainsKey(startId))
            {
                UserNode startNode = graph.Nodes[startId];

                IGraphAlgorithm bfs = new BFS();


                bfs.Execute(graph, startNode);


                pnlGraph.Invalidate();


                MessageBox.Show(bfs.GetResult(), bfs.Name);
            }
            else
            {
                MessageBox.Show("Lütfen 'Start' kutusuna geçerli bir Başlangıç ID'si girin.");
            }
        }

        private void btnDFS_Click(object sender, EventArgs e)
        {
            if (graph == null)
            {
                MessageBox.Show("Önce graf oluşturun veya dosya yükleyin.");
                return;
            }

            if (int.TryParse(txtStart.Text, out int startId) && graph.Nodes.ContainsKey(startId))
            {
                UserNode startNode = graph.Nodes[startId];

                IGraphAlgorithm dfs = new DFS();

                dfs.Execute(graph, startNode);

                pnlGraph.Invalidate();


                MessageBox.Show(dfs.GetResult(), dfs.Name);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir Başlangıç ID'si girin.");
            }
        }

        private void btnColoring_Click(object sender, EventArgs e)
        {
            if (graph == null)
            {
                MessageBox.Show("Önce CSV yükle veya graf oluştur!");
                return;
            }

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            // Performans analizi (ms) baslatiliyor.
            sw.Start();

           
            IGraphAlgorithm wp = new WelshPowell();

            
            wp.Execute(graph, null, null);

            sw.Stop();

            
            
            pnlGraph.Invalidate();

           
            string finalReport = wp.GetResult();
            finalReport += $"\n⏱️ Hesaplama Süresi: {sw.Elapsed.TotalMilliseconds} ms";

            MessageBox.Show(finalReport, "Welsh-Powell Renklendirme Tablosu");
        }

        private void gridTop5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (graph == null) graph = new Graph();

            Random rnd = new Random();

            // Yeni ID belirle
            int newId = (graph.Nodes.Count > 0) ? graph.Nodes.Keys.Max() + 1 : 1;

            // Yeni düğümü oluştur
            UserNode newNode = new UserNode
            {
                Id = newId,
                UserName = "User " + newId,
                ActiveScore = Math.Round(rnd.NextDouble(), 2), // 0.0 - 1.0 arası
                InteractionCount = rnd.Next(10, 100),
                ConnectionCount = rnd.Next(1, 50),
                X = rnd.Next(50, pnlGraph.Width - 50),
                Y = rnd.Next(50, pnlGraph.Height - 50),
                UserNodeColor = Color.Green
            };

            // Sadece listeye ekle, bağlantı yapma!
            graph.Nodes.Add(newId, newNode);

            pnlGraph.Invalidate();
            MessageBox.Show($"{newNode.UserName} eklendi. (Henüz kimseye bağlı değil)");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (graph == null) return;

            // Silinecek ID'yi "Start" kutusundan okuyalım (Pratik olsun)
            if (int.TryParse(txtStart.Text, out int idToDelete))
            {
                if (graph.Nodes.ContainsKey(idToDelete))
                {
                    // 1. Düğümü sil
                    graph.Nodes.Remove(idToDelete);

                    // 2. KRİTİK: Bu düğüme bağlı olan tüm KENARLARI (Çizgileri) da silmeliyiz!
                    // Yoksa olmayan bir düğüme çizgi çizmeye çalışır ve program patlar.

                    // a) Ana listedeki kenarları temizle
                    graph.Edges.RemoveAll(edge => edge.Source.Id == idToDelete || edge.Target.Id == idToDelete);

                    // b) Diğer düğümlerin "Giden Kenarlar" listesinden temizle
                    foreach (var node in graph.Nodes.Values)
                    {
                        node.OutgoingEdges.RemoveAll(edge => edge.Target.Id == idToDelete);
                    }

                    // Ekranı güncelle
                    pnlGraph.Invalidate();
                    MessageBox.Show($"ID: {idToDelete} başarıyla silindi.");
                }
                else
                {
                    MessageBox.Show("Bu ID'ye sahip kullanıcı bulunamadı.");
                }
            }
            else
            {
                MessageBox.Show("Silmek istediğiniz kişinin ID'sini 'Start' kutusuna yazın.");
            }
        }

        private void btnEdgeEkle_Click(object sender, EventArgs e)
        {
            if (graph == null) return;

            // 1. Kutulardaki ID'leri al (Dijkstra için koyduğun kutular)
            if (int.TryParse(txtStart.Text, out int id1) && int.TryParse(txtEnd.Text, out int id2))
            {
                // Kendine bağlanamaz
                if (id1 == id2) { MessageBox.Show("Kişi kendine bağlanamaz!"); return; }

                // Düğümler var mı?
                if (graph.Nodes.ContainsKey(id1) && graph.Nodes.ContainsKey(id2))
                {
                    UserNode u1 = graph.Nodes[id1];
                    UserNode u2 = graph.Nodes[id2];

                    // Zaten bağlılar mı? Kontrol et
                    bool alreadyConnected = u1.OutgoingEdges.Any(edge => edge.Target.Id == id2);
                    if (alreadyConnected)
                    {
                        MessageBox.Show("Bu iki kişi zaten bağlı!");
                        return;
                    }

                    // 2. AĞIRLIK HESAPLA (İster 4.3 Formülü Şart!)
                    // Formül: 1 / (1 + ÖklidUzaklığı)

                    double diffActive = Math.Pow(u1.ActiveScore - u2.ActiveScore, 2);
                    double diffInteract = Math.Pow(u1.InteractionCount - u2.InteractionCount, 2);
                    double diffConnect = Math.Pow(u1.ConnectionCount - u2.ConnectionCount, 2);

                    double euclidean = Math.Sqrt(diffActive + diffInteract + diffConnect);
                    double weight = 1.0 / (1.0 + euclidean);

                    // 3. Kenarları Ekle (Yönsüz olduğu için çift taraflı)

                    // U1 -> U2
                    Edge edge1 = new Edge { Source = u1, Target = u2, Weight = weight };
                    u1.OutgoingEdges.Add(edge1);
                    graph.Edges.Add(edge1);

                    // U2 -> U1
                    Edge edge2 = new Edge { Source = u2, Target = u1, Weight = weight };
                    u2.OutgoingEdges.Add(edge2);
                    graph.Edges.Add(edge2);

                    pnlGraph.Invalidate();
                    MessageBox.Show($"Bağlantı kuruldu!\nHesaplanan Ağırlık: {weight:F4}");
                }
                else
                {
                    MessageBox.Show("Girilen ID'lerden biri veya ikisi bulunamadı.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Start ve End kutularına bağlanacak ID'leri yazın.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (graph == null) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Dosyaları|*.csv";
            sfd.FileName = "UpdatedNetwork.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // CSV Başlık Satırı
                List<string> lines = new List<string>();
                lines.Add("DugumId;Aktiflik;Etkilesim;BaglantiSayisi;Komsular");

                foreach (var node in graph.Nodes.Values)
                {
                    // Komşuları bul ve virgülle birleştir (Ör: "2,3,5")
                    // Not: Edge sınıfında Target (Hedef) bizim komşumuzdur.
                    var neighborIds = node.OutgoingEdges.Select(edge => edge.Target.Id.ToString());
                    string neighborsStr = string.Join(",", neighborIds);

                    // Satırı oluştur
                    string line = $"{node.Id};{node.ActiveScore.ToString(System.Globalization.CultureInfo.InvariantCulture)};" +
                                  $"{node.InteractionCount};{node.ConnectionCount};{neighborsStr}";

                    lines.Add(line);
                }

                // Dosyayı yaz
                System.IO.File.WriteAllLines(sfd.FileName, lines);
                MessageBox.Show("Veriler başarıyla kaydedildi!");
            }
        }

        private void btnEdgeSil_Click(object sender, EventArgs e)
        {
            if (graph == null) return;

            if (int.TryParse(txtStart.Text, out int id1) && int.TryParse(txtEnd.Text, out int id2))
            {
                if (graph.Nodes.ContainsKey(id1) && graph.Nodes.ContainsKey(id2))
                {
                    UserNode u1 = graph.Nodes[id1];
                    UserNode u2 = graph.Nodes[id2];

                    // 1. U1'den U2'ye giden kenarı bul ve sil
                    int removedCount = u1.OutgoingEdges.RemoveAll(edge => edge.Target.Id == id2);

                    // 2. U2'den U1'e giden kenarı bul ve sil (Yönsüz olduğu için)
                    removedCount += u2.OutgoingEdges.RemoveAll(edge => edge.Target.Id == id1);

                    // 3. Ana Graph listesinden de temizle
                    graph.Edges.RemoveAll(edge =>
                        (edge.Source.Id == id1 && edge.Target.Id == id2) ||
                        (edge.Source.Id == id2 && edge.Target.Id == id1));

                    if (removedCount > 0)
                    {
                        pnlGraph.Invalidate();
                        MessageBox.Show("Bağlantı koparıldı!");
                    }
                    else
                    {
                        MessageBox.Show("Bu iki kişi arasında zaten bağlantı yok.");
                    }
                }
            }
            else
            {
                MessageBox.Show("ID kutularını doldurun.");
            }
        }

        private void btnMatrix_Click(object sender, EventArgs e)
        {
            if (graph == null) return;

            string rapor = "--- KOMŞULUK LİSTESİ ---\n";

            foreach (var node in graph.Nodes.Values)
            {
                rapor += $"[{node.Id} - {node.UserName}] -> ";

                var neighborNames = node.OutgoingEdges.Select(edge => edge.Target.UserName).ToList();

                if (neighborNames.Count > 0)
                    rapor += string.Join(", ", neighborNames);
                else
                    rapor += "(Yalnız)";

                rapor += "\n";
            }

            // Mesaj kutusunda göster (Çok uzunsa dosyaya da yazdırabiliriz)
            MessageBox.Show(rapor, "Ağ Raporu");
        }

        private void txtUpdateName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUpdateActive_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedNodeForUpdate != null)
            {
                // 1. İSMİ GÜNCELLE
                if (!string.IsNullOrWhiteSpace(txtUpdateName.Text))
                {
                    selectedNodeForUpdate.UserName = txtUpdateName.Text;
                }
                else
                {
                    MessageBox.Show("İsim boş olamaz!");
                    return;
                }

                // 2. PUANI GÜNCELLE (Sayı kontrolü yaparak)
                if (double.TryParse(txtUpdateActive.Text, out double newScore))
                {
                    selectedNodeForUpdate.ActiveScore = newScore;
                }
                else
                {
                    MessageBox.Show("Lütfen 'Aktiflik' kutusuna geçerli bir sayı giriniz (Örn: 0.8 veya 5).");
                    return;
                }

                // 3. EKRANI YENİLE (İsim değiştiği için tekrar çizilmesi lazım)
                pnlGraph.Invalidate();

                // 4. Bilgi Ver
                MessageBox.Show($"Düğüm güncellendi!\nYeni İsim: {selectedNodeForUpdate.UserName}\nYeni Puan: {selectedNodeForUpdate.ActiveScore}", "Başarılı ✅");
            }
            else
            {
                MessageBox.Show("Lütfen önce haritadan güncellenecek bir topa (düğüme) tıklayın.");
            }
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            if (graph == null)
            {
                MessageBox.Show("Önce bir graf yükleyin.");
                return;
            }

            // 1. TEMİZLİK: Analiz öncesi renkleri sıfırla
            foreach (var n in graph.Nodes.Values) n.UserNodeColor = Color.CornflowerBlue;

            // Ziyaret edilenleri global olarak tutacağız ki aynı kişiyi tekrar saymayalım
            HashSet<int> globalVisited = new HashSet<int>();

            int groupCount = 0; // Kaç tane ayrık grup bulduk?
            StringBuilder report = new StringBuilder(); // Raporu buraya yazacağız

            report.AppendLine("🕵️ TOPLULUK (BAĞLI BİLEŞEN) ANALİZİ");
            report.AppendLine("-----------------------------------");

            // 2. TÜM DÜĞÜMLERİ TEK TEK GEZ
            foreach (var node in graph.Nodes.Values)
            {
                // Eğer bu düğüme daha önce HİÇ uğramadıysak, bu YENİ BİR GRUP (KITA) demektir.
                if (!globalVisited.Contains(node.Id))
                {
                    groupCount++;
                    report.AppendLine($"\n📦 GRUP {groupCount}:");
                    report.Append($"   Üyeler: {node.UserName}");

                    // --- GRUBU KEŞFETMEK İÇİN KÜÇÜK BİR BFS BAŞLATIYORUZ ---
                    Queue<UserNode> q = new Queue<UserNode>();
                    q.Enqueue(node);
                    globalVisited.Add(node.Id);

                    while (q.Count > 0)
                    {
                        var current = q.Dequeue();

                        // Komşularına bak
                        foreach (var edge in current.OutgoingEdges)
                        {
                            if (!globalVisited.Contains(edge.Target.Id))
                            {
                                globalVisited.Add(edge.Target.Id); // Bu gruba dahil et
                                q.Enqueue(edge.Target);

                                // Rapora ismini ekle
                                report.Append($", {edge.Target.UserName}");
                            }
                        }
                    }
                    // Bu grup bitti, döngü başa dönecek ve ziyaret edilmemiş başka kimse kaldı mı bakacak.
                }
            }

            report.AppendLine("\n-----------------------------------");
            report.AppendLine($"✅ TOPLAM AYRIK GRUP SAYISI: {groupCount}");

            // Ekranı yenile (Renkleri sıfırladığımız için)
            pnlGraph.Invalidate();

            // Raporu Göster
            MessageBox.Show(report.ToString(), "Topluluk Analizi Sonucu");
        }
    }
}