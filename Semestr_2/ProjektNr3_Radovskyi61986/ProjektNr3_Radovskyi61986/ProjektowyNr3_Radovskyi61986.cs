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
using static ProjektNr3_Radovskyi61986.BryłyGeometryczne;

namespace ProjektNr3_Radovskyi61986
{
    public partial class ProjektowyNr3_Radovskyi61986 : Form
    {
        const int arPromieńPunktuLok = 2;
        float arKątProsty = 90.0f;
        Graphics arRysownica;
        Graphics arMałąRysownica;
        float arKątObrotu = 5;

        DashStyle arStylLinii = DashStyle.Solid;
        Color arKolorLinii = Color.OrangeRed;

        Point arPunktLokalizacjiBryłu = new Point(0, 0);

        List<BryłaAbstrakcyjna> arLBG = new List<BryłaAbstrakcyjna>(0);
        public ProjektowyNr3_Radovskyi61986()
        {
            InitializeComponent();
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            arRysownica = Graphics.FromImage(pbRysownica.Image);

            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            arMałąRysownica = Graphics.FromImage(pictureBox2.Image);
        }

        private void ProjektowyNr3_Radovskyi61986_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult arOknoMessage = MessageBox.Show("Samoocena: 4 - za część laboratoryjną. 3 - dla indywidualnych. " +
                "W laboratorium wykonałem większość pracy, wszystkie kształty są narysowane, wszystko działa oprócz kuli. " +
                "Indywidualnie rysuję wszystkie figury, tylko jedna działa. Drugi działa, ale pojawia się za deską kreślarską. " +
                "Myślę, że ta praca zasługuje na co najmniej 3", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

            if (arOknoMessage == DialogResult.Yes)
            {
                e.Cancel = false;

                foreach (Form formularz in Application.OpenForms)
                {
                    if (formularz.Name == "Kokpit")
                    {
                        this.Hide();
                        formularz.Show();
                        return;
                    }


                }
                this.Hide();

                Kokpit kokpit = new Kokpit();
                kokpit.Show();

            }
            else
                e.Cancel = true;
        }

        private void ZegarObrotu_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < arLBG.Count; i++)
                arLBG[i].Obróć_i_Wykreś(pbRysownica, arRysownica, arKątObrotu);

            Refresh();
        }

        private void btnDodajNowąBrułę_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (arPunktLokalizacjiBryłu.X == -1)
            {
                errorProvider1.SetError(btnDodajNowąBrułę, "Error");
                return;
            }
            else
            {
                using (SolidBrush arPędzel = new SolidBrush(pbRysownica.BackColor))
                {
                    Random arrnd = new Random();
                    arRysownica.FillEllipse(arPędzel, arPunktLokalizacjiBryłu.X - arPromieńPunktuLok,
                        arPunktLokalizacjiBryłu.Y - arPromieńPunktuLok,
                        2 * arPromieńPunktuLok, 2 * arPromieńPunktuLok);

                    int arWysokośćBryły = tbWysokośćFiguryGeometrycznej.Value;
                    int arPromieńBryły = tbWartośćPromieniu.Value;
                    int arStopieńWielokątaBryły = (int)numericUpDown1.Value;
                    float arKątPochyleniaBryły = arKątProsty;
                    int arGrubośćLinii = 3;
                    int arWspółrzędnaXpodłogiBryły = arPunktLokalizacjiBryłu.X;
                    int arWspółrzędnaYpodłogiBryły = arPunktLokalizacjiBryłu.Y;

                    switch (cmbStylLinii.SelectedIndex)
                    {
                        case 0: arStylLinii = DashStyle.Solid; break;
                        case 1: arStylLinii = DashStyle.Dash; break;
                        case 2: arStylLinii = DashStyle.Dot; break;
                        case 3: arStylLinii = DashStyle.DashDot; break;
                        case 4: arStylLinii = DashStyle.DashDotDot; break;
                        default: arStylLinii = DashStyle.Solid; break;
                    }

                    switch (comboBox1.SelectedItem)
                    {
                        case "Graniastosłup":
                            Graniastosłup argraniastosłup = new Graniastosłup(arPromieńBryły, arWysokośćBryły, arStopieńWielokątaBryły,
                                arWspółrzędnaXpodłogiBryły, arWspółrzędnaYpodłogiBryły, arWspółrzędnaXpodłogiBryły, arWspółrzędnaYpodłogiBryły,
                                arKolorLinii, arStylLinii, arGrubośćLinii);
                            arLBG.Add(argraniastosłup); arLBG[arLBG.Count - 1].Wykreśl(arRysownica);
                            break;
                        case "GraniastosłupPochyły":
                            GraniastosłupPochyły argraniastosłupPochyły = new GraniastosłupPochyły(arPromieńBryły, arWysokośćBryły, arStopieńWielokątaBryły,
                                 arrnd.Next(0, pbRysownica.Width), arrnd.Next(0, pbRysownica.Height), arrnd.Next(0, pbRysownica.Width), arrnd.Next(0, pbRysownica.Height),
                                arKolorLinii, arStylLinii, arGrubośćLinii, arKątPochyleniaBryły);
                            arLBG.Add(argraniastosłupPochyły); arLBG[arLBG.Count - 1].Wykreśl(arRysownica);
                            break;
                        case "Ostrosłup":
                            OstrosłupProsty arostrosłup = new OstrosłupProsty(arPromieńBryły,arWysokośćBryły);
                            arostrosłup.Narysuj(arRysownica, pbRysownica,arWspółrzędnaXpodłogiBryły ,arWspółrzędnaYpodłogiBryły);
                            break;
                        default:
                            break;
                    }

                    pbRysownica.Refresh();
                    ZegarObrotu.Enabled = true;
                }
            }
        }

        private void pbRysownica_MouseClick(object sender, MouseEventArgs e)
        {
            if (arPunktLokalizacjiBryłu.X != -1)
            {
                using (SolidBrush arPędzel = new SolidBrush(pbRysownica.BackColor))
                {
                    arRysownica.FillEllipse(arPędzel, arPunktLokalizacjiBryłu.X - arPromieńPunktuLok,
                                            arPunktLokalizacjiBryłu.Y - arPromieńPunktuLok,
                                            2 * arPromieńPunktuLok,
                                            2 * arPromieńPunktuLok);

                    arPunktLokalizacjiBryłu = new Point(e.Location.X, e.Location.Y);

                    arRysownica.FillEllipse(Brushes.Red, arPunktLokalizacjiBryłu.X - arPromieńPunktuLok,
                                          arPunktLokalizacjiBryłu.Y - arPromieńPunktuLok,
                                          2 * arPromieńPunktuLok,
                                          2 * arPromieńPunktuLok);

                }

            }
            pbRysownica.Refresh();
        }

        private void btnKierunekPrawo_Click(object sender, EventArgs e)
        {
            arKątObrotu = -10;
        }

        private void btnKierunekLewo_Click(object sender, EventArgs e)
        {
            arKątObrotu = 10;
        }

        private void btnUstawNoweAtrybuty_Click(object sender, EventArgs e)
        {
            ColorDialog arcolorDialog = new ColorDialog();

            if (arcolorDialog.ShowDialog() == DialogResult.OK)
                arKolorLinii = arcolorDialog.Color;

            arcolorDialog.Dispose();
        }

        private void btnUsuńPierwsząDodanąBryłę_Click(object sender, EventArgs e)
        {
            if (arLBG.Count <= 0)
                return;
            arLBG[0].Wymaż(arRysownica, pbRysownica);
            arLBG.Remove(arLBG[0]);
            pbRysownica.Refresh();
            Refresh();
        }

        private void btnUsuńOstatniąDodanąBryłę_Click(object sender, EventArgs e)
        {
            if (arLBG.Count <= 0)
                return;
            arLBG[arLBG.Count - 1].Wymaż(arRysownica, pbRysownica);
            arLBG.Remove(arLBG[arLBG.Count - 1]);
            pbRysownica.Refresh();
            Refresh();
        }

        private void btnUsuńWybranąBryłę_Click(object sender, EventArgs e)
        {
            if (arLBG.Count - 1 < nudNumerUsuwanejBryły.Value)
                return;
            arLBG[(int)nudNumerUsuwanejBryły.Value].Wymaż(arRysownica, pbRysownica);
            arLBG.Remove(arLBG[(int)nudNumerUsuwanejBryły.Value]);
            pbRysownica.Refresh();
            Refresh();
        }

        private void btnWylosujNowePołożenie_Click(object sender, EventArgs e)
        {
            if (arLBG.Count <= 0)
                return;
            Random arrnd = new Random();
            for (int i = 0; i < arLBG.Count; i++)
            {
                arLBG[i].PrzesuńDoNowegoXY(pbRysownica, arRysownica, arrnd.Next(0, pbRysownica.Width), arrnd.Next(0, pbRysownica.Height));
            }
        }

        private void btnWłączSlajderPokazu_Click(object sender, EventArgs e)
        {
            arMałąRysownica.Clear(pictureBox2.BackColor);
            pictureBox2.Refresh();
            txtNumerBryły.Text = 0.ToString();

            int arN = int.Parse(txtNumerBryły.Text);
            int arXmax = pictureBox2.Width;
            int arYmax = pictureBox2.Height;
            arLBG[arN].PrzesuńDoNowegoXY(pictureBox2, arMałąRysownica, arXmax / 2, arYmax / 2);
            pictureBox2.Refresh();
        }

        private void btnNastępny_Click(object sender, EventArgs e)
        {
            int arN = int.Parse(txtNumerBryły.Text);
            arLBG[arN].Wymaż(arMałąRysownica, pictureBox2);
            pictureBox2.Refresh();
            if (arN == arLBG.Count - 1)
            {
                arN = 0;
            }
            else
            {
                arN++;

                int Xmax = pictureBox2.Width;
                int Ymax = pictureBox2.Height;

                arLBG[arN].PrzesuńDoNowegoXY(pictureBox2, arMałąRysownica, Xmax / 2, Ymax / 2);
                pictureBox2.Refresh();

                txtNumerBryły.Text = arN.ToString();
            }
        }

        private void btnPoprzedni_Click(object sender, EventArgs e)
        {
            int arN = int.Parse(txtNumerBryły.Text);
            arLBG[arN].Wymaż(arMałąRysownica, pictureBox2);
            pictureBox2.Refresh();
            if (arN == 0)
            {
                arN = arLBG.Count - 1;
            }
            else
            {
                arN--;

                int Xmax = pictureBox2.Width;
                int Ymax = pictureBox2.Height;

                arLBG[arN].PrzesuńDoNowegoXY(pictureBox2, arMałąRysownica, Xmax / 2, Ymax / 2);
                pictureBox2.Refresh();

                txtNumerBryły.Text = arN.ToString();
            }
        }

        private void btnWyłączSlajderPokazu_Click(object sender, EventArgs e)
        {
            arMałąRysownica.Clear(pictureBox2.BackColor);
            pictureBox2.Refresh();

            txtNumerBryły.Text = "";
            txtNumerBryły.Enabled = true;

            rdbPrzyciskowy.Checked = false;
        }

        private void rdbPrzyciskowy_CheckedChanged(object sender, EventArgs e)
        {
            txtNumerBryły.Enabled = false;
            txtNumerBryły.Text = 0.ToString();
        }
    }
}
