namespace ProjectNr1_Radovskyi61986
{
    partial class ProjectowyNr1_Radovskiy61986
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtH = new System.Windows.Forms.TextBox();
            this.txtXg = new System.Windows.Forms.TextBox();
            this.txtXd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblH = new System.Windows.Forms.Label();
            this.lblXg = new System.Windows.Forms.Label();
            this.lblXd = new System.Windows.Forms.Label();
            this.btnResetuj = new System.Windows.Forms.Button();
            this.btnAnimacja = new System.Windows.Forms.Button();
            this.btnWizualizacjaGraficzna = new System.Windows.Forms.Button();
            this.btnWizualizacjaTabeleryczna = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.koloryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atrybutyLiniiTonuIObiektuAnimowanegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kształtObiektuAnimowanegoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvTWS = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chtWykresSzeregu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTWS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtWykresSzeregu)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(32, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1076, 615);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(28, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 19);
            this.label1.TabIndex = 27;
            this.label1.Text = "Przedział wartości zmiennej niezależnej X:";
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(648, 35);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(79, 20);
            this.txtH.TabIndex = 26;
            // 
            // txtXg
            // 
            this.txtXg.Location = new System.Drawing.Point(456, 35);
            this.txtXg.Name = "txtXg";
            this.txtXg.Size = new System.Drawing.Size(71, 20);
            this.txtXg.TabIndex = 25;
            // 
            // txtXd
            // 
            this.txtXd.Location = new System.Drawing.Point(343, 35);
            this.txtXd.Name = "txtXd";
            this.txtXd.Size = new System.Drawing.Size(71, 20);
            this.txtXd.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1154, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "Zmiana prękości animacji";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(1148, 77);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(263, 45);
            this.trackBar1.TabIndex = 22;
            this.trackBar1.TickFrequency = 30;
            this.trackBar1.Value = 10;
            // 
            // lblH
            // 
            this.lblH.AutoSize = true;
            this.lblH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblH.Location = new System.Drawing.Point(554, 34);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(85, 57);
            this.lblH.TabIndex = 21;
            this.lblH.Text = "h:\r\n(krok zmian\r\n wartości)";
            // 
            // lblXg
            // 
            this.lblXg.AutoSize = true;
            this.lblXg.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblXg.Location = new System.Drawing.Point(420, 36);
            this.lblXg.Name = "lblXg";
            this.lblXg.Size = new System.Drawing.Size(32, 19);
            this.lblXg.TabIndex = 20;
            this.lblXg.Text = "Xg:";
            // 
            // lblXd
            // 
            this.lblXd.AutoSize = true;
            this.lblXd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblXd.Location = new System.Drawing.Point(304, 34);
            this.lblXd.Name = "lblXd";
            this.lblXd.Size = new System.Drawing.Size(32, 19);
            this.lblXd.TabIndex = 19;
            this.lblXd.Text = "Xd:";
            // 
            // btnResetuj
            // 
            this.btnResetuj.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnResetuj.Location = new System.Drawing.Point(1158, 463);
            this.btnResetuj.Name = "btnResetuj";
            this.btnResetuj.Size = new System.Drawing.Size(263, 88);
            this.btnResetuj.TabIndex = 18;
            this.btnResetuj.Text = "Resetuj";
            this.btnResetuj.UseVisualStyleBackColor = true;
            this.btnResetuj.Click += new System.EventHandler(this.btnResetuj_Click);
            // 
            // btnAnimacja
            // 
            this.btnAnimacja.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAnimacja.Location = new System.Drawing.Point(1158, 369);
            this.btnAnimacja.Name = "btnAnimacja";
            this.btnAnimacja.Size = new System.Drawing.Size(263, 88);
            this.btnAnimacja.TabIndex = 17;
            this.btnAnimacja.Text = "Animacja po linii toru\r\n(wyznaczonej przez \r\nszereg potęgowy)";
            this.btnAnimacja.UseVisualStyleBackColor = true;
            this.btnAnimacja.Click += new System.EventHandler(this.btnAnimacja_Click);
            // 
            // btnWizualizacjaGraficzna
            // 
            this.btnWizualizacjaGraficzna.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWizualizacjaGraficzna.Location = new System.Drawing.Point(1158, 275);
            this.btnWizualizacjaGraficzna.Name = "btnWizualizacjaGraficzna";
            this.btnWizualizacjaGraficzna.Size = new System.Drawing.Size(263, 88);
            this.btnWizualizacjaGraficzna.TabIndex = 16;
            this.btnWizualizacjaGraficzna.Text = "Wizualizacja graficzna\r\nzmian wartości szeregu potęgowego";
            this.btnWizualizacjaGraficzna.UseVisualStyleBackColor = true;
            this.btnWizualizacjaGraficzna.Click += new System.EventHandler(this.btnWizualizacjaGraficzna_Click);
            // 
            // btnWizualizacjaTabeleryczna
            // 
            this.btnWizualizacjaTabeleryczna.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWizualizacjaTabeleryczna.Location = new System.Drawing.Point(1158, 181);
            this.btnWizualizacjaTabeleryczna.Name = "btnWizualizacjaTabeleryczna";
            this.btnWizualizacjaTabeleryczna.Size = new System.Drawing.Size(263, 88);
            this.btnWizualizacjaTabeleryczna.TabIndex = 15;
            this.btnWizualizacjaTabeleryczna.Text = "Wizualizacja tabeleryczna\r\nzmian wartości szeregu potęgowego";
            this.btnWizualizacjaTabeleryczna.UseVisualStyleBackColor = true;
            this.btnWizualizacjaTabeleryczna.Click += new System.EventHandler(this.btnWizualizacjaTabeleryczna_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.koloryToolStripMenuItem,
            this.atrybutyLiniiTonuIObiektuAnimowanegoToolStripMenuItem,
            this.kształtObiektuAnimowanegoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1445, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // koloryToolStripMenuItem
            // 
            this.koloryToolStripMenuItem.Name = "koloryToolStripMenuItem";
            this.koloryToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.koloryToolStripMenuItem.Text = "Kolory";
            // 
            // atrybutyLiniiTonuIObiektuAnimowanegoToolStripMenuItem
            // 
            this.atrybutyLiniiTonuIObiektuAnimowanegoToolStripMenuItem.Name = "atrybutyLiniiTonuIObiektuAnimowanegoToolStripMenuItem";
            this.atrybutyLiniiTonuIObiektuAnimowanegoToolStripMenuItem.Size = new System.Drawing.Size(243, 20);
            this.atrybutyLiniiTonuIObiektuAnimowanegoToolStripMenuItem.Text = "Atrybuty linii tonu i obiektu animowanego";
            // 
            // kształtObiektuAnimowanegoToolStripMenuItem
            // 
            this.kształtObiektuAnimowanegoToolStripMenuItem.Name = "kształtObiektuAnimowanegoToolStripMenuItem";
            this.kształtObiektuAnimowanegoToolStripMenuItem.Size = new System.Drawing.Size(175, 20);
            this.kształtObiektuAnimowanegoToolStripMenuItem.Text = "Kształt obiektu animowanego";
            // 
            // dgvTWS
            // 
            this.dgvTWS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTWS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this.dgvTWS.Location = new System.Drawing.Point(32, 94);
            this.dgvTWS.Name = "dgvTWS";
            this.dgvTWS.Size = new System.Drawing.Size(1076, 615);
            this.dgvTWS.TabIndex = 30;
            this.dgvTWS.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // chtWykresSzeregu
            // 
            chartArea1.Name = "ChartArea1";
            this.chtWykresSzeregu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtWykresSzeregu.Legends.Add(legend1);
            this.chtWykresSzeregu.Location = new System.Drawing.Point(32, 94);
            this.chtWykresSzeregu.Name = "chtWykresSzeregu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtWykresSzeregu.Series.Add(series1);
            this.chtWykresSzeregu.Size = new System.Drawing.Size(1076, 615);
            this.chtWykresSzeregu.TabIndex = 31;
            this.chtWykresSzeregu.Text = "chart1";
            this.chtWykresSzeregu.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // X
            // 
            this.X.HeaderText = "Column1";
            this.X.Name = "X";
            // 
            // Y
            // 
            this.Y.HeaderText = "Column1";
            this.Y.Name = "Y";
            // 
            // ProjectowyNr1_Radovskiy61986
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 736);
            this.Controls.Add(this.chtWykresSzeregu);
            this.Controls.Add(this.dgvTWS);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.txtXg);
            this.Controls.Add(this.txtXd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lblH);
            this.Controls.Add(this.lblXg);
            this.Controls.Add(this.lblXd);
            this.Controls.Add(this.btnResetuj);
            this.Controls.Add(this.btnAnimacja);
            this.Controls.Add(this.btnWizualizacjaGraficzna);
            this.Controls.Add(this.btnWizualizacjaTabeleryczna);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ProjectowyNr1_Radovskiy61986";
            this.Text = "ProjectowyNr1_Radovskiy61986";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectowyNr1_Radovskiy61986_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTWS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtWykresSzeregu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.TextBox txtXg;
        private System.Windows.Forms.TextBox txtXd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblXg;
        private System.Windows.Forms.Label lblXd;
        private System.Windows.Forms.Button btnResetuj;
        private System.Windows.Forms.Button btnAnimacja;
        private System.Windows.Forms.Button btnWizualizacjaGraficzna;
        private System.Windows.Forms.Button btnWizualizacjaTabeleryczna;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem koloryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atrybutyLiniiTonuIObiektuAnimowanegoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kształtObiektuAnimowanegoToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvTWS;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtWykresSzeregu;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
    }
}