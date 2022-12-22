namespace ProjectNr2_Radovskyi61986
{
    partial class ProjectNr2_Radovskyi61986
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LaboratoriumBtn = new System.Windows.Forms.Button();
            this.ProjectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LaboratoriumBtn
            // 
            this.LaboratoriumBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LaboratoriumBtn.Location = new System.Drawing.Point(68, 127);
            this.LaboratoriumBtn.Name = "LaboratoriumBtn";
            this.LaboratoriumBtn.Size = new System.Drawing.Size(381, 115);
            this.LaboratoriumBtn.TabIndex = 0;
            this.LaboratoriumBtn.Text = "Laboratorium Nr2\r\n( analizator labaratoryjnego szeregu potęgowego )\r\n";
            this.LaboratoriumBtn.UseVisualStyleBackColor = true;
            this.LaboratoriumBtn.Click += new System.EventHandler(this.BtnSheregLaboratoryjny_Click);
            // 
            // ProjectBtn
            // 
            this.ProjectBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProjectBtn.Location = new System.Drawing.Point(576, 127);
            this.ProjectBtn.Name = "ProjectBtn";
            this.ProjectBtn.Size = new System.Drawing.Size(381, 115);
            this.ProjectBtn.TabIndex = 1;
            this.ProjectBtn.Text = "Project Nr2\r\n( analizator indywidualnego szeregu potęgowego )\r\n";
            this.ProjectBtn.UseVisualStyleBackColor = true;
            this.ProjectBtn.Click += new System.EventHandler(this.ProjectBtn_Click);
            // 
            // ProjectNr2_Radovskyi61986
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1040, 324);
            this.Controls.Add(this.ProjectBtn);
            this.Controls.Add(this.LaboratoriumBtn);
            this.Name = "ProjectNr2_Radovskyi61986";
            this.Text = "Kalkulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectNr2_Radovskyi61986_FormClosing);
            this.Load += new System.EventHandler(this.ProjectNr2_Radovskyi61986_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LaboratoriumBtn;
        private System.Windows.Forms.Button ProjectBtn;
    }
}

