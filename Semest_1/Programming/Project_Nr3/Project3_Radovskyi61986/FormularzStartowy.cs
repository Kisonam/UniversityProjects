using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3_Radovskyi61986
{
    public partial class FormularzStartowy : Form
    {
        public FormularzStartowy()
        {
            InitializeComponent();
        }

        private void btnLaboratoryjny_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
            {
                if (Formularz.Text == "Laboratoryjny_Radovskyi61986")
                {
                    this.Hide();
                    Formularz.Show();
                    return;
                }

            }

            Laboratoryjny_Radovskyi61986 FormularzLaboratoryjny = new Laboratoryjny_Radovskyi61986();
            this.Hide();
            FormularzLaboratoryjny.Show();
        }
    }
}
