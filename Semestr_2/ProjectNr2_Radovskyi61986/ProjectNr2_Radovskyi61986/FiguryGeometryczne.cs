using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectNr2_Radovskyi61986
{
    internal class FiguryGeometryczne
    {
        public FiguryGeometryczne()
        {

        }

        public class Punkt
        {
            public const int PromieńPunktu = 5;
            public enum FiguraGeometryczna : byte
            {
                Punkt = 0,
                Linia,
                Elipsa,
                Prostakąt,
                Okrag,
                Kwadrat,
                Wielokąt,
                KwadratWypełniony
            }

            public FiguraGeometryczna Figura 
            {
                get;
                protected set;
            }
            public bool Widoczny
            {
                get; 
                protected set;
            }
            public int ŚrednicaPunktu
            {
                get;
                protected set;
            }
            public int X
            {
                get; protected set;
            }
            public int Y
            {
                get; protected set;
            }
            public Color Kolor
            {
                get;
                protected set;
            }
            public float GrubośćLinii
            {
                get;
                protected set;
            }
            public DashStyle StylLinii
            {
                get;
                protected set;
            }
            public Color KolorWypełniea 
            {
                get; protected set; 

            }
            public Punkt(int x, int y)
            {
                Figura = FiguraGeometryczna.Punkt;
                this.X = x;
                this.Y = y;
                ŚrednicaPunktu= 2 * PromieńPunktu;
                Widoczny = false;
                Kolor = Color.Black;
                GrubośćLinii = 1.0f;
                StylLinii = DashStyle.Solid;
                KolorWypełniea = Color.Wheat;
            }
            public Punkt(int x, int y, Color Kolor) : this(x, y)
            {
                this.Kolor = Kolor;
            }
            public Punkt(int x, int y, Color Kolor, int ŚrednicaPunktu) : this (x, y, Kolor)
            {
                this.ŚrednicaPunktu = ŚrednicaPunktu;
            }
            public virtual void Wykreśl(Graphics Rysownica)
            {
                SolidBrush Pędzel = new SolidBrush(Kolor);
                Rysownica.FillEllipse(Pędzel, X - ŚrednicaPunktu / 2, Y - ŚrednicaPunktu / 2, ŚrednicaPunktu, ŚrednicaPunktu);
                Widoczny = true;
                Pędzel.Dispose();

                using (SolidBrush Pędzel2 = new SolidBrush(Kolor))
                {
                    Rysownica.FillEllipse(Pędzel, X - ŚrednicaPunktu / 2, Y - ŚrednicaPunktu / 2, ŚrednicaPunktu, ŚrednicaPunktu);
                    Widoczny = true;
                }
            }
            public virtual void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                using (SolidBrush Pędzel = new SolidBrush(Kontrolka.BackColor))
                {
                    Rysownica.FillEllipse(Pędzel, X - ŚrednicaPunktu / 2, Y - ŚrednicaPunktu / 2, ŚrednicaPunktu, ŚrednicaPunktu);
                    Widoczny = false;
                }
            }
            public virtual void PrzesuńDoNowegoXY(Control Kontrolka ,Graphics Rysownica,int Xp,int Yp)
            {
                X = Xp; Y = Yp;
                Wykreśl(Rysownica);
            }
        }
        public class Linia : Punkt
        {
            int Xk, Yk; 
            public Linia(int Xk, int Yk, int Xp, int Yp) : base(Xp, Yp)
            {
                this.Xk = Xk; this.Yk = Yk;
            }
            public Linia(int Xp, int Yp, int Xk, int Yk, Color KolorLinii) : base(Xp, Yp, KolorLinii)
            {
                Figura = FiguraGeometryczna.Linia;
                this.Xk = Xk; this.Yk = Yk;
            }
            public override void Wykreśl(Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                {
                    Pióro.DashStyle = StylLinii;
                    Rysownica.DrawLine(Pióro,X,Y,Xk,Yk);
                }
            }
            public override void Wymaż(Control Kontrolka, Graphics Rysownica)
            {
                if (Widoczny)
                {
                    using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                    {
                        Pióro.DashStyle = StylLinii;
                        Rysownica.DrawLine(Pióro, X, Y, Xk, Yk);
                        Widoczny = false;
                    }
                }
                
            }
            public override void PrzesuńDoNowegoXY(Control Kontrolka,Graphics Rysownica, int Xp, int Yp)
            {
                int dx, dy;

                if (Xp > X)
                    dx = Xp - X;
                else
                    dx = X - Xp;

                if (Yp> Y) dy = Yp - Y;
                else dy= Y - Yp;

                X = Xp; Y = Yp;
                Xk = (Xk + dx) % Kontrolka.Width;
                Yk = (Yk + dy) % Kontrolka.Height;

                Wykreśl(Rysownica);  
            }
        }
        public class Prostokąt : Punkt
        {
            public int Szerokość { get; protected set; }
            public int Wysokość { get; protected set; }

            public Prostokąt(int x, int y, int szerokość, int wysokość) : base(x, y)
            {
                Figura = FiguraGeometryczna.Prostakąt;
                Szerokość = szerokość;
                Wysokość = wysokość;
            }

            public Prostokąt(int x, int y, int szerokość, int wysokość, Color kolor) : this(x, y, szerokość, wysokość)
            {
                Kolor = kolor;
            }

            public Prostokąt(int x, int y, int szerokość, int wysokość, Color kolor, int średnicaPunktu) : this(x, y, szerokość, wysokość, kolor)
            {
                ŚrednicaPunktu = średnicaPunktu;
            }

            public override void Wykreśl(Graphics rysownica)
            {
                using (SolidBrush pędzel = new SolidBrush(Kolor))
                {
                    rysownica.FillRectangle(pędzel, X - Szerokość / 2, Y - Wysokość / 2, Szerokość, Wysokość);
                    Widoczny = true;
                }
            }

            public override void Wymaż(Control kontrolka, Graphics rysownica)
            {
                using (SolidBrush pędzel = new SolidBrush(kontrolka.BackColor))
                {
                    rysownica.FillRectangle(pędzel, X - Szerokość / 2, Y - Wysokość / 2, Szerokość, Wysokość);
                    Widoczny = false;
                }
            }

            public override void PrzesuńDoNowegoXY(Control kontrolka, Graphics rysownica, int xp, int yp)
            {
                X = xp;
                Y = yp;
                Wykreśl(rysownica);
            }
        }
        public class Elipsa : Punkt
        {
            public int OśDuża { get; protected set; }
            public int OśMała { get; protected set; }

            public Elipsa(int x, int y, int ośDuża, int ośMała) : base(x, y)
            {
                Figura = FiguraGeometryczna.Elipsa;
                OśDuża = ośDuża;
                OśMała = ośMała;
            }

            public Elipsa(int x, int y, int ośDuża, int ośMała, Color kolor) : base(x, y, kolor)
            {
                Figura = FiguraGeometryczna.Elipsa;
                OśDuża = ośDuża;
                OśMała = ośMała;
            }

            public Elipsa(int x, int y, int ośDuża, int ośMała, Color kolor, int średnicaPunktu) : base(x, y, kolor, średnicaPunktu)
            {
                Figura = FiguraGeometryczna.Elipsa;
                OśDuża = ośDuża;
                OśMała = ośMała;
            }
            public Elipsa(int x, int y, int ośDuża, int ośMała, Color kolorLinii, DashStyle stylLinii, float grubośćLinii) : base(x, y)
            {
                Figura = FiguraGeometryczna.Elipsa;
                OśDuża = ośDuża;
                OśMała = ośMała;
                Kolor = kolorLinii;
                StylLinii = stylLinii;
                GrubośćLinii = grubośćLinii;
            }

            public override void Wykreśl(Graphics rysownica)
            {
                SolidBrush pędzel = new SolidBrush(Kolor);
                rysownica.FillEllipse(pędzel, X - OśDuża / 2, Y - OśMała / 2, OśDuża, OśMała);
                Widoczny = true;
                pędzel.Dispose();

                using (SolidBrush pędzel2 = new SolidBrush(Kolor))
                {
                    rysownica.FillEllipse(pędzel2, X - OśDuża / 2, Y - OśMała / 2, OśDuża, OśMała);
                    Widoczny = true;
                }
            }

            public override void Wymaż(Control kontrolka, Graphics rysownica)
            {
                using (SolidBrush pędzel = new SolidBrush(kontrolka.BackColor))
                {
                    rysownica.FillEllipse(pędzel, X - OśDuża / 2, Y - OśMała / 2, OśDuża, OśMała);
                    Widoczny = false;
                }
            }

            public override void PrzesuńDoNowegoXY(Control kontrolka, Graphics rysownica, int xp, int yp)
            {
                X = xp;
                Y = yp;
                Wykreśl(rysownica);
            }
        }
        public class Okrąg : Elipsa
        {
            protected int Promień
            {
                get { return OśDuża; }
                set { OśDuża= value;
                    OśMała = value;
                }
            }

            public Okrąg(int x, int y, int Promień, Color KolorLinii,
                DashStyle StylLinii, float GrubośćLinii): base(x,y, 2 * Promień, 2 * Promień, KolorLinii, StylLinii, GrubośćLinii)
            {
                Figura = FiguraGeometryczna.Okrag;
                Widoczny = false;
            }
            public override void Wykreśl(Graphics rysownica)
            {
                Pen pisak = new Pen(Kolor, GrubośćLinii);
                pisak.DashStyle = StylLinii;

                rysownica.DrawEllipse(pisak, X - Promień, Y - Promień, Promień * 2, Promień * 2);
                Widoczny = true;

                pisak.Dispose();
            }

            public override void Wymaż(Control kontrolka, Graphics rysownica)
            {
                SolidBrush pędzel = new SolidBrush(kontrolka.BackColor);
                rysownica.FillEllipse(pędzel, X - Promień, Y - Promień, Promień * 2, Promień * 2);
                Widoczny = false;

                pędzel.Dispose();
            }

            public override void PrzesuńDoNowegoXY(Control kontrolka, Graphics rysownica, int xp, int yp)
            {
                X = xp;
                Y = yp;
                Wykreśl(rysownica);
            }
        }
        public class Kwadrat : Prostokąt
        {
            public int bok { get; protected set; }

            public Kwadrat(int x, int y, int bok) : base(x, y, bok, bok)
            {
                this.bok = bok;
                Figura = FiguraGeometryczna.Kwadrat;
            }

            public Kwadrat(int x, int y, int bok, Color kolor) : base(x, y, bok, bok, kolor)
            {
                this.bok = bok;
                Figura = FiguraGeometryczna.Kwadrat;
            }

            public Kwadrat(int x, int y, int bok, Color kolor, int średnicaPunktu) : base(x, y, bok, bok, kolor, średnicaPunktu)
            {
                this.bok = bok;
                Figura = FiguraGeometryczna.Kwadrat;
            }

            public override void Wykreśl(Graphics rysownica)
            {
                using (SolidBrush pędzel = new SolidBrush(Kolor))
                {
                    rysownica.FillRectangle(pędzel, X - bok / 2, Y - bok / 2, bok, bok);
                    Widoczny = true;
                }
            }

            public override void Wymaż(Control kontrolka, Graphics rysownica)
            {
                using (SolidBrush pędzel = new SolidBrush(kontrolka.BackColor))
                {
                    rysownica.FillRectangle(pędzel, X - bok / 2, Y - bok / 2, bok, bok);
                    Widoczny = false;
                }
            }

            public override void PrzesuńDoNowegoXY(Control kontrolka, Graphics rysownica, int xp, int yp)
            {
                X = xp;
                Y = yp;
                Wykreśl(rysownica);
            }
        }
        public class KwadratWypełniony : Kwadrat
        {
            private Color kolor;

            public KwadratWypełniony(int x, int y, int bok, Color kolor) : base(x, y, bok)
            {
                this.kolor = kolor;
            }

            public override void Wykreśl(Graphics rysownica)
            {
                SolidBrush pędzel = new SolidBrush(kolor);
                rysownica.FillRectangle(pędzel, X - bok / 2, Y - bok / 2, bok, bok);
            }

            public override void Wymaż(Control kontrolka, Graphics rysownica)
            {
                SolidBrush pędzel = new SolidBrush(kontrolka.BackColor);
                rysownica.FillRectangle(pędzel, X - bok / 2, Y - bok / 2, bok, bok);
            }

            public override void PrzesuńDoNowegoXY(Control kontrolka, Graphics rysownica, int xp, int yp)
            {
                Wymaż(kontrolka, rysownica);
                X = xp;
                Y = yp;
                Wykreśl(rysownica);
            }
        }
    }
}
