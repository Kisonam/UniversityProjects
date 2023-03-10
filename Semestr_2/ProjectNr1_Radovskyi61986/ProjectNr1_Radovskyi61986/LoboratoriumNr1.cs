using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectNr1_Radovskyi61986
{
    public partial class LoboratoriumNr1_Raovskyi61986 : Form
    {
        public LoboratoriumNr1_Raovskyi61986()
        {
            InitializeComponent();
        }

        private void LoboratoriumNr1_Raovskyi61986_Load(object sender, EventArgs e)
        {

        }

        private void LoboratoriumNr1_Raovskyi61986_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
            {
                if (Formularz.Name == "LaboratoriumNr1")
                {
                    this.Hide();
                    //
                    Formularz.Show();
                    //
                    return;
                }
            }
            Kokpit_Radovskyi61986 Laboratorium = new Kokpit_Radovskyi61986();
            Laboratorium.Show();
            this.Hide();
        }
    }
}
