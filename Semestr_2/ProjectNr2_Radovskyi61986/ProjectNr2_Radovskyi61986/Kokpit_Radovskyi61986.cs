using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectNr2_Radovskyi61986
{
    public partial class Kokpit_Radovskyi61986 : Form
    {
        public Kokpit_Radovskyi61986()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Kokpit_Radovskyi61986_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
            {
                // sprwdzenie,czy to jest formularz LaboratoriumNr1
                if (Formularz.Name == "Laboratorny_Radovskyi61986")
                { // ukrycie bieżącego (to będzie główny) formularza
                    this.Hide();
                    // odsłonięcie formularza znalezionego
                    Formularz.Show();
                    // bezwarunkowe zakończenie obsługi zdarzenia Click
                    return;
                }
            }
            Laboratorny_Radovskyi61986 Laboratorium = new Laboratorny_Radovskyi61986();
            Laboratorium.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* sprawdzanie, czy był już utworzony egzemolarza formularza
             LaboratoriumNr1*/
            foreach (Form Formularz in Application.OpenForms)
            {
                // sprwdzenie,czy to jest formularz LaboratoriumNr1
                if (Formularz.Name == "Projectowy_Radovskyi61986")
                { // ukrycie bieżącego (to będzie główny) formularza
                    this.Hide();
                    // odsłonięcie formularza znalezionego
                    Formularz.Show();
                    // bezwarunkowe zakończenie obsługi zdarzenia Click
                    return;
                }
            }
            Projectowy_Radovskyi61986 Project = new Projectowy_Radovskyi61986();
            Project.Show();
            this.Hide();
        }
    }
}
