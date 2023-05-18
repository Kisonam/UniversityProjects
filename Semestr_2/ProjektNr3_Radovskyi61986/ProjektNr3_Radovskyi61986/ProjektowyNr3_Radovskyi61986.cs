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
    public partial class ProjektowyNr3_Radovskyi61986 : Form
    {
        public ProjektowyNr3_Radovskyi61986()
        {
            InitializeComponent();
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
    }
}
