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
                Wielokąt
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
        }
    }
}
