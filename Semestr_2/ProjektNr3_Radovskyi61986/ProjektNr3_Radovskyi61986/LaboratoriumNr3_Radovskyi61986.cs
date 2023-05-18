using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr3_Radovskyi61986
{
    public partial class LaboratoriumNr3_Radovskyi61986 : Form
    {
        const int Margines = 10;

        Graphics Rysownica;
        float KątObrotu;
        BryłyGeometryczne[] LBG;

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
            //for (int i = 0; i < LBG.Count; i++)
            //{
                
            //}

            Refresh();
        }
    }
}
