using System;
using System.Windows.Forms;

namespace ProjectNr2_Radovskyi61986
{
    public partial class ProjectNr2_Radovskyi61986 : Form
    {
        public ProjectNr2_Radovskyi61986()
        {
            InitializeComponent();
        }

        private void BtnSheregLaboratoryjny_Click(object sender, EventArgs e)
        {
            /* sprawdzenie, czy w kolekcji OpenForms jest już egzemplarza
             formularza SzeregLaboratoryjny */
            foreach (Form Formularz in Application.OpenForms)
            { /* sprawdzenie czy zidentyfikowany formularz w kolekcji 
               OpenForms jest egzemplarzem formularza SzeregLaboratoryjnego*/
                if (Formularz.Name == "SzeregLaboratoryjny")
                {// ukrycie bieżącego formularza, którego referencję udostępnia autoreferencja: this
                    this.Hide(); /* można też opuściś autorefencję: this,
                                  czyli ukrycie bieżącego formularza można
                                  zapisać tak: Hide(); */
                    // odsłonięcie formularza SzeregLaboratoryjny
                    Formularz.Show();
                    // zakończenie (wyjście z) obsługi zdarzenia Click dla przycisku poleceń BtnSheregLaboratoryjny
                    return;
                }
            }
            /* gdy "będziemy tutaj", to będzie to oznaczało, że 
               formularz SzeregLaboratoryjny nie był jeszcze utworzony, 
               to go tworzymy i odsłaniamy */
            SzeregLaboratoryjny AnalizatorSzeregu = new SzeregLaboratoryjny();
            // odsłonięcie nowego formularza
            AnalizatorSzeregu.Show();
            // ukrycie bieżącego formularza, czyli formularza głównego
            this.Hide();
        }

        private void ProjectNr2_Radovskyi61986_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void ProjectNr2_Radovskyi61986_FormClosing(object sender, FormClosingEventArgs e)
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

        private void ProjectNr2_Radovskyi61986_Load(object sender, EventArgs e)
        {

        }

        private void ProjectBtn_Click(object sender, EventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
            { /* sprawdzenie czy zidentyfikowany formularz w kolekcji 
               OpenForms jest egzemplarzem formularza SzeregLaboratoryjnego*/
                if (Formularz.Name == "SzeregProjectowy")
                {// ukrycie bieżącego formularza, którego referencję udostępnia autoreferencja: this
                    this.Hide(); /* można też opuściś autorefencję: this,
                                  czyli ukrycie bieżącego formularza można
                                  zapisać tak: Hide(); */
                    // odsłonięcie formularza SzeregLaboratoryjny
                    Formularz.Show();
                    // zakończenie (wyjście z) obsługi zdarzenia Click dla przycisku poleceń BtnSheregLaboratoryjny
                    return;
                }
            }

            SzeregProjectowy AnalizatorSzeregu = new SzeregProjectowy();
            AnalizatorSzeregu.Show();
            this.Hide();
        }
    }
}
