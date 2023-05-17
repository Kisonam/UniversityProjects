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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLaboratorium_Click(object sender, EventArgs e)
        {
            foreach (Form formularz in Application.OpenForms)
            {
                if (formularz.Name == "LaboratoriumNr3")
                {
                    this.Hide();
                    formularz.Show();
                    return;
                }

                this.Hide();

                LaboratoriumNr3 laboratoriumNr3 = new LaboratoriumNr3();
                laboratoriumNr3.Show();
            }
        }
    }
}
