using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProjectNr2_Radovskyi61986.FiguryGeometryczne;

namespace ProjectNr2_Radovskyi61986
{
    public partial class Laboratorny_Radovskyi61986 : Form
    {
        const int Margines = 10;

        Graphics Rysownica;
        Punkt[] TFG;
        ushort IndexTFG;

        public Laboratorny_Radovskyi61986()
        {
            InitializeComponent();
            this.Location = new Point(Screen.PrimaryScreen.Bounds.X + Margines,
                                      Screen.PrimaryScreen.Bounds.Y + Margines);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0,85f);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0,85f);
        }
    }
}
