namespace ProjektNr3_Radovskyi61986
{
    partial class Kokpit
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
            this.btnLaboratorium = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLaboratorium
            // 
            this.btnLaboratorium.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLaboratorium.Location = new System.Drawing.Point(48, 45);
            this.btnLaboratorium.Name = "btnLaboratorium";
            this.btnLaboratorium.Size = new System.Drawing.Size(195, 66);
            this.btnLaboratorium.TabIndex = 0;
            this.btnLaboratorium.Text = "Labaratorium Nr 3";
            this.btnLaboratorium.UseVisualStyleBackColor = true;
            this.btnLaboratorium.Click += new System.EventHandler(this.btnLaboratorium_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(249, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 66);
            this.button2.TabIndex = 1;
            this.button2.Text = "Projektowy Nr 3";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Kokpit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 157);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLaboratorium);
            this.Name = "Kokpit";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLaboratorium;
        private System.Windows.Forms.Button button2;
    }
}

