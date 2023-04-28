namespace ProjectNr1_Radovskyi61986
{
    partial class LoboratoriumNr1_Raovskyi61986
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea17 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend17 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnAnimacja = new System.Windows.Forms.Button();
            this.btnResetuj = new System.Windows.Forms.Button();
            this.lblXd = new System.Windows.Forms.Label();
            this.lblXg = new System.Windows.Forms.Label();
            this.lblH = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.txtXd = new System.Windows.Forms.TextBox();
            this.txtXg = new System.Windows.Forms.TextBox();
            this.txtH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnWizualizacjaGraficzna = new System.Windows.Forms.Button();
            this.btnWizualizacjaTabeleryczna = new System.Windows.Forms.Button();
            this.chtWykresSzeregu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvTWS = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.liniaToruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grubośćLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stylLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaKreskowaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaKreskowaKrapkowaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaKreskowaKrapkowaKrapkowaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.liniaKrapkowaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agłasolidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtWykresSzeregu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTWS)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAnimacja
            // 
            this.btnAnimacja.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAnimacja.Location = new System.Drawing.Point(1132, 331);
            this.btnAnimacja.Name = "btnAnimacja";
            this.btnAnimacja.Size = new System.Drawing.Size(263, 88);
            this.btnAnimacja.TabIndex = 2;
            this.btnAnimacja.Text = "Animacja po linii toru\r\n(wyznaczonej przez \r\nszereg potęgowy)";
            this.btnAnimacja.UseVisualStyleBackColor = true;
            this.btnAnimacja.Click += new System.EventHandler(this.btnAnimacja_Click);
            // 
            // btnResetuj
            // 
            this.btnResetuj.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnResetuj.Location = new System.Drawing.Point(1132, 425);
            this.btnResetuj.Name = "btnResetuj";
            this.btnResetuj.Size = new System.Drawing.Size(263, 88);
            this.btnResetuj.TabIndex = 3;
            this.btnResetuj.Text = "Resetuj";
            this.btnResetuj.UseVisualStyleBackColor = true;
            this.btnResetuj.Click += new System.EventHandler(this.btnResetuj_Click);
            // 
            // lblXd
            // 
            this.lblXd.AutoSize = true;
            this.lblXd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblXd.Location = new System.Drawing.Point(288, 46);
            this.lblXd.Name = "lblXd";
            this.lblXd.Size = new System.Drawing.Size(32, 19);
            this.lblXd.TabIndex = 4;
            this.lblXd.Text = "Xd:";
            // 
            // lblXg
            // 
            this.lblXg.AutoSize = true;
            this.lblXg.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblXg.Location = new System.Drawing.Point(404, 48);
            this.lblXg.Name = "lblXg";
            this.lblXg.Size = new System.Drawing.Size(32, 19);
            this.lblXg.TabIndex = 5;
            this.lblXg.Text = "Xg:";
            // 
            // lblH
            // 
            this.lblH.AutoSize = true;
            this.lblH.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblH.Location = new System.Drawing.Point(538, 46);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(85, 57);
            this.lblH.TabIndex = 6;
            this.lblH.Text = "h:\r\n(krok zmian\r\n wartości)";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(1132, 89);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(263, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.TickFrequency = 30;
            this.trackBar1.Value = 10;
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1138, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Zmiana prękości animacji";
            // 
            // txtXd
            // 
            this.txtXd.Location = new System.Drawing.Point(327, 47);
            this.txtXd.Name = "txtXd";
            this.txtXd.Size = new System.Drawing.Size(71, 20);
            this.txtXd.TabIndex = 9;
            // 
            // txtXg
            // 
            this.txtXg.Location = new System.Drawing.Point(440, 47);
            this.txtXg.Name = "txtXg";
            this.txtXg.Size = new System.Drawing.Size(71, 20);
            this.txtXg.TabIndex = 10;
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(632, 47);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(79, 20);
            this.txtH.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Przedział wartości zmiennej niezależnej X:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(39, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1076, 736);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnWizualizacjaGraficzna
            // 
            this.btnWizualizacjaGraficzna.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWizualizacjaGraficzna.Location = new System.Drawing.Point(1132, 234);
            this.btnWizualizacjaGraficzna.Name = "btnWizualizacjaGraficzna";
            this.btnWizualizacjaGraficzna.Size = new System.Drawing.Size(263, 88);
            this.btnWizualizacjaGraficzna.TabIndex = 18;
            this.btnWizualizacjaGraficzna.Text = "Wizualizacja graficzna\r\nzmian wartości szeregu potęgowego";
            this.btnWizualizacjaGraficzna.UseVisualStyleBackColor = true;
            this.btnWizualizacjaGraficzna.Click += new System.EventHandler(this.btnWizualizacjaGraficzna_Click);
            // 
            // btnWizualizacjaTabeleryczna
            // 
            this.btnWizualizacjaTabeleryczna.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWizualizacjaTabeleryczna.Location = new System.Drawing.Point(1132, 140);
            this.btnWizualizacjaTabeleryczna.Name = "btnWizualizacjaTabeleryczna";
            this.btnWizualizacjaTabeleryczna.Size = new System.Drawing.Size(263, 88);
            this.btnWizualizacjaTabeleryczna.TabIndex = 17;
            this.btnWizualizacjaTabeleryczna.Text = "Wizualizacja tabeleryczna\r\nzmian wartości szeregu potęgowego";
            this.btnWizualizacjaTabeleryczna.UseVisualStyleBackColor = true;
            this.btnWizualizacjaTabeleryczna.Click += new System.EventHandler(this.btnWizualizacjaTabeleryczna_Click);
            // 
            // chtWykresSzeregu
            // 
            chartArea17.Name = "ChartArea1";
            this.chtWykresSzeregu.ChartAreas.Add(chartArea17);
            legend17.Name = "Legend1";
            this.chtWykresSzeregu.Legends.Add(legend17);
            this.chtWykresSzeregu.Location = new System.Drawing.Point(39, 117);
            this.chtWykresSzeregu.Name = "chtWykresSzeregu";
            series17.ChartArea = "ChartArea1";
            series17.Legend = "Legend1";
            series17.Name = "Series1";
            this.chtWykresSzeregu.Series.Add(series17);
            this.chtWykresSzeregu.Size = new System.Drawing.Size(1076, 736);
            this.chtWykresSzeregu.TabIndex = 19;
            this.chtWykresSzeregu.Text = "chart1";
            this.chtWykresSzeregu.Visible = false;
            // 
            // dgvTWS
            // 
            this.dgvTWS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTWS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvTWS.Location = new System.Drawing.Point(39, 117);
            this.dgvTWS.Name = "dgvTWS";
            this.dgvTWS.Size = new System.Drawing.Size(1076, 753);
            this.dgvTWS.TabIndex = 20;
            this.dgvTWS.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Xg";
            this.Column1.Name = "Column1";
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Xd";
            this.Column2.Name = "Column2";
            this.Column2.Width = 300;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liniaToruToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1417, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // liniaToruToolStripMenuItem
            // 
            this.liniaToruToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grubośćLiniiToolStripMenuItem,
            this.stylLiniiToolStripMenuItem,
            this.kolorToolStripMenuItem});
            this.liniaToruToolStripMenuItem.Name = "liniaToruToolStripMenuItem";
            this.liniaToruToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.liniaToruToolStripMenuItem.Text = "Linia toru";
            // 
            // grubośćLiniiToolStripMenuItem
            // 
            this.grubośćLiniiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.grubośćLiniiToolStripMenuItem.Name = "grubośćLiniiToolStripMenuItem";
            this.grubośćLiniiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grubośćLiniiToolStripMenuItem.Text = "Grubość linii";
            // 
            // stylLiniiToolStripMenuItem
            // 
            this.stylLiniiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liniaKreskowaToolStripMenuItem,
            this.liniaKreskowaKrapkowaToolStripMenuItem,
            this.liniaKreskowaKrapkowaKrapkowaToolStripMenuItem,
            this.liniaKrapkowaToolStripMenuItem,
            this.agłasolidToolStripMenuItem});
            this.stylLiniiToolStripMenuItem.Name = "stylLiniiToolStripMenuItem";
            this.stylLiniiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stylLiniiToolStripMenuItem.Text = "Styl linii";
            // 
            // kolorToolStripMenuItem
            // 
            this.kolorToolStripMenuItem.Name = "kolorToolStripMenuItem";
            this.kolorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kolorToolStripMenuItem.Text = "Kolor";
            this.kolorToolStripMenuItem.Click += new System.EventHandler(this.kolorToolStripMenuItem_Click);
            // 
            // liniaKreskowaToolStripMenuItem
            // 
            this.liniaKreskowaToolStripMenuItem.Name = "liniaKreskowaToolStripMenuItem";
            this.liniaKreskowaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.liniaKreskowaToolStripMenuItem.Text = "Linia kreskowa";
            this.liniaKreskowaToolStripMenuItem.Click += new System.EventHandler(this.liniaKreskowaToolStripMenuItem_Click);
            // 
            // liniaKreskowaKrapkowaToolStripMenuItem
            // 
            this.liniaKreskowaKrapkowaToolStripMenuItem.Name = "liniaKreskowaKrapkowaToolStripMenuItem";
            this.liniaKreskowaKrapkowaToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.liniaKreskowaKrapkowaToolStripMenuItem.Text = "Linia kreskowaKrapkowa";
            this.liniaKreskowaKrapkowaToolStripMenuItem.Click += new System.EventHandler(this.liniaKreskowaKrapkowaToolStripMenuItem_Click);
            // 
            // liniaKreskowaKrapkowaKrapkowaToolStripMenuItem
            // 
            this.liniaKreskowaKrapkowaKrapkowaToolStripMenuItem.Name = "liniaKreskowaKrapkowaKrapkowaToolStripMenuItem";
            this.liniaKreskowaKrapkowaKrapkowaToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.liniaKreskowaKrapkowaKrapkowaToolStripMenuItem.Text = "Linia kreskowaKrapkowaKrapkowa";
            this.liniaKreskowaKrapkowaKrapkowaToolStripMenuItem.Click += new System.EventHandler(this.liniaKreskowaKrapkowaKrapkowaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "1";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "2";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "3";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem5.Text = "4";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem6.Text = "5";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // liniaKrapkowaToolStripMenuItem
            // 
            this.liniaKrapkowaToolStripMenuItem.Name = "liniaKrapkowaToolStripMenuItem";
            this.liniaKrapkowaToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.liniaKrapkowaToolStripMenuItem.Text = "Linia Krapkowa";
            this.liniaKrapkowaToolStripMenuItem.Click += new System.EventHandler(this.liniaKrapkowaToolStripMenuItem_Click);
            // 
            // agłasolidToolStripMenuItem
            // 
            this.agłasolidToolStripMenuItem.Name = "agłasolidToolStripMenuItem";
            this.agłasolidToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.agłasolidToolStripMenuItem.Text = "agła (solid)";
            this.agłasolidToolStripMenuItem.Click += new System.EventHandler(this.agłasolidToolStripMenuItem_Click);
            // 
            // LoboratoriumNr1_Raovskyi61986
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 882);
            this.Controls.Add(this.dgvTWS);
            this.Controls.Add(this.chtWykresSzeregu);
            this.Controls.Add(this.btnWizualizacjaGraficzna);
            this.Controls.Add(this.btnWizualizacjaTabeleryczna);
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
            this.Controls.Add(this.menuStrip1);
            this.Name = "LoboratoriumNr1_Raovskyi61986";
            this.Text = "LoboratoriumNr1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoboratoriumNr1_Raovskyi61986_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtWykresSzeregu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTWS)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAnimacja;
        private System.Windows.Forms.Button btnResetuj;
        private System.Windows.Forms.Label lblXd;
        private System.Windows.Forms.Label lblXg;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtXd;
        private System.Windows.Forms.TextBox txtXg;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnWizualizacjaGraficzna;
        private System.Windows.Forms.Button btnWizualizacjaTabeleryczna;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtWykresSzeregu;
        private System.Windows.Forms.DataGridView dgvTWS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem liniaToruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grubośćLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stylLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liniaKreskowaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liniaKreskowaKrapkowaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem liniaKreskowaKrapkowaKrapkowaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liniaKrapkowaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agłasolidToolStripMenuItem;
    }
}