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

        private void btnProjectowy_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
            {
                if (Formularz.Text == "Projectowy_Radovskyi61986")
                {
                    this.Hide();
                    Formularz.Show();
                    return;
                }

            }

            Projectowy_Radovskyi61986 FormularzLaboratoryjny = new Projectowy_Radovskyi61986();
            this.Hide();
            FormularzLaboratoryjny.Show();
        }

        private void FormularzStartowy_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* utworzenie okna dialogowego dla spytania Użytkownika, czy 
              na pewno chce zamknąć formularz główny*/
            DialogResult OknoMessage = MessageBox.Show("Czy na pewno chcesz zamkąć formularz główny" +
                                                        "i zakońcycz działanie programu", this.Text,
                                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button3);
            // rozpoznanie decyzji użytkownika programu
            if (OknoMessage == DialogResult.Yes)
            { // potwierdzenie zamknięcia formularza
                e.Cancel = false; // czyli nie kasujemy zdarzenia zamknięcia formularza 
                // zakończenie programu
                Application.ExitThread(); /* wyjście ze wszzystkich tzw. 
                                           'wątków' (procesów) działającej aplikacji*/
            }
            else // anulowanie zamknięcia formularza głównego 
                e.Cancel = true; // czyli kasujemy zdarzenie zamknięcia formularza
        }
    }
}
