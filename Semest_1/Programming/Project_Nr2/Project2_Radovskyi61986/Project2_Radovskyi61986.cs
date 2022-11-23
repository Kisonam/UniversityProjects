using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2_№№№№
{
    public partial class Project2_№№№№ : Form
    {
        public Project2_№№№№() // konstruktor klasy 
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Laboratoryjny
        {
            /* sprawdzenie i otszukanie w kolekcji OpenForms, czy zawiera on referencję
               egzemplarza formularza: 'SzeregLaboratoryjny' */
            foreach (Form Formularz in Application.OpenForms)
            {// sprawdzenie, czy jest to formularz 'SzeregLaboratoryjny'
                if(Formularz.Name == "SzeregLab")
                {
                    this.Hide(); //autorefrencja this "pokazuje" bieżący formularz
                    //odsłonięcie formularza znalerzenego
                    Formularz.Show();
                    /* wyjcze z metody obsługi zdarzenia Click dla przycisku poleceń
                       BtnLab*/
                    return;
                }
                /* gdy jesteśmy "tutaj" to jest to "znak" że  egzemplara formularza 
                 SzeregLaboratoryjny nie był jeście utworzony*/
                SzeregLab AnalizatorSzeregu = new SzeregLab();
                this.Hide();

                AnalizatorSzeregu.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
