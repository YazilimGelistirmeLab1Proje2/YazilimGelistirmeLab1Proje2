using System;
using System.Collections.Generic;
using System.Drawing; // Color sınıfı için gerekli
using System.Linq;
using System.Windows.Forms;

namespace SocialNetwork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // --- 1. RASTGELE DÜĞÜM EKLE ---
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (graph == null) graph = new Graph();

            Random rnd = new Random();

            int newId = (graph.Nodes.Count > 0) ? graph.Nodes.Keys.Max() + 1 : 1;

            UserNode newNode = new UserNode
            {
                Id = newId,
                UserName = "User " + newId,
                ActiveScore = Math.Round(rnd.NextDouble(), 2),
                InteractionCount = rnd.Next(10, 100),
                ConnectionCount = rnd.Next(1, 50),
                X = rnd.Next(50, pnlGraph.Width - 50),
                Y = rnd.Next(50, pnlGraph.Height - 50),
                UserNodeColor = Color.Green
            };

            graph.Nodes.Add(newId, newNode);

            pnlGraph.Invalidate();
            MessageBox.Show($"{newNode.UserName} eklendi. (Henüz kimseye bağlı değil)");
        }

        // --- 2. MATRİS (KOMŞULUK) RAPORU ---
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

            MessageBox.Show(rapor, "Ağ Raporu");
        }

        // --- 3. BAĞLANTI EKLE ---
        private void btnEdgeEkle_Click(object sender, EventArgs e)
        {
            if (graph == null) return;

            if (int.TryParse(txtStart.Text, out int id1) && int.TryParse(txtEnd.Text, out int id2))
            {
                if (id1 == id2) { MessageBox.Show("Kişi kendine bağlanamaz!"); return; }

                if (graph.Nodes.ContainsKey(id1) && graph.Nodes.ContainsKey(id2))
                {
                    UserNode u1 = graph.Nodes[id1];
                    UserNode u2 = graph.Nodes[id2];

                    bool alreadyConnected = u1.OutgoingEdges.Any(edge => edge.Target.Id == id2);
                    if (alreadyConnected)
                    {
                        MessageBox.Show("Bu iki kişi zaten bağlı!");
                        return;
                    }

                    double diffActive = Math.Pow(u1.ActiveScore - u2.ActiveScore, 2);
                    double diffInteract = Math.Pow(u1.InteractionCount - u2.InteractionCount, 2);
                    double diffConnect = Math.Pow(u1.ConnectionCount - u2.ConnectionCount, 2);

                    double euclidean = Math.Sqrt(diffActive + diffInteract + diffConnect);
                    double weight = 1.0 / (1.0 + euclidean);

                    Edge edge1 = new Edge { Source = u1, Target = u2, Weight = weight };
                    u1.OutgoingEdges.Add(edge1);
                    graph.Edges.Add(edge1);

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

        // --- 4. BAĞLANTI SİL ---
        private void btnEdgeSil_Click(object sender, EventArgs e)
        {
            if (graph == null) return;

            if (int.TryParse(txtStart.Text, out int id1) && int.TryParse(txtEnd.Text, out int id2))
            {
                if (graph.Nodes.ContainsKey(id1) && graph.Nodes.ContainsKey(id2))
                {
                    UserNode u1 = graph.Nodes[id1];
                    UserNode u2 = graph.Nodes[id2];

                    int removedCount = u1.OutgoingEdges.RemoveAll(edge => edge.Target.Id == id2);
                    removedCount += u2.OutgoingEdges.RemoveAll(edge => edge.Target.Id == id1);

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

        // --- 5. VERİLERİ KAYDET (CSV) ---
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (graph == null) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Dosyaları|*.csv";
            sfd.FileName = "UpdatedNetwork.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                List<string> lines = new List<string>();
                lines.Add("DugumId;Aktiflik;Etkilesim;BaglantiSayisi;Komsular");

                foreach (var node in graph.Nodes.Values)
                {
                    var neighborIds = node.OutgoingEdges.Select(edge => edge.Target.Id.ToString());
                    string neighborsStr = string.Join(",", neighborIds);

                    string line = $"{node.Id};{node.ActiveScore.ToString(System.Globalization.CultureInfo.InvariantCulture)};" +
                                  $"{node.InteractionCount};{node.ConnectionCount};{neighborsStr}";

                    lines.Add(line);
                }

                System.IO.File.WriteAllLines(sfd.FileName, lines);
                MessageBox.Show("Veriler başarıyla kaydedildi!");
            }
        }

        // --- 6. SEÇİLİ DÜĞÜMÜ SİL ---
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (graph == null) return;

            if (int.TryParse(txtStart.Text, out int idToDelete))
            {
                if (graph.Nodes.ContainsKey(idToDelete))
                {
                    // 1. Düğümü ana listeden sil
                    graph.Nodes.Remove(idToDelete);

                    // 2. Bu düğümle ilgili tüm kenarları (ilişkileri) her yerden temizle
                    graph.Edges.RemoveAll(edge => edge.Source.Id == idToDelete || edge.Target.Id == idToDelete);

                    foreach (var node in graph.Nodes.Values)
                    {
                        node.OutgoingEdges.RemoveAll(edge => edge.Target.Id == idToDelete);
                    }

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
    }
}