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
    public partial class ProjectowyNr1_Radovskiy61986 : Form
    {
        const int arMargines = 10;
        const int arPromienObiekty = 5;
        const float arDGprzedziałuX = float.MinValue;
        const float arGGprzedziałuX = float.MaxValue;

        // deklaracje pomocnicza
        static ProjectowyNr1_Radovskiy61986 UchwytFormularza;
        float arXd, arXg, arh;
        //
        float[,] arTWS = null;
        int arLiczbaPrzedziałówH;
        int arIndexPOA;
        int arMaxIndexPOA;
        Graphics arRysownica;
        Pen arPióroXY;

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
            if (arTWS is null)
            {
                // egzemplarz tablicy TWS nie został jeszcze utworzony i szereg nie został stablicowany
                // utworzenie egzemplarza i stablicowanie szeregu
                TablicowanieSzeregu(arTWS, arXd, arXg, arh);
            }
            /* 3) wpisanie do kontrolki DataGridView (o name: dgvTWS) stablicowanych
                  wartości szeregu w przedziale: [Xd, Xg] */
            WpisanieWynikówDoKontrolkiDataGridView(arTWS, dgvTWS);

            //4) obsłomięcie i ukrycie kontrolek oraz ustawienie stany braku aktywno

            // ukrycie kontrolki Chart
            chtWykresSzeregu.Visible = false;
            // obsłonięcie kontrolki DataGridView
            dgvTWS.Visible = true;
        } 

        Pen arPioroLiniiToru;
        public ProjectowyNr1_Radovskiy61986()
        {
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Left + arMargines, Screen.PrimaryScreen.Bounds.Top + arMargines);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.85f);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Width * 0.7f);
            this.StartPosition = FormStartPosition.Manual;

            InitializeComponent();
            UchwytFormularza = this;
            pictureBox1.BackColor = Color.LightBlue;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            arRysownica = Graphics.FromImage(pictureBox1.Image);

            arPióroXY = new Pen(Color.Blue, 1);
            arPióroXY.StartCap = LineCap.Flat;
            arPióroXY.EndCap = LineCap.ArrowAnchor;
            AdjustableArrowCap dużoGrotyStrzałek = new AdjustableArrowCap(3, 5);
            arPióroXY.StartCap = LineCap.Square;
            arPióroXY.CustomEndCap = dużoGrotyStrzałek;
            arPioroLiniiToru = new Pen(Color.Black, 1.5f);
            arPioroLiniiToru.DashStyle = DashStyle.Dot;
        }

        float ObliczenieWartościSzeregu(float arx)
        {
            const float arEps = 0.0000001F;
            float arw = 1, arS;
            int ark = 1;
            arS = 0;
            while (Math.Abs(arw) > arEps)
            {
                ark++;
                arw = (float)Math.Pow(arx - 2, ark) / ((ark + 5) * (float)Math.Pow(3, ark));
                arS += arw;
            }
            return arS;
        }

        void TablicowanieSzeregu(float[,] arTWS, float arXd, float arXg, float arh)
        {
            float arX;
            int ari;
            for (arX = arXd, ari = 0; ari < arTWS.GetLength(0); arX = arXd + ari * arh, ari++)
            {
                arTWS[ari, 0] = arX;
                arTWS[ari, 1] = ObliczenieWartościSzeregu(arX);
            }
        }
        public static class PrzeliczanieWsprznych
        {
            static float arSx, arSy;
            static float arDx, arDy;
            // deklaracje zmiannych dla przechowania rozmiarów powierzchni graficznej
            static int arXe_min, arXe_max, arYe_min, arYe_max;
            public static float arXmax { get; private set; }
            public static float arXmin { get; private set; }
            public static float arYmin { get; private set; }
            public static float arYmax { get; private set; }

            static PrzeliczanieWsprznych()
            {
                arXmin = UchwytFormularza.arXd;
                arXmax = UchwytFormularza.arXg;
                //
                arYmin = ExtremuSzeregu.MinSx(UchwytFormularza.arTWS);
                arYmax = ExtremuSzeregu.MaxSx(UchwytFormularza.arTWS);
                //
                arXe_min = arMargines;
                arXe_max = UchwytFormularza.pictureBox1.Width - (arMargines + arMargines);
                arYe_min = arMargines;
                arYe_max = UchwytFormularza.pictureBox1.Height - (arMargines + arMargines);
                //
                arSx = (arXe_max - arXe_min) / (arXmax - arXmin);
                arSy = (arYe_max - arYe_min) / (arYmax - arYmin);
                arDx = arXe_min - arXmin * arSx;
                arDy = arYe_min - arYmin * arSy;

            }
            // deklaracja metod
            public static int WspX(float arx)
            {
                return (int)(arSx * arx + arDx);
            }
            public static int WspY(float ary)
            {
                return (int)(arSx * ary + arDy);
            }
        }

        private void btnAnimacja_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (!PobirzDaneWejściowe(out arXd, out arXg, out arh))
            {
                return;
            }
            arLiczbaPrzedziałówH = (int)((arXg - arXd) / arh) + 1;

            arTWS = new float[arLiczbaPrzedziałówH, 2];
            TablicowanieSzeregu(arTWS, arXd, arXg, arh);
            arIndexPOA = 0;
            arMaxIndexPOA = arTWS.GetLength(0) - 1;
            timer1.Enabled = true;

            dgvTWS.Visible= false;
            chtWykresSzeregu.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (arIndexPOA >= arMaxIndexPOA)
                arIndexPOA = 0;
            else
            {
                arIndexPOA++;
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (arTWS is null)
                return;
            arRysownica.Clear(Color.AliceBlue);
            arRysownica.RotateTransform(180);
            arRysownica.SmoothingMode = SmoothingMode.AntiAlias;
            arRysownica.DrawLine(arPióroXY, PrzeliczanieWsprznych.WspX(0),
                PrzeliczanieWsprznych.WspY(PrzeliczanieWsprznych.arYmax),
                PrzeliczanieWsprznych.WspX(0),
                PrzeliczanieWsprznych.WspY(PrzeliczanieWsprznych.arYmin));
            arRysownica.DrawLine(arPióroXY, PrzeliczanieWsprznych.WspX(PrzeliczanieWsprznych.arXmin),
               PrzeliczanieWsprznych.WspY(0), PrzeliczanieWsprznych.WspY(PrzeliczanieWsprznych.arXmax), PrzeliczanieWsprznych.WspY(0));

            for (int j = 0; j < arTWS.GetLength(0) - 1; j++)
            {
                arRysownica.DrawLine(arPioroLiniiToru, PrzeliczanieWsprznych.WspX(arTWS[j, 0]),
                   PrzeliczanieWsprznych.WspY(arTWS[j, 1]),
                   PrzeliczanieWsprznych.WspX(arTWS[j + 1, 0]),
                   PrzeliczanieWsprznych.WspY(arTWS[j + 1, 1]));
            }
            arRysownica.FillEllipse(Brushes.DarkRed, PrzeliczanieWsprznych.WspX(arTWS[arIndexPOA, 0]) - arPromienObiekty,
                PrzeliczanieWsprznych.WspY(arTWS[arIndexPOA, 1]) - arPromienObiekty, 2 * arPromienObiekty, 2 * arPromienObiekty);
        }
        private void ProjectowyNr1_Radovskiy61986_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form arFormularz in Application.OpenForms)
            {
                if (arFormularz.Name == "Form1")
                {
                    this.Hide();
                    //
                    arFormularz.Show();
                    //
                    return;
                }
            }
            Kokpit_Radovskyi61986 arkokpit = new Kokpit_Radovskyi61986();
            arkokpit.Show();
            this.Hide();
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
            if (arTWS is null)
            {
                // egzemplarz tablicy TWS nie został jeszcze utworzony i szereg nie został stablicowany
                // utworzenie egzemplarza i stablicowanie szeregu
                TablicowanieSzeregu(arTWS, arXd, arXg, arh);
            }
            // 3) Wpisanie wyników tablicowania do kontrolki Char
            WpisanieWynikówDoKontrolkiChart(arTWS, chtWykresSzeregu);
            // 4) ukrycie i obsłonięcie kontrolek dla potrzeb obsługowanego przycisku poleceń
            dgvTWS.Visible = false;
            chtWykresSzeregu.Visible = true;
        }

        bool PobirzDaneWejściowe(out float arXd, out float arXg, out float arh)
        {
            arXd = arXg = arh = 0;
            if (!float.TryParse(txtXd.Text, out arXd))
            {
                errorProvider1.SetError(txtXd, "Error: wystąpił znak");
                return false;
            }

            if ((arXd < arDGprzedziałuX) || (arXd > arGGprzedziałuX))
            {
                return false;
            }
            if (!float.TryParse(txtXg.Text, out arXg))
            {
                errorProvider1.SetError(txtXd, "Error: wystąpił znak");
                return false;
            }
            if (arXd > arXg)
            {
                errorProvider1.SetError(txtXg, "ERROR");
                return false;
            }
            if (!float.TryParse(txtH.Text, out arh))
            {
                errorProvider1.SetError(txtH, "ERROR");
                return false;
            }
            if ((arh <= 0.0f) || (arh > 1.0f))
            {
                errorProvider1.SetError(txtH, "ERROR");
                return false;
            }


            return true;
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
