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
                BG_Walec, BG_Stożek, BG_Kula, BG_Graniastosłup, BG_Ostrosłup, BG_Sześcian, BG_GraniastosłupPochyły
            }

            protected int XsP, YsP;
            protected Color KolorLinii;
            protected DashStyle StylLinii;
            protected float GrubośćLinii;
            protected int WysokośćBryły;

            protected TypBryłyGeometrycznej RodzajBryły;

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
        public class Wielościany : BryłaAbstrakcyjna
        {
            protected int Promień;
            protected int StopieńWielokątaPodstawy;


            public Wielościany(int R, int StopieńWielokątaPodstawy, Color KolorLinii, DashStyle StylLinii, float GrubośćLinii)
                : base(KolorLinii, StylLinii, GrubośćLinii)
            {
                this.Promień = R;
                this.StopieńWielokątaPodstawy = StopieńWielokątaPodstawy;
            }

            public override void Obróć_i_Wykreś(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {

            }

            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
            {
            }

            public override void Wykreśl(Graphics Rysownica)
            {
            }

            public override void Wymaż(Graphics Rysownica, Control Kontrolka)
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
                this.XsP = XSP;
                this.YsP = YSP;

                this.KątMiędzyWierzchołkami = 360.0F / StopieńWielokątaPodstawy;
                this.KątPołożenia = 0.0F;

                WielokątPodłogi = new Point[StopieńWielokątaPodstawy];
                WielokątSufitu = new Point[StopieńWielokątaPodstawy];

                 KątMiędzyWierzchołkami = 360.0F / StopieńWielokątaPodstawy;

                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                {
                    WielokątPodłogi[i] = new Point();
                    WielokątSufitu[i] = new Point();

                    WielokątPodłogi[i].X = (int)(XSP + OśDuża / 2 * Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F));
                    WielokątPodłogi[i].Y = (int)(YSP + OśMała / 2 * Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F));


                    WielokątSufitu[i].X = (int)(XSP + OśDuża / 2 * Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F));
                    WielokątSufitu[i].Y = (int)(YSP + OśMała / 2 * Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F) - WysokośćWalca);
                }
            }

            public override void Wykreśl(Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(this.KolorLinii, GrubośćLinii))
                {
                    Pióro.DashStyle = this.StylLinii;

                    float krok = 360.0F / StopieńWielokątaPodstawy;

                    Rysownica.DrawEllipse(Pióro, this.XsP - this.OśDuża / 2,
                                                 this.YsP - this.OśMała / 2,
                                                 OśDuża, OśMała);
                    Rysownica.DrawEllipse(Pióro, this.XsS - this.OśDuża / 2,
                                                 this.YsS - this.OśMała / 2,
                                                 OśDuża, OśMała);

                    Rysownica.DrawLine(Pióro, XsP - OśDuża / 2,
                        this.YsP, XsS - OśDuża / 2, this.YsS);
                    Rysownica.DrawLine(Pióro, XsP + OśDuża / 2,
                      this.YsP, XsS + OśDuża / 2, this.YsS);

                    Pióro.Width /= 2;
                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        float kąt = KątPołożenia + i * krok;
                        WielokątPodłogi[i].X = (int)(XsP + OśDuża / 2 * Math.Cos(Math.PI * kąt / 180F));
                        WielokątPodłogi[i].Y = (int)(YsP + OśMała / 2 * Math.Sin(Math.PI * kąt / 180F));
                        WielokątSufitu[i].X = (int)(XsS + OśDuża / 2 * Math.Cos(Math.PI * kąt / 180F));
                        WielokątSufitu[i].Y = (int)(YsS + OśMała / 2 * Math.Sin(Math.PI * kąt / 180F));
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                    }

                    KątPołożenia += krok;
                }
            }
            public override void Wymaż(Graphics Rysownica, Control Kontrolka)
            {
                using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                {
                    Pióro.DashStyle = this.StylLinii;

                    float krok = 360.0F / StopieńWielokątaPodstawy;

                    Rysownica.DrawEllipse(Pióro, this.XsP - this.OśDuża / 2,
                                                 this.YsP - this.OśMała / 2,
                                                 OśDuża, OśMała);
                    Rysownica.DrawEllipse(Pióro, this.XsS - this.OśDuża / 2,
                                                 this.YsS - this.OśMała / 2,
                                                 OśDuża, OśMała);

                    Rysownica.DrawLine(Pióro, XsP - OśDuża / 2,
                        this.YsP, XsS - OśDuża / 2, this.YsS);
                    Rysownica.DrawLine(Pióro, XsP + OśDuża / 2,
                      this.YsP, XsS + OśDuża / 2, this.YsS);

                    Pióro.Width /= 2;
                    for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                    {
                        float kąt = KątPołożenia + i * krok;
                        WielokątPodłogi[i].X = (int)(XsP + OśDuża / 2 * Math.Cos(Math.PI * kąt / 180F));
                        WielokątPodłogi[i].Y = (int)(YsP + OśMała / 2 * Math.Sin(Math.PI * kąt / 180F));
                        WielokątSufitu[i].X = (int)(XsS + OśDuża / 2 * Math.Cos(Math.PI * kąt / 180F));
                        WielokątSufitu[i].Y = (int)(YsS + OśMała / 2 * Math.Sin(Math.PI * kąt / 180F));
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                    }

                    KątPołożenia += krok;
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
                    WielokątPodłogi[i].X = (int)(XsP + OśDuża / 2 * Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F));
                    WielokątPodłogi[i].Y = (int)(YsP + OśMała / 2 * Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F));

                    WielokątSufitu[i].X = (int)(XsP + OśDuża / 2 * Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F));
                    WielokątSufitu[i].Y = (int)(YsP + OśMała / 2 * Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F) - WysokośćWalca);
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
                    WielokątPodłogi[i].X = (int)(XsP + OśDuża / 2 * Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F));
                    WielokątPodłogi[i].Y = (int)(YsP + OśMała / 2 * Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F));

                    WielokątSufitu[i].X = (int)(XsP + OśDuża / 2 * Math.Cos(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F));
                    WielokątSufitu[i].Y = (int)(YsP + OśMała / 2 * Math.Sin(Math.PI * (KątPołożenia + i * KątMiędzyWierzchołkami) / 180F) - WysokośćWalca);
                }

                Wykreśl(Rysownica);
            }

        } //++
        public class Stożek : BryłyObrotowe
        {
            protected int XsS, YsS; 
            protected int StopieńWielokątaPodstawy;
            protected float OśDuża, OśMała;
            protected int WysokośćStożka;
            float KątMiędzyWierchołkamiWielokąta;
            float KątPołożeniaPierwszegoWierchołkaWielokąta = 0.0F;

            protected Point[] WelokątPodłogi;
            public Stożek(int R, int WysokośćStoąka, int StopieńWielokąta, int XsP, int YsP, float KątPochyleniaStożka ,Color KolorLinii, DashStyle StylLinii, float GrubośćLinii) :
                base(R, KolorLinii, StylLinii, GrubośćLinii)
            {
                RodzajBryły = TypBryłyGeometrycznej.BG_Stożek;
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
                    WelokątPodłogi[i].Y = (int)(YsP + OśMała / 2.0F + Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierchołkaWielokąta + i * KątMiędzyWierchołkamiWielokąta) / 180));

                }
            }
            public override void Wykreśl(Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(KolorLinii, GrubośćLinii))
                {
                    Rysownica.DrawEllipse(Pióro, XsP - OśDuża / 2, YsP - OśMała / 2, OśDuża, OśMała);
                    Rysownica.DrawLine(Pióro, XsP - OśDuża / 2, YsP, XsS, this.YsS);
                    Rysownica.DrawLine(Pióro, XsP + OśDuża / 2, YsP, XsS, this.YsS);

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
                Wymaż(Rysownica, Kontrolka);

                if (KierunekObrotu)
                    KątPołożeniaPierwszegoWierchołkaWielokąta += KątObrotu;
                else
                    KątPołożeniaPierwszegoWierchołkaWielokąta -= KątObrotu;

                for (int i = 0; i < StopieńWielokątaPodstawy; i++)
                {
                    float angle = (KątPołożeniaPierwszegoWierchołkaWielokąta + i * KątMiędzyWierchołkamiWielokąta) * (float)Math.PI / 180.0F;
                    WelokątPodłogi[i].X = (int)(XsP + OśDuża / 2.0F * (float)Math.Cos(angle));
                    WelokątPodłogi[i].Y = (int)(YsP + OśMała / 2.0F * (float)Math.Sin(angle));
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

        } // ++
        public class Kula : BryłyObrotowe
        {
            protected int StopieńWielokąta;
            float OśDuza, OśMała;
            float KątPołożeniaPirwszegoWierzchołka, KątŚrodkowyWielokąta;
            Point[] WilokątPrzekrojuKuli;
            public Kula(int R, int StopieńWielokąta, int XsP, int YsP, Color KolorLinii, DashStyle StylLinii, float GrubośćLinii) : 
                base(R, KolorLinii, StylLinii, GrubośćLinii)
            {
                this.StopieńWielokąta = StopieńWielokąta;
                this.XsP = XsP;
                this.YsP = YsP;

                OśDuza = 2.0F * R;
                OśMała = R / 2;

                KątŚrodkowyWielokąta = 360F / StopieńWielokąta;
                KątPołożeniaPirwszegoWierzchołka = 0.0f;

                WilokątPrzekrojuKuli = new Point[StopieńWielokąta];

                for (int i = 0; i < StopieńWielokąta; i++)
                {
                    WilokątPrzekrojuKuli[i] = new Point();
                    WilokątPrzekrojuKuli[i].X = (int)(XsP + OśDuza / 2.0f * Math.Cos(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                    WilokątPrzekrojuKuli[i].Y = (int)(YsP + OśMała / 2.0f * Math.Sin(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                }
            }

            public override void Obróć_i_Wykreś(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {
                Wymaż(Rysownica, Kontrolka);

                if (KierunekObrotu)
                    KątPołożeniaPirwszegoWierzchołka += KątObrotu;
                else
                    KątPołożeniaPirwszegoWierzchołka -= KątObrotu;

                for (int i = 0; i < WilokątPrzekrojuKuli.Length - 1; i++)
                {
                    WilokątPrzekrojuKuli[i].X = (int)(XsP + OśDuza / 2.0f * Math.Sin(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                    WilokątPrzekrojuKuli[i].Y = (int)(YsP + OśMała / 2.0f * Math.Cos(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
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

                for (int i = 0; i < WilokątPrzekrojuKuli.Length - 1; i++)
                {
                    WilokątPrzekrojuKuli[i].X = (int)(XsP + OśDuza / 2.0f * Math.Cos(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                    WilokątPrzekrojuKuli[i].Y = (int)(YsP + OśMała / 2f * Math.Sin(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                }

                Wykreśl(Rysownica);
            }

            public override void Wykreśl(Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(KolorLinii, GrubośćLinii))
                {
                    // Малюємо другу кулю горизонтально
                    Rysownica.DrawEllipse(Pióro, XsP - OśDuza / 2.0f, YsP - OśMała / 2.0f, OśDuza, OśMała);

                    // Перераховуємо координати вершин відповідно до горизонтальної кулі
                    for (int i = 0; i < WilokątPrzekrojuKuli.Length - 1; i++)
                    {
                        WilokątPrzekrojuKuli[i].X = (int)(XsP + OśDuza / 2.0f * Math.Cos(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                        WilokątPrzekrojuKuli[i].Y = (int)(YsP + OśMała / 2f * Math.Sin(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                    }

                    // Малюємо першу кулю вертикально
                    Rysownica.DrawEllipse(Pióro, XsP - OśDuza / 2, YsP - OśDuza / 2.0f, OśDuza, OśDuza);

                   

                    // Перераховуємо координати вершин відповідно до вертикальної кулі
                    for (int i = 0; i < WilokątPrzekrojuKuli.Length - 1; i++)
                    {
                        WilokątPrzekrojuKuli[i].X = (int)(XsP + OśMała / 2.0f * Math.Cos(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                        WilokątPrzekrojuKuli[i].Y = (int)(YsP + OśDuza / 2f * Math.Sin(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                    }

                    for (int i = 0; i < WilokątPrzekrojuKuli.Length - 1; i++)
                        Rysownica.DrawLine(Pióro, WilokątPrzekrojuKuli[i],new Point(XsP, YsP));
                }
            }

            public override void Wymaż(Graphics Rysownica, Control Kontrolka)
            {
                using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                {
                    // Малюємо другу кулю горизонтально
                    Rysownica.DrawEllipse(Pióro, XsP - OśDuza / 2.0f, YsP - OśMała / 2.0f, OśDuza, OśMała);

                    // Перераховуємо координати вершин відповідно до горизонтальної кулі
                    for (int i = 0; i < WilokątPrzekrojuKuli.Length - 1; i++)
                    {
                        WilokątPrzekrojuKuli[i].X = (int)(XsP + OśDuza / 2.0f * Math.Cos(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                        WilokątPrzekrojuKuli[i].Y = (int)(YsP + OśMała / 2f * Math.Sin(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                    }

                    // Малюємо першу кулю вертикально
                    Rysownica.DrawEllipse(Pióro, XsP - OśDuza / 2, YsP - OśDuza / 2.0f, OśDuza, OśDuza);

                    // Перераховуємо координати вершин відповідно до вертикальної кулі
                    for (int i = 0; i < WilokątPrzekrojuKuli.Length - 1; i++)
                    {
                        WilokątPrzekrojuKuli[i].X = (int)(XsP + OśMała / 2.0f * Math.Cos(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                        WilokątPrzekrojuKuli[i].Y = (int)(YsP + OśDuza / 2f * Math.Sin(Math.PI * (KątPołożeniaPirwszegoWierzchołka + i * KątŚrodkowyWielokąta) / 180f));
                    }

                    for (int i = 0; i < WilokątPrzekrojuKuli.Length - 1; i++)
                        Rysownica.DrawLine(Pióro, WilokątPrzekrojuKuli[i].Y, WilokątPrzekrojuKuli[i].X, XsP, YsP);
                }
            }
        } // +
        public class Graniastosłup : Wielościany
        {
            float Oś_duża, Oś_mała;
            float KątPołożeniaPierwszegoWierzchołka;
            Point[] WielokątPodłogi;
            Point[] WielokątSufitu;
            int XsS, YsS;
            public Graniastosłup(int R,int Wysokość , int StopieńWielokątaPodstawy,int XsS, int YsS, int XsP, int YsP ,
                Color KolorLinii, DashStyle StylLinii, float GrubośćLinii) 
                : base(R, StopieńWielokątaPodstawy, KolorLinii, StylLinii, GrubośćLinii)
            {
                this.RodzajBryły = TypBryłyGeometrycznej.BG_Graniastosłup;
                this.WysokośćBryły = Wysokość;
                this.StopieńWielokątaPodstawy = StopieńWielokątaPodstawy;
                this.Oś_duża = this.Promień * 2.0f;
                this.Oś_mała = this.Promień / 2.0f;
                this.XsS = XsS;
                this.YsS = YsS; 
                this.XsP = XsP;
                this.YsP = YsP;

                float KątMiędzyWierchołkami = 360.0f / StopieńWielokątaPodstawy;

                this.KątPołożeniaPierwszegoWierzchołka = 0.0f;

                this.WielokątPodłogi = new Point[StopieńWielokątaPodstawy + 1];
                this.WielokątSufitu = new Point[StopieńWielokątaPodstawy + 1];

                for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                {
                    WielokątPodłogi[i] = new Point();
                    WielokątSufitu[i] = new Point();

                    WielokątPodłogi[i].X = (int)(this.XsP + Oś_duża / 2 * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołka + i * KątMiędzyWierchołkami) / 180F));
                    WielokątPodłogi[i].Y = (int)(this.YsP + Oś_mała / 2 * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka + i * KątMiędzyWierchołkami) / 180F));
                    // "sufit" Walca
                    WielokątSufitu[i].X = WielokątPodłogi[i].X;
                    WielokątSufitu[i].Y = WielokątPodłogi[i].Y - Wysokość;
                }
            }

            public override void Obróć_i_Wykreś(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {
                Wymaż(Rysownica,Kontrolka);

                if (!KierunekObrotu)
                    this.KątPołożeniaPierwszegoWierzchołka += KątObrotu;
                else
                    KątPołożeniaPierwszegoWierzchołka -= KątObrotu;

                float KątMiędzyWierchołkami = 360.0f / StopieńWielokątaPodstawy;

                for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                {
                    WielokątPodłogi[i] = new Point();
                    WielokątSufitu[i] = new Point();

                    WielokątPodłogi[i].X = (int)(this.XsP + Oś_duża / 2 * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołka + i * KątMiędzyWierchołkami) / 180F));
                    WielokątPodłogi[i].Y = (int)(this.YsP + Oś_mała / 2 * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka + i * KątMiędzyWierchołkami) / 180F));
                    // "sufit" Walca
                    WielokątSufitu[i].X = WielokątPodłogi[i].X;
                    WielokątSufitu[i].Y = WielokątPodłogi[i].Y - WysokośćBryły;
                }

                Wykreśl(Rysownica);
            }

            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
            {
                Wymaż(Rysownica, Kontrolka);

                XsP = X; YsP = Y;
                XsS = X; YsS = Y - WysokośćBryły;

                float KątMiędzyWierchołkami = 360.0f / StopieńWielokątaPodstawy;

                for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                {
                    WielokątPodłogi[i] = new Point();
                    WielokątSufitu[i] = new Point();

                    WielokątPodłogi[i].X = (int)(this.XsP + Oś_duża / 2 * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołka + i * KątMiędzyWierchołkami) / 180F));
                    WielokątPodłogi[i].Y = (int)(this.YsP + Oś_mała / 2 * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka + i * KątMiędzyWierchołkami) / 180F));
                    
                    WielokątSufitu[i].X = WielokątPodłogi[i].X;
                    WielokątSufitu[i].Y = WielokątPodłogi[i].Y - WysokośćBryły;
                }

                Wykreśl(Rysownica);
            }

            public override void Wykreśl(Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(this.KolorLinii, this.GrubośćLinii))
                {
                    Pióro.DashStyle = this.StylLinii;

                    for (int i = 0; i < WielokątPodłogi.Length - 1; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątPodłogi[i + 1]);
                    for (int i = 0; i < WielokątSufitu.Length - 1; i++)
                        Rysownica.DrawLine(Pióro, WielokątSufitu[i], WielokątSufitu[i + 1]);
                    for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                }
            }

            public override void Wymaż(Graphics Rysownica, Control Kontrolka)
            {
                using (Pen Pióro = new Pen(Kontrolka.BackColor, this.GrubośćLinii))
                {
                    Pióro.DashStyle = this.StylLinii;

                    for (int i = 0; i < WielokątPodłogi.Length - 1; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątPodłogi[i + 1]);
                    for (int i = 0; i < WielokątSufitu.Length - 1; i++)
                        Rysownica.DrawLine(Pióro, WielokątSufitu[i], WielokątSufitu[i + 1]);
                    for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                }
            }
        } //++
        public class GraniastosłupPochyły : Wielościany
        {
            float Oś_duża, Oś_mała;
            float KątPołożeniaPierwszegoWierzchołka;
            Point[] WielokątPodłogi;
            Point[] WielokątSufitu;
            int XsS, YsS;
            float KątNachylenia;

            public GraniastosłupPochyły(int R, int Wysokość, int StopieńWielokątaPodstawy, int XsS, int YsS, int XsP, int YsP,
                Color KolorLinii, DashStyle StylLinii, float GrubośćLinii, float KątNachylenia)
                : base(R, StopieńWielokątaPodstawy, KolorLinii, StylLinii, GrubośćLinii)
            {
                this.RodzajBryły = TypBryłyGeometrycznej.BG_GraniastosłupPochyły;
                this.WysokośćBryły = Wysokość;
                this.StopieńWielokątaPodstawy = StopieńWielokątaPodstawy;
                this.Oś_duża = this.Promień * 2.0f;
                this.Oś_mała = this.Promień / 2.0f;
                this.XsS = XsS;
                this.YsS = YsS;
                this.XsP = XsP;
                this.YsP = YsP;
                this.KątNachylenia = KątNachylenia;

                float KątMiędzyWierchołkami = 360.0f / StopieńWielokątaPodstawy;

                this.KątPołożeniaPierwszegoWierzchołka = 0.0f;

                this.WielokątPodłogi = new Point[StopieńWielokątaPodstawy + 1];
                this.WielokątSufitu = new Point[StopieńWielokątaPodstawy + 1];

                for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                {
                    WielokątPodłogi[i] = new Point();
                    WielokątSufitu[i] = new Point();

                    float kąt = (KątPołożeniaPierwszegoWierzchołka + i * KątMiędzyWierchołkami) * (float)Math.PI / 180.0f;

                    float xPodłogi = (float)(XsP + Oś_duża / 2 * Math.Cos(kąt));
                    float yPodłogi = (float)(YsP + Oś_mała / 2 * Math.Sin(kąt));

                    float nachylenieRad = KątNachylenia * (float)Math.PI / 180.0f;
                    float xSufitu = xPodłogi + Wysokość * (float)Math.Sin(nachylenieRad);
                    float ySufitu = yPodłogi - Wysokość * (float)Math.Cos(nachylenieRad);

                    WielokątPodłogi[i].X = (int)xPodłogi;
                    WielokątPodłogi[i].Y = (int)yPodłogi;
                    WielokątSufitu[i].X = (int)xSufitu;
                    WielokątSufitu[i].Y = (int)ySufitu;
                }
            }

            public override void Obróć_i_Wykreś(Control Kontrolka, Graphics Rysownica, float KątObrotu)
            {
                Wymaż(Rysownica, Kontrolka);

                if (!KierunekObrotu)
                    this.KątPołożeniaPierwszegoWierzchołka += KątObrotu;
                else
                    KątPołożeniaPierwszegoWierzchołka -= KątObrotu;

                float KątMiędzyWierchołkami = 360.0f / StopieńWielokątaPodstawy;

                for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                {
                    WielokątPodłogi[i] = new Point();
                    WielokątSufitu[i] = new Point();

                    float x = (float)(this.XsP + Oś_duża / 2 * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołka + i * KątMiędzyWierchołkami) / 180F));
                    float y = (float)(this.YsP + Oś_mała / 2 * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka + i * KątMiędzyWierchołkami) / 180F));

                    float radians = KątNachylenia * (float)Math.PI / 180.0f;
                    float cos = (float)Math.Cos(radians);
                    float sin = (float)Math.Sin(radians);
                    float newX = x * cos - y * sin;
                    float newY = x * sin + y * cos;

                    WielokątPodłogi[i].X = (int)newX;
                    WielokątPodłogi[i].Y = (int)newY;

                    WielokątSufitu[i].X = WielokątPodłogi[i].X;
                    WielokątSufitu[i].Y = WielokątPodłogi[i].Y - WysokośćBryły;
                }

                Wykreśl(Rysownica);
            }
            public override void PrzesuńDoNowegoXY(Control Kontrolka, Graphics Rysownica, int X, int Y)
            {
                Wymaż(Rysownica, Kontrolka);

                XsP = X;
                YsP = Y;
                XsS = X;
                YsS = Y - WysokośćBryły;

                float KątMiędzyWierchołkami = 360.0f / StopieńWielokątaPodstawy;

                for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                {
                    WielokątPodłogi[i] = new Point();
                    WielokątSufitu[i] = new Point();

                    float x = (float)(this.XsP + Oś_duża / 2 * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołka + i * KątMiędzyWierchołkami) / 180F));
                    float y = (float)(this.YsP + Oś_mała / 2 * Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka + i * KątMiędzyWierchołkami) / 180F));

                    float radians = KątNachylenia * (float)Math.PI / 180.0f;
                    float cos = (float)Math.Cos(radians);
                    float sin = (float)Math.Sin(radians);
                    float newX = x * cos - y * sin;
                    float newY = x * sin + y * cos;

                    WielokątPodłogi[i].X = (int)newX;
                    WielokątPodłogi[i].Y = (int)newY;

                    WielokątSufitu[i].X = WielokątPodłogi[i].X - WysokośćBryły;
                    WielokątSufitu[i].Y = WielokątPodłogi[i].Y - WysokośćBryły;
                }

                Wykreśl(Rysownica);
            }

            public override void Wykreśl(Graphics Rysownica)
            {
                using (Pen Pióro = new Pen(this.KolorLinii, this.GrubośćLinii))
                {
                    Pióro.DashStyle = this.StylLinii;

                    for (int i = 0; i < WielokątPodłogi.Length - 1; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątPodłogi[i + 1]);

                    for (int i = 0; i < WielokątSufitu.Length - 1; i++)
                        Rysownica.DrawLine(Pióro, WielokątSufitu[i], WielokątSufitu[i + 1]);

                    Rysownica.DrawLine(Pióro, WielokątPodłogi[WielokątPodłogi.Length - 1], WielokątPodłogi[0]);
                    Rysownica.DrawLine(Pióro, WielokątSufitu[WielokątSufitu.Length - 1], WielokątSufitu[0]);

                    for (int i = 0; i < WielokątPodłogi.Length; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                }
            }

            public override void Wymaż(Graphics Rysownica, Control Kontrolka)
            {
                using (Pen Pióro = new Pen(Kontrolka.BackColor, this.GrubośćLinii))
                {
                    Pióro.DashStyle = this.StylLinii;

                    for (int i = 0; i < WielokątPodłogi.Length - 1; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątPodłogi[i + 1]);
                    for (int i = 0; i < WielokątSufitu.Length - 1; i++)
                        Rysownica.DrawLine(Pióro, WielokątSufitu[i], WielokątSufitu[i + 1]);
                    for (int i = 0; i <= StopieńWielokątaPodstawy; i++)
                        Rysownica.DrawLine(Pióro, WielokątPodłogi[i], WielokątSufitu[i]);
                }
            }
        } //+
    }
}
