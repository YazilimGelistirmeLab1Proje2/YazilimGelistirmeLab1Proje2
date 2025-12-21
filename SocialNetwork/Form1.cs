using SocialNetwork.Algorithms;
using SocialNetworkAnalysis.Model;

namespace SocialNetwork

{

    public partial class Form1 : Form

    {
        Graph graph;
        public Form1()

        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)

        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "CSV Dosyalarý|*.csv";

            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                FileManager fm = new FileManager();
                graph = fm.LoadGraphFromCSV(openfiledialog.FileName);
                if (graph != null)
                    MessageBox.Show($"Baþarýlý! {graph.Nodes.Count} kiþi yüklendi.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (graph == null)
            {
                MessageBox.Show("Lütfen önce bir dosya yükleyin.");
                return;
            }
            Centrality centrality = new Centrality();

            var centralitybutton = centrality.FindMostPopularUser(graph);

            if (centralitybutton != null)
                MessageBox.Show($"En popüler kullanýcý: {centralitybutton.UserName} \n Baðlantý Sayýsý:{centralitybutton.ConnectionCount}");
        }
    }
}