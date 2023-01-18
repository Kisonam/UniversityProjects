namespace Project3_Radovskyi61986
{
    partial class Projectowy_Radovskyi61986
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
            this.pbRisownica = new System.Windows.Forms.PictureBox();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbFigury_Linie = new System.Windows.Forms.GroupBox();
            this.rdbProstokąt = new System.Windows.Forms.RadioButton();
            this.rdbKwadrat = new System.Windows.Forms.RadioButton();
            this.rdbElipsa = new System.Windows.Forms.RadioButton();
            this.rdbOkrag = new System.Windows.Forms.RadioButton();
            this.rdbKrzywaBeziera = new System.Windows.Forms.RadioButton();
            this.rdbSklejanaKrzywaBeziera = new System.Windows.Forms.RadioButton();
            this.rdbKrzywaKardynalna = new System.Windows.Forms.RadioButton();
            this.rdbZamkniętaKrzywaKardynalna = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.koloryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atrybutyLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atrybutyKreślonejCzcionkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszaBitMapęWPlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odczytajBitMapęZPlikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitZFormularzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartProgramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorTłaRysownicyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorWypełnieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grubośćLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stylLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grotyRozpoczęciaLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grotyZakończeniaLiniiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.krójCzcionkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rozmiarCzcionkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolorCzcionkiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbRisownica)).BeginInit();
            this.grbFigury_Linie.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbRisownica
            // 
            this.pbRisownica.Location = new System.Drawing.Point(12, 99);
            this.pbRisownica.Name = "pbRisownica";
            this.pbRisownica.Size = new System.Drawing.Size(1041, 560);
            this.pbRisownica.TabIndex = 1;
            this.pbRisownica.TabStop = false;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblY.Location = new System.Drawing.Point(367, 63);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(23, 21);
            this.lblY.TabIndex = 7;
            this.lblY.Text = "Y";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblX.Location = new System.Drawing.Point(315, 63);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(23, 21);
            this.lblX.TabIndex = 6;
            this.lblX.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sługebne X & Y aktualnego myszi";
            // 
            // grbFigury_Linie
            // 
            this.grbFigury_Linie.Controls.Add(this.rdbZamkniętaKrzywaKardynalna);
            this.grbFigury_Linie.Controls.Add(this.rdbKrzywaKardynalna);
            this.grbFigury_Linie.Controls.Add(this.rdbSklejanaKrzywaBeziera);
            this.grbFigury_Linie.Controls.Add(this.rdbKrzywaBeziera);
            this.grbFigury_Linie.Controls.Add(this.rdbOkrag);
            this.grbFigury_Linie.Controls.Add(this.rdbElipsa);
            this.grbFigury_Linie.Controls.Add(this.rdbKwadrat);
            this.grbFigury_Linie.Controls.Add(this.rdbProstokąt);
            this.grbFigury_Linie.Location = new System.Drawing.Point(1068, 99);
            this.grbFigury_Linie.Name = "grbFigury_Linie";
            this.grbFigury_Linie.Size = new System.Drawing.Size(309, 560);
            this.grbFigury_Linie.TabIndex = 8;
            this.grbFigury_Linie.TabStop = false;
            this.grbFigury_Linie.Text = "Wybierz (zaznacz) figurę lub linię geometryczną";
            // 
            // rdbProstokąt
            // 
            this.rdbProstokąt.AutoSize = true;
            this.rdbProstokąt.Location = new System.Drawing.Point(6, 31);
            this.rdbProstokąt.Name = "rdbProstokąt";
            this.rdbProstokąt.Size = new System.Drawing.Size(128, 17);
            this.rdbProstokąt.TabIndex = 0;
            this.rdbProstokąt.TabStop = true;
            this.rdbProstokąt.Text = "Prostokąt (Rectangle)";
            this.rdbProstokąt.UseVisualStyleBackColor = true;
            // 
            // rdbKwadrat
            // 
            this.rdbKwadrat.AutoSize = true;
            this.rdbKwadrat.Location = new System.Drawing.Point(6, 54);
            this.rdbKwadrat.Name = "rdbKwadrat";
            this.rdbKwadrat.Size = new System.Drawing.Size(64, 17);
            this.rdbKwadrat.TabIndex = 1;
            this.rdbKwadrat.TabStop = true;
            this.rdbKwadrat.Text = "Kwadrat";
            this.rdbKwadrat.UseVisualStyleBackColor = true;
            // 
            // rdbElipsa
            // 
            this.rdbElipsa.AutoSize = true;
            this.rdbElipsa.Location = new System.Drawing.Point(6, 77);
            this.rdbElipsa.Name = "rdbElipsa";
            this.rdbElipsa.Size = new System.Drawing.Size(90, 17);
            this.rdbElipsa.TabIndex = 2;
            this.rdbElipsa.TabStop = true;
            this.rdbElipsa.Text = "Elipsa (Elipse)";
            this.rdbElipsa.UseVisualStyleBackColor = true;
            // 
            // rdbOkrag
            // 
            this.rdbOkrag.AutoSize = true;
            this.rdbOkrag.Location = new System.Drawing.Point(6, 100);
            this.rdbOkrag.Name = "rdbOkrag";
            this.rdbOkrag.Size = new System.Drawing.Size(54, 17);
            this.rdbOkrag.TabIndex = 3;
            this.rdbOkrag.TabStop = true;
            this.rdbOkrag.Text = "Okrag";
            this.rdbOkrag.UseVisualStyleBackColor = true;
            // 
            // rdbKrzywaBeziera
            // 
            this.rdbKrzywaBeziera.AutoSize = true;
            this.rdbKrzywaBeziera.Location = new System.Drawing.Point(6, 123);
            this.rdbKrzywaBeziera.Name = "rdbKrzywaBeziera";
            this.rdbKrzywaBeziera.Size = new System.Drawing.Size(168, 17);
            this.rdbKrzywaBeziera.TabIndex = 4;
            this.rdbKrzywaBeziera.TabStop = true;
            this.rdbKrzywaBeziera.Text = "Krzywa Beziera (Draw Beziers)";
            this.rdbKrzywaBeziera.UseVisualStyleBackColor = true;
            this.rdbKrzywaBeziera.CheckedChanged += new System.EventHandler(this.rdbKrzywaBeziera_CheckedChanged);
            // 
            // rdbSklejanaKrzywaBeziera
            // 
            this.rdbSklejanaKrzywaBeziera.AutoSize = true;
            this.rdbSklejanaKrzywaBeziera.Location = new System.Drawing.Point(6, 146);
            this.rdbSklejanaKrzywaBeziera.Name = "rdbSklejanaKrzywaBeziera";
            this.rdbSklejanaKrzywaBeziera.Size = new System.Drawing.Size(143, 17);
            this.rdbSklejanaKrzywaBeziera.TabIndex = 5;
            this.rdbSklejanaKrzywaBeziera.TabStop = true;
            this.rdbSklejanaKrzywaBeziera.Text = "Sklejana krzywa Beziera ";
            this.rdbSklejanaKrzywaBeziera.UseVisualStyleBackColor = true;
            // 
            // rdbKrzywaKardynalna
            // 
            this.rdbKrzywaKardynalna.AutoSize = true;
            this.rdbKrzywaKardynalna.Location = new System.Drawing.Point(6, 169);
            this.rdbKrzywaKardynalna.Name = "rdbKrzywaKardynalna";
            this.rdbKrzywaKardynalna.Size = new System.Drawing.Size(176, 17);
            this.rdbKrzywaKardynalna.TabIndex = 6;
            this.rdbKrzywaKardynalna.TabStop = true;
            this.rdbKrzywaKardynalna.Text = "Krzywa kardynalna (DrawCurve)";
            this.rdbKrzywaKardynalna.UseVisualStyleBackColor = true;
            // 
            // rdbZamkniętaKrzywaKardynalna
            // 
            this.rdbZamkniętaKrzywaKardynalna.AutoSize = true;
            this.rdbZamkniętaKrzywaKardynalna.Location = new System.Drawing.Point(6, 192);
            this.rdbZamkniętaKrzywaKardynalna.Name = "rdbZamkniętaKrzywaKardynalna";
            this.rdbZamkniętaKrzywaKardynalna.Size = new System.Drawing.Size(260, 17);
            this.rdbZamkniętaKrzywaKardynalna.TabIndex = 7;
            this.rdbZamkniętaKrzywaKardynalna.TabStop = true;
            this.rdbZamkniętaKrzywaKardynalna.Text = "Zamknięta krzywa kardynalna (DrawClosedCurve)";
            this.rdbZamkniętaKrzywaKardynalna.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.koloryToolStripMenuItem,
            this.atrybutyLiniiToolStripMenuItem,
            this.atrybutyKreślonejCzcionkiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1478, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zapiszaBitMapęWPlikuToolStripMenuItem,
            this.odczytajBitMapęZPlikuToolStripMenuItem,
            this.exitZFormularzaToolStripMenuItem,
            this.restartProgramuToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // koloryToolStripMenuItem
            // 
            this.koloryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kolorLiniiToolStripMenuItem,
            this.kolorTłaRysownicyToolStripMenuItem,
            this.kolorWypełnieniaToolStripMenuItem});
            this.koloryToolStripMenuItem.Name = "koloryToolStripMenuItem";
            this.koloryToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.koloryToolStripMenuItem.Text = "Kolory";
            // 
            // atrybutyLiniiToolStripMenuItem
            // 
            this.atrybutyLiniiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grubośćLiniiToolStripMenuItem,
            this.stylLiniiToolStripMenuItem,
            this.grotyRozpoczęciaLiniiToolStripMenuItem,
            this.grotyZakończeniaLiniiToolStripMenuItem});
            this.atrybutyLiniiToolStripMenuItem.Name = "atrybutyLiniiToolStripMenuItem";
            this.atrybutyLiniiToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.atrybutyLiniiToolStripMenuItem.Text = "Styl linii";
            // 
            // atrybutyKreślonejCzcionkiToolStripMenuItem
            // 
            this.atrybutyKreślonejCzcionkiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.krójCzcionkiToolStripMenuItem,
            this.rozmiarCzcionkiToolStripMenuItem,
            this.kolorCzcionkiToolStripMenuItem});
            this.atrybutyKreślonejCzcionkiToolStripMenuItem.Name = "atrybutyKreślonejCzcionkiToolStripMenuItem";
            this.atrybutyKreślonejCzcionkiToolStripMenuItem.Size = new System.Drawing.Size(161, 20);
            this.atrybutyKreślonejCzcionkiToolStripMenuItem.Text = "Atrybuty kreślonej czcionki";
            // 
            // zapiszaBitMapęWPlikuToolStripMenuItem
            // 
            this.zapiszaBitMapęWPlikuToolStripMenuItem.Name = "zapiszaBitMapęWPlikuToolStripMenuItem";
            this.zapiszaBitMapęWPlikuToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.zapiszaBitMapęWPlikuToolStripMenuItem.Text = "Zapisza BitMapę w pliku";
            // 
            // odczytajBitMapęZPlikuToolStripMenuItem
            // 
            this.odczytajBitMapęZPlikuToolStripMenuItem.Name = "odczytajBitMapęZPlikuToolStripMenuItem";
            this.odczytajBitMapęZPlikuToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.odczytajBitMapęZPlikuToolStripMenuItem.Text = "Odczytaj BitMapę z pliku";
            // 
            // exitZFormularzaToolStripMenuItem
            // 
            this.exitZFormularzaToolStripMenuItem.Name = "exitZFormularzaToolStripMenuItem";
            this.exitZFormularzaToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.exitZFormularzaToolStripMenuItem.Text = "Exit z formularza";
            // 
            // restartProgramuToolStripMenuItem
            // 
            this.restartProgramuToolStripMenuItem.Name = "restartProgramuToolStripMenuItem";
            this.restartProgramuToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.restartProgramuToolStripMenuItem.Text = "Restart programu";
            // 
            // kolorLiniiToolStripMenuItem
            // 
            this.kolorLiniiToolStripMenuItem.Name = "kolorLiniiToolStripMenuItem";
            this.kolorLiniiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kolorLiniiToolStripMenuItem.Text = "Kolor linii";
            // 
            // kolorTłaRysownicyToolStripMenuItem
            // 
            this.kolorTłaRysownicyToolStripMenuItem.Name = "kolorTłaRysownicyToolStripMenuItem";
            this.kolorTłaRysownicyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kolorTłaRysownicyToolStripMenuItem.Text = "Kolor tła rysownicy";
            // 
            // kolorWypełnieniaToolStripMenuItem
            // 
            this.kolorWypełnieniaToolStripMenuItem.Name = "kolorWypełnieniaToolStripMenuItem";
            this.kolorWypełnieniaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kolorWypełnieniaToolStripMenuItem.Text = "Kolor wypełnienia";
            // 
            // grubośćLiniiToolStripMenuItem
            // 
            this.grubośćLiniiToolStripMenuItem.Name = "grubośćLiniiToolStripMenuItem";
            this.grubośćLiniiToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.grubośćLiniiToolStripMenuItem.Text = "Grubość linii";
            // 
            // stylLiniiToolStripMenuItem
            // 
            this.stylLiniiToolStripMenuItem.Name = "stylLiniiToolStripMenuItem";
            this.stylLiniiToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.stylLiniiToolStripMenuItem.Text = "Styl linii";
            // 
            // grotyRozpoczęciaLiniiToolStripMenuItem
            // 
            this.grotyRozpoczęciaLiniiToolStripMenuItem.Name = "grotyRozpoczęciaLiniiToolStripMenuItem";
            this.grotyRozpoczęciaLiniiToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.grotyRozpoczęciaLiniiToolStripMenuItem.Text = "Groty rozpoczęcia linii";
            // 
            // grotyZakończeniaLiniiToolStripMenuItem
            // 
            this.grotyZakończeniaLiniiToolStripMenuItem.Name = "grotyZakończeniaLiniiToolStripMenuItem";
            this.grotyZakończeniaLiniiToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.grotyZakończeniaLiniiToolStripMenuItem.Text = "Groty zakończenia linii";
            // 
            // krójCzcionkiToolStripMenuItem
            // 
            this.krójCzcionkiToolStripMenuItem.Name = "krójCzcionkiToolStripMenuItem";
            this.krójCzcionkiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.krójCzcionkiToolStripMenuItem.Text = "Krój czcionki";
            // 
            // rozmiarCzcionkiToolStripMenuItem
            // 
            this.rozmiarCzcionkiToolStripMenuItem.Name = "rozmiarCzcionkiToolStripMenuItem";
            this.rozmiarCzcionkiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rozmiarCzcionkiToolStripMenuItem.Text = "Rozmiar czcionki";
            // 
            // kolorCzcionkiToolStripMenuItem
            // 
            this.kolorCzcionkiToolStripMenuItem.Name = "kolorCzcionkiToolStripMenuItem";
            this.kolorCzcionkiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kolorCzcionkiToolStripMenuItem.Text = "Kolor czcionki";
            // 
            // Projectowy_Radovskyi61986
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 711);
            this.Controls.Add(this.grbFigury_Linie);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbRisownica);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Projectowy_Radovskyi61986";
            this.Text = "Projectowy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Projectowy_Radovskyi61986_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Projectowy_Radovskyi61986_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Projectowy_Radovskyi61986_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Projectowy_Radovskyi61986_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbRisownica)).EndInit();
            this.grbFigury_Linie.ResumeLayout(false);
            this.grbFigury_Linie.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRisownica;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbFigury_Linie;
        private System.Windows.Forms.RadioButton rdbElipsa;
        private System.Windows.Forms.RadioButton rdbKwadrat;
        private System.Windows.Forms.RadioButton rdbProstokąt;
        private System.Windows.Forms.RadioButton rdbSklejanaKrzywaBeziera;
        private System.Windows.Forms.RadioButton rdbKrzywaBeziera;
        private System.Windows.Forms.RadioButton rdbOkrag;
        private System.Windows.Forms.RadioButton rdbZamkniętaKrzywaKardynalna;
        private System.Windows.Forms.RadioButton rdbKrzywaKardynalna;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszaBitMapęWPlikuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odczytajBitMapęZPlikuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitZFormularzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartProgramuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem koloryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolorLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolorTłaRysownicyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolorWypełnieniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atrybutyLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grubośćLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stylLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grotyRozpoczęciaLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grotyZakończeniaLiniiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atrybutyKreślonejCzcionkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem krójCzcionkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rozmiarCzcionkiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kolorCzcionkiToolStripMenuItem;
    }
}