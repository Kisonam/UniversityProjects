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
            this.Location = new Point(Screen.PrimaryScreen.Bounds.X + Margines,
                                      Screen.PrimaryScreen.Bounds.Y + Margines);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.85F);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.75F);
            this.StartPosition = FormStartPosition.Manual;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Rysownica = Graphics.FromImage(pictureBox1.Image);
        }

        private void chblFiguryGeometryczne_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            int Xmax, Ymax, Xp, Yp, Xk, Yk, OśDuża, OśMała, IndksWylosowanejFG; 
            Color Kolor, KolorWypełnienia;
            float GrubośćLinii;
            DashStyle StylLinii;
            ushort LiczbaWybranychFG;
            Random rnd = new Random();  

            LiczbaWybranychFG = ushort.Parse(txtH.Text);
            TFG = new Punkt[LiczbaWybranychFG];
            IndexTFG = 0;
            CheckedListBox.CheckedItemCollection WybraneFG = chblFiguryGeometryczne.CheckedItems;
            Xmax = pictureBox1.Width;
            Ymax = pictureBox1.Height;
            Xp = 0;
            for (int i = 1; i < LiczbaWybranychFG; i++)
            {
                Xp = rnd.Next(Margines, Xmax - Margines);
                Yp = rnd.Next(Margines, Xmax - Margines);
                Kolor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                KolorWypełnienia = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));

                switch (rnd.Next(0,5))
                {
                    case 0: StylLinii = DashStyle.Solid;
                        break; case 1:
                        StylLinii = DashStyle.Dash;
                        break; case 2:
                        StylLinii = DashStyle.Dot;
                        break; case 3:
                        StylLinii = DashStyle.DashDot;
                        break; case 4:
                        StylLinii = DashStyle.DashDotDot;
                        break;
                    default: MessageBox.Show("ERROR ");
                        break;
                }
                IndksWylosowanejFG = rnd.Next(WybraneFG.Count);
                GrubośćLinii = (float)(rnd.NextDouble() * (Margines - 1) + 1);
                switch (WybraneFG[IndksWylosowanejFG].ToString())
                {
                    case "Punkt":
                        TFG[IndexTFG] = new Punkt(Xp, Yp, Kolor);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        break;
                    case "Linia":
                        Xk = rnd.Next(Margines, Xmax - Margines);
                        Yk = rnd.Next(Margines, Ymax - Margines);
                        TFG[IndexTFG] = new Linia(Xp, Yp, Xk, Yk, Kolor);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        IndexTFG++;
                        break;
                    default:
                        break;
                }

            }
            pictureBox1.Refresh();

        }

        private void txtH_TextChanged(object sender, EventArgs e)
        {
            ushort N;
        }
    }
}
