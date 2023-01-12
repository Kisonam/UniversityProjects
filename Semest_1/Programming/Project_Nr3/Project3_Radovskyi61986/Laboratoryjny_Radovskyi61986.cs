﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// dodanie nowej grafiki 2D
using System.Drawing.Drawing2D;
using System.Data.SqlTypes;

namespace Project3_Radovskyi61986
{
    public partial class Laboratoryjny_Radovskyi61986 : Form
    { // deklaracje stałej dla określenia PromieniaPunktu
        const ushort PromieńPunktu = 2;
        // deklaracja zmiennych referencyjnych narzędni grafichnych
        Graphics Rysownica;
        Pen Pióro;
        SolidBrush Pędzle;
        Point Punkt = Point.Empty;

        public Laboratoryjny_Radovskyi61986()
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

        private void pbRisownica_MouseDown(object sender, MouseEventArgs e)
        {
            // wizualizacja wpółrzędnych aktualnego położenia myszy
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();
            //obsługa zdarzenia MouseDown
            if (e.Button == MouseButtons.Left)
            {// przechowanie wspołorzędnych poleżonia "Myszy" w zmiennej Punkt
               Punkt =  e.Location;
            }


        }

        private void pbRisownica_MouseUp(object sender, MouseEventArgs e)
        {
            // wizualizacja wpółrzędnych aktualnego położenia myszy
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();
            //
            int LewyGórnyX = (Punkt.X > e.Location.X) ? e.Location.X : Punkt.X;
            int LewyGórnyY = (Punkt.Y > e.Location.Y) ? e.Location.Y : Punkt.Y;
            int Szerokość = Math.Abs(Punkt.X - e.Location.X);
            int Wysokość = Math.Abs(Punkt.Y - e.Location.Y);

            // sprawdzenie, czy zdarzenie MouseUp 'pochodz1' od lewego przychisku
            if (e.Button == MouseButtons.Left)
            {
                // rozpoznanie zaznaczonej controlki radioButton

                //Czy to jest Punkt
                if (rdbPunkt.Checked)
                {
                    // tak to wykreślamy punkt
                    Rysownica.FillEllipse(Pędzle, Punkt.X - PromieńPunktu, 
                        Punkt.Y - PromieńPunktu, 
                        2 * PromieńPunktu,
                        2 * PromieńPunktu);
                    // czy zaznaczona (wybrana) jest kontrolka RadioButton dla 'LiniiProstej'
                    
                }
                if (rdbLiniaProsta.Checked)
                    Rysownica.DrawLine(Pióro, Punkt.X,
                                        Punkt.Y,
                                        e.Location.X,
                                        e.Location.Y);
                if (rdbLiniaKreślena.Checked)
                    Rysownica.DrawLine(Pióro, Punkt.X, Punkt.Y,
                                              e.Location.X, e.Location.Y);
                // foremny
                if (rdbWielokatForemny.Checked)
                {
                    ushort StopieńWielokąt = (ushort)NumU.Value;
                    int R = Szerokość;
                    double KątMiędzWierzchołkamiWielokta = 360.0 / StopieńWielokąt;
                    double KątPołożeniaPierwszegoWierzchowka = 0.0;
                    //
                    NumU.Enabled = false;
                    //
                    Point[] WierzchołkiWielokąta = new Point[StopieńWielokąt];
                    for (int i = 0; i < StopieńWielokąt; i++)
                    {
                        WierzchołkiWielokąta[i].X = LewyGórnyX + (int)(R * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchowka + i * KątMiędzWierzchołkamiWielokta) / 100.0));
                        WierzchołkiWielokąta[i].Y = LewyGórnyY - (int)(R * Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchowka + i * KątMiędzWierzchołkamiWielokta) / 100.0));
                    }
                    Rysownica.FillPolygon(Pędzle,WierzchołkiWielokąta);
                }

            }
            pbRisownica.Refresh();
        }

        private void pbRisownica_MouseMove(object sender, MouseEventArgs e)
        {
            // wizualizacja wpółrzędnych aktualnego położenia myszy
            lblX.Text = e.Location.X.ToString();
            lblY.Text = e.Location.X.ToString();
            //obsługa zdarzenia MouseDown
            if (e.Button == MouseButtons.Left)
            {// przechowanie wspołorzędnych poleżonia "Myszy" w zmiennej Punkt
                if (rdbLiniaKreślena.Checked)
                {
                    // tak to wykreślamy punkt
                    Rysownica.DrawLine(Pióro, Punkt.X, Punkt.Y,
                                                    e.Location.X, e.Location.Y);
                    // uaktualnie współrzędnych przechowywanych w zmiennej Punkt od ktorego będzie wykreślany następny odcinek prostej
                    Punkt = e.Location;
                }

            }
            pbRisownica.Refresh();
        }

        private void rdbWielokatForemny_CheckedChanged(object sender, EventArgs e)
        {
            // rozpoznanie stanu kontrolki rdbWielokąt
            if (rdbWielokatForemny.Checked)
            {
                MessageBox.Show("Wykreślenie wielokąta foremnego wymaga ustalenia liczby jego kątów (minimalna liczba kątów, to 3!)", "Wykreślenie foramego"
                    ,MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblLiczba.Visible = true;
                NumU.Visible = true;

                NumU.Minimum = 3;
                // ustawienie stanu aktualności dla kontrolki NumU
            }
            else
            {
                lblLiczba.Visible = false;
                NumU.Visible = false;
            }
        }
    }
}
