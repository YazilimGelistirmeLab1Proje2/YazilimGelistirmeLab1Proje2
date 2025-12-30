namespace SocialNetwork
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnAnalysis = new Button();
            label2 = new Label();
            btnEkle = new Button();
            btnSave = new Button();
            btnColoring = new Button();
            label1 = new Label();
            btnMatrix = new Button();
            btnSil = new Button();
            btnDFS = new Button();
            Dosya = new Label();
            btnBFS = new Button();
            btnLoad = new Button();
            btnCentrality = new Button();
            btnAStar = new Button();
            btnDijkstra = new Button();
            txtEnd = new TextBox();
            txtStart = new TextBox();
            btnEdgeSil = new Button();
            btnEdgeEkle = new Button();
            pnlGraph = new Panel();
            panel2 = new Panel();
            btnUpdate = new Button();
            txtUpdateActive = new TextBox();
            txtUpdateName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            gridTop5 = new DataGridView();
            panel1.SuspendLayout();
            pnlGraph.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridTop5).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScrollMargin = new Size(0, 60);
            panel1.BackColor = Color.FromArgb(35, 40, 65);
            panel1.Controls.Add(btnAnalysis);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnEkle);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnColoring);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnMatrix);
            panel1.Controls.Add(btnSil);
            panel1.Controls.Add(btnDFS);
            panel1.Controls.Add(Dosya);
            panel1.Controls.Add(btnBFS);
            panel1.Controls.Add(btnLoad);
            panel1.Controls.Add(btnCentrality);
            panel1.Controls.Add(btnAStar);
            panel1.Controls.Add(btnDijkstra);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 700);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnAnalysis
            // 
            btnAnalysis.BackColor = Color.FromArgb(44, 62, 80);
            btnAnalysis.FlatAppearance.BorderSize = 0;
            btnAnalysis.FlatStyle = FlatStyle.Flat;
            btnAnalysis.ForeColor = Color.White;
            btnAnalysis.Location = new Point(158, 548);
            btnAnalysis.MaximumSize = new Size(90, 40);
            btnAnalysis.MinimumSize = new Size(0, 10);
            btnAnalysis.Name = "btnAnalysis";
            btnAnalysis.Size = new Size(90, 40);
            btnAnalysis.TabIndex = 18;
            btnAnalysis.Text = "Topluluk Analizi";
            btnAnalysis.UseVisualStyleBackColor = false;
            btnAnalysis.Click += btnAnalysis_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 509);
            label2.Name = "label2";
            label2.Size = new Size(89, 28);
            label2.TabIndex = 17;
            label2.Text = "Düzenle";
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.FromArgb(44, 62, 80);
            btnEkle.FlatAppearance.BorderSize = 0;
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.ForeColor = Color.White;
            btnEkle.Location = new Point(3, 604);
            btnEkle.Margin = new Padding(3, 2, 3, 2);
            btnEkle.MinimumSize = new Size(0, 50);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(129, 50);
            btnEkle.TabIndex = 9;
            btnEkle.Text = "Rastgele Düğüm Ekle";
            btnEkle.TextAlign = ContentAlignment.MiddleLeft;
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(44, 62, 80);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 106);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.MinimumSize = new Size(0, 50);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(122, 50);
            btnSave.TabIndex = 12;
            btnSave.Text = "CSV Kaydet";
            btnSave.TextAlign = ContentAlignment.MiddleLeft;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnColoring
            // 
            btnColoring.BackColor = Color.FromArgb(44, 62, 80);
            btnColoring.FlatAppearance.BorderSize = 0;
            btnColoring.FlatStyle = FlatStyle.Flat;
            btnColoring.ForeColor = Color.White;
            btnColoring.Location = new Point(156, 51);
            btnColoring.MinimumSize = new Size(0, 50);
            btnColoring.Name = "btnColoring";
            btnColoring.Size = new Size(112, 50);
            btnColoring.TabIndex = 8;
            btnColoring.Text = "Welsh-Powell";
            btnColoring.TextAlign = ContentAlignment.MiddleLeft;
            btnColoring.UseVisualStyleBackColor = false;
            btnColoring.Click += btnColoring_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 225);
            label1.Name = "label1";
            label1.Size = new Size(132, 28);
            label1.TabIndex = 16;
            label1.Text = "Algoritmalar";
            // 
            // btnMatrix
            // 
            btnMatrix.BackColor = Color.FromArgb(44, 62, 80);
            btnMatrix.FlatAppearance.BorderSize = 0;
            btnMatrix.FlatStyle = FlatStyle.Flat;
            btnMatrix.ForeColor = Color.White;
            btnMatrix.ImageAlign = ContentAlignment.MiddleLeft;
            btnMatrix.Location = new Point(14, 160);
            btnMatrix.Margin = new Padding(3, 2, 3, 2);
            btnMatrix.MinimumSize = new Size(0, 50);
            btnMatrix.Name = "btnMatrix";
            btnMatrix.Size = new Size(124, 50);
            btnMatrix.TabIndex = 14;
            btnMatrix.Text = "Matris Raporu";
            btnMatrix.TextAlign = ContentAlignment.MiddleLeft;
            btnMatrix.UseVisualStyleBackColor = false;
            btnMatrix.Click += btnMatrix_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.FromArgb(44, 62, 80);
            btnSil.FlatAppearance.BorderSize = 0;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.ForeColor = Color.White;
            btnSil.ImageAlign = ContentAlignment.MiddleLeft;
            btnSil.Location = new Point(3, 548);
            btnSil.Margin = new Padding(3, 2, 3, 2);
            btnSil.MaximumSize = new Size(90, 40);
            btnSil.MinimumSize = new Size(0, 10);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(90, 40);
            btnSil.TabIndex = 10;
            btnSil.Text = "Seçili ID'yi Sil";
            btnSil.TextAlign = ContentAlignment.MiddleLeft;
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnDFS
            // 
            btnDFS.BackColor = Color.FromArgb(44, 62, 80);
            btnDFS.FlatAppearance.BorderSize = 0;
            btnDFS.FlatStyle = FlatStyle.Flat;
            btnDFS.ForeColor = Color.White;
            btnDFS.ImageAlign = ContentAlignment.MiddleLeft;
            btnDFS.Location = new Point(12, 448);
            btnDFS.MaximumSize = new Size(90, 40);
            btnDFS.MinimumSize = new Size(0, 10);
            btnDFS.Name = "btnDFS";
            btnDFS.Size = new Size(90, 40);
            btnDFS.TabIndex = 7;
            btnDFS.Text = "DFS";
            btnDFS.TextAlign = ContentAlignment.MiddleLeft;
            btnDFS.UseVisualStyleBackColor = false;
            btnDFS.Click += btnDFS_Click;
            // 
            // Dosya
            // 
            Dosya.AutoSize = true;
            Dosya.BorderStyle = BorderStyle.FixedSingle;
            Dosya.Dock = DockStyle.Top;
            Dosya.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Dosya.ForeColor = Color.White;
            Dosya.Location = new Point(0, 0);
            Dosya.Margin = new Padding(10, 10, 0, 0);
            Dosya.Name = "Dosya";
            Dosya.Size = new Size(72, 30);
            Dosya.TabIndex = 15;
            Dosya.Text = "Dosya";
            // 
            // btnBFS
            // 
            btnBFS.BackColor = Color.FromArgb(44, 62, 80);
            btnBFS.FlatAppearance.BorderSize = 0;
            btnBFS.FlatStyle = FlatStyle.Flat;
            btnBFS.ForeColor = Color.White;
            btnBFS.ImageAlign = ContentAlignment.MiddleLeft;
            btnBFS.Location = new Point(12, 402);
            btnBFS.MaximumSize = new Size(90, 40);
            btnBFS.MinimumSize = new Size(0, 10);
            btnBFS.Name = "btnBFS";
            btnBFS.Size = new Size(90, 40);
            btnBFS.TabIndex = 6;
            btnBFS.Text = "BFS";
            btnBFS.TextAlign = ContentAlignment.MiddleLeft;
            btnBFS.UseVisualStyleBackColor = false;
            btnBFS.Click += btnBFS_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(44, 62, 80);
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.ForeColor = Color.White;
            btnLoad.Location = new Point(12, 51);
            btnLoad.MinimumSize = new Size(0, 50);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(124, 50);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "CSV Yükle";
            btnLoad.TextAlign = ContentAlignment.MiddleLeft;
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += button1_Click_1;
            // 
            // btnCentrality
            // 
            btnCentrality.BackColor = Color.FromArgb(44, 62, 80);
            btnCentrality.FlatAppearance.BorderSize = 0;
            btnCentrality.FlatStyle = FlatStyle.Flat;
            btnCentrality.ForeColor = Color.White;
            btnCentrality.ImageAlign = ContentAlignment.MiddleLeft;
            btnCentrality.Location = new Point(12, 264);
            btnCentrality.MaximumSize = new Size(90, 40);
            btnCentrality.MinimumSize = new Size(0, 10);
            btnCentrality.Name = "btnCentrality";
            btnCentrality.Size = new Size(90, 40);
            btnCentrality.TabIndex = 1;
            btnCentrality.Text = "En popüler";
            btnCentrality.TextAlign = ContentAlignment.MiddleLeft;
            btnCentrality.UseVisualStyleBackColor = false;
            btnCentrality.Click += btnCentrality_Click;
            // 
            // btnAStar
            // 
            btnAStar.BackColor = Color.FromArgb(44, 62, 80);
            btnAStar.FlatAppearance.BorderSize = 0;
            btnAStar.FlatStyle = FlatStyle.Flat;
            btnAStar.ForeColor = Color.White;
            btnAStar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAStar.Location = new Point(12, 356);
            btnAStar.MaximumSize = new Size(90, 40);
            btnAStar.MinimumSize = new Size(0, 10);
            btnAStar.Name = "btnAStar";
            btnAStar.Size = new Size(90, 40);
            btnAStar.TabIndex = 5;
            btnAStar.Text = "A* Algoritması";
            btnAStar.TextAlign = ContentAlignment.MiddleLeft;
            btnAStar.UseVisualStyleBackColor = false;
            btnAStar.Click += btnAStar_Click;
            // 
            // btnDijkstra
            // 
            btnDijkstra.BackColor = Color.FromArgb(44, 62, 80);
            btnDijkstra.FlatAppearance.BorderSize = 0;
            btnDijkstra.FlatStyle = FlatStyle.Flat;
            btnDijkstra.ForeColor = Color.White;
            btnDijkstra.ImageAlign = ContentAlignment.MiddleLeft;
            btnDijkstra.Location = new Point(12, 310);
            btnDijkstra.MaximumSize = new Size(90, 40);
            btnDijkstra.MinimumSize = new Size(0, 10);
            btnDijkstra.Name = "btnDijkstra";
            btnDijkstra.Size = new Size(90, 40);
            btnDijkstra.TabIndex = 4;
            btnDijkstra.Text = "En Kısa Yol Bul";
            btnDijkstra.TextAlign = ContentAlignment.MiddleLeft;
            btnDijkstra.UseVisualStyleBackColor = false;
            btnDijkstra.Click += btnDijkstra_Click;
            // 
            // txtEnd
            // 
            txtEnd.Location = new Point(317, 18);
            txtEnd.Name = "txtEnd";
            txtEnd.Size = new Size(100, 23);
            txtEnd.TabIndex = 3;
            txtEnd.TextChanged += txtEnd_TextChanged;
            // 
            // txtStart
            // 
            txtStart.Location = new Point(44, 20);
            txtStart.Name = "txtStart";
            txtStart.Size = new Size(100, 23);
            txtStart.TabIndex = 2;
            txtStart.TextChanged += txtStart_TextChanged;
            // 
            // btnEdgeSil
            // 
            btnEdgeSil.BackColor = Color.FromArgb(231, 76, 60);
            btnEdgeSil.FlatAppearance.BorderSize = 0;
            btnEdgeSil.FlatStyle = FlatStyle.Flat;
            btnEdgeSil.ForeColor = Color.White;
            btnEdgeSil.Location = new Point(445, 8);
            btnEdgeSil.Margin = new Padding(3, 2, 3, 2);
            btnEdgeSil.MaximumSize = new Size(90, 0);
            btnEdgeSil.MinimumSize = new Size(0, 45);
            btnEdgeSil.Name = "btnEdgeSil";
            btnEdgeSil.Size = new Size(90, 45);
            btnEdgeSil.TabIndex = 13;
            btnEdgeSil.Text = "Bağlantı Sil";
            btnEdgeSil.TextAlign = ContentAlignment.MiddleLeft;
            btnEdgeSil.UseVisualStyleBackColor = false;
            btnEdgeSil.Click += btnEdgeSil_Click;
            // 
            // btnEdgeEkle
            // 
            btnEdgeEkle.BackColor = Color.FromArgb(52, 152, 219);
            btnEdgeEkle.FlatAppearance.BorderSize = 0;
            btnEdgeEkle.FlatStyle = FlatStyle.Flat;
            btnEdgeEkle.ForeColor = Color.White;
            btnEdgeEkle.Location = new Point(163, 8);
            btnEdgeEkle.Margin = new Padding(3, 2, 3, 2);
            btnEdgeEkle.MaximumSize = new Size(90, 0);
            btnEdgeEkle.MinimumSize = new Size(0, 45);
            btnEdgeEkle.Name = "btnEdgeEkle";
            btnEdgeEkle.Size = new Size(90, 45);
            btnEdgeEkle.TabIndex = 11;
            btnEdgeEkle.Text = "Bağlantı Ekle";
            btnEdgeEkle.TextAlign = ContentAlignment.MiddleLeft;
            btnEdgeEkle.UseVisualStyleBackColor = false;
            btnEdgeEkle.Click += btnEdgeEkle_Click;
            // 
            // pnlGraph
            // 
            pnlGraph.Controls.Add(panel2);
            pnlGraph.Controls.Add(gridTop5);
            pnlGraph.Dock = DockStyle.Fill;
            pnlGraph.Location = new Point(284, 0);
            pnlGraph.Name = "pnlGraph";
            pnlGraph.Size = new Size(1162, 700);
            pnlGraph.TabIndex = 1;
            pnlGraph.Paint += pnlGraph_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.Controls.Add(btnUpdate);
            panel2.Controls.Add(txtUpdateActive);
            panel2.Controls.Add(txtUpdateName);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(btnEdgeSil);
            panel2.Controls.Add(txtStart);
            panel2.Controls.Add(btnEdgeEkle);
            panel2.Controls.Add(txtEnd);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.MaximumSize = new Size(0, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(968, 60);
            panel2.TabIndex = 1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.ForestGreen;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(844, 8);
            btnUpdate.MaximumSize = new Size(90, 0);
            btnUpdate.MinimumSize = new Size(0, 45);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(90, 45);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Güncelle";
            btnUpdate.TextAlign = ContentAlignment.MiddleLeft;
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtUpdateActive
            // 
            txtUpdateActive.Location = new Point(728, 23);
            txtUpdateActive.Name = "txtUpdateActive";
            txtUpdateActive.Size = new Size(92, 23);
            txtUpdateActive.TabIndex = 17;
            txtUpdateActive.TextChanged += txtUpdateActive_TextChanged;
            // 
            // txtUpdateName
            // 
            txtUpdateName.Location = new Point(616, 23);
            txtUpdateName.Name = "txtUpdateName";
            txtUpdateName.Size = new Size(92, 23);
            txtUpdateName.TabIndex = 16;
            txtUpdateName.TextChanged += txtUpdateName_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(290, 23);
            label4.Name = "label4";
            label4.Size = new Size(21, 15);
            label4.TabIndex = 15;
            label4.Text = "ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 23);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 14;
            label3.Text = "ID:";
            // 
            // gridTop5
            // 
            gridTop5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridTop5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTop5.Dock = DockStyle.Right;
            gridTop5.Location = new Point(968, 0);
            gridTop5.Margin = new Padding(3, 2, 3, 2);
            gridTop5.MaximumSize = new Size(200, 0);
            gridTop5.Name = "gridTop5";
            gridTop5.RowHeadersWidth = 51;
            gridTop5.Size = new Size(194, 700);
            gridTop5.TabIndex = 0;
            gridTop5.CellContentClick += gridTop5_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1446, 700);
            Controls.Add(pnlGraph);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlGraph.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridTop5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnLoad;
        private Button btnCentrality;
        private Panel pnlGraph;
        private TextBox txtEnd;
        private TextBox txtStart;
        private Button btnDijkstra;
        private Button btnAStar;
        private Button btnBFS;
        private Button btnDFS;
        private Button btnColoring;
        private DataGridView gridTop5;
        private Button btnSil;
        private Button btnEkle;
        private Button btnEdgeEkle;
        private Button btnSave;
        private Button btnEdgeSil;
        private Button btnMatrix;
        private Panel panel2;
        private Label label1;
        private Label Dosya;
        private Label label2;
        private Label label4;
        private Label label3;
        private Button btnUpdate;
        private TextBox txtUpdateActive;
        private TextBox txtUpdateName;
        private Button btnAnalysis;
    }
}
