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
    public partial class LaboratoriumNr3_Radovskyi61986 : Form
    {
        const int PromieńPunktuLok = 2;

        Graphics Rysownica;
        float KątObrotu;

        DashStyle StylLinii = DashStyle.Solid;
        Color KolorLinii = Color.OrangeRed;

        Point PunktLokalizacjiBryłu = new Point(-1, 1);

        List<BryłaAbstrakcyjna> LBG = new List<BryłaAbstrakcyjna>();
        public LaboratoriumNr3_Radovskyi61986()
        {
            InitializeComponent();

            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            Rysownica = Graphics.FromImage(pbRysownica.Image);
        }

        private void LaboratoriumNr3_FormClosing(object sender, FormClosingEventArgs e)
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
            KątObrotu = 5f;
            for (int i = 0; i < LBG.Count; i++)
            {

            }

            Refresh();
        }

        private void btnDodajNowąBrułę_Click(object sender, EventArgs e)
        {
            using (SolidBrush pędzel = new SolidBrush(pbRysownica.BackColor))
            {
                Rysownica.FillEllipse(pędzel, PunktLokalizacjiBryłu.X - PromieńPunktuLok,
                    PunktLokalizacjiBryłu.Y - PromieńPunktuLok, 2 * PromieńPunktuLok, 2 * PromieńPunktuLok);

                int WysokośćBryły = tbWysokośćFiguryGeometrycznej.Value;
                int PromieńBryły = tbWartośćPromieniu.Value;
                int GrubośćLinii = tbKątNachyleniaBryłyGeometrycznej.Value;
                int XsP = PunktLokalizacjiBryłu.X;
                int YsP = PunktLokalizacjiBryłu.Y;


                switch (comboBox1.SelectedItem)
                {
                    case "Walec":

                        break;

                    case "Stożek":
                        Stożek stożek = new Stożek(PromieńBryły, WysokośćBryły, (int)numericUpDown1.Value,PunktLokalizacjiBryłu.X,
                            PunktLokalizacjiBryłu.Y, KolorLinii, StylLinii, GrubośćLinii);
                        LBG.Add(stożek); LBG[LBG.Count - 1].Wykreśl(Rysownica);
                        break;
                    case "BryłaObrotowa":

                        break;
                    default:
                        break;
                }

                pbRysownica.Refresh();
                ZegarObrotu.Enabled = true;

                PunktLokalizacjiBryłu.X = -1; PunktLokalizacjiBryłu.Y = -1;
            }
        }
    }
}
