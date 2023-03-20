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
    public partial class LoboratoriumNr1_Raovskyi61986 : Form
    {
        const int Margines = 10;
        const int PromienObiekty = 5;
        // deklaracje pomocnicza
        static LoboratoriumNr1_Raovskyi61986 UchwytFormularza;
        float Xd, Xg;
        //
        float[,] TWS = null;
        int IndexPOA;
        int MaxIndexPOA;
        Graphics Rysownica;
        Pen PióroXY;
        Pen PioroLiniiToru;

        public LoboratoriumNr1_Raovskyi61986()
        {
            InitializeComponent();
            UchwytFormularza = this;
            pictureBox1.BackColor = Color.LightBlue;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = new Bitmap (pictureBox1.Width, pictureBox1.Height);

            PióroXY = new Pen(Color.Blue, 1);
            PioroLiniiToru = new Pen(Color.Black, 1.5f);
        }

        private void LoboratoriumNr1_Raovskyi61986_Load(object sender, EventArgs e)
        {

        }

        private void LoboratoriumNr1_Raovskyi61986_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form Formularz in Application.OpenForms)
            {
                if (Formularz.Name == "LaboratoriumNr1")
                {
                    this.Hide();
                    //
                    Formularz.Show();
                    //
                    return;
                }
            }
            Kokpit_Radovskyi61986 Laboratorium = new Kokpit_Radovskyi61986();
            Laboratorium.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IndexPOA >= MaxIndexPOA)
                IndexPOA = 0;
            else
                IndexPOA++;  
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Rysownica.Clear(Color.AliceBlue);
            Rysownica.DrawLine(PióroXY, PrzeliczanieWsprznych.WspX(0),
                PrzeliczanieWsprznych.WspY(PrzeliczanieWsprznych.Ymax),
                PrzeliczanieWsprznych.WspX(0), PrzeliczanieWsprznych.WspY(PrzeliczanieWsprznych.Ymin));
            Rysownica.DrawLine(PióroXY, PrzeliczanieWsprznych.WspX(PrzeliczanieWsprznych.Xmin),
               PrzeliczanieWsprznych.WspY(0), PrzeliczanieWsprznych.WspY(PrzeliczanieWsprznych.Xmax), PrzeliczanieWsprznych.WspY(0));

            for (int j = 0; j < TWS.GetLength(0) - 1; j++)
            {
                Rysownica.DrawLine(PioroLiniiToru, PrzeliczanieWsprznych.WspX(TWS[j, 0]),
                   PrzeliczanieWsprznych.WspY(TWS[j, 1]),
                   PrzeliczanieWsprznych.WspX(TWS[j + 1, 0]),
                   PrzeliczanieWsprznych.WspX(TWS[j + 1, 1]));
            }
            Rysownica.FillEllipse(Brushes.Yellow, PrzeliczanieWsprznych.WspX(TWS[IndexPOA, 0]) - PromienObiekty, PrzeliczanieWsprznych.WspX(TWS[IndexPOA, 1]) - PromienObiekty, 2 * PromienObiekty, PromienObiekty);
        }

        public static class PrzeliczanieWsprznych 
        {
            static float Sx, Sy;
            static float Dx, Dy;
            // deklaracje zmiannych dla przechowania rozmiarów powierzchni graficznej
            static int Xe_min, Xe_max, Ye_min, Ye_max;
            public static float Xmax { get;private set; }
            public static float Xmin { get; private set; }
            public static float Ymin { get; private set; }
            public static float Ymax { get; private set; }

            static PrzeliczanieWsprznych()
            {
                Xmin = UchwytFormularza.Xd;
                Xmax = UchwytFormularza.Xg;
                //
                Ymin = ExtremuSzeregu.MinSx(UchwytFormularza.TWS);
                Ymax = ExtremuSzeregu.MaxSx(UchwytFormularza.TWS);
                //
                Xe_min = Margines;
                Xe_max = UchwytFormularza.pictureBox1.Width - (Margines + Margines);
                Ye_min = Margines;
                Ye_max = UchwytFormularza.pictureBox1.Height - (Margines + Margines);
                //
                Sx = (Xe_max - Xe_min) / (Xmax- Xmin);
                Sy = (Ye_max - Ye_min) / (Ymax- Ymin);
                Dx = Xe_min - Xmin * Sx;
                Dy = Ye_min - Ymin * Sx;

            }
            // deklaracja metod
            public static int WspX(float x)
            {
                return (int)(Sx * x + Dx);
            }
            public static int WspY(float y)
            {
                return (int)((Sx * y) + Dy);
            }
        }
    }
}
