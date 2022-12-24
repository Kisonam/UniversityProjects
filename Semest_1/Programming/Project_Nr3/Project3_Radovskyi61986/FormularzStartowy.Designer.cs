namespace Project3_Radovskyi61986
{
    partial class FormularzStartowy
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
            this.btnProjectowy = new System.Windows.Forms.Button();
            this.btnLaboratoryjny = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProjectowy
            // 
            this.btnProjectowy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnProjectowy.Location = new System.Drawing.Point(571, 186);
            this.btnProjectowy.Name = "btnProjectowy";
            this.btnProjectowy.Size = new System.Drawing.Size(263, 80);
            this.btnProjectowy.TabIndex = 3;
            this.btnProjectowy.Text = "Projectowy Nr3\r\n(kreślenie figur i linij geometrycznych)";
            this.btnProjectowy.UseVisualStyleBackColor = true;
            // 
            // btnLaboratoryjny
            // 
            this.btnLaboratoryjny.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLaboratoryjny.Location = new System.Drawing.Point(174, 186);
            this.btnLaboratoryjny.Name = "btnLaboratoryjny";
            this.btnLaboratoryjny.Size = new System.Drawing.Size(247, 80);
            this.btnLaboratoryjny.TabIndex = 2;
            this.btnLaboratoryjny.Text = "Laboratorium Nr3\r\n(kreślenie krzywych geometrycznych)";
            this.btnLaboratoryjny.UseVisualStyleBackColor = true;
            this.btnLaboratoryjny.Click += new System.EventHandler(this.btnLaboratoryjny_Click);
            // 
            // FormularzStartowy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 472);
            this.Controls.Add(this.btnProjectowy);
            this.Controls.Add(this.btnLaboratoryjny);
            this.Name = "FormularzStartowy";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProjectowy;
        private System.Windows.Forms.Button btnLaboratoryjny;
    }
}

