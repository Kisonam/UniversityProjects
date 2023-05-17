using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNr3_Radovskyi61986
{
    internal class BryłyGeometryczne
    {
        public abstract class BryłaAbstrakcyjna
        {
            public enum TypBryłyGeometrycznej
            {
                BG_Walec, BG_Stożek, BG_Kula, BG_Graniastosłup, BG_Ostrosłup, BG_Sześcian
            }

            protected int XsP, YsP;
            protected Color KolorLinii;
            protected DashStyle StylLinii;
            protected float GrubośćLinii;

            protected TypBryłyGeometrycznej TRodzajBryły;

            public BryłaAbstrakcyjna(Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
            {
                this.KolorLinii = KolorLinii;
                this.StylLinii = StylLinii;
                this.GrubośćLinii = GrubośćLinii;
            }

            public abstract void Wykreśl(Graphics Rysownica);
            public abstract void Wymaż(Graphics Rysownica, Control Kontrolka);
            public abstract void Obróć_i_Wykreś(Control Kontrolka, Graphics Rysownica, float KątObrotu);
            public abstract void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y);

        }

        public class BryłyObrotowe : BryłaAbstrakcyjna
        {
            public int PromińBryłu
            {
                get;
                protected set;
            }

            public BryłyObrotowe(int R,Color KolorLinii, DashStyle StylLinii, float GrubośćLinii) : base(KolorLinii, StylLinii, GrubośćLinii)
            {
                PromińBryłu = R;
            }

            public override void Wykreśl(Graphics Rysownica)
            {

            }
            public override void Wymaż(Graphics Rysownica, Control Kontrolka)
            {

            }
            public override void Obróć_i_Wykreś(Control Kontrolka, Graphics Rysownica, float KątObrotu) 
            {

            }
            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
            {

            }
        }
        public class Walec : BryłyObrotowe
        {
            public Walec(int R, Color KolorLinii, DashStyle StylLinii, float GrubośćLinii) : base(R, KolorLinii, StylLinii, GrubośćLinii)
            {

            }
        }
        public class Stożek : BryłyObrotowe
        {
            protected int XsS, YsS;
            protected int StopieńWielokątaPodstawy;

            protected float OśDuża, OśMała;
            protected int WysokośćStożka;

            protected Point[] WelokątPodłogi;
            public Stożek(int R, int WysokośćStoąka, int StopieńWielokąta, int XsP, int YsP, Color KolorLinii, DashStyle StylLinii, float GrubośćLinii) :
                base(R, KolorLinii, StylLinii, GrubośćLinii)
            {
                TRodzajBryły = TypBryłyGeometrycznej.BG_Stożek;
                this.WysokośćStożka = WysokośćStoąka;
                this.StopieńWielokątaPodstawy = StopieńWielokąta;
                OśDuża = 2 * PromińBryłu; // lub 2 * R
                OśMała = PromińBryłu / 2;
                XsS = XsP;
                YsS = YsP - WysokośćStoąka;
                this.XsP = XsP;
                this.YsP = YsP;

                float KątMiędzyWierchołkamiWielokąta = 360.0F / StopieńWielokąta;
                float KątPołożeniaPierwszegoWierchołkaWielokąta = 0.0F;

                WelokątPodłogi = new Point[StopieńWielokątaPodstawy];

                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                {
                    WelokątPodłogi[i] = new Point();

                    WelokątPodłogi[i].X = (int)(XsP + OśDuża / 2.0F + Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierchołkaWielokąta + i * KątMiędzyWierchołkamiWielokąta) / 180));
                    WelokątPodłogi[i].Y = (int)(YsP + OśMała / 2.0F + Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierchołkaWielokąta + i * KątMiędzyWierchołkamiWielokąta) / 180));

                }
            }
            public override void Wykreśl(Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(KolorLinii, GrubośćLinii))
                {
                    Rysownica.DrawEllipse(Pióro, XsP - OśDuża / 2, YsP - OśMała / 2, OśDuża, OśMała);
                    Rysownica.DrawLine(Pióro, XsP - OśDuża / 2, YsP, XsS, YsS);
                    Rysownica.DrawLine(Pióro, XsP + OśDuża / 2, YsP, XsS, YsS);

                    Pióro.Width = Pióro.Width / 2.0f;

                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        Rysownica.DrawLine(Pióro, WelokątPodłogi[i], new Point(XsS, YsS));
                    }

                }
            }

            public override void Wymaż(Graphics Rysownica, Control Kontrolka)
            {
                using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                {
                    Rysownica.DrawEllipse(Pióro, XsP - OśDuża / 2, YsP - OśMała / 2, OśDuża, OśMała);
                    Rysownica.DrawLine(Pióro, XsP - OśDuża / 2, YsP, XsS, YsS);
                    Rysownica.DrawLine(Pióro, XsP + OśDuża / 2, YsP, XsS, YsS);

                    Pióro.Width = Pióro.Width / 2.0f;

                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        Rysownica.DrawLine(Pióro, WelokątPodłogi[i], new Point(XsS, YsS));
                    }

                }
            }
            public override void Obróć_i_Wykreś(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {
                Wymaż(Rysownica, Kontrolka);
            }
        }
        public class Kula : BryłyObrotowe
        {
            public Kula(int R, int WysokośćStoąka, int StopieńWielokąta, int XsP, int YsP, Color KolorLinii, DashStyle StylLinii, float GrubośćLinii) : 
                base(R, KolorLinii, StylLinii, GrubośćLinii)
            {
                
            }
        }
    }
}
