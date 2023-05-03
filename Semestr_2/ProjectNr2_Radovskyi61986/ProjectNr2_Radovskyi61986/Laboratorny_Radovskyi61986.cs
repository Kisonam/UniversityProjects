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
using static ProjectNr2_Radovskyi61986.FiguryGeometryczne;

namespace ProjectNr2_Radovskyi61986
{
    public partial class Laboratorny_Radovskyi61986 : Form
    {
        const int Margines = 10;

        Graphics Rysownica;
        Punkt[] TFG;
        ushort IndexTFG;

        public Laboratorny_Radovskyi61986()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Rysownica = Graphics.FromImage(pictureBox1.Image); 
        }

        private void chblFiguryGeometryczne_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            int Xmax, Ymax, 
                Xp, Yp, Xk, Yk, 
                OśDuża, OśMała, 
                IndksWylosowanejFG; 

            Color Kolor, KolorWypełnienia;
            float GrubośćLinii;
            DashStyle StylLinii;
            ushort LiczbaWybranychFG;
            Random rnd = new Random();  

            LiczbaWybranychFG = ushort.Parse(txtH.Text);
            TFG = new Punkt[LiczbaWybranychFG];

            IndexTFG = 0;

            CheckedListBox.CheckedItemCollection WybraneFG = chblFiguryGeometryczne.CheckedItems;
            Xmax = pictureBox1.Width; Ymax = pictureBox1.Height;
            
            for (int i = 1; i < LiczbaWybranychFG; i++)
            {
                Xp = rnd.Next(Margines, Xmax - Margines);
                Yp = rnd.Next(Margines, Xmax - Margines);
                Kolor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                GrubośćLinii = (float)(rnd.NextDouble() * (double)(Margines - 0.5) + 0.5);
                KolorWypełnienia = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));

                switch (rnd.Next(0,5))
                {
                    case 0: StylLinii = DashStyle.Solid;break;
                    case 1: StylLinii = DashStyle.Dash;break; 
                    case 2: StylLinii = DashStyle.Dot;break; 
                    case 3: StylLinii = DashStyle.DashDot;break; 
                    case 4: StylLinii = DashStyle.DashDotDot;break;
                    default: StylLinii = DashStyle.Solid;break;
                }
               
                switch (WybraneFG[rnd.Next(WybraneFG.Count)].ToString())
                {
                    case "Punkt":
                        TFG[IndexTFG] = new Punkt(Xp, Yp, Kolor);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        IndexTFG++;
                        break;
                    case "Linia":
                        Xk = rnd.Next(Margines, Xmax - Margines);
                        Yk = rnd.Next(Margines, Ymax - Margines);

                        TFG[IndexTFG] = new Linia(Xp, Yp, Xk, Yk, Kolor, StylLinii, GrubośćLinii);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        IndexTFG++;
                        break;
                    case "Elipsa":
                        OśDuża = rnd.Next(Margines, Xmax / 4);
                        OśMała = rnd.Next(Margines, Ymax / 6);
                        TFG[IndexTFG] = new Elipsa(Xp, Yp, OśDuża, OśMała, Kolor, StylLinii, GrubośćLinii);
                        TFG[IndexTFG].Wykreśl(Rysownica);

                        IndexTFG++;
                        break;
                    case "Okrag":
                            int Promień = rnd.Next(Margines, Xmax / 4);

                            TFG[IndexTFG] = new Okrąg(Xp, Yp, Promień, Kolor, StylLinii, GrubośćLinii);
                            TFG[IndexTFG].Wykreśl(Rysownica);

                            IndexTFG++;
                            break;
                    case "Prostokąt":
                        int Szerokość = rnd.Next(10, Margines);
                        int Wysokość = rnd.Next(10, Margines);
                        TFG[IndexTFG] = new Prostokąt(Xp, Yp, Szerokość, Wysokość, Kolor, (int)GrubośćLinii , (int)GrubośćLinii);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        IndexTFG++;
                        break;
                    case "Kwadrat":
                        OśDuża = rnd.Next(Margines, Math.Min(Xmax - Margines, Ymax - Margines));
                        TFG[IndexTFG] = new Kwadrat(Xp, Yp, OśDuża, Kolor, OśDuża,(int)GrubośćLinii);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        IndexTFG++;
                        break;
                    case "Wielokąt":
                        int liczbaWierzchołków = rnd.Next(3, 7);
                        List<Punkt> wierzchołki = new List<Punkt>();
                        for (int o = 0; o < liczbaWierzchołków; o++)
                        {
                            int x = rnd.Next(Margines, (Xmax - Margines) / 2);
                            int y = rnd.Next(Margines, (Ymax - Margines) / 2);
                            wierzchołki.Add(new Punkt(x, y));
                        }
                        TFG[IndexTFG] = new Wielokąt(wierzchołki, Kolor, GrubośćLinii, StylLinii);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        IndexTFG++;
                        break;
                    default:
                        MessageBox.Show("UWAGA: tej figury jeszcze nie wykreślam"); break;
                }

            }
            pictureBox1.Refresh();
            btnXY.Enabled = true;
        }

        private void txtH_TextChanged(object sender, EventArgs e)
        {
            ushort N;
            errorProvider1.Dispose();

            if (!ushort.TryParse(txtH.Text, out N))
            {
                errorProvider1.SetError(txtH, "ERROR: w zapisie liczby figur wystąpił błąd: niedozwolony znak");
                return;
            }

            txtH.Enabled = false;

            if (chblFiguryGeometryczne.CheckedItems.Count > 0)
            {
                button1.Enabled = true;
            }

            else
            {
                errorProvider1.SetError(chblFiguryGeometryczne, "UWAGA: musisz zaznaczyć (wybrać) co najmniej jedna figurę geometryczną");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int Xmax, Ymax, Xp, Yp;
            Rysownica.Clear(pictureBox1.BackColor);

            Xmax = pictureBox1.Width; Ymax = pictureBox1.Height;

            for (int i = 0; i < TFG.Length; i++)
            {
                Xp = rnd.Next(Margines, Xmax - Margines);
                Yp = rnd.Next(Margines, Ymax - Margines);

                if (TFG[i] is null)
                {
                    MessageBox.Show("ERROR");
                    return;
                }
                TFG[i].PrzesuńDoNowegoXY(pictureBox1,Rysownica, Xp, Yp);
            }
            pictureBox1.Refresh();
        }

        private void rdbManualny_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox1.Text = 0.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Rysownica.Clear(pictureBox1.BackColor);

            int Xmax = pictureBox1.Width;
            int Ymax = pictureBox1.Height;
            int N = int.Parse(timer1.Tag.ToString());
            TFG[N].PrzesuńDoNowegoXY(pictureBox1,Rysownica, Xmax / 2, Ymax /2);
            pictureBox1.Refresh();
            timer1.Tag = (N + 1) % (TFG.Length - 1);

            //if (int.Parse(timer1.Tag.ToString()) == TFG.Length - 1)
            //{
            //    timer1.Tag = 0;
            //}
            //else timer1.Tag = (int)timer1.Tag + 1;
        }

        private void btnWłącz_Click(object sender, EventArgs e)
        {
            Rysownica.Clear(pictureBox1.BackColor);
            pictureBox1.Refresh();

            if (rdbAuto.Checked)
            {
                timer1.Tag = 0;
                timer1.Enabled = true;
            }

            else
            {
                textBox1.Text = 0.ToString();
                int N;  
                N = int.Parse(textBox1.Text);

                int Xmax = pictureBox1.Width;
                int Ymax = pictureBox1.Height;
                    
                TFG[N].PrzesuńDoNowegoXY(pictureBox1, Rysownica, Xmax / 2, Ymax / 2);
                pictureBox1.Refresh();

                button3.Enabled = true;
                button4.Enabled = true;
            }

            btnWłącz.Enabled = false;
            btnWyłącz.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ushort N;

            if (!ushort.TryParse(textBox1.Text, out N))
            {
                errorProvider1.SetError(textBox1, "ERROR: w podanym zapisie numeru (indeksu) wystąpił niedozwolony znak");
                return;
            }

            if (N > TFG.Length - 1)
            {
                errorProvider1.SetError(textBox1, "ERROR: podany numer (indeks) wykracza poza zakres indeksów");
                return;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int N = int.Parse(textBox1.Text);
            TFG[N].Wymaż(pictureBox1, Rysownica);
            pictureBox1.Refresh();
            if (N == TFG.Length - 1)
            {
                N = 0;
            }
            else
            {
                N++;

                int Xmax = pictureBox1.Width;
                int Ymax = pictureBox1.Height;

                TFG[N].PrzesuńDoNowegoXY(pictureBox1, Rysownica, Xmax / 2, Ymax / 2);
                pictureBox1.Refresh();

                textBox1.Text = N.ToString();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int N = int.Parse(textBox1.Text);
            TFG[N].Wymaż(pictureBox1, Rysownica);

            if (N == 0)
            {
                N = TFG.Length - 1;
            }
            else
            {
                N--;
                int Xmax = pictureBox1.Width;
                int Ymax = pictureBox1.Height;

                TFG[N].PrzesuńDoNowegoXY(pictureBox1, Rysownica, Xmax / 2, Ymax / 2);
                pictureBox1.Refresh();

                textBox1.Text = N.ToString();
            }
        }

        private void btnWyłącz_Click(object sender, EventArgs e)
        {
            Rysownica.Clear(pictureBox1.BackColor);
            timer1.Enabled = false;
            btnWyłącz.Enabled = false;
            btnWłącz.Enabled = true;

            int Xmax = pictureBox1.Width;
            int Ymax = pictureBox1.Height;
            int Xn, Yn;
            Random rnd = new Random();

            for (int i = 0; i < TFG.Length; i++)
            {
                Xn = rnd.Next(Margines, Xmax - Margines);
                Yn = rnd.Next(Margines, Ymax - Margines);
                TFG[i].PrzesuńDoNowegoXY(pictureBox1, Rysownica, Xn, Yn);
            }

            pictureBox1.Refresh();
            button3.Enabled = false;
            button4.Enabled = false;
            textBox1.Enabled = false;
            rdbAuto.Enabled = false;
        }

        private void btnPrzesuńIZmiana_Click(object sender, EventArgs e)
        {

        }

        private void btnKolorLinii_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog.Color;
            }
            colorDialog.Dispose();
        }

        private void Laboratorny_Radovskyi61986_FormClosing(object sender, FormClosingEventArgs e)
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
            Kokpit_Radovskyi61986 Kokpit = new Kokpit_Radovskyi61986();
            Kokpit.Show();
            this.Hide();
        }

        private void rdbAuto_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
