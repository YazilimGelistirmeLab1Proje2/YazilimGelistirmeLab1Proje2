using System;
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
    }
}