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
            /* sprawdzanie, czy był już utworzony egzemolarza formularza
             LaboratoriumNr1*/
            foreach (Form Formularz in Application.OpenForms)
            {
                // sprwdzenie,czy to jest formularz LaboratoriumNr1
                if (Formularz.Name == "LaboratoriumNr1")
                { // ukrycie bieżącego (to będzie główny) formularza
                    this.Hide();
                    // odsłonięcie formularza znalezionego
                    Formularz.Show();
                    // bezwarunkowe zakończenie obsługi zdarzenia Click
                    return;
                }
            }
            LoboratoriumNr1_Raovskyi61986 Laboratorium = new LoboratoriumNr1_Raovskyi61986();
            Laboratorium.Show();
            this.Hide();
        }

        private void Kokpit_Radovskyi61986_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult OknoMessage = MessageBox.Show("Czy na pewno" +
                " chcesz zamknąć formularz główny, co spowoduje również zakończenie " +
                "działania programu", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // rozpoznawanie decyzji Użytkownika programu
            if (OknoMessage == DialogResult.Yes)
            {
                foreach (Form Formularz in Application.OpenForms)
                {
                    // sprwdzenie,czy to jest formularz LaboratoriumNr1
                    if (Formularz.Name == "LaboratoriumNr1")
                    { // ukrycie bieżącego (to będzie główny) formularza
                        this.Hide();
                        // odsłonięcie formularza znalezionego
                        Formularz.Show();
                        // bezwarunkowe zakończenie obsługi zdarzenia Click
                        return;
                    }
                }

                MessageBox.Show("AWARIA: niespdziełanie został usunięty egzemplarz " +
                    "formularza głównego przez 'kogoś' i program musi zostać " +
                    "zamknięty! Przykro nam!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.ExitThread();
            }
            else
                e.Cancel= true;
        }   

        private void Kokpit_Radovskyi61986_Load(object sender, EventArgs e)
        {

        }
    }
}
