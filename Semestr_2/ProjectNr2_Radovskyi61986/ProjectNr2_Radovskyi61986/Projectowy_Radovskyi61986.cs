using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjectNr2_Radovskyi61986.FiguryGeometryczne;

namespace ProjectNr2_Radovskyi61986
{
    public partial class Projectowy_Radovskyi61986 : Form
    {
        const ushort ArMargines = 10;
        const ushort ArMarginesFormularza = 20;

        Graphics ArRysownica;
        Graphics ArRysownicaTymczasowa;

        Color ArKolorLinii;
        Color ArKolorWypełnienia;
        DashStyle ArDashStyle;

        Point ArPunkt;
        Pen ArPióro;
        Pen ArPióroTymczasowe;

        SolidBrush ArPędzel;

        List<Punkt> ArLFG = new List<Punkt>();

        public Projectowy_Radovskyi61986()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            ArRysownica = Graphics.FromImage(pictureBox1.Image);

            ArDashStyle = DashStyle.Solid;
            ArKolorLinii = Color.Black;
            ArKolorWypełnienia = Color.Black;
            ArPióro = new Pen(ArKolorLinii);
            ArPędzel = new SolidBrush(ArKolorWypełnienia);
        }

        private void Projectowy_Radovskyi61986_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
            {
                // sprwdzenie,czy to jest formularz LaboratoriumNr1
                if (Formularz.Name == "Kokpit_Radovskyi61986")
                { // ukrycie bieżącego (to będzie główny) formularza
                    this.Hide();
                    // odsłonięcie formularza znalezionego
                    Formularz.Show();
                    // bezwarunkowe zakończenie obsługi zdarzenia Click
                    return;
                }
            }
            Kokpit_Radovskyi61986 ArKokpit = new Kokpit_Radovskyi61986();
            ArKokpit.Show();
            this.Hide();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();

            int ArlewyGórnyNarożnikX = (ArPunkt.X > e.Location.X) ? e.Location.X : ArPunkt.X;
            int ArlewyGórnyNarożnikY = (ArPunkt.Y > e.Location.Y) ? e.Location.Y : ArPunkt.Y;
            int ArSzerokość = Math.Abs(ArPunkt.X - e.Location.X);
            int ArWysokość = Math.Abs(ArPunkt.Y - e.Location.Y);
            /* sprawdzenie, czy obsługiwane zdarzenie MouseUp zostało * spowodowane zwolnieniem lewego przycisku myszy */
            if (e.Button == MouseButtons.Left)
            { /* rozpoznanie figury geometrycznej, utworzenie jej egzemplarza i wykreślenie */
                if (rdbPunkt.Checked)
                {/* utworzenie egzemplarza klasy Punkt i dodanie jego referencji do LFG */
                    ArLFG.Add(new Punkt(ArPunkt.X, ArPunkt.Y + 10, ArKolorLinii));
                    ArLFG[ArLFG.Count - 1].Wykreśl(ArRysownica);
                    // wykreślenie Punktu
                }
                if (rdbLiniaProsta.Checked)
                {/* utworzenie egzemplarza klasy Linia i dodanie jej referencji do listy LFG */
                    ArLFG.Add(new Linia(ArPunkt.X, ArPunkt.Y, e.Location.X, e.Location.Y, ArKolorLinii, ArDashStyle, trbSuwakGrubościLinii.Value));
                    // wykreślenie Linii
                    ArLFG[ArLFG.Count - 1].Wykreśl(ArRysownica);
                    
                }
                if (rdbElipsa.Checked)
                {/* utworzenie egzemplarza klasy Elipsa i dodanie jej referencji do listy LFG */
                    ArLFG.Add(new Elipsa(ArPunkt.X, ArPunkt.Y, ArSzerokość, ArWysokość, ArKolorLinii, ArDashStyle, trbSuwakGrubościLinii.Value));
                    // wykreślenie Elipsy
                    ArLFG[ArLFG.Count - 1].Wykreśl(ArRysownica);
                }
                if (rdbOkrag.Checked)
                {
                    {/* utworzenie egzemplarza klasy Okrąg i dodanie jej referencji do listy LFG */
                        ArLFG.Add(new Okrąg(ArlewyGórnyNarożnikX, ArlewyGórnyNarożnikY, ArSzerokość, ArKolorLinii, ArDashStyle, trbSuwakGrubościLinii.Value));
                        // wykreślenie Okręgu
                    }
                    ArLFG[ArLFG.Count - 1].Wykreśl(ArRysownica);
                }
                if (rdbWielokątWypełniony.Checked)
                {
                    Random rnd = new Random();
                    int ArliczbaWierzchołków = rnd.Next(3, 7);
                    List<Punkt> wierzchołki = new List<Punkt>();
                    for (int o = 0; o < ArliczbaWierzchołków; o++)
                    {
                        int Arx = rnd.Next(ArMargines, (ArlewyGórnyNarożnikX - ArMargines) / 2);
                        int Ary = rnd.Next(ArMargines, (ArlewyGórnyNarożnikY - ArMargines) / 2);
                        wierzchołki.Add(new Punkt(Arx, Ary));
                    }
                    ArLFG.Add(new Wielokąt(wierzchołki, ArKolorLinii, trbSuwakGrubościLinii.Value,ArDashStyle));
                    ArLFG[ArLFG.Count - 1].Wykreśl(ArRysownica);
                }
                if (rdbLiniaCiągłaMysz.Checked)
                {
                    ArPióro.Width = trbSuwakGrubościLinii.Value;
                    ArRysownica.DrawLine(ArPióro, ArPunkt.X, ArPunkt.Y,
                                                     e.Location.X, e.Location.Y);
                }
                if (rdbKwadrat.Checked)
                {
                    ArLFG.Add(new Kwadrat(ArlewyGórnyNarożnikX, ArlewyGórnyNarożnikY,ArSzerokość,ArKolorLinii, ArWysokość, trbSuwakGrubościLinii.Value));
                    ArLFG[ArLFG.Count - 1].Wykreśl(ArRysownica);
                }
                if (rdbProstokąt.Checked)
                {
                    ArLFG.Add(new Prostokąt(ArlewyGórnyNarożnikX, ArlewyGórnyNarożnikY, ArSzerokość, ArWysokość,ArKolorLinii, 0, trbSuwakGrubościLinii.Value));
                    ArLFG[ArLFG.Count - 1].Wykreśl(ArRysownica);

                }
                if (rdbFillRect.Checked)
                {
                    ArLFG.Add(new FillProstokąt(ArlewyGórnyNarożnikX, ArlewyGórnyNarożnikY, ArSzerokość, ArWysokość, ArKolorLinii, ArKolorWypełnienia,0,trbSuwakGrubościLinii.Value));
                    ArLFG[ArLFG.Count - 1].Wykreśl(ArRysownica);

                }
                if (rdbFillElipse.Checked)
                {
                    ArLFG.Add(new FillElipsa(ArPunkt.X, ArPunkt.Y, ArSzerokość, ArWysokość, ArKolorLinii, ArKolorWypełnienia, ArDashStyle, trbSuwakGrubościLinii.Value));
                    ArLFG[ArLFG.Count - 1].Wykreśl(ArRysownica);

                }
                if (rdbKoło.Checked)
                {
                    ArLFG.Add(new Koło(ArlewyGórnyNarożnikX, ArlewyGórnyNarożnikY, ArSzerokość, ArKolorLinii, ArDashStyle, trbSuwakGrubościLinii.Value));
                    ArLFG[ArLFG.Count - 1].Wykreśl(ArRysownica);
                }
                if (rdbDrawArc.Checked)
                {
                    ArLFG.Add(new Arc(ArlewyGórnyNarożnikX, ArlewyGórnyNarożnikY, ArSzerokość, ArlewyGórnyNarożnikX, ArlewyGórnyNarożnikY, ArKolorLinii, ArDashStyle, trbSuwakGrubościLinii.Value));
                    ArLFG[ArLFG.Count - 1].Wykreśl(ArRysownica);
                }
                if (rdbDrawPie.Checked)
                {
                    ArLFG.Add(new Pie(ArlewyGórnyNarożnikX, ArlewyGórnyNarożnikY, ArSzerokość, ArlewyGórnyNarożnikX, ArlewyGórnyNarożnikY, ArKolorLinii, ArDashStyle, trbSuwakGrubościLinii.Value));
                    ArLFG[ArLFG.Count - 1].Wykreśl(ArRysownica);
                }
                if (rdbFillPie.Checked)
                {
                    ArLFG.Add(new FillPie(ArlewyGórnyNarożnikX, ArlewyGórnyNarożnikY, ArSzerokość, ArlewyGórnyNarożnikX, ArlewyGórnyNarożnikY,ArKolorLinii, ArKolorWypełnienia, ArDashStyle, trbSuwakGrubościLinii.Value));
                    ArLFG[ArLFG.Count - 1].Wykreśl(ArRysownica);
                }

                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();
            //obsługa zdarzenia MouseDown
            if (e.Button == MouseButtons.Left)
            {
                ArPunkt = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();

            if (e.Button == MouseButtons.Left)
            {// przechowanie wspołorzędnych poleżonia "Myszy" w zmiennej Punkt
                if (rdbLiniaCiągłaMysz.Checked)
                {
                    ArPióro.Width = trbSuwakGrubościLinii.Value;
                    // tak to wykreślamy punkt
                    ArRysownica.DrawLine(ArPióro, ArPunkt.X, ArPunkt.Y,
                                                    e.Location.X, e.Location.Y);
                    // uaktualnie współrzędnych przechowywanych w zmiennej Punkt od ktorego będzie wykreślany następny odcinek prostej
                    ArPunkt = e.Location;
                }

                pictureBox1.Refresh();
            }
        }

        private void btnKolorLinii_Click(object sender, EventArgs e)
        {
            ColorDialog ArColorDialog = new ColorDialog();
            if (ArColorDialog.ShowDialog() == DialogResult.OK)
            {
                ArKolorLinii = ArColorDialog.Color;
                ArPióro.Color = ArColorDialog.Color;
            }
            ArColorDialog.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog ArColorDialog = new ColorDialog();
            if (ArColorDialog.ShowDialog() == DialogResult.OK)
            {
                ArKolorWypełnienia = ArColorDialog.Color;
                ArPędzel.Color = ArColorDialog.Color;
            }
            ArColorDialog.Dispose();
        }

        private void btnWczytajPlik_Click(object sender, EventArgs e)
        {
            OpenFileDialog AROknoWyboruPlikuOdczytu = new OpenFileDialog();
            AROknoWyboruPlikuOdczytu.Title = "Odczytaj BitMapę";
            AROknoWyboruPlikuOdczytu.Filter = "Image Files|*.jpg;*.jpeg;*.png|Allfiles(*.*)|*.*";
            AROknoWyboruPlikuOdczytu.FilterIndex = 1;
            AROknoWyboruPlikuOdczytu.RestoreDirectory = true;
            AROknoWyboruPlikuOdczytu.InitialDirectory = "D:\\";

            if (AROknoWyboruPlikuOdczytu.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(AROknoWyboruPlikuOdczytu.FileName);
                this.Controls.Add(pictureBox1);
            }
            AROknoWyboruPlikuOdczytu.Dispose();
        }

        private void btnZapiszPlik_Click(object sender, EventArgs e)
        {
            SaveFileDialog AROknoWyboru = new SaveFileDialog();
            AROknoWyboru.Filter = "Image Files|*.jpg;*.jpeg;*.png|Allfiles(*.*.)|*.*";
            AROknoWyboru.FilterIndex = 1;
            AROknoWyboru.RestoreDirectory = true;
            AROknoWyboru.InitialDirectory = "D:\\";
            AROknoWyboru.Title = "Zapisz BitMapę";

            if (AROknoWyboru.ShowDialog() == DialogResult.OK)
            {
                int AMSzerokośćRysownicy = Convert.ToInt32(pictureBox1.Width);
                int AMWysokośćRysownicy = Convert.ToInt32(pictureBox1.Height);

                using (Bitmap AMBmap = new Bitmap(AMSzerokośćRysownicy, AMWysokośćRysownicy))
                {
                    pictureBox1.DrawToBitmap(AMBmap, new Rectangle(0, 0, AMSzerokośćRysownicy, AMWysokośćRysownicy));
                    AMBmap.Save(AROknoWyboru.FileName, ImageFormat.Jpeg);
                }
            }
        }

        private void btnWłącz_Click(object sender, EventArgs e)
        {
            ArRysownica.Clear(pictureBox1.BackColor);
            pictureBox1.Refresh();

            if (rdbAuto.Checked)
            {
                timer1.Tag = 0;
                timer1.Enabled = true;
            }

            else
            {
                textBox1.Text = 0.ToString();
                int ArN;
                ArN = int.Parse(textBox1.Text);

                int ArXmax = pictureBox1.Width;
                int ArYmax = pictureBox1.Height;

                ArLFG[ArN].PrzesuńDoNowegoXY(pictureBox1, ArRysownica, ArXmax / 2, ArYmax / 2);
                pictureBox1.Refresh();

                button3.Enabled = true;
                button4.Enabled = true;
            }

            btnWłącz.Enabled = false;
            btnWyłącz.Enabled = true;
        }

        private void btnWyłącz_Click(object sender, EventArgs e)
        {
            ArRysownica.Clear(pictureBox1.BackColor);
            timer1.Enabled = false;
            btnWyłącz.Enabled = false;
            btnWłącz.Enabled = true;

            int ArXmax = pictureBox1.Width;
            int ArYmax = pictureBox1.Height;
            int ArXn, ArYn;
            Random rnd = new Random();

            for (int i = 0; i < ArLFG.Count; i++)
            {
                ArXn = rnd.Next(ArMargines, ArXmax - ArMargines);
                ArYn = rnd.Next(ArMargines, ArYmax - ArMargines);
                ArLFG[i].PrzesuńDoNowegoXY(pictureBox1, ArRysownica, ArXn, ArYn);
            }

            pictureBox1.Refresh();
            button3.Enabled = false;
            button4.Enabled = false;
            textBox1.Enabled = false;
            rdbAuto.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ArRysownica.Clear(pictureBox1.BackColor);

            int Xmax = pictureBox1.Width;
            int Ymax = pictureBox1.Height;
            int N = int.Parse(timer1.Tag.ToString());
            ArLFG[N].PrzesuńDoNowegoXY(pictureBox1, ArRysownica, Xmax / 2, Ymax / 2);
            pictureBox1.Refresh();
            timer1.Tag = (N + 1) % (ArLFG.Count - 1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ushort N;

            if (!ushort.TryParse(textBox1.Text, out N))
            {
                errorProvider1.SetError(textBox1, "ERROR: w podanym zapisie numeru (indeksu) wystąpił niedozwolony znak");
                return;
            }

            if (N > ArLFG.Count - 1)
            {
                errorProvider1.SetError(textBox1, "ERROR: podany numer (indeks) wykracza poza zakres indeksów");
                return;
            }
        }

        private void rdbManualny_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox1.Text = 0.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ArN = int.Parse(textBox1.Text);
            ArLFG[ArN].Wymaż(pictureBox1, ArRysownica);
            pictureBox1.Refresh();
            if (ArN == ArLFG.Count - 1)
            {
                ArN = 0;
            }
            else
            {
                ArN++;

                int ArXmax = pictureBox1.Width;
                int ArYmax = pictureBox1.Height;

                ArLFG[ArN].PrzesuńDoNowegoXY(pictureBox1, ArRysownica, ArXmax / 2, ArYmax / 2);
                pictureBox1.Refresh();

                textBox1.Text = ArN.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ArN = int.Parse(textBox1.Text);
            ArLFG[ArN].Wymaż(pictureBox1, ArRysownica);

            if (ArN == 0)
            {
                ArN = ArLFG.Count - 1;
            }
            else
            {
                ArN--;
                int Xmax = pictureBox1.Width;
                int Ymax = pictureBox1.Height;

                ArLFG[ArN].PrzesuńDoNowegoXY(pictureBox1, ArRysownica, Xmax / 2, Ymax / 2);
                pictureBox1.Refresh();

                textBox1.Text = ArN.ToString();
            }
        }

        private void btnPrzesuń_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int ArXmax, ArYmax, ArXp, ArYp;
            ArRysownica.Clear(pictureBox1.BackColor);

            ArXmax = pictureBox1.Width; ArYmax = pictureBox1.Height;

            for (int i = 0; i < ArLFG.Count; i++)
            {
                ArXp = rnd.Next(ArMargines, ArXmax - ArMargines);
                ArYp = rnd.Next(ArMargines, ArYmax - ArMargines);

                if (ArLFG[i] is null)
                {
                    MessageBox.Show("ERROR");
                    return;
                }
                ArLFG[i].PrzesuńDoNowegoXY(pictureBox1, ArRysownica, ArXp, ArYp);
            }
            pictureBox1.Refresh();
        }
    }
}
