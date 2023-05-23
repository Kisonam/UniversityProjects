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

            protected bool KierunekObrotu;

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
            protected int WysokośćWalca;

            Point[] WielokątSufitu;
            Point[] WielokątPodłogi;

            int StopieńWielokątaPodstawy;
            int XsS, YsS;
            int WektorPrzesunięciaŚrodkaSufituWalca;

            float KątMiędzyWierzchołkami;
            float OśDuża, OśMała;
            float KątPołożenia;
            
            public Walec(int R, int WysokośćWalca, int StopieńWielokątaPodstawy, int XSP, int YSP, Color KolorLinii, DashStyle StylLinii, float GrubośćLinii) 
                : base(R, KolorLinii, StylLinii, GrubośćLinii)
            {
                this.WysokośćWalca = WysokośćWalca;
                this.StopieńWielokątaPodstawy = StopieńWielokątaPodstawy;
                OśDuża = this.PromińBryłu * 2;
                OśMała = this.PromińBryłu / 2;

                this.YsS = YSP - WysokośćWalca;
                this.XsS = XSP;
                this.YsS = YSP;
                this.XsP = XSP;
                this.YsP = YSP;

                this.KątMiędzyWierzchołkami = 360.0F / StopieńWielokątaPodstawy;

                this.KątPołożenia = 0.0F;

                WielokątPodłogi = new Point[StopieńWielokątaPodstawy];
                WielokątSufitu = new Point[StopieńWielokątaPodstawy];

                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
{
                    WielokątPodłogi[i] = new Point();
                    WielokątSufitu[i] = new Point();
                    // "podłoga" Walca
                    WielokątPodłogi[i].X = (int)(this.XsP + OśDuża / 2 * Math.Cos(Math.PI * (KątPołożenia +i * KątMiędzyWierzchołkami)  / 180F));
                    WielokątPodłogi[i].X = (int)(this.YsP + OśMała / 2 * Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F));
                    // "sufit" Walca
                    WielokątSufitu[i].X = (int)(this.XsS + OśDuża / 2 * Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F));
                    WielokątSufitu[i].Y = (int)(this.YsS + OśMała / 2 * Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F));
                }
            }

            public override void Wykreśl(Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(this.KolorLinii, GrubośćLinii))
                {
                    Pióro.DashStyle = this.StylLinii;

                    Rysownica.DrawEllipse(Pióro, this.XsP - this.OśDuża / 2,
                                                 this.YsP - this.OśMała / 2,
                                                 OśDuża, OśMała);
                    Rysownica.DrawEllipse(Pióro, this.XsS - this.OśDuża / 2,
                                                 this.YsS - this.OśMała / 2,
                                                 OśDuża, OśMała);

                    Rysownica.DrawLine(Pióro, XsP - OśDuża / 2,
                        this.YsP, XsS - OśDuża / 2, YsS);
                    Rysownica.DrawLine(Pióro, XsP + OśDuża / 2,
                      this.YsP, XsS + OśDuża / 2, YsS);

                    Pióro.Width /= 2;
                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                    }
                }
            }
            public override void Wymaż(Graphics Rysownica, Control Kontrolka)
            {
                using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                {
                    Pióro.DashStyle = StylLinii;

                    Rysownica.DrawEllipse(Pióro, this.XsP - this.OśDuża / 2,
                                               this.YsP - this.OśMała / 2,
                                               OśDuża, OśMała);
                    Rysownica.DrawEllipse(Pióro, this.XsS - this.OśDuża / 2,
                                                 this.YsS - this.OśMała / 2,
                                                 OśDuża, OśMała);

                    Rysownica.DrawLine(Pióro, XsP - OśDuża / 2,
                        this.YsP, XsS - OśDuża / 2, YsS);
                    Rysownica.DrawLine(Pióro, XsP + OśDuża / 2,
                      this.YsP, XsS + OśDuża / 2, YsS);

                    Pióro.Width /= 2;
                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                    }
                }
            }

            public override void Obróć_i_Wykreś(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {
                Wymaż(Rysownica, Kontrolka);

                if (!KierunekObrotu)
                    KątPołożenia += KątObrotu;
                else
                    KątPołożenia -= KątObrotu;

                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                {
                    WielokątPodłogi[i].X = (int)(XsP + OśDuża / 2.0F + Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180));
                    WielokątPodłogi[i].Y = (int)(YsP + OśMała / 2.0F + Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180));

                    WielokątSufitu[i].X = WielokątPodłogi[i].X;
                    WielokątSufitu[i].Y = WielokątPodłogi[i].Y - WysokośćWalca;
                }

                Wykreśl(Rysownica);
            }

            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
            {
                int dX, dY;
                Wymaż(Rysownica, Kontrolka);

                dX = XsP < X ? dX = X - XsP : -(XsP - X);
                dY = YsP < Y ? dY = Y - YsP : -(YsP - Y);

                XsP = XsP + dX;
                YsP = YsP + dY;
                XsS = XsS + dX;
                YsS = YsS + dY;

                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                {
                    WielokątPodłogi[i].X = (int)(XsP + OśDuża / 2.0F + Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180));
                    WielokątPodłogi[i].Y = (int)(YsP + OśMała / 2.0F + Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180));

                    WielokątSufitu[i].X = WielokątPodłogi[i].X;
                    WielokątSufitu[i].Y = WielokątPodłogi[i].Y - WysokośćWalca;
                }

                Wykreśl(Rysownica);
            }

        }
        public class Stożek : BryłyObrotowe
        {
            protected int XsS, YsS; 
            protected int StopieńWielokątaPodstawy;
            protected float OśDuża, OśMała;
            protected int WysokośćStożka;
            float KątMiędzyWierchołkamiWielokąta;
            float KątPołożeniaPierwszegoWierchołkaWielokąta = 0.0F;

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

                KątMiędzyWierchołkamiWielokąta = 360.0F / StopieńWielokąta;
                //float KątPołożeniaPierwszegoWierchołkaWielokąta = 0.0F;

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

                    Pióro.Width /= 2.0f;

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
                float KątPołożenia;

                Wymaż(Rysownica, Kontrolka);

                if (KierunekObrotu)
                    KątPołożeniaPierwszegoWierchołkaWielokąta += KątObrotu;
                else
                    KątPołożeniaPierwszegoWierchołkaWielokąta -= KątObrotu;

                float KątMiędzyPierwszegoWierchołkaWielokąta = 360.0f / StopieńWielokątaPodstawy;

                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                {
                    WelokątPodłogi[i].X = (int)(XsP + OśDuża / 2.0F + Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierchołkaWielokąta + i * KątMiędzyWierchołkamiWielokąta) / 180));
                    WelokątPodłogi[i].Y = (int)(YsP + OśMała / 2.0F + Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierchołkaWielokąta + i * KątMiędzyWierchołkamiWielokąta) / 180));
                }
                Wykreśl(Rysownica);

            }
            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
            {
                int dX, dY;
                Wymaż(Rysownica, Kontrolka);

                dX = XsP < X ? dX = X - XsP : -(XsP - X);
                dY = YsP < Y ? dY = Y - YsP : -(YsP - Y);

                XsP = XsP + dX;
                YsP = YsP + dY;
                XsS = XsS + dX;
                YsS = YsS + dY;

                float KątMiędzyWierzchowkamiWielokąta = 360.0F / StopieńWielokątaPodstawy;
                float KątPołożeniaPierwszegoWierzchołka = 0.0F;

                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                {
                    WelokątPodłogi[i] = new Point();
                    WelokątPodłogi[i].X = (int)(XsP + OśDuża / 2.0F + Math.Cos(Math.PI * (KątMiędzyWierzchowkamiWielokąta + i * KątMiędzyWierzchowkamiWielokąta) / 180.0F));
                    WelokątPodłogi[i].Y = (int)(YsP + OśMała / 2.0F + Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka + i * KątPołożeniaPierwszegoWierzchołka) / 180.0F));
                }
                Wykreśl(Rysownica);
            }

        }
        public class Kula : BryłyObrotowe
        {
            protected int StopieńWielokąta;
            float OśDuza, OśMała;
            float KątPołożeniaPirwszegoWierzchołka, KątŚrodkowyWielokąta;
            Point[] WilokątPrzekrojuKuli;
            public Kula(int R, int WysokośćStoąka, int StopieńWielokąta, int XsP, int YsP, Color KolorLinii, DashStyle StylLinii, float GrubośćLinii) : 
                base(R, KolorLinii, StylLinii, GrubośćLinii)
            {
                this.StopieńWielokąta = StopieńWielokąta;
                this.XsP = XsP;
                this.YsP = YsP;

                KątŚrodkowyWielokąta = 360F/ StopieńWielokąta;
                KątPołożeniaPirwszegoWierzchołka = 0.0f;

                WilokątPrzekrojuKuli = new Point[StopieńWielokąta];

                for (int i = 0; i < WilokątPrzekrojuKuli.Length - 1; i++)
                {
                    WilokątPrzekrojuKuli[i] = new Point();
                    WilokątPrzekrojuKuli[i].X = (int)(XsP + OśDuza/2.0f * Math.Cos(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                    //WilokątPrzekrojuKuli[i].Y = (int)(YsP + OśMała/2f * Math.Sin(Math.PI * ()))
                }
            }
        }
    }
}
