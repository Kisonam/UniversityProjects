﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static ProjektNr3_Radovskyi61986.BryłyGeometryczne;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjektNr3_Radovskyi61986
{
    public partial class LaboratoriumNr3_Radovskyi61986 : Form
    {
        const int PromieńPunktuLok = 2;
        float KątProsty = 90.0f;
        Graphics Rysownica;
        Graphics MałąRysownica;
        float KątObrotu = 5;

        DashStyle StylLinii = DashStyle.Solid;
        Color KolorLinii = Color.OrangeRed;

        Point PunktLokalizacjiBryłu = new Point(0, 0);

        List<BryłaAbstrakcyjna> LBG = new List<BryłaAbstrakcyjna>(0);
        public LaboratoriumNr3_Radovskyi61986()
        {
            InitializeComponent();

            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            Rysownica = Graphics.FromImage(pbRysownica.Image);

            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            MałąRysownica = Graphics.FromImage(pictureBox2.Image);
        }

        private void LaboratoriumNr3_FormClosing(object sender, FormClosingEventArgs e)
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
                        case "Walec":
                            Walec walec = new Walec(PromieńBryły, WysokośćBryły, StopieńWielokątaBryły
                                                    , WspółrzędnaXpodłogiBryły,
                                                    WspółrzędnaYpodłogiBryły, KolorLinii
                                                    , StylLinii, GrubośćLinii);
                            LBG.Add(walec); LBG[LBG.Count - 1].Wykreśl(Rysownica);
                            break;
                        case "Stożek":
                            Stożek stożek = new Stożek(PromieńBryły, WysokośćBryły,
                                StopieńWielokątaBryły, 
                                WspółrzędnaXpodłogiBryły,
                                WspółrzędnaYpodłogiBryły,
                                StopieńWielokątaBryły,
                                KolorLinii, StylLinii, GrubośćLinii);
                            LBG.Add(stożek); LBG[LBG.Count - 1].Wykreśl(Rysownica);
                            break;
                        case "Kula":
                            Kula kula = new Kula(PromieńBryły, StopieńWielokątaBryły,
                                WspółrzędnaXpodłogiBryły,
                                WspółrzędnaYpodłogiBryły,
                                KolorLinii, StylLinii, GrubośćLinii);
                            LBG.Add(kula); LBG[LBG.Count - 1].Wykreśl(Rysownica);
                            break;
                        case "Graniastosłup":
                            Graniastosłup graniastosłup = new Graniastosłup(PromieńBryły, WysokośćBryły, StopieńWielokątaBryły,
                                WspółrzędnaXpodłogiBryły, WspółrzędnaYpodłogiBryły, WspółrzędnaXpodłogiBryły, WspółrzędnaYpodłogiBryły,
                                KolorLinii, StylLinii, GrubośćLinii);
                            LBG.Add(graniastosłup); LBG[LBG.Count - 1].Wykreśl(Rysownica);
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
            LBG[LBG.Count -1].Wymaż(Rysownica, pbRysownica);
            LBG.Remove(LBG[LBG.Count - 1]);
            pbRysownica.Refresh();
            Refresh();
        }

        private void btnUsuńWybranąBryłę_Click(object sender, EventArgs e)
        {
            if (LBG.Count -1 < nudNumerUsuwanejBryły.Value)
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
            for (int i = 0; i < LBG.Count ; i++)
            {
                LBG[i].PrzesuńDoNowegoXY(pbRysownica,Rysownica, rnd.Next(0, pbRysownica.Width), rnd.Next(0, pbRysownica.Height));
            }
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

        private void btnWłączSlajderPokazu_Click(object sender, EventArgs e)
        {
            MałąRysownica.Clear(pictureBox2.BackColor);
            pictureBox2.Refresh();
            txtNumerBryły.Text = 0.ToString();

                int N = int.Parse(txtNumerBryły.Text);
                int Xmax = pictureBox2.Width;
                int Ymax = pictureBox2.Height;
                LBG[N].PrzesuńDoNowegoXY(pictureBox2, MałąRysownica, Xmax / 2, Ymax / 2);
                pictureBox2.Refresh();
        }

        private void rdbPrzyciskowy_CheckedChanged(object sender, EventArgs e)
        {
            txtNumerBryły.Enabled = false;
            txtNumerBryły.Text = 0.ToString();
        }

        private void btnNastępny_Click(object sender, EventArgs e)
        {
            int N = int.Parse(txtNumerBryły.Text);
            LBG[N].Wymaż( MałąRysownica, pictureBox2);
            pictureBox2.Refresh();
            if (N == LBG.Count- 1)
            {
                N = 0;
            }
            else
            {
                N++;

                int Xmax = pictureBox2.Width;
                int Ymax = pictureBox2.Height;

                LBG[N].PrzesuńDoNowegoXY(pictureBox2, MałąRysownica, Xmax / 2, Ymax / 2);
                pictureBox2.Refresh();

                txtNumerBryły.Text = N.ToString();
            }
        }

        private void btnPoprzedni_Click(object sender, EventArgs e)
        {
            int N = int.Parse(txtNumerBryły.Text);
            LBG[N].Wymaż(MałąRysownica, pictureBox2);
            pictureBox2.Refresh();
            if (N == 0)
            {
                N = LBG.Count - 1;
            }
            else
            {
                N--;

                int Xmax = pictureBox2.Width;
                int Ymax = pictureBox2.Height;

                LBG[N].PrzesuńDoNowegoXY(pictureBox2, MałąRysownica, Xmax / 2, Ymax / 2);
                pictureBox2.Refresh();

                txtNumerBryły.Text = N.ToString();
            }
        }

        private void btnWyłączSlajderPokazu_Click(object sender, EventArgs e)
        {
            MałąRysownica.Clear(pictureBox2.BackColor);
            pictureBox2.Refresh();

            txtNumerBryły.Text = "";
            txtNumerBryły.Enabled = true;

            rdbPrzyciskowy.Checked = false;
        }
    }
}
