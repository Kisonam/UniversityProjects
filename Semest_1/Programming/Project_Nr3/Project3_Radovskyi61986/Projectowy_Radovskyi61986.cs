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
        Graphics Rysownica;
        Pen Pióro;
        SolidBrush Pędzle;
        Point Punkt = Point.Empty;

        struct OpisKrzywejBeziera
        {
            public Point PunktP0;
            public Point PunktP1;
            public Point PunktP2;
            public Point PunktP3;
            public ushort NumerPunktuKontrolnego;
            public float PromieńPunktuKontrolnego;
        }
        // deklaracja zmiennej dla KrzywejBeziera
        OpisKrzywejBeziera KrzywaBeziera;
        // deklaracja Fontu opisu punktu kontrolnego
        Font FontOpisuPunktów = new Font("Arial", 10, FontStyle.Italic);

        public Projectowy_Radovskyi61986()
        {
            InitializeComponent();
            // ....
            // "podpięcie" BitMapy do kontrolki PictureBox
            pbRisownica.Image = new Bitmap(pbRisownica.Width, pbRisownica.Height);
            // utworzenie egzemplarza graficznej na bitmapie
            Rysownica = Graphics.FromImage(pbRisownica.Image);
            // utworzenie egzemlarza Pióra i jego sformatowania 
            Pióro = new Pen(Color.Red, 1.4f);
            Pióro.DashStyle = DashStyle.Dash;
            Pióro.StartCap = LineCap.Round;
            Pióro.EndCap = LineCap.Round;

            Pędzle = new SolidBrush(Color.Blue);
        }

        private void btnLaboratoryjny_Click(object sender, EventArgs e)
        {

        }

        private void Projectowy_Radovskyi61986_MouseUp(object sender, MouseEventArgs e)
        {
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();

            int LewyGórnyX = (Punkt.X > e.Location.X) ? e.Location.X : Punkt.X;
            int LewyGórnyY = (Punkt.Y > e.Location.Y) ? e.Location.Y : Punkt.Y;
            int Szerokość = Math.Abs(Punkt.X - e.Location.X);
            int Wysokość = Math.Abs(Punkt.Y - e.Location.Y);

            if (e.Button == MouseButtons.Left)
            {
                if (rdbKrzywaBeziera.Checked)
                {
                    if (grbFigury_Linie.Enabled)
                    {
                        grbFigury_Linie.Enabled = false;
                        //
                        KrzywaBeziera.NumerPunktuKontrolnego = 0;
                        KrzywaBeziera.PromieńPunktuKontrolnego = 5;
                        //
                        KrzywaBeziera.PunktP0 = e.Location;
                        // wykreślenie  (wymalowanie) opisu punktu P0
                        using (SolidBrush Pędzel = new SolidBrush(Color.Black))
                        {
                            // wykreślenie punktu P0
                            Rysownica.FillEllipse(Pędzel,
                                e.Location.X - KrzywaBeziera.PromieńPunktuKontrolnego,
                                e.Location.Y - KrzywaBeziera.PromieńPunktuKontrolnego,
                                2 * KrzywaBeziera.PromieńPunktuKontrolnego,
                                2 * KrzywaBeziera.PromieńPunktuKontrolnego);
                            //
                            Rysownica.DrawString("p" + KrzywaBeziera.NumerPunktuKontrolnego.ToString(),
                                FontOpisuPunktów, Pędzel, e.Location);
                        }
                    }
                    else
                    {
                        KrzywaBeziera.NumerPunktuKontrolnego++;
                        switch (KrzywaBeziera.NumerPunktuKontrolnego)
                        {
                            case 1: KrzywaBeziera.PunktP1 = e.Location; break;
                            case 2: KrzywaBeziera.PunktP2 = e.Location; break;
                            case 3: KrzywaBeziera.PunktP3 = e.Location; break;
                        }
                        //
                        if (KrzywaBeziera.NumerPunktuKontrolnego < 3)
                        {
                            using (SolidBrush Pędzel = new SolidBrush(Color.Red))
                            {
                                Rysownica.FillEllipse(Pędzel,
                                    e.Location.X - KrzywaBeziera.PromieńPunktuKontrolnego,
                                    e.Location.Y - KrzywaBeziera.PromieńPunktuKontrolnego,
                                    2 * KrzywaBeziera.PromieńPunktuKontrolnego,
                                    2 * KrzywaBeziera.PromieńPunktuKontrolnego);

                                Rysownica.DrawString("p" + KrzywaBeziera.NumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, Pędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush Pędzel = new SolidBrush(Color.Black))
                            {
                                Rysownica.FillEllipse(Pędzel,
                                    e.Location.X - KrzywaBeziera.PromieńPunktuKontrolnego,
                                    e.Location.Y - KrzywaBeziera.PromieńPunktuKontrolnego,
                                    2 * KrzywaBeziera.PromieńPunktuKontrolnego,
                                    2 * KrzywaBeziera.PromieńPunktuKontrolnego);

                                Rysownica.DrawString("p" + KrzywaBeziera.NumerPunktuKontrolnego.ToString(),
                                    FontOpisuPunktów, Pędzel, e.Location);
                            }
                            //
                            Rysownica.DrawBezier(Pióro, KrzywaBeziera.PunktP0,
                                                        KrzywaBeziera.PunktP1,
                                                        KrzywaBeziera.PunktP2,
                                                        KrzywaBeziera.PunktP3);

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
                Punkt = e.Location;
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
