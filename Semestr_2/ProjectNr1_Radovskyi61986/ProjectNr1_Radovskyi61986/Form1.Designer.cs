namespace ProjectNr1_Radovskyi61986
{
    partial class Kokpit_Radovskyi61986
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
            this.label1 = new System.Windows.Forms.Label();
            this.LaboratoriumNr1 = new System.Windows.Forms.Button();
            this.ProjectowyNr1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(157, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Animacja Komputerova po linii wyznaczenego przez wykres szeregu potęgowego ";
            // 
            // LaboratoriumNr1
            // 
            this.LaboratoriumNr1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LaboratoriumNr1.Location = new System.Drawing.Point(12, 180);
            this.LaboratoriumNr1.Name = "LaboratoriumNr1";
            this.LaboratoriumNr1.Size = new System.Drawing.Size(386, 48);
            this.LaboratoriumNr1.TabIndex = 1;
            this.LaboratoriumNr1.Text = "Laboratorium Nr1\r\n(Szereg laboratorijny)";
            this.LaboratoriumNr1.UseVisualStyleBackColor = true;
            this.LaboratoriumNr1.Click += new System.EventHandler(this.LaboratoriumNr1_Click);
            // 
            // ProjectowyNr1
            // 
            this.ProjectowyNr1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProjectowyNr1.Location = new System.Drawing.Point(404, 180);
            this.ProjectowyNr1.Name = "ProjectowyNr1";
            this.ProjectowyNr1.Size = new System.Drawing.Size(386, 48);
            this.ProjectowyNr1.TabIndex = 2;
            this.ProjectowyNr1.Text = "Projectowy  Nr1\r\n(Szereg indywidualny)";
            this.ProjectowyNr1.UseVisualStyleBackColor = true;
            // 
            // Kokpit_Radovskyi61986
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 323);
            this.Controls.Add(this.ProjectowyNr1);
            this.Controls.Add(this.LaboratoriumNr1);
            this.Controls.Add(this.label1);
            this.Name = "Kokpit_Radovskyi61986";
            this.Text = "Kokpit_Radovskyi61986";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kokpit_Radovskyi61986_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LaboratoriumNr1;
        private System.Windows.Forms.Button ProjectowyNr1;
    }
}

