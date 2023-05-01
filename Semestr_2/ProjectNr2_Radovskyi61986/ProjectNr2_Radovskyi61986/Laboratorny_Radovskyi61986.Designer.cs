namespace ProjectNr2_Radovskyi61986
{
    partial class Laboratorny_Radovskyi61986
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtH = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chblFiguryGeometryczne = new System.Windows.Forms.CheckedListBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnXY = new System.Windows.Forms.Button();
            this.btnWłącz = new System.Windows.Forms.Button();
            this.btnWyłącz = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.rdbManualny = new System.Windows.Forms.RadioButton();
            this.rdbAuto = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnDodaj = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrzesuńIZmiana = new System.Windows.Forms.Button();
            this.btnKolorLinii = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // txtH
            // 
            this.txtH.Location = new System.Drawing.Point(12, 45);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(156, 20);
            this.txtH.TabIndex = 1;
            this.txtH.TextChanged += new System.EventHandler(this.txtH_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(174, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(738, 411);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // chblFiguryGeometryczne
            // 
            this.chblFiguryGeometryczne.FormattingEnabled = true;
            this.chblFiguryGeometryczne.Items.AddRange(new object[] {
            "Punkt",
            "Linia",
            "Elipsa",
            "Prostokąt",
            "Okrag"});
            this.chblFiguryGeometryczne.Location = new System.Drawing.Point(918, 45);
            this.chblFiguryGeometryczne.Name = "chblFiguryGeometryczne";
            this.chblFiguryGeometryczne.Size = new System.Drawing.Size(162, 139);
            this.chblFiguryGeometryczne.TabIndex = 5;
            this.chblFiguryGeometryczne.SelectedIndexChanged += new System.EventHandler(this.chblFiguryGeometryczne_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnXY
            // 
            this.btnXY.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnXY.Location = new System.Drawing.Point(12, 123);
            this.btnXY.Name = "btnXY";
            this.btnXY.Size = new System.Drawing.Size(156, 91);
            this.btnXY.TabIndex = 6;
            this.btnXY.Text = "Przesumniącie wszystkich figur do nowego położenia bez zmiany atrybutów graficzny" +
    "ch ";
            this.btnXY.UseVisualStyleBackColor = true;
            this.btnXY.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnWłącz
            // 
            this.btnWłącz.Location = new System.Drawing.Point(918, 190);
            this.btnWłącz.Name = "btnWłącz";
            this.btnWłącz.Size = new System.Drawing.Size(162, 45);
            this.btnWłącz.TabIndex = 7;
            this.btnWłącz.Text = "Włącz pokaz figur";
            this.btnWłącz.UseVisualStyleBackColor = true;
            this.btnWłącz.Click += new System.EventHandler(this.btnWłącz_Click);
            // 
            // btnWyłącz
            // 
            this.btnWyłącz.Location = new System.Drawing.Point(918, 241);
            this.btnWyłącz.Name = "btnWyłącz";
            this.btnWyłącz.Size = new System.Drawing.Size(162, 44);
            this.btnWyłącz.TabIndex = 8;
            this.btnWyłącz.Text = "Wyłącz pokaz figur";
            this.btnWyłącz.UseVisualStyleBackColor = true;
            this.btnWyłącz.Click += new System.EventHandler(this.btnWyłącz_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.rdbManualny);
            this.groupBox1.Controls.Add(this.rdbAuto);
            this.groupBox1.Location = new System.Drawing.Point(918, 291);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 153);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tryb pokazu figur geometrycznych";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 96);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Poprzednia";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 67);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Następn";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // rdbManualny
            // 
            this.rdbManualny.AutoSize = true;
            this.rdbManualny.Location = new System.Drawing.Point(7, 44);
            this.rdbManualny.Name = "rdbManualny";
            this.rdbManualny.Size = new System.Drawing.Size(71, 17);
            this.rdbManualny.TabIndex = 1;
            this.rdbManualny.TabStop = true;
            this.rdbManualny.Text = "Manualny";
            this.rdbManualny.UseVisualStyleBackColor = true;
            this.rdbManualny.CheckedChanged += new System.EventHandler(this.rdbManualny_CheckedChanged);
            // 
            // rdbAuto
            // 
            this.rdbAuto.AutoSize = true;
            this.rdbAuto.Location = new System.Drawing.Point(7, 20);
            this.rdbAuto.Name = "rdbAuto";
            this.rdbAuto.Size = new System.Drawing.Size(145, 17);
            this.rdbAuto.TabIndex = 0;
            this.rdbAuto.TabStop = true;
            this.rdbAuto.Text = "Automatyczny (zegarowy)";
            this.rdbAuto.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(12, 406);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(156, 50);
            this.btnDodaj.TabIndex = 10;
            this.btnDodaj.Text = "Dodaj nową figurę geometryczną";
            this.btnDodaj.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Podaj liczbę figur geometrycznych";
            // 
            // btnPrzesuńIZmiana
            // 
            this.btnPrzesuńIZmiana.Location = new System.Drawing.Point(12, 220);
            this.btnPrzesuńIZmiana.Name = "btnPrzesuńIZmiana";
            this.btnPrzesuńIZmiana.Size = new System.Drawing.Size(156, 80);
            this.btnPrzesuńIZmiana.TabIndex = 12;
            this.btnPrzesuńIZmiana.Text = "Przesumniącie wszystkich figur do nowego położenia i zmiana atrybutów graficznych" +
    " ";
            this.btnPrzesuńIZmiana.UseVisualStyleBackColor = true;
            this.btnPrzesuńIZmiana.Click += new System.EventHandler(this.btnPrzesuńIZmiana_Click);
            // 
            // btnKolorLinii
            // 
            this.btnKolorLinii.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnKolorLinii.Location = new System.Drawing.Point(174, 485);
            this.btnKolorLinii.Name = "btnKolorLinii";
            this.btnKolorLinii.Size = new System.Drawing.Size(152, 40);
            this.btnKolorLinii.TabIndex = 13;
            this.btnKolorLinii.Text = "Zmień kolor linii";
            this.btnKolorLinii.UseVisualStyleBackColor = true;
            this.btnKolorLinii.Click += new System.EventHandler(this.btnKolorLinii_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Wzierniki narzędzi graficznych:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 485);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Zmień styl linii";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot",
            "DashDot",
            "DashDotDot"});
            this.comboBox1.Location = new System.Drawing.Point(335, 501);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // Laboratorny_Radovskyi61986
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 588);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnKolorLinii);
            this.Controls.Add(this.btnPrzesuńIZmiana);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnWyłącz);
            this.Controls.Add(this.btnWłącz);
            this.Controls.Add(this.btnXY);
            this.Controls.Add(this.chblFiguryGeometryczne);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtH);
            this.Controls.Add(this.label1);
            this.Name = "Laboratorny_Radovskyi61986";
            this.Text = "Laboratorny_Radovskyi61986";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Laboratorny_Radovskyi61986_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckedListBox chblFiguryGeometryczne;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnXY;
        private System.Windows.Forms.Button btnWłącz;
        private System.Windows.Forms.Button btnWyłącz;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbManualny;
        private System.Windows.Forms.RadioButton rdbAuto;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnPrzesuńIZmiana;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKolorLinii;
    }
}