namespace Project3_Radovskyi61986
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
            this.pbRisownica = new System.Windows.Forms.PictureBox();
            this.gbWybórKrzywych = new System.Windows.Forms.GroupBox();
            this.rdbLiniaKreślena = new System.Windows.Forms.RadioButton();
            this.rdbLiniaProsta = new System.Windows.Forms.RadioButton();
            this.rdbPunkt = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbRisownica)).BeginInit();
            this.gbWybórKrzywych.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbRisownica
            // 
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
            this.gbWybórKrzywych.Controls.Add(this.rdbLiniaKreślena);
            this.gbWybórKrzywych.Controls.Add(this.rdbLiniaProsta);
            this.gbWybórKrzywych.Controls.Add(this.rdbPunkt);
            this.gbWybórKrzywych.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbWybórKrzywych.Location = new System.Drawing.Point(1030, 51);
            this.gbWybórKrzywych.Name = "gbWybórKrzywych";
            this.gbWybórKrzywych.Size = new System.Drawing.Size(286, 560);
            this.gbWybórKrzywych.TabIndex = 1;
            this.gbWybórKrzywych.TabStop = false;
            this.gbWybórKrzywych.Text = "W";
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
            this.label1.Location = new System.Drawing.Point(64, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sługebne X & Y aktualnego myszi";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblX.Location = new System.Drawing.Point(328, 9);
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
            // Laboratoryjny_Radovskyi61986
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 638);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbWybórKrzywych);
            this.Controls.Add(this.pbRisownica);
            this.Name = "Laboratoryjny_Radovskyi61986";
            this.Text = "Laboratoryjny";
            ((System.ComponentModel.ISupportInitialize)(this.pbRisownica)).EndInit();
            this.gbWybórKrzywych.ResumeLayout(false);
            this.gbWybórKrzywych.PerformLayout();
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
    }
}