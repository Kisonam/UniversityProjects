﻿namespace Project3_Radovskyi61986
{
    partial class Laboratoryjny_Radovskyi61986
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
            this.pbRisownica = new System.Windows.Forms.PictureBox();
            this.gbWybórKrzywych = new System.Windows.Forms.GroupBox();
            this.rdbFraktal = new System.Windows.Forms.RadioButton();
            this.rdDywanSierpińskiego = new System.Windows.Forms.RadioButton();
            this.NUD_WielokątWypelniony = new System.Windows.Forms.NumericUpDown();
            this.lblLiczbaWyp = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.NumUD_Rekwencja = new System.Windows.Forms.NumericUpDown();
            this.lblRekwęcja = new System.Windows.Forms.Label();
            this.rdbTrójkąSierpińskiego = new System.Windows.Forms.RadioButton();
            this.NumU = new System.Windows.Forms.NumericUpDown();
            this.rdbGwiazdaWieloramienna = new System.Windows.Forms.RadioButton();
            this.lblLiczba = new System.Windows.Forms.Label();
            this.rdbWielokatWypelniony = new System.Windows.Forms.RadioButton();
            this.rdbWielokatForemny = new System.Windows.Forms.RadioButton();
            this.rdbLiniaKreślena = new System.Windows.Forms.RadioButton();
            this.rdbLiniaProsta = new System.Windows.Forms.RadioButton();
            this.rdbPunkt = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbRisownica)).BeginInit();
            this.gbWybórKrzywych.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_WielokątWypelniony)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_Rekwencja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumU)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRisownica
            // 
            this.pbRisownica.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbRisownica.Location = new System.Drawing.Point(12, 51);
            this.pbRisownica.Name = "pbRisownica";
            this.pbRisownica.Size = new System.Drawing.Size(1001, 560);
            this.pbRisownica.TabIndex = 0;
            this.pbRisownica.TabStop = false;
            this.pbRisownica.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbRisownica_MouseDown);
            this.pbRisownica.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbRisownica_MouseMove);
            this.pbRisownica.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbRisownica_MouseUp);
            // 
            // gbWybórKrzywych
            // 
            this.gbWybórKrzywych.Controls.Add(this.rdbFraktal);
            this.gbWybórKrzywych.Controls.Add(this.rdDywanSierpińskiego);
            this.gbWybórKrzywych.Controls.Add(this.NUD_WielokątWypelniony);
            this.gbWybórKrzywych.Controls.Add(this.lblLiczbaWyp);
            this.gbWybórKrzywych.Controls.Add(this.btnColor);
            this.gbWybórKrzywych.Controls.Add(this.NumUD_Rekwencja);
            this.gbWybórKrzywych.Controls.Add(this.lblRekwęcja);
            this.gbWybórKrzywych.Controls.Add(this.rdbTrójkąSierpińskiego);
            this.gbWybórKrzywych.Controls.Add(this.NumU);
            this.gbWybórKrzywych.Controls.Add(this.rdbGwiazdaWieloramienna);
            this.gbWybórKrzywych.Controls.Add(this.lblLiczba);
            this.gbWybórKrzywych.Controls.Add(this.rdbWielokatWypelniony);
            this.gbWybórKrzywych.Controls.Add(this.rdbWielokatForemny);
            this.gbWybórKrzywych.Controls.Add(this.rdbLiniaKreślena);
            this.gbWybórKrzywych.Controls.Add(this.rdbLiniaProsta);
            this.gbWybórKrzywych.Controls.Add(this.rdbPunkt);
            this.gbWybórKrzywych.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbWybórKrzywych.Location = new System.Drawing.Point(1030, 51);
            this.gbWybórKrzywych.Name = "gbWybórKrzywych";
            this.gbWybórKrzywych.Size = new System.Drawing.Size(372, 560);
            this.gbWybórKrzywych.TabIndex = 1;
            this.gbWybórKrzywych.TabStop = false;
            this.gbWybórKrzywych.Text = "Wybierz (zaznacz) krzywą geometryczną";
            // 
            // rdbFraktal
            // 
            this.rdbFraktal.AutoSize = true;
            this.rdbFraktal.Location = new System.Drawing.Point(7, 292);
            this.rdbFraktal.Name = "rdbFraktal";
            this.rdbFraktal.Size = new System.Drawing.Size(76, 23);
            this.rdbFraktal.TabIndex = 14;
            this.rdbFraktal.TabStop = true;
            this.rdbFraktal.Text = "Fraktal";
            this.rdbFraktal.UseVisualStyleBackColor = true;
            this.rdbFraktal.CheckedChanged += new System.EventHandler(this.rdbFraktal_CheckedChanged);
            // 
            // rdDywanSierpińskiego
            // 
            this.rdDywanSierpińskiego.AutoSize = true;
            this.rdDywanSierpińskiego.Location = new System.Drawing.Point(7, 263);
            this.rdDywanSierpińskiego.Name = "rdDywanSierpińskiego";
            this.rdDywanSierpińskiego.Size = new System.Drawing.Size(162, 23);
            this.rdDywanSierpińskiego.TabIndex = 13;
            this.rdDywanSierpińskiego.TabStop = true;
            this.rdDywanSierpińskiego.Text = "Dywan Sierpińskiego";
            this.rdDywanSierpińskiego.UseVisualStyleBackColor = true;
            // 
            // NUD_WielokątWypelniony
            // 
            this.NUD_WielokątWypelniony.Location = new System.Drawing.Point(223, 181);
            this.NUD_WielokątWypelniony.Name = "NUD_WielokątWypelniony";
            this.NUD_WielokątWypelniony.Size = new System.Drawing.Size(120, 26);
            this.NUD_WielokątWypelniony.TabIndex = 12;
            this.NUD_WielokątWypelniony.Visible = false;
            // 
            // lblLiczbaWyp
            // 
            this.lblLiczbaWyp.AutoSize = true;
            this.lblLiczbaWyp.Location = new System.Drawing.Point(232, 159);
            this.lblLiczbaWyp.Name = "lblLiczbaWyp";
            this.lblLiczbaWyp.Size = new System.Drawing.Size(101, 19);
            this.lblLiczbaWyp.TabIndex = 11;
            this.lblLiczbaWyp.Text = "Liczba kontrol";
            this.lblLiczbaWyp.Visible = false;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(240, 264);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 10;
            this.btnColor.Text = "Kolor";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Visible = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // NumUD_Rekwencja
            // 
            this.NumUD_Rekwencja.Location = new System.Drawing.Point(227, 232);
            this.NumUD_Rekwencja.Name = "NumUD_Rekwencja";
            this.NumUD_Rekwencja.Size = new System.Drawing.Size(120, 26);
            this.NumUD_Rekwencja.TabIndex = 9;
            this.NumUD_Rekwencja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumUD_Rekwencja.Visible = false;
            // 
            // lblRekwęcja
            // 
            this.lblRekwęcja.AutoSize = true;
            this.lblRekwęcja.Location = new System.Drawing.Point(244, 210);
            this.lblRekwęcja.Name = "lblRekwęcja";
            this.lblRekwęcja.Size = new System.Drawing.Size(71, 19);
            this.lblRekwęcja.TabIndex = 8;
            this.lblRekwęcja.Text = "Rekwęcja";
            this.lblRekwęcja.Visible = false;
            // 
            // rdbTrójkąSierpińskiego
            // 
            this.rdbTrójkąSierpińskiego.AutoSize = true;
            this.rdbTrójkąSierpińskiego.Location = new System.Drawing.Point(7, 234);
            this.rdbTrójkąSierpińskiego.Name = "rdbTrójkąSierpińskiego";
            this.rdbTrójkąSierpińskiego.Size = new System.Drawing.Size(165, 23);
            this.rdbTrójkąSierpińskiego.TabIndex = 7;
            this.rdbTrójkąSierpińskiego.TabStop = true;
            this.rdbTrójkąSierpińskiego.Text = "Trójkąt Sierpińskiego";
            this.rdbTrójkąSierpińskiego.UseVisualStyleBackColor = true;
            this.rdbTrójkąSierpińskiego.CheckedChanged += new System.EventHandler(this.rdbTrójkąSierpińskiego_CheckedChanged);
            // 
            // NumU
            // 
            this.NumU.Location = new System.Drawing.Point(223, 130);
            this.NumU.Name = "NumU";
            this.NumU.Size = new System.Drawing.Size(120, 26);
            this.NumU.TabIndex = 6;
            this.NumU.Visible = false;
            // 
            // rdbGwiazdaWieloramienna
            // 
            this.rdbGwiazdaWieloramienna.AutoSize = true;
            this.rdbGwiazdaWieloramienna.Location = new System.Drawing.Point(7, 205);
            this.rdbGwiazdaWieloramienna.Name = "rdbGwiazdaWieloramienna";
            this.rdbGwiazdaWieloramienna.Size = new System.Drawing.Size(184, 23);
            this.rdbGwiazdaWieloramienna.TabIndex = 5;
            this.rdbGwiazdaWieloramienna.TabStop = true;
            this.rdbGwiazdaWieloramienna.Text = "Gwiazda Wieloramienna\r\n";
            this.rdbGwiazdaWieloramienna.UseVisualStyleBackColor = true;
            this.rdbGwiazdaWieloramienna.CheckedChanged += new System.EventHandler(this.rdbGwiazdaWieloramienna_CheckedChanged);
            // 
            // lblLiczba
            // 
            this.lblLiczba.AutoSize = true;
            this.lblLiczba.Location = new System.Drawing.Point(232, 108);
            this.lblLiczba.Name = "lblLiczba";
            this.lblLiczba.Size = new System.Drawing.Size(101, 19);
            this.lblLiczba.TabIndex = 5;
            this.lblLiczba.Text = "Liczba kontrol";
            this.lblLiczba.Visible = false;
            // 
            // rdbWielokatWypelniony
            // 
            this.rdbWielokatWypelniony.AutoSize = true;
            this.rdbWielokatWypelniony.Location = new System.Drawing.Point(7, 176);
            this.rdbWielokatWypelniony.Name = "rdbWielokatWypelniony";
            this.rdbWielokatWypelniony.Size = new System.Drawing.Size(159, 23);
            this.rdbWielokatWypelniony.TabIndex = 4;
            this.rdbWielokatWypelniony.TabStop = true;
            this.rdbWielokatWypelniony.Text = "Wielokąt wypelniony";
            this.rdbWielokatWypelniony.UseVisualStyleBackColor = true;
            this.rdbWielokatWypelniony.CheckedChanged += new System.EventHandler(this.rdbWielokatWypelniony_CheckedChanged);
            // 
            // rdbWielokatForemny
            // 
            this.rdbWielokatForemny.AutoSize = true;
            this.rdbWielokatForemny.Location = new System.Drawing.Point(7, 147);
            this.rdbWielokatForemny.Name = "rdbWielokatForemny";
            this.rdbWielokatForemny.Size = new System.Drawing.Size(139, 23);
            this.rdbWielokatForemny.TabIndex = 3;
            this.rdbWielokatForemny.TabStop = true;
            this.rdbWielokatForemny.Text = "Wielokąt foremny";
            this.rdbWielokatForemny.UseVisualStyleBackColor = true;
            this.rdbWielokatForemny.CheckedChanged += new System.EventHandler(this.rdbWielokatForemny_CheckedChanged);
            // 
            // rdbLiniaKreślena
            // 
            this.rdbLiniaKreślena.AutoSize = true;
            this.rdbLiniaKreślena.Location = new System.Drawing.Point(7, 118);
            this.rdbLiniaKreślena.Name = "rdbLiniaKreślena";
            this.rdbLiniaKreślena.Size = new System.Drawing.Size(121, 23);
            this.rdbLiniaKreślena.TabIndex = 2;
            this.rdbLiniaKreślena.TabStop = true;
            this.rdbLiniaKreślena.Text = "Linia Kreślona";
            this.rdbLiniaKreślena.UseVisualStyleBackColor = true;
            // 
            // rdbLiniaProsta
            // 
            this.rdbLiniaProsta.AutoSize = true;
            this.rdbLiniaProsta.Location = new System.Drawing.Point(7, 88);
            this.rdbLiniaProsta.Name = "rdbLiniaProsta";
            this.rdbLiniaProsta.Size = new System.Drawing.Size(104, 23);
            this.rdbLiniaProsta.TabIndex = 1;
            this.rdbLiniaProsta.TabStop = true;
            this.rdbLiniaProsta.Text = "Linia prosta";
            this.rdbLiniaProsta.UseVisualStyleBackColor = true;
            // 
            // rdbPunkt
            // 
            this.rdbPunkt.AutoSize = true;
            this.rdbPunkt.Location = new System.Drawing.Point(7, 58);
            this.rdbPunkt.Name = "rdbPunkt";
            this.rdbPunkt.Size = new System.Drawing.Size(66, 23);
            this.rdbPunkt.TabIndex = 0;
            this.rdbPunkt.TabStop = true;
            this.rdbPunkt.Text = "Punkt";
            this.rdbPunkt.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sługebne X & Y aktualnego myszi";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblX.Location = new System.Drawing.Point(315, 9);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(23, 21);
            this.lblX.TabIndex = 3;
            this.lblX.Text = "X";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblY.Location = new System.Drawing.Point(367, 9);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(23, 21);
            this.lblY.TabIndex = 4;
            this.lblY.Text = "Y";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Laboratoryjny_Radovskyi61986
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 638);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbWybórKrzywych);
            this.Controls.Add(this.pbRisownica);
            this.Name = "Laboratoryjny_Radovskyi61986";
            this.Text = "Laboratoryjny_Radovskyi61986";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Laboratoryjny_Radovskyi61986_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbRisownica)).EndInit();
            this.gbWybórKrzywych.ResumeLayout(false);
            this.gbWybórKrzywych.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_WielokątWypelniony)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_Rekwencja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumU)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRisownica;
        private System.Windows.Forms.GroupBox gbWybórKrzywych;
        private System.Windows.Forms.RadioButton rdbPunkt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.RadioButton rdbLiniaProsta;
        private System.Windows.Forms.RadioButton rdbLiniaKreślena;
        private System.Windows.Forms.RadioButton rdbGwiazdaWieloramienna;
        private System.Windows.Forms.RadioButton rdbWielokatWypelniony;
        private System.Windows.Forms.RadioButton rdbWielokatForemny;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.NumericUpDown NumU;
        private System.Windows.Forms.Label lblLiczba;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.NumericUpDown NumUD_Rekwencja;
        private System.Windows.Forms.Label lblRekwęcja;
        private System.Windows.Forms.RadioButton rdbTrójkąSierpińskiego;
        private System.Windows.Forms.NumericUpDown NUD_WielokątWypelniony;
        private System.Windows.Forms.Label lblLiczbaWyp;
        private System.Windows.Forms.RadioButton rdbFraktal;
        private System.Windows.Forms.RadioButton rdDywanSierpińskiego;
    }
}