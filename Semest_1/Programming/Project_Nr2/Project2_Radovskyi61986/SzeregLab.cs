using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2_Radovskyi61986
{
    public partial class SzeregLab : Form
    {
        public SzeregLab()
        {
            InitializeComponent();
        }

        private void SzeregLab_FormClosing(object sender, EventArgs e)
        {
            DialogResult OlnoMassage = MessageBox.Show("Czy rzechywicie chcesz zakąć ten " +
                "formularz i powrócić do formularza głuwnego", this.Text,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            // rozpoznanie decyzji użytkownika programu
//             if (OlnoMassage == DialogResult.Yes)    ---Wrong!---
//             {
//                 e.Cancel = true;

//                 foreach (Form Formukaez in Application.OpenForms)
//                 {
//                     if (Formukaez.Name == "Project2_Radovskyi61986")
//                     {
//                         this.Hide();

//                         Formukaez.Show();

//                         return;
//                     }
//                     Project2_Radovskyi61986 FormularzPr = new Project2_Radovskyi61986();
//                     this.Hide();
//                     FormularzPr.Show();
//                 }
//             }
//             else
//                 e.Cancle = false;
        }
    }
}
