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
        const int PromieńPunktuLok = 2;
        float KątProsty = 90.0f;
        Graphics Rysownica;
        float KątObrotu = 5;

        DashStyle StylLinii = DashStyle.Solid;
        Color KolorLinii = Color.OrangeRed;

        Point PunktLokalizacjiBryłu = new Point(0, 0);

        List<BryłaAbstrakcyjna> LBG = new List<BryłaAbstrakcyjna>(0);
        public ProjektowyNr3_Radovskyi61986()
        {
            InitializeComponent();
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            Rysownica = Graphics.FromImage(pbRysownica.Image);
        }

        private void ProjektowyNr3_Radovskyi61986_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private void ZegarObrotu_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < LBG.Count; i++)
                LBG[i].Obróć_i_Wykreś(pbRysownica, Rysownica, KątObrotu);

            Refresh();
        }

        private void btnDodajNowąBrułę_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();

            if (PunktLokalizacjiBryłu.X == -1)
            {
                errorProvider1.SetError(btnDodajNowąBrułę, "Error");
                return;
            }
            else
            {
                using (SolidBrush Pędzel = new SolidBrush(pbRysownica.BackColor))
                {
                    Random rnd = new Random();
                    Rysownica.FillEllipse(Pędzel, PunktLokalizacjiBryłu.X - PromieńPunktuLok,
                        PunktLokalizacjiBryłu.Y - PromieńPunktuLok,
                        2 * PromieńPunktuLok, 2 * PromieńPunktuLok);

                    int WysokośćBryły = tbWysokośćFiguryGeometrycznej.Value;
                    int PromieńBryły = tbWartośćPromieniu.Value;
                    int StopieńWielokątaBryły = (int)numericUpDown1.Value;
                    float KątPochyleniaBryły = KątProsty;
                    int GrubośćLinii = 3;
                    int WspółrzędnaXpodłogiBryły = PunktLokalizacjiBryłu.X;
                    int WspółrzędnaYpodłogiBryły = PunktLokalizacjiBryłu.Y;

                    switch (cmbStylLinii.SelectedIndex)
                    {
                        case 0: StylLinii = DashStyle.Solid; break;
                        case 1: StylLinii = DashStyle.Dash; break;
                        case 2: StylLinii = DashStyle.Dot; break;
                        case 3: StylLinii = DashStyle.DashDot; break;
                        case 4: StylLinii = DashStyle.DashDotDot; break;
                        default: StylLinii = DashStyle.Solid; break;
                    }

                    switch (comboBox1.SelectedItem)
                    {
                        case "Graniastosłup":
                            Graniastosłup graniastosłup = new Graniastosłup(PromieńBryły, WysokośćBryły, StopieńWielokątaBryły,
                                WspółrzędnaXpodłogiBryły, WspółrzędnaYpodłogiBryły, WspółrzędnaXpodłogiBryły, WspółrzędnaYpodłogiBryły,
                                KolorLinii, StylLinii, GrubośćLinii);
                            LBG.Add(graniastosłup); LBG[LBG.Count - 1].Wykreśl(Rysownica);
                            break;
                        case "GraniastosłupPochyły":
                            GraniastosłupPochyły graniastosłupPochyły = new GraniastosłupPochyły(PromieńBryły, WysokośćBryły, StopieńWielokątaBryły,
                                 rnd.Next(0, pbRysownica.Width), rnd.Next(0, pbRysownica.Height), rnd.Next(0, pbRysownica.Width), rnd.Next(0, pbRysownica.Height),
                                KolorLinii, StylLinii, GrubośćLinii, KątPochyleniaBryły);
                            LBG.Add(graniastosłupPochyły); LBG[LBG.Count - 1].Wykreśl(Rysownica);
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
            if (PunktLokalizacjiBryłu.X != -1)
            {
                using (SolidBrush Pędzel = new SolidBrush(pbRysownica.BackColor))
                {
                    Rysownica.FillEllipse(Pędzel, PunktLokalizacjiBryłu.X - PromieńPunktuLok,
                                            PunktLokalizacjiBryłu.Y - PromieńPunktuLok,
                                            2 * PromieńPunktuLok,
                                            2 * PromieńPunktuLok);

                    PunktLokalizacjiBryłu = new Point(e.Location.X, e.Location.Y);

                    Rysownica.FillEllipse(Brushes.Red, PunktLokalizacjiBryłu.X - PromieńPunktuLok,
                                          PunktLokalizacjiBryłu.Y - PromieńPunktuLok,
                                          2 * PromieńPunktuLok,
                                          2 * PromieńPunktuLok);

                }

            }
            pbRysownica.Refresh();
        }

        private void btnKierunekPrawo_Click(object sender, EventArgs e)
        {
            KątObrotu = -10;
        }

        private void btnKierunekLewo_Click(object sender, EventArgs e)
        {
            KątObrotu = 10;
        }

        private void btnUstawNoweAtrybuty_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
                KolorLinii = colorDialog.Color;

            colorDialog.Dispose();
        }

        private void btnUsuńPierwsząDodanąBryłę_Click(object sender, EventArgs e)
        {
            if (LBG.Count <= 0)
                return;
            LBG[0].Wymaż(Rysownica, pbRysownica);
            LBG.Remove(LBG[0]);
            pbRysownica.Refresh();
            Refresh();
        }

        private void btnUsuńOstatniąDodanąBryłę_Click(object sender, EventArgs e)
        {
            if (LBG.Count <= 0)
                return;
            LBG[LBG.Count - 1].Wymaż(Rysownica, pbRysownica);
            LBG.Remove(LBG[LBG.Count - 1]);
            pbRysownica.Refresh();
            Refresh();
        }

        private void btnUsuńWybranąBryłę_Click(object sender, EventArgs e)
        {
            if (LBG.Count - 1 < nudNumerUsuwanejBryły.Value)
                return;
            LBG[(int)nudNumerUsuwanejBryły.Value].Wymaż(Rysownica, pbRysownica);
            LBG.Remove(LBG[(int)nudNumerUsuwanejBryły.Value]);
            pbRysownica.Refresh();
            Refresh();
        }

        private void btnWylosujNowePołożenie_Click(object sender, EventArgs e)
        {
            if (LBG.Count <= 0)
                return;
            Random rnd = new Random();
            for (int i = 0; i < LBG.Count; i++)
            {
                LBG[i].PrzesuńDoNowegoXY(pbRysownica, Rysownica, rnd.Next(0, pbRysownica.Width), rnd.Next(0, pbRysownica.Height));
            }
        }
    }
}
