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
    public partial class Kokpit_Radovskyi61986 : Form
    {
        public Kokpit_Radovskyi61986()
        {
            InitializeComponent();
        }
        
        private void LaboratoriumNr1_Click(object sender, EventArgs e)
        {
            //
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
            LoboratoriumNr1_Raovskyi61986 Laboratorium = new LoboratoriumNr1_Raovskyi61986();
            Laboratorium.Show();
            this.Hide();
        }

        private void Kokpit_Radovskyi61986_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }   

        private void Kokpit_Radovskyi61986_Load(object sender, EventArgs e)
        {

        }
    }
}
