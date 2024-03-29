﻿using System;
using System.Drawing;
using System.Windows.Forms;
// dodanie nowej grafiki 2D
using System.Drawing.Drawing2D;

namespace Project3_Radovskyi61986
{
    public partial class Laboratoryjny_Radovskyi61986 : Form
    { // deklaracje stałej dla określenia PromieniaPunktu
        const ushort PromieńPunktu = 2;
        // deklaracja zmiennych referencyjnych narzędni grafichnych
        Graphics Rysownica;
        // deklaracja rysownict tymczasowej na pobierzchbi kontolki PictureBox
        Graphics RysownicaTymczasowa;
        // deklaracja Pióra tymczasowego
        Pen PióroTymczasowe;


        Pen Pióro;
        SolidBrush Pędzle;
        Point Punkt = Point.Empty;
        const int MarginesFormularza = 10;

        public Laboratoryjny_Radovskyi61986()
        {
            InitializeComponent();
            // lokalizacja i zwymiarowanie formularza 
            // wyznaczęnie płożenia na ekranie lewego górnego narożnika formularza
            this.Location = new Point(Screen.PrimaryScreen.Bounds.X + MarginesFormularza, Screen.PrimaryScreen.Bounds.Y + MarginesFormularza);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.9f);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.8f);
            // "wumuszenie" uwzględnienia naszych ustawień przy tworzeniu egzemplarza formularza 
            this.StartPosition = FormStartPosition.Manual;
            // ustawienie innych atrybutów formularza
            this.AutoScroll = true;
            // lokalizacja i zwymiarowanie kontrolki PictureBox
            pbRisownica.Location = new Point(this.Left + 2 * MarginesFormularza,
                this.Top + 2 * MarginesFormularza);
            pbRisownica.Width = (int)(this.Width * 0.7);
            pbRisownica.Height = (int)(this.Height * 0.8);
            // loalizacja kontenera GroupBox: gbWybórKrzywych
            gbWybórKrzywych.Location = new Point(pbRisownica.Location.X + pbRisownica.Width + MarginesFormularza,
                pbRisownica.Location.Y);



            // ....
            // "podpięcie" BitMapy do kontrolki PictureBox
            pbRisownica.Image = new Bitmap(pbRisownica.Width, pbRisownica.Height);
            // utworzenie egzemplarza graficznej na bitmapie
            Rysownica = Graphics.FromImage(pbRisownica.Image);
            /* utworzenie egzemplarza tymczasowej powierzchni graficznej na 
             przezroczystej powierzchni kontrolki PictureBox*/
            RysownicaTymczasowa = pbRisownica.CreateGraphics();
            // utworzenie egzemplarza Pióra tymczasowego
            PióroTymczasowe = new Pen(Color.Blue, 1);
            // utworzenie egzemlarza Pióra i jego sformatowania 
            Pióro = new Pen(Color.Red, 1.4f);
            Pióro.DashStyle = DashStyle.Dash;
            Pióro.StartCap = LineCap.Round;
            Pióro.EndCap = LineCap.Round;

            Pędzle = new SolidBrush(Color.Blue);


        }

        private void pbRisownica_MouseDown(object sender, MouseEventArgs e)
        {
            // wizualizacja wpółrzędnych aktualnego położenia myszy
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();
            //obsługa zdarzenia MouseDown
            if (e.Button == MouseButtons.Left)
            {// przechowanie wspołorzędnych poleżonia "Myszy" w zmiennej Punkt
               Punkt =  e.Location;
            }
        }

        private void pbRisownica_MouseUp(object sender, MouseEventArgs e)
        {
            // wizualizacja wpółrzędnych aktualnego położenia myszy
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();
            //
            int LewyGórnyX = (Punkt.X > e.Location.X) ? e.Location.X : Punkt.X;
            int LewyGórnyY = (Punkt.Y > e.Location.Y) ? e.Location.Y : Punkt.Y;
            int Szerokość = Math.Abs(Punkt.X - e.Location.X);
            int Wysokość = Math.Abs(Punkt.Y - e.Location.Y);

            // sprawdzenie, czy zdarzenie MouseUp 'pochodz1' od lewego przychisku
            if (e.Button == MouseButtons.Left)
            {
                // rozpoznanie zaznaczonej controlki radioButton

                //Czy to jest Punkt
                if (rdbPunkt.Checked)
                {
                    // tak to wykreślamy punkt
                    Rysownica.FillEllipse(Pędzle, Punkt.X - PromieńPunktu, 
                        Punkt.Y - PromieńPunktu, 
                        2 * PromieńPunktu,
                        2 * PromieńPunktu);
                    // czy zaznaczona (wybrana) jest kontrolka RadioButton dla 'LiniiProstej'
                    
                }
                if (rdbLiniaProsta.Checked)
                {
                    Rysownica.DrawLine(Pióro, Punkt.X,
                                        Punkt.Y,
                                        e.Location.X,
                                        e.Location.Y);
                }
                if (rdbLiniaKreślena.Checked)
                    Rysownica.DrawLine(Pióro, Punkt.X, Punkt.Y,
                                              e.Location.X, e.Location.Y);
                // foremny
                if (rdbWielokatForemny.Checked)
                {
                    ushort StopieńWielokąt = (ushort)NumU.Value;
                    int R = Szerokość;
                    double KątMiędzWierzchołkamiWielokta = 360.0 / StopieńWielokąt;
                    double KątPołożeniaPierwszegoWierzchowka = 0.0;
                    //
                    Point[] WierzchołkiWielokąta = new Point[StopieńWielokąt];
                    for (int i = 0; i < StopieńWielokąt; i++)
                    {
                        WierzchołkiWielokąta[i].X = LewyGórnyX + (int)(R * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchowka + i * KątMiędzWierzchołkamiWielokta) / 180.0));
                        WierzchołkiWielokąta[i].Y = LewyGórnyY - (int)(R * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchowka + i * KątMiędzWierzchołkamiWielokta) / 180.0));
                    }
                    Rysownica.DrawPolygon(Pióro,WierzchołkiWielokąta);
                }
                if (rdbWielokatWypelniony.Checked)
                {
                    ushort StopieńWielokąt = (ushort)NUD_WielokątWypelniony.Value;
                    int R = Szerokość;
                    double KątMiędzWierzchołkamiWielokta = 360.0 / StopieńWielokąt;
                    double KątPołożeniaPierwszegoWierzchowka = 0.0;
                    //
                    Point[] WierzchołkiWielokąta = new Point[StopieńWielokąt];
                    for (int i = 0; i < StopieńWielokąt; i++)
                    {
                        WierzchołkiWielokąta[i].X = LewyGórnyX + (int)(R * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchowka + i * KątMiędzWierzchołkamiWielokta) / 180.0));
                        WierzchołkiWielokąta[i].Y = LewyGórnyY - (int)(R * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchowka + i * KątMiędzWierzchołkamiWielokta) / 180.0));
                    }
                    Rysownica.DrawPolygon(Pióro, WierzchołkiWielokąta);
                    Rysownica.FillPolygon(Pędzle, WierzchołkiWielokąta);
                }
                //
                if (rdbGwiazdaWieloramienna.Checked)
                {
                    Point[] p = new Point[8];
                    p[0] = new Point(0, 50);
                    p[1] = new Point(40, 40);
                    p[2] = new Point(50, 0);
                    p[3] = new Point(60, 40);
                    p[4] = new Point(100, 50);
                    p[5] = new Point(60, 60);
                    p[6] = new Point(50, 100);
                    p[7] = new Point(40, 60);
                    GraphicsPath gp = new GraphicsPath();
                    gp.AddPolygon(p);
                    Region r = new Region(gp);
                    Rysownica.FillRegion(Brushes.BlueViolet, r);
                }

                // 
                if (rdbTrójkąSierpińskiego.Checked)
                {
                    int PoziomRecurencji = (int)NumUD_Rekwencja.Value;
                    Color KolorWypełnienia = btnColor.BackColor;
                    //
                    Point WierzchołekGórny = new Point(LewyGórnyX + Szerokość/2,
                        LewyGórnyY);
                    Point WierzchołekLewyDolny = new Point(LewyGórnyX,
                                                            LewyGórnyY + Wysokość);
                    Point WierzchołekPrawyDolny = new Point(LewyGórnyX + Szerokość,
                                                            LewyGórnyY + Wysokość);
                    WykreślTrójkąSierpińskiego(Rysownica, PoziomRecurencji, KolorWypełnienia, WierzchołekGórny, WierzchołekLewyDolny, WierzchołekPrawyDolny);
                }
                if (rdbFraktal.Checked)
                {
                    for (int x = 0; x < 400; x++)
                    {
                        for (int y = 0; y < 400; y++)
                        {
                            double zx, zy, cX, cY, x1, y1;
                            zx = zy = 0;
                            cX = (x - 200) / 200.0;
                            cY = (y - 200) / 200.0;
                            int iteration = 0;
                            int max_iteration = 100;

                            while (zx * zx + zy * zy < 4 && iteration < max_iteration)
                            {
                                x1 = zx * zx - zy * zy + cX;
                                y1 = 2 * zx * zy + cY;
                                zx = x1;
                                zy = y1;
                                iteration = iteration + 1;
                            }

                            if (iteration == max_iteration)
                            {
                                Rysownica.DrawRectangle(Pens.Black, x, y, 1, 1);
                            }
                            else
                            {
                                Rysownica.DrawRectangle(Pens.Gray, x, y, 1, 1);
                            }
                        }
                    }
                }
            }
            pbRisownica.Refresh();
        }

        private void pbRisownica_MouseMove(object sender, MouseEventArgs e)
        {

            // wizualizacja wpółrzędnych aktualnego położenia myszy
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();
            //
            int LewyGórnyX = (Punkt.X > e.Location.X) ? e.Location.X : Punkt.X;
            int LewyGórnyY = (Punkt.Y > e.Location.Y) ? e.Location.Y : Punkt.Y;
            int Szerokość = Math.Abs(Punkt.X - e.Location.X);
            int Wysokość = Math.Abs(Punkt.Y - e.Location.Y);
            //obsługa zdarzenia MouseDown
            if (e.Button == MouseButtons.Left)
            {// przechowanie wspołorzędnych poleżonia "Myszy" w zmiennej Punkt
                if (rdbLiniaKreślena.Checked)
                {
                    // tak to wykreślamy punkt
                    Rysownica.DrawLine(Pióro, Punkt.X, Punkt.Y,
                                                    e.Location.X, e.Location.Y);
                    // uaktualnie współrzędnych przechowywanych w zmiennej Punkt od ktorego będzie wykreślany następny odcinek prostej
                    Punkt = e.Location;
                }
                //czy jest kreślona linia prosta
                if (rdbLiniaProsta.Checked)
                {
                    RysownicaTymczasowa.DrawLine(PióroTymczasowe, Punkt.X, Punkt.Y, e.Location.X, e.Location.Y);
                }
                // czy wielokąt foremny 
                if (rdbWielokatForemny.Checked)
                {// deklaracje pomocniecze i pobranie danych z formularza
                    int StopieńWielokąta = (int) NumU.Value;
                    int PromieńWielokąta = Szerokość;
                    // wyznaczenie współrzednych wierzchołków wielokąta
                    Point[] WierchołkiWielokąta = new Point[StopieńWielokąta];
                    // deklaracja i wyznaczenie kata środkowego wielokąta
                    double KątAlfa = 360.0 / StopieńWielokąta;
                    double KątFi;
                    for (int i = 0; i < StopieńWielokąta; i++)
                    {
                        // wyznaczenie kąta położenia i-tego wierzchołka wielokąta
                        KątFi = Math.PI * (i * KątAlfa) / 180.0;
                        WierchołkiWielokąta[i].X = (LewyGórnyX + Szerokość / 2) + (int)(PromieńWielokąta * Math.Cos(KątFi));
                        WierchołkiWielokąta[i].Y = (LewyGórnyY + Wysokość / 2) + (int)(PromieńWielokąta * Math.Sin(KątFi));
                    }
                    // wykreślenie wielokąta na powierzcni tymczasowej
                    RysownicaTymczasowa.DrawPolygon(PióroTymczasowe, WierchołkiWielokąta);
                }
                if (rdbWielokatWypelniony.Checked)
                {
                    ushort StopieńWielokąt = (ushort)NUD_WielokątWypelniony.Value;
                    int R = Szerokość;
                    double KątMiędzWierzchołkamiWielokta = 360.0 / StopieńWielokąt;
                    double KątPołożeniaPierwszegoWierzchowka = 0.0;
                    //
                    Point[] WierzchołkiWielokąta = new Point[StopieńWielokąt];
                    for (int i = 0; i < StopieńWielokąt; i++)
                    {
                        WierzchołkiWielokąta[i].X = LewyGórnyX + (int)(R * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchowka + i * KątMiędzWierzchołkamiWielokta) / 180.0));
                        WierzchołkiWielokąta[i].Y = LewyGórnyY - (int)(R * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchowka + i * KątMiędzWierzchołkamiWielokta) / 180.0));
                    }
                    RysownicaTymczasowa.DrawPolygon(PióroTymczasowe, WierzchołkiWielokąta);
                }
                if (rdbTrójkąSierpińskiego.Checked)
                {
                    int PoziomRecurencji = (int)NumUD_Rekwencja.Value;  
                    Color KolorWypełnienia = btnColor.BackColor;
                    //
                    Point WierzchołekGórny = new Point(LewyGórnyX + Szerokość / 2,
                        LewyGórnyY);
                    Point WierzchołekLewyDolny = new Point(LewyGórnyX,
                                                            LewyGórnyY + Wysokość);
                    Point WierzchołekPrawyDolny = new Point(LewyGórnyX + Szerokość,
                                                            LewyGórnyY + Wysokość);
                    WykreślTrójkąSierpińskiego(RysownicaTymczasowa, PoziomRecurencji, KolorWypełnienia, WierzchołekGórny, WierzchołekLewyDolny, WierzchołekPrawyDolny);
                }

            }
            pbRisownica.Refresh();
        }

        private void rdbWielokatForemny_CheckedChanged(object sender, EventArgs e)
        {
            // rozpoznanie stanu kontrolki rdbWielokąt
            if (rdbWielokatForemny.Checked)
            {
                MessageBox.Show("Wykreślenie wielokąta foremnego wymaga ustalenia liczby jego kątów (minimalna liczba kątów, to 3!)", "Wykreślenie foramego"
                    ,MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblLiczba.Visible = true;
                NumU.Visible = true;

                NumU.Minimum = 3;
                // ustawienie stanu aktualności dla kontrolki NumU
            }
            else
            {
                lblLiczba.Visible = false;
                NumU.Visible = false;
            }
        }

        private void Laboratoryjny_Radovskyi61986_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult OknoMessage = MessageBox.Show("Czy rzechywicie chcesz zakąć ten " +
              "formularz i powrócić do formularza głuwnego", this.Text,
              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            // rozpoznanie decyzji użytkownika programu
            if (OknoMessage == DialogResult.Yes)
            {
                e.Cancel = false;

                foreach (Form Formularz in Application.OpenForms)
                {
                    if (Formularz.Name == "FormularzStartowy")
                    { // ukrycie bieżącego formularza
                        this.Hide();
                        // odsłonięcie znalezionego głównego formularza
                        Formularz.Show();
                        // wyjście z metody obsługi zdarzenia FormClosing
                        return;
                    }

                }
                FormularzStartowy FormularzProjectuNr3 = new FormularzStartowy();
                // ukrycie bieżącego formularza głównego
                FormularzProjectuNr3.Show();
                // ukrycie bieżącego formularza
                this.Hide();
            }
            else
                e.Cancel = true;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog PalataKolorów = new ColorDialog();
            // zaznacienie biężacego koloru wypełnienia w PolecieKolorów
            PalataKolorów.Color = btnColor.BackColor;
            // wizualizacja 
            if (PalataKolorów.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = PalataKolorów.Color;
            }
        }

        private void rdbTrójkąSierpińskiego_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTrójkąSierpińskiego.Checked)
            {
                MessageBox.Show("Wykreślenie Trójkąta Sierpińsiego wymaga podania " +
                    "poziomu  rekurencji  (od 0 2 'górę') oraz wybrania koloru wypełnienia\n" +
                    "UWAGA: moąna przyląc zaprogramowane ustawienia domyślne",
                    "Kreślenie Trójkąta Sierpińskieg    o", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                lblRekwęcja.Visible = true;
                NumUD_Rekwencja.Visible = true;
                btnColor.Visible = true;

                NumUD_Rekwencja.Value = 3;
                btnColor.BackColor = Color.LightGreen;
                NumUD_Rekwencja.Enabled = true;
                btnColor.Enabled = true;
            }
            else
            {
                lblRekwęcja.Visible = false;
                NumUD_Rekwencja.Visible = false;
                btnColor.Visible = false;
            }
        }

        void WykreślTrójkąSierpińskiego(Graphics Rysownica, int PoziomRekurencji, Color KolorWykresu,  Point WierchoekGurny, Point WierchoekiLewyDolny,Point WierzchoekPrawyDolny)
        {
            if (PoziomRekurencji == 0)
            {
                Point[] WierzchołkiTrójkata = { WierchoekGurny, WierchoekiLewyDolny, WierzchoekPrawyDolny };
                using (SolidBrush Pędzel = new SolidBrush(KolorWykresu))
                {
                    Rysownica.FillPolygon(Pędzel, WierzchołkiTrójkata);
                }

            }
            else
            {
                Point PunktyŚrodkowyLewejKrawędzi = new Point((WierchoekGurny.X + WierchoekiLewyDolny.X) / 2,
                                                              (WierchoekGurny.Y + WierchoekiLewyDolny.Y) / 2);
                Point PunktyŚrodkowyPrawejKrawędzi = new Point((WierchoekGurny.X + WierzchoekPrawyDolny.X) / 2,
                                                              (WierchoekGurny.Y + WierzchoekPrawyDolny.Y) / 2);
                Point PunktyŚrodkowyDolnejKrawędzi = new Point((WierchoekiLewyDolny.X + WierzchoekPrawyDolny.X) / 2,
                                                              (WierchoekiLewyDolny.Y + WierzchoekPrawyDolny.Y) / 2);
                //
                WykreślTrójkąSierpińskiego(Rysownica, PoziomRekurencji - 1, KolorWykresu, WierchoekGurny, PunktyŚrodkowyLewejKrawędzi, PunktyŚrodkowyPrawejKrawędzi);
                WykreślTrójkąSierpińskiego(Rysownica, PoziomRekurencji - 1, KolorWykresu, WierchoekiLewyDolny, PunktyŚrodkowyLewejKrawędzi, PunktyŚrodkowyDolnejKrawędzi);
                WykreślTrójkąSierpińskiego(Rysownica, PoziomRekurencji - 1, KolorWykresu, PunktyŚrodkowyDolnejKrawędzi, PunktyŚrodkowyPrawejKrawędzi, WierzchoekPrawyDolny);
            }
        }

        private void rdbWielokatWypelniony_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbWielokatWypelniony.Checked)
            {
                MessageBox.Show("Wykreślenie wielokąta wypełnionego foremnego wymaga podania stopnia wielokąta, czyli liczby katów wielokata (minimalny stopień wielokąta jest równy 3)", "Wykreślanie wielokąta foremnego", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblLiczbaWyp.Visible = true;
                NUD_WielokątWypelniony.Visible = true;
                NUD_WielokątWypelniony.Enabled = true;
                NUD_WielokątWypelniony.Minimum = 3;
            }

            else
            {
                lblLiczbaWyp.Visible = false;
                NUD_WielokątWypelniony.Visible = false;
            }

        }

        private void rdbGwiazdaWieloramienna_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rdbFraktal_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
