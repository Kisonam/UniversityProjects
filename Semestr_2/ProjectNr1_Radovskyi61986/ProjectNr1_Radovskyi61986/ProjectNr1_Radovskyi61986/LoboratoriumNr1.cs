using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjectNr1_Radovskyi61986
{
    public partial class LoboratoriumNr1_Raovskyi61986 : Form
    {
        const int Margines = 10;
        const int PromienObiekty = 5;
        const float DGprzedziałuX = float.MinValue;
        const float GGprzedziałuX = float.MaxValue;

        // deklaracje pomocnicza
        static LoboratoriumNr1_Raovskyi61986 UchwytFormularza;
        float Xd, Xg, h;
        //
        float[,] TWS = null;
        int LiczbaPrzedziałówH;
        int IndexPOA;
        int MaxIndexPOA;
        Graphics Rysownica;
        Pen PióroXY;
        Pen PioroLiniiToru;

        public LoboratoriumNr1_Raovskyi61986()
        {
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Left + Margines, Screen.PrimaryScreen.Bounds.Top + Margines);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.85f);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Width * 0.7f);
            this.StartPosition = FormStartPosition.Manual;

            InitializeComponent();
            UchwytFormularza = this;
            pictureBox1.BackColor = Color.LightBlue;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = new Bitmap (pictureBox1.Width, pictureBox1.Height);
            Rysownica = Graphics.FromImage(pictureBox1.Image);

            PióroXY = new Pen(Color.Blue, 1);
            PióroXY.StartCap = LineCap.Flat;
            PióroXY.EndCap = LineCap.ArrowAnchor;
            AdjustableArrowCap dużoGrotyStrzałek = new AdjustableArrowCap(3, 5);
            PióroXY.StartCap = LineCap.Square;
            PióroXY.CustomEndCap = dużoGrotyStrzałek;
            PioroLiniiToru = new Pen(Color.Black, 1.5f);
            PioroLiniiToru.DashStyle = DashStyle.Dot;
        }
        private void LoboratoriumNr1_Raovskyi61986_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult OknoMessage = MessageBox.Show("Samoocena Sprawdzaniu Nr 1 = 4, gdyż zostały" +
                " zrealizowane 3 z 4  zadań sprawdzanianu\n" +
                "Autor programu: R");
            foreach (Form Formularz in Application.OpenForms)
            {
                if (Formularz.Name == "Form1")
                {
                    this.Hide();
                    //
                    Formularz.Show();
                    //
                    return;
                }
            }
            Kokpit_Radovskyi61986 kokpit = new Kokpit_Radovskyi61986();
            kokpit.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IndexPOA >= MaxIndexPOA)
                IndexPOA = 0;
            else
            {
                IndexPOA++;
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (TWS is null)
                return;
            Rysownica.Clear(Color.AliceBlue);
            Rysownica.SmoothingMode = SmoothingMode.AntiAlias;
            Rysownica.DrawLine(PióroXY, PrzeliczanieWsprznych.WspX(0),
                PrzeliczanieWsprznych.WspY(PrzeliczanieWsprznych.Ymax),
                PrzeliczanieWsprznych.WspX(0), 
                PrzeliczanieWsprznych.WspY(PrzeliczanieWsprznych.Ymin));
            Rysownica.DrawLine(PióroXY, PrzeliczanieWsprznych.WspX(PrzeliczanieWsprznych.Xmin),
               PrzeliczanieWsprznych.WspY(0), PrzeliczanieWsprznych.WspY(PrzeliczanieWsprznych.Xmax), PrzeliczanieWsprznych.WspY(0));

            for (int j = 0; j < TWS.GetLength(0) - 1; j++)
            {
                Rysownica.DrawLine(PioroLiniiToru, PrzeliczanieWsprznych.WspX(TWS[j, 0]),
                   PrzeliczanieWsprznych.WspY(TWS[j, 1]),
                   PrzeliczanieWsprznych.WspX(TWS[j + 1, 0]),
                   PrzeliczanieWsprznych.WspY(TWS[j + 1, 1]));
            }
            Rysownica.FillEllipse(Brushes.Yellow, PrzeliczanieWsprznych.WspX(TWS[IndexPOA, 0]) - PromienObiekty, 
                PrzeliczanieWsprznych.WspY(TWS[IndexPOA, 1]) - PromienObiekty, 2 * PromienObiekty, 2 * PromienObiekty);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        bool PobirzDaneWejściowe(out float Xd, out float Xg, out float h)
        {
            Xd = Xg = h = 0;
            if (!float.TryParse(txtXd.Text, out Xd))
            {
                errorProvider1.SetError(txtXd, "Error: wystąpił znak");
                return false;
            }

            if ((Xd < DGprzedziałuX) || (Xd > GGprzedziałuX))
            {
                return false;
            }
            if (!float.TryParse(txtXg.Text, out Xg))
            {
                errorProvider1.SetError(txtXd, "Error: wystąpił znak");
                return false;
            }
            if (Xd > Xg)
            {
                errorProvider1.SetError(txtXg, "ERROR");
                return false;
            }
            if (!float.TryParse(txtH.Text,out h))
            {
                errorProvider1.SetError(txtH, "ERROR");
                return false;
            }
            if ((h <= 0.0f) || (h > 1.0f))
            {
                errorProvider1.SetError(txtH, "ERROR");
                return false;
            }


            return true;
        }
        private void btnAnimacja_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (!PobirzDaneWejściowe(out Xd, out Xg, out h))
            {
                return;
            }
            LiczbaPrzedziałówH = (int)((Xg - Xd) / h) + 1;

            TWS = new float[LiczbaPrzedziałówH, 2];
            TablicowanieSzeregu(TWS,Xd,Xg,h);
            IndexPOA = 0;
            MaxIndexPOA= TWS.GetLength(0) - 1;
            timer1.Enabled = true;
        }

        void TablicowanieSzeregu(float[,] TWS, float Xd, float Xg, float h)
        {
            float X;
            int i;
            for (X = Xd, i = 0; i < TWS.GetLength(0); X = Xd + i * h, i++)
            {
                TWS[i, 0] = X;
                TWS[i, 1] = ObliczenieWartościSzeregu(X);
            }
        }
        private void btnResetuj_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnWizualizacjaGraficzna_Click(object sender, EventArgs e)
        {
            // "zgaszanie" kontrolki errorProvider, która mogła wcześniej zapalona
            errorProvider1.Dispose();

            float arXd, arXg, arh;

            if (!PobirzDaneWejściowe(out arXd, out arXg, out arh))
            {
                errorProvider1.SetError(btnWizualizacjaGraficzna, "ERROR: przy pobieraniu " +
                    "danych wejściowych wykryto błąd i dlatego ta funkcjonalność nie może " +
                    "być zrealizowana");
                // przerwanie obsługi zdarzenia Click: btnWizualizacjaTabelaryczna_Click
                return;
            }

            // 2) talicowanie wartości szeregu w predzieale: [Xd, Sg]
            /* sprawdzenie czy egzemplarz tablicy TWS został już utworzony i szereg
               został stablicowany*/
            if (TWS is null)
            {
                // egzemplarz tablicy TWS nie został jeszcze utworzony i szereg nie został stablicowany
                // utworzenie egzemplarza i stablicowanie szeregu
                TablicowanieSzeregu(TWS, arXd, arXg, arh);
            }
            // 3) Wpisanie wyników tablicowania do kontrolki Char
            WpisanieWynikówDoKontrolkiChart(TWS, chtWykresSzeregu);
            // 4) ukrycie i obsłonięcie kontrolek dla potrzeb obsługowanego przycisku poleceń
            dgvTWS.Visible = false;
            chtWykresSzeregu.Visible = true;
        }

        float ObliczenieWartościSzeregu(float x)
        {
            const float Eps = 0.0000001F;
            float w, S;
            int k;
            w = 1;
            k = 0;
            S = w;
            while (Math.Abs(w) > Eps)
            {
                k++;
                w = w * ((-1.0f) * x * x) / (float)(w * k * (2 *k + 1));
                S = S + w;
            } 
            return S;
        }

        private void btnWizualizacjaTabeleryczna_Click(object sender, EventArgs e)
        {
            // "zgaszanie" kontrolki errorProvider, która mogła wcześniej zapalona
            errorProvider1.Dispose();
            // pobranie dannych wejściowych z formularza: Eps, Xd,Xg,h

            // 2) Stabicowanie szeregu w podanym przedziale: [xd, Xg]

            // 3) Przepisanie danych z TWS (Tablicz wartościSzeregu) do  kontrolki DataGridVie
            // ad 1)
            // deklaracje zmiennych dla przechowania pobranych danych wejściowych z formularza
            float arXd, arXg, arh;

            if (!PobirzDaneWejściowe(out arXd, out arXg, out arh))
            {
                errorProvider1.SetError(btnWizualizacjaTabeleryczna, "ERROR: przy pobieraniu " +
                    "danych wejściowych wykryto błąd i dlatego ta funkcjonalność nie może " +
                    "być zrealizowana");
                // przerwanie obsługi zdarzenia Click: btnWizualizacjaTabelaryczna_Click
                return;
            }

            // 2) talicowanie wartości szeregu w predzieale: [Xd, Sg]
            /* sprawdzenie czy egzemplarz tablicy TWS został już utworzony i szereg
               został stablicowany*/
            if (TWS is null)
            {
                // egzemplarz tablicy TWS nie został jeszcze utworzony i szereg nie został stablicowany
                // utworzenie egzemplarza i stablicowanie szeregu
                TablicowanieSzeregu(TWS, arXd, arXg, arh);
            }
            /* 3) wpisanie do kontrolki DataGridView (o name: dgvTWS) stablicowanych
                  wartości szeregu w przedziale: [Xd, Xg] */
            WpisanieWynikówDoKontrolkiDataGridView(TWS, dgvTWS);

            //4) obsłomięcie i ukrycie kontrolek oraz ustawienie stany braku aktywno

            // ukrycie kontrolki Chart
            chtWykresSzeregu.Visible = false;
            // obsłonięcie kontrolki DataGridView
            dgvTWS.Visible = true;
        }

        public static class PrzeliczanieWsprznych 
        {
            static float Sx, Sy;
            static float Dx, Dy;
            // deklaracje zmiannych dla przechowania rozmiarów powierzchni graficznej
            static int Xe_min, Xe_max, Ye_min, Ye_max;
            public static float Xmax { get;private set; }
            public static float Xmin { get; private set; }
            public static float Ymin { get; private set; }
            public static float Ymax { get; private set; }

            static PrzeliczanieWsprznych()
            {
                Xmin = UchwytFormularza.Xd;
                Xmax = UchwytFormularza.Xg;
                //
                Ymin = ExtremuSzeregu.MinSx(UchwytFormularza.TWS);
                Ymax = ExtremuSzeregu.MaxSx(UchwytFormularza.TWS);
                //
                Xe_min = Margines;
                Xe_max = UchwytFormularza.pictureBox1.Width - (Margines + Margines);
                Ye_min = Margines;
                Ye_max = UchwytFormularza.pictureBox1.Height - (Margines + Margines);
                //
                Sx = (Xe_max - Xe_min) / (Xmax- Xmin);
                Sy = (Ye_max - Ye_min) / (Ymax- Ymin);
                Dx = Xe_min - Xmin * Sx;
                Dy = Ye_min - Ymin * Sy;

            }
            // deklaracja metod
            public static int WspX(float x)
            {
                return (int)(Sx * x + Dx);
            }
            public static int WspY(float y)
            {
                return (int)(Sx * y + Dy);
            }
        }

        private void liniaKreskowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PioroLiniiToru.DashStyle = DashStyle.Dash;
        }

        private void liniaKreskowaKrapkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PioroLiniiToru.DashStyle = DashStyle.DashDot;

        }

        private void liniaKreskowaKrapkowaKrapkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PioroLiniiToru.DashStyle = DashStyle.DashDotDot;

        }

        private void liniaKrapkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PioroLiniiToru.DashStyle = DashStyle.Dot;

        }

        private void agłasolidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PioroLiniiToru.DashStyle = DashStyle.Solid;

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PioroLiniiToru.Width = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            PioroLiniiToru.Width = 2;

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            PioroLiniiToru.Width = 3;

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            PioroLiniiToru.Width = 4;

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            PioroLiniiToru.Width = 5;
        }

        private void kolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog PaleteDialog = new ColorDialog();

            PaleteDialog.Color = PioroLiniiToru.Color;
            if (PaleteDialog.ShowDialog () == DialogResult.OK)
            {
               PioroLiniiToru.Color = PaleteDialog.Color;
            }
            PaleteDialog.Dispose();
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        void WpisanieWynikówDoKontrolkiChart(float[,] arTWS, Chart archtWykresSzeregu)
        {
            // 1.formatowanie (ustawienie atrybutów) kontrolki Chart, obramowanie kontrolki Chart
            archtWykresSzeregu.BorderlineWidth = 2;
            archtWykresSzeregu.BorderlineColor = Color.Red;
            archtWykresSzeregu.BorderlineDashStyle = ChartDashStyle.DashDotDot;
            // skonfigurowanie kontrolki Chart
            // ustalenie tytułu wykresu
            archtWykresSzeregu.Titles.Add("Wykres zmian wartości szeregu S(x)");
            // umieszczenie legendy pod wykresem
            archtWykresSzeregu.Legends.FindByName("Legend1").Docking = Docking.Bottom;
            //ustawienie koloru tła 
            archtWykresSzeregu.BackColor = Color.LightSkyBlue;
            archtWykresSzeregu.ChartAreas[0].AxisX.Title = "Wartości X";
            archtWykresSzeregu.ChartAreas[0].AxisY.Title = "Wartości S(x)";
            // sformatowanie opisu osi X (kontrolki Chart)
            archtWykresSzeregu.ChartAreas[0].AxisX.LabelStyle.Format = "{0:f2}";
            archtWykresSzeregu.ChartAreas[0].AxisY.LabelStyle.Format = "{0:f2}";
            // 2.formatowanie serii danych dodanej do kontrolki Chart,
            // "wyzerowanie"serii danych kontrolki Chart
            archtWykresSzeregu.Series.Clear();
            //dodanie nowej serii danych
            archtWykresSzeregu.Series.Add("Seria 0");
            // ustalenie nazw osi układu współezędnych
            archtWykresSzeregu.Series[0].XValueMember = "X";
            archtWykresSzeregu.Series[0].XValueMember = "Y";
            // ustalenie widoczności legendy
            archtWykresSzeregu.Series[0].IsVisibleInLegend = true;
            // ustalenie nazwy legendy (opisu linii wykresu)
            archtWykresSzeregu.Series[0].Name = "Wartości szeregu potęgowego S(X)"; // legenda
            // ustalenie typu wykresu
            archtWykresSzeregu.Series[0].ChartType = SeriesChartType.Line; // liniowy
            // ustawienie koloru linii 
            archtWykresSzeregu.Series[0].Color = Color.Black;
            //ustawienie stylu linii 
            archtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.Solid;
            // ustalenie grubości linii
            archtWykresSzeregu.Series[0].BorderWidth = 1;

            /* 3. wpisania współrzędnych (X oraz Y) linii wykresu 
             szeregu (na podstawie zapisanych w tablicy TWS) */
            /* dodanie do serii danych (kontrolki Chart) współrzędnych
               punktów wykresu (wartości X oraz Wartości Y, czyli 
               wartości szeregu: S (X) */
            for (int i = 0; i < arTWS.GetLength(0); i++)
            {
                archtWykresSzeregu.Series[0].Points.AddXY(arTWS[i, 0], arTWS[i, 1]);
            }
        }
        void WpisanieWynikówDoKontrolkiDataGridView(float[,] arTWS, DataGridView ardgvTWS)
        {
            // wyzerowanie wierszy kontrolki DataGridView
            ardgvTWS.Rows.Clear();
            // wpisywanie kolejnych wierszy tablicy TWS do kontrolki dvgTWS
            for (int i = 0; i < arTWS.GetLength(0); i++)
            {
                // dodanie nowego wiersza
                ardgvTWS.Rows.Add();
                // wpisanie wartości X
                ardgvTWS.Rows[i].Cells[0].Value = string.Format($"{arTWS[i, 0]:00}");
                // wpisanie wartości szeregu
                ardgvTWS.Rows[i].Cells[1].Value = string.Format($"{arTWS[i, 1]:0.000}");
            }
        }
    }
}
