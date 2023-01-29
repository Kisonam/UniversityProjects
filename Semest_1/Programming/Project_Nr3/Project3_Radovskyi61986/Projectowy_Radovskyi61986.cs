using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


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

        Graphics RysownicaTymczasowa;
        // deklaracja Pióra tymczasowego
        Pen PióroTymczasowe;

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

        struct OpisKrzywejKardynalnej
        {
            public Point ARPunktP0;
            public Point ARPunktP1;
            public Point ARPunktP2;
            public Point ARPunktP3;
            public Point ARPunktP4;
            public ushort ARNumerPunktuKontrolnego;
            public float ARPromieńPunktuKontrolnego;
        }

        OpisKrzywejKardynalnej ARKrzywaKard;

        // deklaracja Fontu opisu punktu kontrolnego
        Font ARFontOpisuPunktów = new Font("TimesNewRoman", 14, FontStyle.Regular);

        public Projectowy_Radovskyi61986()
        {
            InitializeComponent();
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

            RysownicaTymczasowa = pbRisownica.CreateGraphics();
            // utworzenie egzemplarza Pióra tymczasowego
            PióroTymczasowe = new Pen(Color.Blue, 1);

        }

        private void btnLaboratoryjny_Click(object sender, EventArgs e)
        {

        }
        private void rdbKrzywaBeziera_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKrzywaBeziera.Checked)
                MessageBox.Show("Wykreślenie krzywej beziera wymaga zaznaczenia " +
                                 "(kliknięciem) 4 punktów na Rysownicy",
                                 "Kreślenie krzywej Beziera", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
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

        private void kolorWypełnieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog ARPaletaKolorówWyp = new ColorDialog();
            if (ARPaletaKolorówWyp.ShowDialog() == DialogResult.OK)
            {
                ArPióro.Color = ARPaletaKolorówWyp.Color;
                ArPędzle.Color = ARPaletaKolorówWyp.Color;
            }
        }

        private void pbRisownica_MouseDown(object sender, MouseEventArgs e)
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

        private void pbRisownica_MouseUp(object sender, MouseEventArgs e)
        {
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();

            int ARLewyGórnyX = (ARPunkt.X > e.Location.X) ? e.Location.X : ARPunkt.X;
            int ARLewyGórnyY = (ARPunkt.Y > e.Location.Y) ? e.Location.Y : ARPunkt.Y;
            int ARSzerokość = Math.Abs(ARPunkt.X - e.Location.X);
            int ARWysokość = Math.Abs(ARPunkt.Y - e.Location.Y);

            if (e.Button == MouseButtons.Left)
            {
                if (rdbProstokąt.Checked)
                {
                    Rectangle Prostokąt = new Rectangle(ARLewyGórnyX, 
                        ARLewyGórnyY, ARSzerokość, ARWysokość);
                    ARRysownica.DrawRectangle(ArPióro, Prostokąt);
                }
                if (rdbKwadrat.Checked)
                {
                    int ARi = ARSzerokość;
                    Rectangle AMKwadrat = new Rectangle(ARLewyGórnyX, 
                        ARLewyGórnyY, ARi, ARi);
                    ARRysownica.DrawRectangle(ArPióro, AMKwadrat);
                }
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
                        using (SolidBrush ARPędzel = new SolidBrush(Color.Black))
                        {
                            // wykreślenie punktu P0
                            ARRysownica.FillEllipse(ARPędzel,
                                e.Location.X - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                e.Location.Y - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego);
                            //
                            ARRysownica.DrawString("p" + ARKrzywaBeziera.ARNumerPunktuKontrolnego.ToString(),
                                ARFontOpisuPunktów, ARPędzel, e.Location);
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
                            using (SolidBrush ARPędzel = new SolidBrush(Color.Red))
                            {
                                ARRysownica.FillEllipse(ARPędzel,
                                    e.Location.X - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    e.Location.Y - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego);

                                ARRysownica.DrawString("p" + ARKrzywaBeziera.ARNumerPunktuKontrolnego.ToString(),
                                    ARFontOpisuPunktów, ARPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush ARPędzel = new SolidBrush(Color.Black))
                            {
                                ARRysownica.FillEllipse(ARPędzel,
                                    e.Location.X - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    e.Location.Y - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego);

                                ARRysownica.DrawString("p" + ARKrzywaBeziera.ARNumerPunktuKontrolnego.ToString(),
                                    ARFontOpisuPunktów, ARPędzel, e.Location);
                            }
                            //
                            ARRysownica.DrawBezier(ArPióro, ARKrzywaBeziera.ARPunktP0,
                                                        ARKrzywaBeziera.ARPunktP1,
                                                        ARKrzywaBeziera.ARPunktP2,
                                                        ARKrzywaBeziera.ARPunktP3);
                            grbFigury_Linie.Enabled = true;
                        }

                    }
                }
                if (rdbElipsa.Checked)
                {
                    ARRysownica.DrawEllipse(ArPióro, ARLewyGórnyX, 
                        ARLewyGórnyY, ARSzerokość * 2,ARWysokość);
                }
                if (rdbOkrag.Checked)
                {
                    int ARi = ARSzerokość;
                    ARRysownica.DrawEllipse(ArPióro, ARLewyGórnyX, 
                        ARLewyGórnyY, ARi + ARi, ARi + ARi);
                }
                if (rdbSklejanaKrzywaBeziera.Checked) // --
                {

                }
                if (rdbKrzywaKardynalna.Checked)
                {
                    if (grbFigury_Linie.Enabled)
                    {
                        grbFigury_Linie.Enabled = false;

                        ARKrzywaKard.ARNumerPunktuKontrolnego = 0;
                        ARKrzywaKard.ARPromieńPunktuKontrolnego = 3;
                        ARKrzywaKard.ARPunktP0 = e.Location;

                        using (SolidBrush AMPędzel = new SolidBrush(Color.Black))
                        {
                            ARRysownica.FillEllipse(AMPędzel, e.Location.X - ARKrzywaKard.ARNumerPunktuKontrolnego, e.Location.Y - 
                                ARKrzywaKard.ARNumerPunktuKontrolnego, 2 * ARKrzywaKard.ARNumerPunktuKontrolnego, 2 * ARKrzywaKard.ARNumerPunktuKontrolnego);
                            ARRysownica.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, AMPędzel, e.Location);
                        }
                    }
                    else
                    {
                        ARKrzywaKard.ARNumerPunktuKontrolnego += 1;
                        switch (ARKrzywaKard.ARNumerPunktuKontrolnego)
                        {
                            case 1: ARKrzywaKard.ARPunktP1 = e.Location; break;
                            case 2: ARKrzywaKard.ARPunktP2 = e.Location; break;
                            case 3: ARKrzywaKard.ARPunktP3 = e.Location; break;
                            case 4: ARKrzywaKard.ARPunktP4 = e.Location; break;
                        }
                        if (ARKrzywaKard.ARNumerPunktuKontrolnego < 4)
                        {
                            using (SolidBrush AMPędzel = new SolidBrush(Color.Red))
                            {
                                ARRysownica.FillEllipse(AMPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego, e.Location.Y - 
                                    ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                                ARRysownica.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, AMPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush AMPędzel = new SolidBrush(Color.Black))
                            {
                                ARRysownica.FillEllipse(AMPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego, e.Location.Y - 
                                    ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                                ARRysownica.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, AMPędzel, e.Location);
                            }
                            PointF[] AMpoints = { ARKrzywaKard.ARPunktP0, ARKrzywaKard.ARPunktP1, ARKrzywaKard.ARPunktP2, ARKrzywaKard.ARPunktP3, ARKrzywaKard.ARPunktP4 };
                            ARRysownica.DrawCurve(ArPióro, AMpoints);
                            grbFigury_Linie.Enabled = true;
                        }
                    }
                }
                if (rdbZamkniętaKrzywaKardynalna.Checked)
                {
                    if (grbFigury_Linie.Enabled)
                    {
                        grbFigury_Linie.Enabled = false;

                        ARKrzywaKard.ARNumerPunktuKontrolnego = 0;
                        ARKrzywaKard.ARPromieńPunktuKontrolnego = 3;
                        ARKrzywaKard.ARPunktP0 = e.Location;

                        using (SolidBrush AMPędzel = new SolidBrush(Color.Black))
                        {
                            ARRysownica.FillEllipse(AMPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego, 
                                e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 
                                2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                            ARRysownica.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), 
                                ARFontOpisuPunktów, AMPędzel, e.Location);
                        }
                    }

                    else
                    {
                        ARKrzywaKard.ARNumerPunktuKontrolnego += 1;

                        switch (ARKrzywaKard.ARNumerPunktuKontrolnego)
                        {
                            case 1: ARKrzywaKard.ARPunktP1 = e.Location; break;
                            case 2: ARKrzywaKard.ARPunktP2 = e.Location; break;
                            case 3: ARKrzywaKard.ARPunktP3 = e.Location; break;
                            case 4: ARKrzywaKard.ARPunktP4 = e.Location; break;
                        }

                        if (ARKrzywaKard.ARNumerPunktuKontrolnego < 4)
                        {
                            using (SolidBrush AMPędzel = new SolidBrush(Color.Red))
                            {
                                ARRysownica.FillEllipse(AMPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego,
                                    e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 
                                    2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                                ARRysownica.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, AMPędzel, e.Location);
                            }
                        }

                        else
                        {
                            using (SolidBrush AMPędzel = new SolidBrush(Color.Black))
                            {
                                ARRysownica.FillEllipse(AMPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego, 
                                    e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego, 
                                    2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 
                                    2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                                ARRysownica.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, AMPędzel, e.Location);
                            }

                            PointF[] ARpoints = { ARKrzywaKard.ARPunktP0, ARKrzywaKard.ARPunktP1, ARKrzywaKard.ARPunktP2, ARKrzywaKard.ARPunktP3, ARKrzywaKard.ARPunktP4 };
                            ARRysownica.DrawClosedCurve(ArPióro, ARpoints);

                            grbFigury_Linie.Enabled = true;
                        }
                    }
                }
                if (rdbWypełnionaZamknięta.Checked)
                {
                    if (grbFigury_Linie.Enabled)
                    {
                        grbFigury_Linie.Enabled = false;

                        ARKrzywaKard.ARNumerPunktuKontrolnego = 0;
                        ARKrzywaKard.ARPromieńPunktuKontrolnego = 5;
                        ARKrzywaKard.ARPunktP0 = e.Location;

                        using (SolidBrush ARPędzel = new SolidBrush(Color.Black))
                        {
                            ARRysownica.FillEllipse(ARPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego, 
                                e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 
                                2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                            ARRysownica.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), 
                                ARFontOpisuPunktów, ARPędzel, e.Location);
                        }
                    }
                    else
                    {
                        ARKrzywaKard.ARNumerPunktuKontrolnego += 1;

                        switch (ARKrzywaKard.ARNumerPunktuKontrolnego)
                        {
                            case 1: ARKrzywaKard.ARPunktP1 = e.Location; break;
                            case 2: ARKrzywaKard.ARPunktP2 = e.Location; break;
                            case 3: ARKrzywaKard.ARPunktP3 = e.Location; break;
                            case 4: ARKrzywaKard.ARPunktP4 = e.Location; break;
                        }

                        if (ARKrzywaKard.ARNumerPunktuKontrolnego < 4)
                        {
                            using (SolidBrush ARPędzel = new SolidBrush(Color.Red))
                            {
                                ARRysownica.FillEllipse(ARPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego,
                                    e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego,
                                    2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                                ARRysownica.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), 
                                    ARFontOpisuPunktów, ARPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush ARPędzel = new SolidBrush(Color.Black))
                            {
                                ARRysownica.FillEllipse(ARPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego,
                                    e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego, 
                                    2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                                ARRysownica.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), 
                                    ARFontOpisuPunktów, ARPędzel, e.Location);
                            }
                            PointF[] ARpoints = { ARKrzywaKard.ARPunktP0, ARKrzywaKard.ARPunktP1, 
                                ARKrzywaKard.ARPunktP2, ARKrzywaKard.ARPunktP3, ARKrzywaKard.ARPunktP4 };
                            ARRysownica.FillClosedCurve(ArPędzle, ARpoints);

                            grbFigury_Linie.Enabled = true;
                        }
                    }
                }
                if (rdbWypełnionaObramowana.Checked) // --
                {
                    
                }
                if (rdbWypełnionyWycinek.Checked)
                {
                    ARRysownica.FillPie(ArPędzle, ARLewyGórnyX, ARLewyGórnyY, 
                        ARSzerokość, ARWysokość, e.Location.X, e.Location.Y);
                    ARRysownica.DrawPie(ArPióro, ARLewyGórnyX, ARLewyGórnyY, 
                        ARSzerokość, ARWysokość, e.Location.X, e.Location.Y);
                }
                if (rdbWycinekElipsy.Checked)
                {
                    ARRysownica.DrawPie(ArPióro, ARLewyGórnyX, ARLewyGórnyY,
                        ARSzerokość, ARWysokość, e.Location.X, e.Location.Y);
                }
                if (rdbŁukElipsy.Checked)
                {
                    ARRysownica.DrawArc(ArPióro, ARLewyGórnyX, ARLewyGórnyY, 
                        ARSzerokość, ARWysokość, e.Location.X, e.Location.Y);
                }
            }
        }

        private void pbRisownica_MouseMove(object sender, MouseEventArgs e)
        {
            // wizualizacja wpółrzędnych aktualnego położenia myszy
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();

            //
            int ARLewyGórnyX = (ARPunkt.X > e.Location.X) ? e.Location.X : ARPunkt.X;
            int ARLewyGórnyY = (ARPunkt.Y > e.Location.Y) ? e.Location.Y : ARPunkt.Y;
            int ARSzerokość = Math.Abs(ARPunkt.X - e.Location.X);
            int ARWysokość = Math.Abs(ARPunkt.Y - e.Location.Y);
            //obsługa zdarzenia MouseDown
            if (e.Button == MouseButtons.Left)
            {// przechowanie wspołorzędnych poleżonia "Myszy" w zmiennej Punkt
                if (rdbProstokąt.Checked)
                {
                    Rectangle Prostokąt = new Rectangle(ARLewyGórnyX, ARLewyGórnyY, ARSzerokość, ARWysokość);
                    RysownicaTymczasowa.DrawRectangle(PióroTymczasowe, Prostokąt);
                }
                if (rdbKwadrat.Checked)
                {
                    int ARi = ARSzerokość;
                    Rectangle AMKwadrat = new Rectangle(ARLewyGórnyX, ARLewyGórnyY, ARi, ARi);
                    RysownicaTymczasowa.DrawRectangle(PióroTymczasowe, AMKwadrat);
                }
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
                        using (SolidBrush ARPędzel = new SolidBrush(Color.Black))
                        {
                            // wykreślenie punktu P0
                            RysownicaTymczasowa.FillEllipse(ARPędzel,
                                e.Location.X - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                e.Location.Y - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego);
                            //
                            RysownicaTymczasowa.DrawString("p" + ARKrzywaBeziera.ARNumerPunktuKontrolnego.ToString(),
                                ARFontOpisuPunktów, ARPędzel, e.Location);
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
                            using (SolidBrush ARPędzel = new SolidBrush(Color.Red))
                            {
                                RysownicaTymczasowa.FillEllipse(ARPędzel,
                                    e.Location.X - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    e.Location.Y - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego);

                                RysownicaTymczasowa.DrawString("p" + ARKrzywaBeziera.ARNumerPunktuKontrolnego.ToString(),
                                    ARFontOpisuPunktów, ARPędzel, e.Location);
                            }
                        }
                        else
                        {
                            using (SolidBrush ARPędzel = new SolidBrush(Color.Black))
                            {
                                RysownicaTymczasowa.FillEllipse(ARPędzel,
                                    e.Location.X - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    e.Location.Y - ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego,
                                    2 * ARKrzywaBeziera.ARPromieńPunktuKontrolnego);

                                RysownicaTymczasowa.DrawString("p" + ARKrzywaBeziera.ARNumerPunktuKontrolnego.ToString(),
                                    ARFontOpisuPunktów, ARPędzel, e.Location);
                            }
                            //
                            RysownicaTymczasowa.DrawBezier(PióroTymczasowe, ARKrzywaBeziera.ARPunktP0,
                                                        ARKrzywaBeziera.ARPunktP1,
                                                        ARKrzywaBeziera.ARPunktP2,
                                                        ARKrzywaBeziera.ARPunktP3);
                            grbFigury_Linie.Enabled = true;
                        }

                    }
                }
                if (rdbElipsa.Checked)
                {
                    RysownicaTymczasowa.DrawEllipse(PióroTymczasowe, ARLewyGórnyX, ARLewyGórnyY, ARSzerokość * 2, ARWysokość);
                }
                if (rdbOkrag.Checked)
                {
                    int ARi = ARSzerokość;
                    RysownicaTymczasowa.DrawEllipse(PióroTymczasowe, ARLewyGórnyX, ARLewyGórnyY, ARi + ARi, ARi + ARi);
                }
                if (rdbSklejanaKrzywaBeziera.Checked)
                {

                }
                if (rdbKrzywaKardynalna.Checked)
                {
                    if (grbFigury_Linie.Enabled)
                    {
                        grbFigury_Linie.Enabled = false;

                        ARKrzywaKard.ARNumerPunktuKontrolnego = 0;
                        ARKrzywaKard.ARPromieńPunktuKontrolnego = 3;
                        ARKrzywaKard.ARPunktP0 = e.Location;

                        using (SolidBrush AMPędzel = new SolidBrush(Color.Black))
                        {
                            RysownicaTymczasowa.FillEllipse(AMPędzel, e.Location.X - ARKrzywaKard.ARNumerPunktuKontrolnego, e.Location.Y - ARKrzywaKard.ARNumerPunktuKontrolnego, 2 * ARKrzywaKard.ARNumerPunktuKontrolnego, 2 * ARKrzywaKard.ARNumerPunktuKontrolnego);
                            RysownicaTymczasowa.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, AMPędzel, e.Location);
                        }
                    }

                    else
                    {
                        ARKrzywaKard.ARNumerPunktuKontrolnego += 1;
                        switch (ARKrzywaKard.ARNumerPunktuKontrolnego)
                        {
                            case 1:
                                ARKrzywaKard.ARPunktP1 = e.Location;
                                break;
                            case 2:
                                ARKrzywaKard.ARPunktP2 = e.Location;
                                break;
                            case 3:
                                ARKrzywaKard.ARPunktP3 = e.Location;
                                break;
                            case 4:
                                ARKrzywaKard.ARPunktP4 = e.Location;
                                break;
                        }

                        if (ARKrzywaKard.ARNumerPunktuKontrolnego < 4)
                        {
                            using (SolidBrush AMPędzel = new SolidBrush(Color.Red))
                            {
                                ARRysownica.FillEllipse(AMPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego, e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                                ARRysownica.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, AMPędzel, e.Location);
                            }
                        }

                        else
                        {
                            using (SolidBrush AMPędzel = new SolidBrush(Color.Black))
                            {
                                ARRysownica.FillEllipse(AMPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego, e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                                ARRysownica.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, AMPędzel, e.Location);
                            }

                            PointF[] AMpoints = { ARKrzywaKard.ARPunktP0, ARKrzywaKard.ARPunktP1, ARKrzywaKard.ARPunktP2, ARKrzywaKard.ARPunktP3, ARKrzywaKard.ARPunktP4 };
                            ARRysownica.DrawCurve(ArPióro, AMpoints);

                            grbFigury_Linie.Enabled = true;
                        }
                    }
                }
                if (rdbZamkniętaKrzywaKardynalna.Checked)
                {
                    if (grbFigury_Linie.Enabled)
                    {
                        grbFigury_Linie.Enabled = false;

                        ARKrzywaKard.ARNumerPunktuKontrolnego = 0;
                        ARKrzywaKard.ARPromieńPunktuKontrolnego = 3;
                        ARKrzywaKard.ARPunktP0 = e.Location;

                        using (SolidBrush AMPędzel = new SolidBrush(Color.Black))
                        {
                            RysownicaTymczasowa.FillEllipse(AMPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego, e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                            RysownicaTymczasowa.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, AMPędzel, e.Location);
                        }
                    }

                    else
                    {
                        ARKrzywaKard.ARNumerPunktuKontrolnego += 1;

                        switch (ARKrzywaKard.ARNumerPunktuKontrolnego)
                        {
                            case 1:
                                ARKrzywaKard.ARPunktP1 = e.Location;
                                break;
                            case 2:
                                ARKrzywaKard.ARPunktP2 = e.Location;
                                break;
                            case 3:
                                ARKrzywaKard.ARPunktP3 = e.Location;
                                break;
                            case 4:
                                ARKrzywaKard.ARPunktP4 = e.Location;
                                break;
                        }

                        if (ARKrzywaKard.ARNumerPunktuKontrolnego < 4)
                        {
                            using (SolidBrush AMPędzel = new SolidBrush(Color.Red))
                            {
                                RysownicaTymczasowa.FillEllipse(AMPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego, e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                                RysownicaTymczasowa.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, AMPędzel, e.Location);
                            }
                        }

                        else
                        {
                            using (SolidBrush AMPędzel = new SolidBrush(Color.Black))
                            {
                                RysownicaTymczasowa.FillEllipse(AMPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego, e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                                RysownicaTymczasowa.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, AMPędzel, e.Location);
                            }

                            PointF[] ARpoints = { ARKrzywaKard.ARPunktP0, ARKrzywaKard.ARPunktP1, ARKrzywaKard.ARPunktP2, ARKrzywaKard.ARPunktP3, ARKrzywaKard.ARPunktP4 };
                            RysownicaTymczasowa.DrawClosedCurve(PióroTymczasowe, ARpoints);

                            grbFigury_Linie.Enabled = true;
                        }
                    }
                }
                if (rdbWypełnionaZamknięta.Checked)
                {
                    if (grbFigury_Linie.Enabled)
                    {
                        grbFigury_Linie.Enabled = false;

                        ARKrzywaKard.ARNumerPunktuKontrolnego = 0;
                        ARKrzywaKard.ARPromieńPunktuKontrolnego = 5;
                        ARKrzywaKard.ARPunktP0 = e.Location;

                        using (SolidBrush ARPędzel = new SolidBrush(Color.Black))
                        {
                            RysownicaTymczasowa.FillEllipse(ARPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego, e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                            RysownicaTymczasowa.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, ARPędzel, e.Location);
                        }
                    }

                    else
                    {
                        ARKrzywaKard.ARNumerPunktuKontrolnego += 1;

                        switch (ARKrzywaKard.ARNumerPunktuKontrolnego)
                        {
                            case 1:
                                ARKrzywaKard.ARPunktP1 = e.Location;
                                break;
                            case 2:
                                ARKrzywaKard.ARPunktP2 = e.Location;
                                break;
                            case 3:
                                ARKrzywaKard.ARPunktP3 = e.Location;
                                break;
                            case 4:
                                ARKrzywaKard.ARPunktP4 = e.Location;
                                break;
                        }

                        if (ARKrzywaKard.ARNumerPunktuKontrolnego < 4)
                        {
                            using (SolidBrush ARPędzel = new SolidBrush(Color.Red))
                            {
                                RysownicaTymczasowa.FillEllipse(ARPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego, e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                                RysownicaTymczasowa.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, ARPędzel, e.Location);
                            }
                        }

                        else
                        {
                            using (SolidBrush ARPędzel = new SolidBrush(Color.Black))
                            {
                                RysownicaTymczasowa.FillEllipse(ARPędzel, e.Location.X - ARKrzywaKard.ARPromieńPunktuKontrolnego, e.Location.Y - ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego, 2 * ARKrzywaKard.ARPromieńPunktuKontrolnego);
                                RysownicaTymczasowa.DrawString("p" + ARKrzywaKard.ARNumerPunktuKontrolnego.ToString(), ARFontOpisuPunktów, ARPędzel, e.Location);
                            }



                            PointF[] ARpoints = { ARKrzywaKard.ARPunktP0, ARKrzywaKard.ARPunktP1, ARKrzywaKard.ARPunktP2, ARKrzywaKard.ARPunktP3, ARKrzywaKard.ARPunktP4 };
                            RysownicaTymczasowa.FillClosedCurve(ArPędzle, ARpoints);

                            grbFigury_Linie.Enabled = true;
                        }
                    }
                }
            }
            pbRisownica.Refresh();
        }

        private void kolorTłaRysownicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog ARPaletaKolorow = new ColorDialog();
            if (ARPaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                pbRisownica.BackColor = ARPaletaKolorow.Color;
            }
        }

        private void kolorLiniiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog ARPaletaKolorow = new ColorDialog();
            if (ARPaletaKolorow.ShowDialog() == DialogResult.OK)
            {
                ArPióro.Color = ARPaletaKolorow.Color;
            }
        }

        private void zapiszaBitMapęWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog AROknoWyboru = new SaveFileDialog();
            AROknoWyboru.Filter = "Image Files|*.jpg;*.jpeg;*.png|Allfiles(*.*.)|*.*";
            AROknoWyboru.FilterIndex = 1;
            AROknoWyboru.RestoreDirectory = true;
            AROknoWyboru.InitialDirectory = "D:\\";
            AROknoWyboru.Title = "Zapisz BitMapę";

            if (AROknoWyboru.ShowDialog() == DialogResult.OK)
            {
                int AMSzerokośćRysownicy = Convert.ToInt32(pbRisownica.Width);
                int AMWysokośćRysownicy = Convert.ToInt32(pbRisownica.Height);

                using (Bitmap AMBmap = new Bitmap(AMSzerokośćRysownicy, AMWysokośćRysownicy))
                {
                    pbRisownica.DrawToBitmap(AMBmap, new Rectangle(0, 0, AMSzerokośćRysownicy, AMWysokośćRysownicy));
                    AMBmap.Save(AROknoWyboru.FileName, ImageFormat.Jpeg);
                }
            }
        }

        private void odczytajBitMapęZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog AROknoWyboruPlikuOdczytu = new OpenFileDialog();
            AROknoWyboruPlikuOdczytu.Title = "Odczytaj BitMapę";
            AROknoWyboruPlikuOdczytu.Filter = "Image Files|*.jpg;*.jpeg;*.png|Allfiles(*.*)|*.*";
            AROknoWyboruPlikuOdczytu.FilterIndex = 1;
            AROknoWyboruPlikuOdczytu.RestoreDirectory = true;
            AROknoWyboruPlikuOdczytu.InitialDirectory = "D:\\";

            if (AROknoWyboruPlikuOdczytu.ShowDialog() == DialogResult.OK)
            {
                pbRisownica.Image = new Bitmap(AROknoWyboruPlikuOdczytu.FileName);
                this.Controls.Add(pbRisownica);
            }
            AROknoWyboruPlikuOdczytu.Dispose();
        }

        private void exitZFormularzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void restartProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormularzStartowy Kokpit = new FormularzStartowy();
            Kokpit.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ArPióro.Width = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ArPióro.Width = 2;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ArPióro.Width = 3;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ArPióro.Width = 4;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ArPióro.Width = 5;
        }

        private void liniaKreskowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArPióro.DashStyle = DashStyle.Dash;
        }

        private void liniaKreskowoKropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArPióro.DashStyle = DashStyle.DashDot;
        }

        private void liniaKreskowoKropkowaKropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArPióro.DashStyle = DashStyle.DashDotDot;
        }

        private void liniaKropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArPióro.DashStyle = DashStyle.Dot;
        }

        private void ćągłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArPióro.DashStyle = DashStyle.Solid;
        }

        private void roundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ArPióro.StartCap = LineCap.RoundAnchor;
        }

        private void arrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArPióro.StartCap = LineCap.RoundAnchor;
        }

        private void diamondToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ArPióro.StartCap = LineCap.DiamondAnchor;
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArPióro.StartCap = LineCap.Triangle;
        }

        private void squareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ArPióro.StartCap = LineCap.SquareAnchor;
        }

        private void roundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArPióro.EndCap = LineCap.RoundAnchor;
        }

        private void arrowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ArPióro.EndCap = LineCap.ArrowAnchor;
        }

        private void diamondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArPióro.EndCap = LineCap.DiamondAnchor;
        }

        private void triangleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ArPióro.EndCap = LineCap.Triangle;
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArPióro.EndCap = LineCap.SquareAnchor;
        }

        private void krójCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog AROknoCzcionki = new FontDialog();
            if (AROknoCzcionki.ShowDialog() == DialogResult.OK)
            {
                this.Font = AROknoCzcionki.Font;
            }
            AROknoCzcionki.Dispose();
        }

        private void rozmiarCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog AROknoCzcionki = new FontDialog();
            if (AROknoCzcionki.ShowDialog() == DialogResult.OK)
            {
                this.Font = AROknoCzcionki.Font;
            }

            AROknoCzcionki.Dispose();
        }

        private void kolorCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog ARPaletaKolorów = new ColorDialog();
            if (ARPaletaKolorów.ShowDialog() == DialogResult.OK)
            {
                this.ForeColor = ARPaletaKolorów.Color;
            }

            ARPaletaKolorów.Dispose();
        }
    }
}
