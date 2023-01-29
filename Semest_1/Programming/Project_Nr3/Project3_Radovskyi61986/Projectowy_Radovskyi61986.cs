using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project3_Radovskyi61986
{
    public partial class Projectowy_Radovskyi61986 : Form
    {
        const ushort PromieńPunktu = 2;
        // deklaracja zmiennych referencyjnych narzędni grafichnych
        Graphics ARRysownica;
        Pen ArPióro;
        SolidBrush ArPędzle;
        Point ARPunkt = Point.Empty;

        struct OpisKrzywejBeziera
        {
            public Point ARPunktP0;
            public Point ARPunktP1;
            public Point ARPunktP2;
            public Point ARPunktP3;
            public ushort ARNumerPunktuKontrolnego;
            public float ARPromieńPunktuKontrolnego;
        }
        // deklaracja zmiennej dla KrzywejBeziera
        OpisKrzywejBeziera ARKrzywaBeziera;
        // deklaracja Fontu opisu punktu kontrolnego
        Font ARFontOpisuPunktów = new Font("TimesNewRoman", 14, FontStyle.Regular);

        public Projectowy_Radovskyi61986()
        {
            InitializeComponent();
            // ....
            lblX.Text = "0";
            lblY.Text = "0";
            // "podpięcie" BitMapy do kontrolki PictureBox
            pbRisownica.Image = new Bitmap(pbRisownica.Width, pbRisownica.Height);
            // utworzenie egzemplarza graficznej na bitmapie
            ARRysownica = Graphics.FromImage(pbRisownica.Image);
            // utworzenie egzemlarza Pióra i jego sformatowania 
            ArPióro = new Pen(Color.Red, 1.4f);
            ArPióro.DashStyle = DashStyle.Dash;
            ArPióro.StartCap = LineCap.Round;
            ArPióro.EndCap = LineCap.Round;

            ArPędzle = new SolidBrush(Color.Blue);
        }

        private void btnLaboratoryjny_Click(object sender, EventArgs e)
        {

        }

        private void Projectowy_Radovskyi61986_MouseUp(object sender, MouseEventArgs e)
        {
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();

            int LewyGórnyX = (ARPunkt.X > e.Location.X) ? e.Location.X : ARPunkt.X;
            int LewyGórnyY = (ARPunkt.Y > e.Location.Y) ? e.Location.Y : ARPunkt.Y;
            int Szerokość = Math.Abs(ARPunkt.X - e.Location.X);
            int Wysokość = Math.Abs(ARPunkt.Y - e.Location.Y);

            if (e.Button == MouseButtons.Left)
            {
                if (rdbKrzywaBeziera.Checked)
                {
                    if (grbFigury_Linie.Enabled)
                    {
                        grbFigury_Linie.Enabled = false;
                        //
                        ARKrzywaBeziera.ARNumerPunktuKontrolnego = 0;
                        ARKrzywaBeziera.ARPromieńPunktuKontrolnego = 5;
                        //
                        ARKrzywaBeziera.ARPunktP0 = e.Location;
                        // wykreślenie  (wymalowanie) opisu punktu P0
                        using (SolidBrush Pędzel = new SolidBrush(Color.Black))
                        {
                            // wykreślenie punktu P0
                            ARRysownica.FillEllipse(Pędzel,
                                e.Location.X - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                e.Location.Y - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego);
                            //
                            ARRysownica.DrawString("p" + ARKrzywaBeziera.ARNumerPunktuKontrolnego.ToString(),
                                ARFontOpisuPunktów, Pędzel, e.Location);
                        }
                    }
                    else
                    {
                        ARKrzywaBeziera.ARNumerPunktuKontrolnego++;
                        switch (ARKrzywaBeziera.ARNumerPunktuKontrolnego)
                        {
                            case 1: ARKrzywaBeziera.ARPunktP1 = e.Location; break;
                            case 2: ARKrzywaBeziera.ARPunktP2 = e.Location; break;
                            case 3: ARKrzywaBeziera.ARPunktP3 = e.Location; break;
                        }
                        //
                        if (ARKrzywaBeziera.ARNumerPunktuKontrolnego < 3)
                        {
                            using (SolidBrush Pędzel = new SolidBrush(Color.Red))
                            {
                                ARRysownica.FillEllipse(Pędzel,
                                    e.Location.X - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    e.Location.Y - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego);

                                ARRysownica.DrawString("p" + ARKrzywaBeziera.ARNumerPunktuKontrolnego.ToString(),
                                    ARFontOpisuPunktów, Pędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush Pędzel = new SolidBrush(Color.Black))
                            {
                                ARRysownica.FillEllipse(Pędzel,
                                    e.Location.X - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    e.Location.Y - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego);

                                ARRysownica.DrawString("p" + ARKrzywaBeziera.ARNumerPunktuKontrolnego.ToString(),
                                    ARFontOpisuPunktów, Pędzel, e.Location);
                            }
                            //
                            ARRysownica.DrawBezier(ArPióro, ARKrzywaBeziera.ARPunktP0,
                                                        ARKrzywaBeziera.ARPunktP1,
                                                        ARKrzywaBeziera.ARPunktP2,
                                                        ARKrzywaBeziera.ARPunktP3);

                        }
                        grbFigury_Linie.Enabled = true;
                    }
                }
            }
        }

        private void rdbKrzywaBeziera_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKrzywaBeziera.Checked)
                MessageBox.Show("Wykreślenie krzywej beziera wymaga zaznaczenia " +
                                 "(kliknięciem) 4 punktów na Rysownicy",
                                 "Kreślenie krzywej Beziera", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
        }

        private void Projectowy_Radovskyi61986_MouseDown(object sender, MouseEventArgs e)
        {
            // wizualizacja wpółrzędnych aktualnego położenia myszy
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();
            //obsługa zdarzenia MouseDown
            if (e.Button == MouseButtons.Left)
            {// przechowanie wspołorzędnych poleżonia "Myszy" w zmiennej Punkt
                ARPunkt = e.Location;
            }
        }

        private void Projectowy_Radovskyi61986_MouseMove(object sender, MouseEventArgs e)
        {
            // wizualizacja wpółrzędnych aktualnego położenia myszy
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();
            //obsługa zdarzenia MouseDown
            if (e.Button == MouseButtons.Left)
            {// przechowanie wspołorzędnych poleżonia "Myszy" w zmiennej Punkt

            }
            pbRisownica.Refresh();
        }

        private void Projectowy_Radovskyi61986_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult OknoMessage = MessageBox.Show("Czy rzechywicie chcesz zakąć ten " +
              "formularz i powrócić do formularza głuwnego", this.Text,
              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            // rozpoznanie decyzji użytkownika programu
            if (OknoMessage == DialogResult.Yes)
            {
                e.Cancel = false;

                foreach (Form Formularz in Application.OpenForms)
                {
                    if (Formularz.Name == "FormularzStartowy")
                    { // ukrycie bieżącego formularza
                        this.Hide();
                        // odsłonięcie znalezionego głównego formularza
                        Formularz.Show();
                        // wyjście z metody obsługi zdarzenia FormClosing
                        return;
                    }

                }
                FormularzStartowy FormularzProjectuNr3 = new FormularzStartowy();
                // ukrycie bieżącego formularza głównego
                FormularzProjectuNr3.Show();
                // ukrycie bieżącego formularza
                this.Hide();
            }
            else
                e.Cancel = true;
        }
    }
}
