namespace Rysownica
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnElipse = new System.Windows.Forms.Button();
            this.btnPencil = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnRect = new System.Windows.Forms.Button();
            this.btnChangeColor = new System.Windows.Forms.Button();
            this.pbRysownica = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDetect = new System.Windows.Forms.PictureBox();
            this.tbPenSolid = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorDetect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPenSolid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.tbPenSolid);
            this.panel1.Controls.Add(this.colorDetect);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnElipse);
            this.panel1.Controls.Add(this.btnPencil);
            this.panel1.Controls.Add(this.btnFill);
            this.panel1.Controls.Add(this.btnLine);
            this.panel1.Controls.Add(this.btnRect);
            this.panel1.Controls.Add(this.btnChangeColor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 149);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(213, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 66);
            this.button1.TabIndex = 8;
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnElipse
            // 
            this.btnElipse.Image = global::Rysownica.Properties.Resources.circle;
            this.btnElipse.Location = new System.Drawing.Point(73, 3);
            this.btnElipse.Name = "btnElipse";
            this.btnElipse.Size = new System.Drawing.Size(64, 66);
            this.btnElipse.TabIndex = 7;
            this.btnElipse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnElipse.UseVisualStyleBackColor = true;
            this.btnElipse.Click += new System.EventHandler(this.btnElipse_Click);
            // 
            // btnPencil
            // 
            this.btnPencil.Image = ((System.Drawing.Image)(resources.GetObject("btnPencil.Image")));
            this.btnPencil.Location = new System.Drawing.Point(143, 75);
            this.btnPencil.Name = "btnPencil";
            this.btnPencil.Size = new System.Drawing.Size(64, 66);
            this.btnPencil.TabIndex = 6;
            this.btnPencil.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPencil.UseVisualStyleBackColor = true;
            this.btnPencil.Click += new System.EventHandler(this.btnPencil_Click);
            // 
            // btnFill
            // 
            this.btnFill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFill.Image = global::Rysownica.Properties.Resources.icons8_fill_color_64;
            this.btnFill.Location = new System.Drawing.Point(3, 3);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(64, 66);
            this.btnFill.TabIndex = 5;
            this.btnFill.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnLine
            // 
            this.btnLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLine.Image = global::Rysownica.Properties.Resources.icons8_line_64;
            this.btnLine.Location = new System.Drawing.Point(73, 75);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(64, 66);
            this.btnLine.TabIndex = 4;
            this.btnLine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnRect
            // 
            this.btnRect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRect.Image = ((System.Drawing.Image)(resources.GetObject("btnRect.Image")));
            this.btnRect.Location = new System.Drawing.Point(3, 75);
            this.btnRect.Name = "btnRect";
            this.btnRect.Size = new System.Drawing.Size(64, 66);
            this.btnRect.TabIndex = 3;
            this.btnRect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRect.UseVisualStyleBackColor = true;
            this.btnRect.Click += new System.EventHandler(this.btnRect_Click);
            // 
            // btnChangeColor
            // 
            this.btnChangeColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeColor.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeColor.Image")));
            this.btnChangeColor.Location = new System.Drawing.Point(143, 3);
            this.btnChangeColor.Name = "btnChangeColor";
            this.btnChangeColor.Size = new System.Drawing.Size(64, 66);
            this.btnChangeColor.TabIndex = 2;
            this.btnChangeColor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChangeColor.UseVisualStyleBackColor = true;
            this.btnChangeColor.Click += new System.EventHandler(this.btnChangeColor_Click);
            // 
            // pbRysownica
            // 
            this.pbRysownica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbRysownica.Location = new System.Drawing.Point(0, 24);
            this.pbRysownica.Name = "pbRysownica";
            this.pbRysownica.Size = new System.Drawing.Size(958, 677);
            this.pbRysownica.TabIndex = 0;
            this.pbRysownica.TabStop = false;
            this.pbRysownica.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRysownica_Paint);
            this.pbRysownica.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbRysownica_MouseClick);
            this.pbRysownica.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbRysownica_MouseDown);
            this.pbRysownica.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbRysownica_MouseMove);
            this.pbRysownica.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbRysownica_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(958, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // colorDetect
            // 
            this.colorDetect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.colorDetect.Location = new System.Drawing.Point(213, 16);
            this.colorDetect.Name = "colorDetect";
            this.colorDetect.Size = new System.Drawing.Size(44, 37);
            this.colorDetect.TabIndex = 3;
            this.colorDetect.TabStop = false;
            // 
            // tbPenSolid
            // 
            this.tbPenSolid.LargeChange = 10;
            this.tbPenSolid.Location = new System.Drawing.Point(777, 101);
            this.tbPenSolid.Minimum = 1;
            this.tbPenSolid.Name = "tbPenSolid";
            this.tbPenSolid.Size = new System.Drawing.Size(178, 45);
            this.tbPenSolid.TabIndex = 9;
            this.tbPenSolid.Value = 1;
            this.tbPenSolid.Scroll += new System.EventHandler(this.tbPenSolid_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 701);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbRysownica);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint Radovskyi 61986";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorDetect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPenSolid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRysownica;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnChangeColor;
        private System.Windows.Forms.Button btnRect;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnPencil;
        private System.Windows.Forms.Button btnElipse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.PictureBox colorDetect;
        private System.Windows.Forms.TrackBar tbPenSolid;
    }
}

