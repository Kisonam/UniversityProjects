namespace ProjectNr2_Radovskyi61986
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPrzesuń = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbFillPie = new System.Windows.Forms.RadioButton();
            this.rdbDrawArc = new System.Windows.Forms.RadioButton();
            this.rdbKrzywaKardynalna = new System.Windows.Forms.RadioButton();
            this.rdbFillElipse = new System.Windows.Forms.RadioButton();
            this.rdbLiniaCiągłaMysz = new System.Windows.Forms.RadioButton();
            this.rdbWielokątForemny = new System.Windows.Forms.RadioButton();
            this.rdbProstokąt = new System.Windows.Forms.RadioButton();
            this.rdbOkrag = new System.Windows.Forms.RadioButton();
            this.rdbLiniaProsta = new System.Windows.Forms.RadioButton();
            this.rdbFillClosedCurve = new System.Windows.Forms.RadioButton();
            this.rdbDrawPie = new System.Windows.Forms.RadioButton();
            this.rdbDrawClosedCurve = new System.Windows.Forms.RadioButton();
            this.rdbFillRect = new System.Windows.Forms.RadioButton();
            this.rdbKrzywaBieziera = new System.Windows.Forms.RadioButton();
            this.rdbWielokątWypełniony = new System.Windows.Forms.RadioButton();
            this.rdbKwadrat = new System.Windows.Forms.RadioButton();
            this.rdbKoło = new System.Windows.Forms.RadioButton();
            this.rdbElipsa = new System.Windows.Forms.RadioButton();
            this.rdbPunkt = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trbSuwakGrubościLinii = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.btnKolorLinii = new System.Windows.Forms.Button();
            this.btnWczytajPlik = new System.Windows.Forms.Button();
            this.btnZapiszPlik = new System.Windows.Forms.Button();
            this.btnWyłącz = new System.Windows.Forms.Button();
            this.btnWłącz = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.rdbManualny = new System.Windows.Forms.RadioButton();
            this.rdbAuto = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSuwakGrubościLinii)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(12, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(813, 453);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // btnPrzesuń
            // 
            this.btnPrzesuń.Location = new System.Drawing.Point(843, 48);
            this.btnPrzesuń.Name = "btnPrzesuń";
            this.btnPrzesuń.Size = new System.Drawing.Size(305, 44);
            this.btnPrzesuń.TabIndex = 1;
            this.btnPrzesuń.Text = "Przesumniącie wszystkich figur do nowego położenia bez zmiany atrybutów graficzny" +
    "ch ";
            this.btnPrzesuń.UseVisualStyleBackColor = true;
            this.btnPrzesuń.Click += new System.EventHandler(this.btnPrzesuń_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(35, 9);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(35, 13);
            this.lblX.TabIndex = 4;
            this.lblX.Text = "label3";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(100, 9);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(35, 13);
            this.lblY.TabIndex = 5;
            this.lblY.Text = "label3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbFillPie);
            this.groupBox1.Controls.Add(this.rdbDrawArc);
            this.groupBox1.Controls.Add(this.rdbKrzywaKardynalna);
            this.groupBox1.Controls.Add(this.rdbFillElipse);
            this.groupBox1.Controls.Add(this.rdbLiniaCiągłaMysz);
            this.groupBox1.Controls.Add(this.rdbWielokątForemny);
            this.groupBox1.Controls.Add(this.rdbProstokąt);
            this.groupBox1.Controls.Add(this.rdbOkrag);
            this.groupBox1.Controls.Add(this.rdbLiniaProsta);
            this.groupBox1.Controls.Add(this.rdbFillClosedCurve);
            this.groupBox1.Controls.Add(this.rdbDrawPie);
            this.groupBox1.Controls.Add(this.rdbDrawClosedCurve);
            this.groupBox1.Controls.Add(this.rdbFillRect);
            this.groupBox1.Controls.Add(this.rdbKrzywaBieziera);
            this.groupBox1.Controls.Add(this.rdbWielokątWypełniony);
            this.groupBox1.Controls.Add(this.rdbKwadrat);
            this.groupBox1.Controls.Add(this.rdbKoło);
            this.groupBox1.Controls.Add(this.rdbElipsa);
            this.groupBox1.Controls.Add(this.rdbPunkt);
            this.groupBox1.Location = new System.Drawing.Point(843, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 262);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Figury:";
            // 
            // rdbFillPie
            // 
            this.rdbFillPie.AutoSize = true;
            this.rdbFillPie.Location = new System.Drawing.Point(151, 204);
            this.rdbFillPie.Name = "rdbFillPie";
            this.rdbFillPie.Size = new System.Drawing.Size(52, 17);
            this.rdbFillPie.TabIndex = 18;
            this.rdbFillPie.TabStop = true;
            this.rdbFillPie.Text = "FillPie";
            this.rdbFillPie.UseVisualStyleBackColor = true;
            // 
            // rdbDrawArc
            // 
            this.rdbDrawArc.AutoSize = true;
            this.rdbDrawArc.Location = new System.Drawing.Point(151, 181);
            this.rdbDrawArc.Name = "rdbDrawArc";
            this.rdbDrawArc.Size = new System.Drawing.Size(69, 17);
            this.rdbDrawArc.TabIndex = 17;
            this.rdbDrawArc.TabStop = true;
            this.rdbDrawArc.Text = "Draw Arc";
            this.rdbDrawArc.UseVisualStyleBackColor = true;
            // 
            // rdbKrzywaKardynalna
            // 
            this.rdbKrzywaKardynalna.AutoSize = true;
            this.rdbKrzywaKardynalna.Location = new System.Drawing.Point(151, 158);
            this.rdbKrzywaKardynalna.Name = "rdbKrzywaKardynalna";
            this.rdbKrzywaKardynalna.Size = new System.Drawing.Size(115, 17);
            this.rdbKrzywaKardynalna.TabIndex = 16;
            this.rdbKrzywaKardynalna.TabStop = true;
            this.rdbKrzywaKardynalna.Text = "Krzywa Kardynalna";
            this.rdbKrzywaKardynalna.UseVisualStyleBackColor = true;
            // 
            // rdbFillElipse
            // 
            this.rdbFillElipse.AutoSize = true;
            this.rdbFillElipse.Location = new System.Drawing.Point(151, 135);
            this.rdbFillElipse.Name = "rdbFillElipse";
            this.rdbFillElipse.Size = new System.Drawing.Size(65, 17);
            this.rdbFillElipse.TabIndex = 15;
            this.rdbFillElipse.TabStop = true;
            this.rdbFillElipse.Text = "FillElipse";
            this.rdbFillElipse.UseVisualStyleBackColor = true;
            // 
            // rdbLiniaCiągłaMysz
            // 
            this.rdbLiniaCiągłaMysz.AutoSize = true;
            this.rdbLiniaCiągłaMysz.Location = new System.Drawing.Point(151, 112);
            this.rdbLiniaCiągłaMysz.Name = "rdbLiniaCiągłaMysz";
            this.rdbLiniaCiągłaMysz.Size = new System.Drawing.Size(155, 17);
            this.rdbLiniaCiągłaMysz.TabIndex = 14;
            this.rdbLiniaCiągłaMysz.TabStop = true;
            this.rdbLiniaCiągłaMysz.Text = "Linia ciągła kreślona myszą";
            this.rdbLiniaCiągłaMysz.UseVisualStyleBackColor = true;
            // 
            // rdbWielokątForemny
            // 
            this.rdbWielokątForemny.AutoSize = true;
            this.rdbWielokątForemny.Location = new System.Drawing.Point(151, 89);
            this.rdbWielokątForemny.Name = "rdbWielokątForemny";
            this.rdbWielokątForemny.Size = new System.Drawing.Size(110, 17);
            this.rdbWielokątForemny.TabIndex = 13;
            this.rdbWielokątForemny.TabStop = true;
            this.rdbWielokątForemny.Text = "Wielokąt Foremny";
            this.rdbWielokątForemny.UseVisualStyleBackColor = true;
            // 
            // rdbProstokąt
            // 
            this.rdbProstokąt.AutoSize = true;
            this.rdbProstokąt.Location = new System.Drawing.Point(151, 66);
            this.rdbProstokąt.Name = "rdbProstokąt";
            this.rdbProstokąt.Size = new System.Drawing.Size(70, 17);
            this.rdbProstokąt.TabIndex = 12;
            this.rdbProstokąt.TabStop = true;
            this.rdbProstokąt.Text = "Prostokąt";
            this.rdbProstokąt.UseVisualStyleBackColor = true;
            // 
            // rdbOkrag
            // 
            this.rdbOkrag.AutoSize = true;
            this.rdbOkrag.Location = new System.Drawing.Point(151, 43);
            this.rdbOkrag.Name = "rdbOkrag";
            this.rdbOkrag.Size = new System.Drawing.Size(54, 17);
            this.rdbOkrag.TabIndex = 11;
            this.rdbOkrag.TabStop = true;
            this.rdbOkrag.Text = "Okrag";
            this.rdbOkrag.UseVisualStyleBackColor = true;
            // 
            // rdbLiniaProsta
            // 
            this.rdbLiniaProsta.AutoSize = true;
            this.rdbLiniaProsta.Location = new System.Drawing.Point(151, 20);
            this.rdbLiniaProsta.Name = "rdbLiniaProsta";
            this.rdbLiniaProsta.Size = new System.Drawing.Size(80, 17);
            this.rdbLiniaProsta.TabIndex = 10;
            this.rdbLiniaProsta.TabStop = true;
            this.rdbLiniaProsta.Text = "Linia Prosta";
            this.rdbLiniaProsta.UseVisualStyleBackColor = true;
            // 
            // rdbFillClosedCurve
            // 
            this.rdbFillClosedCurve.AutoSize = true;
            this.rdbFillClosedCurve.Location = new System.Drawing.Point(7, 227);
            this.rdbFillClosedCurve.Name = "rdbFillClosedCurve";
            this.rdbFillClosedCurve.Size = new System.Drawing.Size(97, 17);
            this.rdbFillClosedCurve.TabIndex = 9;
            this.rdbFillClosedCurve.TabStop = true;
            this.rdbFillClosedCurve.Text = "FillClosedCurve";
            this.rdbFillClosedCurve.UseVisualStyleBackColor = true;
            // 
            // rdbDrawPie
            // 
            this.rdbDrawPie.AutoSize = true;
            this.rdbDrawPie.Location = new System.Drawing.Point(7, 204);
            this.rdbDrawPie.Name = "rdbDrawPie";
            this.rdbDrawPie.Size = new System.Drawing.Size(65, 17);
            this.rdbDrawPie.TabIndex = 8;
            this.rdbDrawPie.TabStop = true;
            this.rdbDrawPie.Text = "DrawPie";
            this.rdbDrawPie.UseVisualStyleBackColor = true;
            // 
            // rdbDrawClosedCurve
            // 
            this.rdbDrawClosedCurve.AutoSize = true;
            this.rdbDrawClosedCurve.Location = new System.Drawing.Point(7, 181);
            this.rdbDrawClosedCurve.Name = "rdbDrawClosedCurve";
            this.rdbDrawClosedCurve.Size = new System.Drawing.Size(110, 17);
            this.rdbDrawClosedCurve.TabIndex = 7;
            this.rdbDrawClosedCurve.TabStop = true;
            this.rdbDrawClosedCurve.Text = "DrawClosedCurve";
            this.rdbDrawClosedCurve.UseVisualStyleBackColor = true;
            // 
            // rdbFillRect
            // 
            this.rdbFillRect.AutoSize = true;
            this.rdbFillRect.Location = new System.Drawing.Point(7, 158);
            this.rdbFillRect.Name = "rdbFillRect";
            this.rdbFillRect.Size = new System.Drawing.Size(86, 17);
            this.rdbFillRect.TabIndex = 6;
            this.rdbFillRect.TabStop = true;
            this.rdbFillRect.Text = "FillRectangle";
            this.rdbFillRect.UseVisualStyleBackColor = true;
            // 
            // rdbKrzywaBieziera
            // 
            this.rdbKrzywaBieziera.AutoSize = true;
            this.rdbKrzywaBieziera.Location = new System.Drawing.Point(6, 135);
            this.rdbKrzywaBieziera.Name = "rdbKrzywaBieziera";
            this.rdbKrzywaBieziera.Size = new System.Drawing.Size(99, 17);
            this.rdbKrzywaBieziera.TabIndex = 5;
            this.rdbKrzywaBieziera.TabStop = true;
            this.rdbKrzywaBieziera.Text = "Krzywa Bieziera";
            this.rdbKrzywaBieziera.UseVisualStyleBackColor = true;
            // 
            // rdbWielokątWypełniony
            // 
            this.rdbWielokątWypełniony.AutoSize = true;
            this.rdbWielokątWypełniony.Location = new System.Drawing.Point(7, 112);
            this.rdbWielokątWypełniony.Name = "rdbWielokątWypełniony";
            this.rdbWielokątWypełniony.Size = new System.Drawing.Size(127, 17);
            this.rdbWielokątWypełniony.TabIndex = 4;
            this.rdbWielokątWypełniony.TabStop = true;
            this.rdbWielokątWypełniony.Text = "Wielokąt Wypełniony";
            this.rdbWielokątWypełniony.UseVisualStyleBackColor = true;
            // 
            // rdbKwadrat
            // 
            this.rdbKwadrat.AutoSize = true;
            this.rdbKwadrat.Location = new System.Drawing.Point(7, 89);
            this.rdbKwadrat.Name = "rdbKwadrat";
            this.rdbKwadrat.Size = new System.Drawing.Size(64, 17);
            this.rdbKwadrat.TabIndex = 3;
            this.rdbKwadrat.TabStop = true;
            this.rdbKwadrat.Text = "Kwadrat";
            this.rdbKwadrat.UseVisualStyleBackColor = true;
            // 
            // rdbKoło
            // 
            this.rdbKoło.AutoSize = true;
            this.rdbKoło.Location = new System.Drawing.Point(7, 66);
            this.rdbKoło.Name = "rdbKoło";
            this.rdbKoło.Size = new System.Drawing.Size(48, 17);
            this.rdbKoło.TabIndex = 2;
            this.rdbKoło.TabStop = true;
            this.rdbKoło.Text = "Koło";
            this.rdbKoło.UseVisualStyleBackColor = true;
            // 
            // rdbElipsa
            // 
            this.rdbElipsa.AutoSize = true;
            this.rdbElipsa.Location = new System.Drawing.Point(7, 43);
            this.rdbElipsa.Name = "rdbElipsa";
            this.rdbElipsa.Size = new System.Drawing.Size(53, 17);
            this.rdbElipsa.TabIndex = 1;
            this.rdbElipsa.TabStop = true;
            this.rdbElipsa.Text = "Elipsa";
            this.rdbElipsa.UseVisualStyleBackColor = true;
            // 
            // rdbPunkt
            // 
            this.rdbPunkt.AutoSize = true;
            this.rdbPunkt.Location = new System.Drawing.Point(7, 20);
            this.rdbPunkt.Name = "rdbPunkt";
            this.rdbPunkt.Size = new System.Drawing.Size(53, 17);
            this.rdbPunkt.TabIndex = 0;
            this.rdbPunkt.TabStop = true;
            this.rdbPunkt.Text = "Punkt";
            this.rdbPunkt.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.trbSuwakGrubościLinii);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnKolorLinii);
            this.groupBox2.Location = new System.Drawing.Point(843, 367);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 134);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Atrybuty graficzne";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(109, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ustaw grubość linii";
            // 
            // trbSuwakGrubościLinii
            // 
            this.trbSuwakGrubościLinii.Location = new System.Drawing.Point(112, 42);
            this.trbSuwakGrubościLinii.Maximum = 5;
            this.trbSuwakGrubościLinii.Name = "trbSuwakGrubościLinii";
            this.trbSuwakGrubościLinii.Size = new System.Drawing.Size(183, 45);
            this.trbSuwakGrubościLinii.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Kolor\r\nWypełnienia";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnKolorLinii
            // 
            this.btnKolorLinii.Location = new System.Drawing.Point(6, 20);
            this.btnKolorLinii.Name = "btnKolorLinii";
            this.btnKolorLinii.Size = new System.Drawing.Size(87, 54);
            this.btnKolorLinii.TabIndex = 0;
            this.btnKolorLinii.Text = "Kolor linii";
            this.btnKolorLinii.UseVisualStyleBackColor = true;
            this.btnKolorLinii.Click += new System.EventHandler(this.btnKolorLinii_Click);
            // 
            // btnWczytajPlik
            // 
            this.btnWczytajPlik.Location = new System.Drawing.Point(1004, 507);
            this.btnWczytajPlik.Name = "btnWczytajPlik";
            this.btnWczytajPlik.Size = new System.Drawing.Size(144, 28);
            this.btnWczytajPlik.TabIndex = 8;
            this.btnWczytajPlik.Text = "Wczytaj bitmape w pliku";
            this.btnWczytajPlik.UseVisualStyleBackColor = true;
            this.btnWczytajPlik.Click += new System.EventHandler(this.btnWczytajPlik_Click);
            // 
            // btnZapiszPlik
            // 
            this.btnZapiszPlik.Location = new System.Drawing.Point(843, 507);
            this.btnZapiszPlik.Name = "btnZapiszPlik";
            this.btnZapiszPlik.Size = new System.Drawing.Size(144, 28);
            this.btnZapiszPlik.TabIndex = 9;
            this.btnZapiszPlik.Text = "Zapisz bitmape w pliku";
            this.btnZapiszPlik.UseVisualStyleBackColor = true;
            this.btnZapiszPlik.Click += new System.EventHandler(this.btnZapiszPlik_Click);
            // 
            // btnWyłącz
            // 
            this.btnWyłącz.Location = new System.Drawing.Point(663, 508);
            this.btnWyłącz.Name = "btnWyłącz";
            this.btnWyłącz.Size = new System.Drawing.Size(162, 44);
            this.btnWyłącz.TabIndex = 11;
            this.btnWyłącz.Text = "Wyłącz pokaz figur";
            this.btnWyłącz.UseVisualStyleBackColor = true;
            this.btnWyłącz.Click += new System.EventHandler(this.btnWyłącz_Click);
            // 
            // btnWłącz
            // 
            this.btnWłącz.Location = new System.Drawing.Point(12, 507);
            this.btnWłącz.Name = "btnWłącz";
            this.btnWłącz.Size = new System.Drawing.Size(162, 45);
            this.btnWłącz.TabIndex = 10;
            this.btnWłącz.Text = "Włącz pokaz figur";
            this.btnWłącz.UseVisualStyleBackColor = true;
            this.btnWłącz.Click += new System.EventHandler(this.btnWłącz_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.rdbManualny);
            this.groupBox3.Controls.Add(this.rdbAuto);
            this.groupBox3.Location = new System.Drawing.Point(225, 508);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(332, 96);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tryb pokazu figur geometrycznych";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(169, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(246, 44);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Poprzednia";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(246, 19);
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Projectowy_Radovskyi61986
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 615);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnWyłącz);
            this.Controls.Add(this.btnWłącz);
            this.Controls.Add(this.btnZapiszPlik);
            this.Controls.Add(this.btnWczytajPlik);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrzesuń);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Projectowy_Radovskyi61986";
            this.Text = "Projectowy_Radovskyi61986";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Projectowy_Radovskyi61986_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSuwakGrubościLinii)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPrzesuń;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbElipsa;
        private System.Windows.Forms.RadioButton rdbPunkt;
        private System.Windows.Forms.RadioButton rdbFillRect;
        private System.Windows.Forms.RadioButton rdbKrzywaBieziera;
        private System.Windows.Forms.RadioButton rdbWielokątWypełniony;
        private System.Windows.Forms.RadioButton rdbKwadrat;
        private System.Windows.Forms.RadioButton rdbKoło;
        private System.Windows.Forms.RadioButton rdbProstokąt;
        private System.Windows.Forms.RadioButton rdbOkrag;
        private System.Windows.Forms.RadioButton rdbLiniaProsta;
        private System.Windows.Forms.RadioButton rdbFillClosedCurve;
        private System.Windows.Forms.RadioButton rdbDrawPie;
        private System.Windows.Forms.RadioButton rdbDrawClosedCurve;
        private System.Windows.Forms.RadioButton rdbFillElipse;
        private System.Windows.Forms.RadioButton rdbLiniaCiągłaMysz;
        private System.Windows.Forms.RadioButton rdbWielokątForemny;
        private System.Windows.Forms.RadioButton rdbFillPie;
        private System.Windows.Forms.RadioButton rdbDrawArc;
        private System.Windows.Forms.RadioButton rdbKrzywaKardynalna;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnKolorLinii;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trbSuwakGrubościLinii;
        private System.Windows.Forms.Button btnWczytajPlik;
        private System.Windows.Forms.Button btnZapiszPlik;
        private System.Windows.Forms.Button btnWyłącz;
        private System.Windows.Forms.Button btnWłącz;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton rdbManualny;
        private System.Windows.Forms.RadioButton rdbAuto;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}