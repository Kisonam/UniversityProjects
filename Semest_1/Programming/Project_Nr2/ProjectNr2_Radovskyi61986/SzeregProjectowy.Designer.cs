namespace ProjectNr2_Radovskyi61986
{
    partial class SzeregProjectowy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtG = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLicznikWyrazów = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSumaSzeregu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textEps = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTWS = new System.Windows.Forms.DataGridView();
            this.WartośćX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WartośćSzeregu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Licznikyrazów = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chtWykresSzeregu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Analizator = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapisanieTablicyTWSWPlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odczytanieTablicyTWSZPlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustalanieAtrybutówFormularzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustalanieKoloruTłaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustalenieKoloruLiterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ustalenieRozmiaruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaAtrybutówWykresuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaKoloruLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaTypuWykresuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaGrubościLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zmianaCzionkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnResetu = new System.Windows.Forms.Button();
            this.btnWizualizacjaGraficzna = new System.Windows.Forms.Button();
            this.btnWizualizacjaTabelaryczna = new System.Windows.Forms.Button();
            this.buttonObliczWartośćSzeregu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTWS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtWykresSzeregu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(22, 395);
            this.txtH.Multiline = true;
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(217, 36);
            this.txtH.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(42, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 38);
            this.label7.TabIndex = 29;
            this.label7.Text = "Przyrost h zmian \r\nwartości zmiennej X";
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(22, 315);
            this.txtG.Multiline = true;
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(217, 36);
            this.txtG.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(42, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 19);
            this.label6.TabIndex = 27;
            this.label6.Text = "Górna granica Xg";
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(22, 248);
            this.txtD.Multiline = true;
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(217, 36);
            this.txtD.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(42, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 19);
            this.label5.TabIndex = 25;
            this.label5.Text = "Dolna granica Xd";
            // 
            // txtLicznikWyrazów
            // 
            this.txtLicznikWyrazów.Location = new System.Drawing.Point(1035, 197);
            this.txtLicznikWyrazów.Multiline = true;
            this.txtLicznikWyrazów.Name = "txtLicznikWyrazów";
            this.txtLicznikWyrazów.ReadOnly = true;
            this.txtLicznikWyrazów.Size = new System.Drawing.Size(180, 35);
            this.txtLicznikWyrazów.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1054, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 38);
            this.label4.TabIndex = 23;
            this.label4.Text = "Licznik zmusowanych\r\nwyzazów szeregu";
            // 
            // txtSumaSzeregu
            // 
            this.txtSumaSzeregu.Location = new System.Drawing.Point(1038, 112);
            this.txtSumaSzeregu.Multiline = true;
            this.txtSumaSzeregu.Name = "txtSumaSzeregu";
            this.txtSumaSzeregu.ReadOnly = true;
            this.txtSumaSzeregu.Size = new System.Drawing.Size(180, 39);
            this.txtSumaSzeregu.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1034, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 19);
            this.label3.TabIndex = 21;
            this.label3.Text = "Obliczona wartość szeregu";
            // 
            // textEps
            // 
            this.textEps.Location = new System.Drawing.Point(22, 183);
            this.textEps.Multiline = true;
            this.textEps.Name = "textEps";
            this.textEps.Size = new System.Drawing.Size(217, 36);
            this.textEps.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(41, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Dokładność obliczeń EPS";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(22, 117);
            this.txtX.Multiline = true;
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(217, 36);
            this.txtX.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "Wartość zmiennej niezależnej X";
            // 
            // dgvTWS
            // 
            this.dgvTWS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTWS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WartośćX,
            this.WartośćSzeregu,
            this.Licznikyrazów});
            this.dgvTWS.Location = new System.Drawing.Point(328, 95);
            this.dgvTWS.Name = "dgvTWS";
            this.dgvTWS.Size = new System.Drawing.Size(643, 527);
            this.dgvTWS.TabIndex = 31;
            this.dgvTWS.Visible = false;
            // 
            // WartośćX
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.WartośćX.DefaultCellStyle = dataGridViewCellStyle4;
            this.WartośćX.HeaderText = "Warość zmiennej X";
            this.WartośćX.MinimumWidth = 8;
            this.WartośćX.Name = "WartośćX";
            this.WartośćX.Width = 150;
            // 
            // WartośćSzeregu
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.WartośćSzeregu.DefaultCellStyle = dataGridViewCellStyle5;
            this.WartośćSzeregu.HeaderText = "Obliczona wartość szeregu ";
            this.WartośćSzeregu.MinimumWidth = 8;
            this.WartośćSzeregu.Name = "WartośćSzeregu";
            this.WartośćSzeregu.Width = 200;
            // 
            // Licznikyrazów
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Licznikyrazów.DefaultCellStyle = dataGridViewCellStyle6;
            this.Licznikyrazów.HeaderText = "Licznik zsumowanych wyrazów";
            this.Licznikyrazów.MinimumWidth = 8;
            this.Licznikyrazów.Name = "Licznikyrazów";
            this.Licznikyrazów.Width = 250;
            // 
            // chtWykresSzeregu
            // 
            chartArea2.Name = "ChartArea1";
            this.chtWykresSzeregu.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chtWykresSzeregu.Legends.Add(legend2);
            this.chtWykresSzeregu.Location = new System.Drawing.Point(328, 95);
            this.chtWykresSzeregu.Name = "chtWykresSzeregu";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chtWykresSzeregu.Series.Add(series2);
            this.chtWykresSzeregu.Size = new System.Drawing.Size(643, 527);
            this.chtWykresSzeregu.TabIndex = 32;
            this.chtWykresSzeregu.Text = "Wykres Szeregu Potęgowego";
            this.chtWykresSzeregu.Visible = false;
            this.chtWykresSzeregu.Click += new System.EventHandler(this.chtWykresSzeregu_Click);
            // 
            // Analizator
            // 
            this.Analizator.AccessibleDescription = "Analizator";
            this.Analizator.AccessibleName = "Analizator";
            this.Analizator.AutoSize = true;
            this.Analizator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Analizator.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Analizator.Location = new System.Drawing.Point(421, 29);
            this.Analizator.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.Analizator.Name = "Analizator";
            this.Analizator.Size = new System.Drawing.Size(416, 26);
            this.Analizator.TabIndex = 33;
            this.Analizator.Tag = "";
            this.Analizator.Text = "Analizator projectowego szeregu potęgowego\r\n";
            this.Analizator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.ustalanieAtrybutówFormularzaToolStripMenuItem,
            this.zmianaAtrybutówWykresuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1236, 24);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zapisanieTablicyTWSWPlikuToolStripMenuItem,
            this.odczytanieTablicyTWSZPlikuToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // zapisanieTablicyTWSWPlikuToolStripMenuItem
            // 
            this.zapisanieTablicyTWSWPlikuToolStripMenuItem.Name = "zapisanieTablicyTWSWPlikuToolStripMenuItem";
            this.zapisanieTablicyTWSWPlikuToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.zapisanieTablicyTWSWPlikuToolStripMenuItem.Text = "Zapisanie tablicy TWS w pliku";
            this.zapisanieTablicyTWSWPlikuToolStripMenuItem.Click += new System.EventHandler(this.zapisanieTablicyTWSWPlikuToolStripMenuItem_Click);
            // 
            // odczytanieTablicyTWSZPlikuToolStripMenuItem
            // 
            this.odczytanieTablicyTWSZPlikuToolStripMenuItem.Name = "odczytanieTablicyTWSZPlikuToolStripMenuItem";
            this.odczytanieTablicyTWSZPlikuToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.odczytanieTablicyTWSZPlikuToolStripMenuItem.Text = "Odczytanie tablicy TWS z pliku";
            this.odczytanieTablicyTWSZPlikuToolStripMenuItem.Click += new System.EventHandler(this.odczytanieTablicyTWSZPlikuToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ustalanieAtrybutówFormularzaToolStripMenuItem
            // 
            this.ustalanieAtrybutówFormularzaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ustalanieKoloruTłaToolStripMenuItem,
            this.ustalenieKoloruLiterToolStripMenuItem,
            this.ustalenieRozmiaruToolStripMenuItem});
            this.ustalanieAtrybutówFormularzaToolStripMenuItem.Name = "ustalanieAtrybutówFormularzaToolStripMenuItem";
            this.ustalanieAtrybutówFormularzaToolStripMenuItem.Size = new System.Drawing.Size(184, 20);
            this.ustalanieAtrybutówFormularzaToolStripMenuItem.Text = "Ustalanie atrybutów formularza";
            // 
            // ustalanieKoloruTłaToolStripMenuItem
            // 
            this.ustalanieKoloruTłaToolStripMenuItem.Name = "ustalanieKoloruTłaToolStripMenuItem";
            this.ustalanieKoloruTłaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ustalanieKoloruTłaToolStripMenuItem.Text = "Ustalenie koloru tła";
            this.ustalanieKoloruTłaToolStripMenuItem.Click += new System.EventHandler(this.ustalanieKoloruTłaToolStripMenuItem_Click);
            // 
            // ustalenieKoloruLiterToolStripMenuItem
            // 
            this.ustalenieKoloruLiterToolStripMenuItem.Name = "ustalenieKoloruLiterToolStripMenuItem";
            this.ustalenieKoloruLiterToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ustalenieKoloruLiterToolStripMenuItem.Text = "Ustalenie koloru liter";
            this.ustalenieKoloruLiterToolStripMenuItem.Click += new System.EventHandler(this.ustalenieKoloruLiterToolStripMenuItem_Click);
            // 
            // ustalenieRozmiaruToolStripMenuItem
            // 
            this.ustalenieRozmiaruToolStripMenuItem.Name = "ustalenieRozmiaruToolStripMenuItem";
            this.ustalenieRozmiaruToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ustalenieRozmiaruToolStripMenuItem.Text = "Ustalenie rozmiaru ";
            this.ustalenieRozmiaruToolStripMenuItem.Click += new System.EventHandler(this.ustalenieRozmiaruToolStripMenuItem_Click);
            // 
            // zmianaAtrybutówWykresuToolStripMenuItem
            // 
            this.zmianaAtrybutówWykresuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zmianaKoloruLiniiToolStripMenuItem,
            this.zmianaTypuWykresuToolStripMenuItem,
            this.zmianaGrubościLiniiToolStripMenuItem,
            this.zmianaCzionkiToolStripMenuItem});
            this.zmianaAtrybutówWykresuToolStripMenuItem.Name = "zmianaAtrybutówWykresuToolStripMenuItem";
            this.zmianaAtrybutówWykresuToolStripMenuItem.Size = new System.Drawing.Size(162, 20);
            this.zmianaAtrybutówWykresuToolStripMenuItem.Text = "Zmiana atrybutów wykresu";
            // 
            // zmianaKoloruLiniiToolStripMenuItem
            // 
            this.zmianaKoloruLiniiToolStripMenuItem.Name = "zmianaKoloruLiniiToolStripMenuItem";
            this.zmianaKoloruLiniiToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.zmianaKoloruLiniiToolStripMenuItem.Text = "Zmiana koloru linii";
            this.zmianaKoloruLiniiToolStripMenuItem.Click += new System.EventHandler(this.zmianaKoloruLiniiToolStripMenuItem_Click);
            // 
            // zmianaTypuWykresuToolStripMenuItem
            // 
            this.zmianaTypuWykresuToolStripMenuItem.Name = "zmianaTypuWykresuToolStripMenuItem";
            this.zmianaTypuWykresuToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.zmianaTypuWykresuToolStripMenuItem.Text = "Zmiana typu wykresu";
            // 
            // zmianaGrubościLiniiToolStripMenuItem
            // 
            this.zmianaGrubościLiniiToolStripMenuItem.Name = "zmianaGrubościLiniiToolStripMenuItem";
            this.zmianaGrubościLiniiToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.zmianaGrubościLiniiToolStripMenuItem.Text = "Zmiana grubości linii";
            // 
            // zmianaCzionkiToolStripMenuItem
            // 
            this.zmianaCzionkiToolStripMenuItem.Name = "zmianaCzionkiToolStripMenuItem";
            this.zmianaCzionkiToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.zmianaCzionkiToolStripMenuItem.Text = "Zmiana czionki";
            this.zmianaCzionkiToolStripMenuItem.Click += new System.EventHandler(this.zmianaCzionkiToolStripMenuItem_Click);
            // 
            // btnResetu
            // 
            this.btnResetu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnResetu.Location = new System.Drawing.Point(1035, 450);
            this.btnResetu.Name = "btnResetu";
            this.btnResetu.Size = new System.Drawing.Size(180, 34);
            this.btnResetu.TabIndex = 39;
            this.btnResetu.Text = "Reset";
            this.btnResetu.UseVisualStyleBackColor = true;
            this.btnResetu.Click += new System.EventHandler(this.btnResetu_Click);
            // 
            // btnWizualizacjaGraficzna
            // 
            this.btnWizualizacjaGraficzna.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWizualizacjaGraficzna.Location = new System.Drawing.Point(1035, 395);
            this.btnWizualizacjaGraficzna.Name = "btnWizualizacjaGraficzna";
            this.btnWizualizacjaGraficzna.Size = new System.Drawing.Size(180, 49);
            this.btnWizualizacjaGraficzna.TabIndex = 38;
            this.btnWizualizacjaGraficzna.Text = "Wizualizacja graficzna zmian wartości szeregu potęgowego";
            this.btnWizualizacjaGraficzna.UseVisualStyleBackColor = true;
            this.btnWizualizacjaGraficzna.Click += new System.EventHandler(this.btnWizualizacjaGraficzna_Click);
            // 
            // btnWizualizacjaTabelaryczna
            // 
            this.btnWizualizacjaTabelaryczna.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWizualizacjaTabelaryczna.Location = new System.Drawing.Point(1035, 319);
            this.btnWizualizacjaTabelaryczna.Name = "btnWizualizacjaTabelaryczna";
            this.btnWizualizacjaTabelaryczna.Size = new System.Drawing.Size(180, 66);
            this.btnWizualizacjaTabelaryczna.TabIndex = 36;
            this.btnWizualizacjaTabelaryczna.Text = "Tabelaryczna wizualizacja\r\nzmian wartości szeregu\r\npotęgowego";
            this.btnWizualizacjaTabelaryczna.UseVisualStyleBackColor = true;
            this.btnWizualizacjaTabelaryczna.Click += new System.EventHandler(this.btnWizualizacjaTabelaryczna_Click);
            // 
            // buttonObliczWartośćSzeregu
            // 
            this.buttonObliczWartośćSzeregu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonObliczWartośćSzeregu.Location = new System.Drawing.Point(1035, 248);
            this.buttonObliczWartośćSzeregu.Name = "buttonObliczWartośćSzeregu";
            this.buttonObliczWartośćSzeregu.Size = new System.Drawing.Size(180, 65);
            this.buttonObliczWartośćSzeregu.TabIndex = 35;
            this.buttonObliczWartośćSzeregu.Text = "Oblicz wartość szeregu";
            this.buttonObliczWartośćSzeregu.UseVisualStyleBackColor = true;
            this.buttonObliczWartośćSzeregu.Click += new System.EventHandler(this.buttonObliczWartośćSzeregu_Click);
            // 
            // SzeregProjectowy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1236, 649);
            this.Controls.Add(this.btnResetu);
            this.Controls.Add(this.btnWizualizacjaGraficzna);
            this.Controls.Add(this.btnWizualizacjaTabelaryczna);
            this.Controls.Add(this.buttonObliczWartośćSzeregu);
            this.Controls.Add(this.Analizator);
            this.Controls.Add(this.chtWykresSzeregu);
            this.Controls.Add(this.dgvTWS);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtG);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLicznikWyrazów);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSumaSzeregu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textEps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SzeregProjectowy";
            this.Text = "SzeregProjectowy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SzeregProjectowy_FormClosing);
            this.Load += new System.EventHandler(this.SzeregProjectowy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTWS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtWykresSzeregu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLicznikWyrazów;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSumaSzeregu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textEps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTWS;
        private System.Windows.Forms.DataGridViewTextBoxColumn WartośćX;
        private System.Windows.Forms.DataGridViewTextBoxColumn WartośćSzeregu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Licznikyrazów;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtWykresSzeregu;
        private System.Windows.Forms.Label Analizator;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapisanieTablicyTWSWPlikuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odczytanieTablicyTWSZPlikuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustalanieAtrybutówFormularzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustalanieKoloruTłaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustalenieKoloruLiterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ustalenieRozmiaruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaAtrybutówWykresuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaKoloruLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaTypuWykresuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaGrubościLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zmianaCzionkiToolStripMenuItem;
        private System.Windows.Forms.Button btnResetu;
        private System.Windows.Forms.Button btnWizualizacjaGraficzna;
        private System.Windows.Forms.Button btnWizualizacjaTabelaryczna;
        private System.Windows.Forms.Button buttonObliczWartośćSzeregu;
    }
}