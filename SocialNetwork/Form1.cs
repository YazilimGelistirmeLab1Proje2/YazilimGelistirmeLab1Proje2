using System;
using System.Collections.Generic;
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

        // MATRİS RAPORU BUTONU
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

        // BAĞLANTI EKLE BUTONU
        private void btnEdgeEkle_Click(object sender, EventArgs e)
        {
            if (graph == null) return;

            // Kutulardaki ID'leri al
            if (int.TryParse(txtStart.Text, out int id1) && int.TryParse(txtEnd.Text, out int id2))
            {
                if (id1 == id2) 
                { 
                    MessageBox.Show("Kişi kendine bağlanamaz!"); 
                    return; 
                }

                if (graph.Nodes.ContainsKey(id1) && graph.Nodes.ContainsKey(id2))
                {
                    UserNode u1 = graph.Nodes[id1];
                    UserNode u2 = graph.Nodes[id2];

                    // Zaten bağlılar mı kontrolü
                    bool alreadyConnected = u1.OutgoingEdges.Any(edge => edge.Target.Id == id2);
                    if (alreadyConnected)
                    {
                        MessageBox.Show("Bu iki kişi zaten bağlı!");
                        return;
                    }

                    // AĞIRLIK HESAPLA (Öklid Uzaklığı Formülü)
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
    }
}