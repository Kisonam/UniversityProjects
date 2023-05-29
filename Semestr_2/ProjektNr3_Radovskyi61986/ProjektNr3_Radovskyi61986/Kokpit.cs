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
    public partial class Kokpit : Form
    {
        public Kokpit()
        {
            InitializeComponent();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult arOknoMessage = MessageBox.Show("Samoocena: 4 - za część laboratoryjną. 3 - dla indywidualnych. " +
                 "W laboratorium wykonałem większość pracy, wszystkie kształty są narysowane, wszystko działa oprócz kuli. " +
                 "Indywidualnie rysuję wszystkie figury, tylko jedna działa. Drugi działa, ale pojawia się za deską kreślarską. " +
                 "Myślę, że ta praca zasługuje na co najmniej 3", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

            if (arOknoMessage == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }
        private void btnLaboratorium_Click(object sender, EventArgs e)
        {
            foreach (Form formularz in Application.OpenForms)
            {
                if (formularz.Name == "LaboratoriumNr3_Radovskyi61986")
                {
                    this.Hide();
                    formularz.Show();
                    return;
                }
            }
            this.Hide();

            LaboratoriumNr3_Radovskyi61986 laboratoriumNr3 = new LaboratoriumNr3_Radovskyi61986();
            laboratoriumNr3.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Form formularz in Application.OpenForms)
            {
                if (formularz.Name == "ProjektowyNr3_Radovskyi61986")
                {
                    this.Hide();
                    formularz.Show();
                    return;
                }
            }
            this.Hide();

            ProjektowyNr3_Radovskyi61986 projektowyNr3 = new ProjektowyNr3_Radovskyi61986();
            projektowyNr3.Show();
        }
    }
}
