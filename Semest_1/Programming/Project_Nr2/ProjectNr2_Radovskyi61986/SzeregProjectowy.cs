using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjectNr2_Radovskyi61986
{
    public partial class SzeregProjectowy : Form
    {
        // deklaracja zminnej tablicowej (referencyjnej)
        float[,] TWS;
        const float DgPrzedziauX = float.MinValue;
        const float GgPrzedziauX = float.MaxValue;
        public SzeregProjectowy()
        {
            InitializeComponent();
        }

        private void chtWykresSzeregu_Click(object sender, EventArgs e)
        {

        }

        private void SzeregProjectowy_Load(object sender, EventArgs e)
        {

        }

        private void SzeregProjectowy_FormClosing(object sender, FormClosingEventArgs e)
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
                    if (Formularz.Name == "Project2_Radovskyi61986")
                    { // ukrycie bieżącego formularza
                        this.Hide();
                        // odsłonięcie znalezionego głównego formularza
                        Formularz.Show();
                        // wyjście z metody obsługi zdarzenia FormClosing
                        return;
                    }
                    /* gdy "będziemy tutaj" to będzie to oznaczało, że ktoś
                       skasował formularz główny, ale nie było na nim żadnych 
                       wyników obliczeń, tylko przyciki poleceń, to możemy go
                       odtworzyć; bez sygnalizacji błędu */
                    // utworzenie nowego egzemplarza formularza głównego
                    ProjectNr2_Radovskyi61986 FormularzProjectuNr2 = new ProjectNr2_Radovskyi61986();
                    // ukrycie bieżącego formularza głównego
                    FormularzProjectuNr2.Show();
                    // ukrycie bieżącego formularza
                    this.Hide();
                }
            }
            else
                e.Cancel = true;
        }

        #region Metody pomocnicze dla obsługi przycisków funkcjonalnych
        float ObliczenieSumySzereguPotęngowego(float X, float Eps, out ushort LicznikWyrazów)
        {
            //// obliczamy sume szeregu, tak jak powyżej
            //// ustalenie poczatkowego stanu obliczeń iteracyjnych

            //// powtarzanie obliczania sum szęsciowych szeregu
            //do
            //{
            //    LicznikWyrazów++; // numer kolejnego wyrazu szeregu
            //    S += w; // kolejna suma szeregu
            //    w = w * (-1) * X / LicznikWyrazów; // kolejna wartość wyrazu szeregu
            //} while (Math.Abs(w) > Eps);  
            ////zwrot wyniku


            float S = 0; // suma szeregu
            LicznikWyrazów = 1; // licznik wyrazów szeregu
            float w = 1.0f; // wyraz szeregu

            do
            {
                LicznikWyrazów++;
                S += w;
                w = ((float)Math.Pow(X - 2, LicznikWyrazów)) / ((LicznikWyrazów + 5) * (float)Math.Pow(3, LicznikWyrazów));
            } while (Math.Abs(w) > Eps);

            return S;
        }

        bool Pobierz_X_Eps(out float X, out float Eps)
        { // dla potezeb technicznych
            X = Eps = 0.0f;
            // pobranie wartości zmiennej niezależnej X
            if (!float.TryParse(txtX.Text, out X))
            {// był błąd
                errorProvider1.SetError(txtX, "ERROR: w zapisie wartości zmiennej X" +
                    " wystapił niedozwolony znak ");
                // przerwanie dalszej obcługi zdarzenia Click od przycisku poleceń: buttonObliczWartośćSzeregu_Click
                return false;
            }
            // sprawdzenie, czy pobrana wartości X należy do przedziału zbieżności szeregu
            // .    .   .
            // ustawienie stanu braku aktywności dla kontrolki 'txtX'
            txtX.Enabled = false;

            if (!float.TryParse(textEps.Text, out Eps))
            {
                errorProvider1.SetError(textEps, "ERROR: w zapisie dokładności obliczeń Eps" +
                    " wystapił niedozwolony znak ");
                // przerwanie dalszej obcługi zdarzenia Click od przycisku poleceń: buttonObliczWartośćSzeregu_Click
                return false;
            }
            // sprawdzenie warunku wejściowego dla Eps
            if ((Eps <= 0.0f) || (Eps >= +1.0f))
            {
                errorProvider1.SetError(textEps, "ERROR: wartość dokładności obliczeń Eps" +
                  " musi spełniać warunek wejściowy: 0.0 < Eps < 1.0");
                // przerwanie dalszej obcługi zdarzenia Click od przycisku poleceń: buttonObliczWartośćSzeregu_Click
                return false;
            }
            textEps.Enabled = false;
            // zwrotne przekazanie informacji o braku  błędu
            return true;

        }

        bool Pobranie_Eps_Xd_Xg_h(out float Xd, out float Xg, out float h, out float Eps)
        {// makieta programowa 
            Xd = Xg = h = Eps = 0;
            if (!float.TryParse(txtD.Text, out Xd))
            {
                errorProvider1.SetError(txtD, "ERROR: w zapisie Xd wystąpił niedozwolony znak");
                // przerwanie pobirania danych
                return false;
            }
            // sprawdzenie pobirania danych 
            if ((Xd < DgPrzedziauX) || (Xd > GgPrzedziauX))
            {// błąd, poprawnie Xd nie należy do przedżiału zbieżniści
                errorProvider1.SetError(txtD, "ERROR: podane Xd nie należe przedziału " +
                    "zbiżności szeregu: MaxValue > Xd > MinValue");
                // przerwanie pobirania danych
                return false;
            }
            // pobranie Xg
            if (!float.TryParse(txtG.Text, out Xg))
            {
                errorProvider1.SetError(txtD, "ERROR: w zapisie Xg wystąpił niedozwolony znak");
                // przerwanie pobirania danych
                return false;
            }

            if ((Xg < DgPrzedziauX) || (Xg > GgPrzedziauX))
            {// błąd, poprawnie Xd nie należy do przedżiału zbieżniści
                errorProvider1.SetError(txtG, "ERROR: podane Xg nie należe przedziału " +
                    "zbiżności szeregu: MaxValue > Xg > MinValue");
                // przerwanie pobirania danych
                return false;
            }
            // spawdzenie poprawności kolejności zapisu granice
            if (Xg < Xd)
            {
                errorProvider1.SetError(txtG, "ERROR: granice przedziału zostały zapisane odwrotnie: " +
                   "musi być spełniony tzw. warunek wejściowy: Xd <= Xg");
                // przerwanie pobirania danych
                return false;
            }
            txtD.Enabled = false;
            txtG.Enabled = false;
            // pobranie przyrost h zmian wartości zmiennej niezale znaj X
            if (!float.TryParse(txtH.Text, out h))
            {
                errorProvider1.SetError(txtH, "ERROR: w zapisie wystąpił niedozwolony znak");
                return false;
            }
            // sprawdzenie tzw. warunku wejściowego 
            if (h >= (Xg - Xd))
            {
                errorProvider1.SetError(txtH, "ERROR: podana wartość 'h' nie spełnia warunku wejściowego: h < (Xg - Xd)");

                return false;
            }
            //
            if (!float.TryParse(textEps.Text, out Eps))
            {// jest błąd, to go sygnalizacja
                errorProvider1.SetError(textEps, "ERROR: w zapisie dokładności obliczeń Eps " +
                    "wystąpił niedozwolony znak");
                // przerwanie pobirania danych
                return false;
            }
            // sprawdzenie tzw. warunku wiejściowego dla dokładności
            if ((Eps < 0.0f) || (Eps > 1.0f))
            {

                errorProvider1.SetError(textEps, "ERROR: podana dokładność obliczeń Eps " +
                   "nie spełnia warunku wejściowego (Eps < 0.0f) || (Eps > 1.0f)");
                // przerwanie pobirania danych
                return false;
            }
            return true;
        }

        void TablicowanieWartościSzeregu(float Xd, float Xg, float h, float Eps, out float[,] TWS)
        {
            // dla utworzenia egzamplarza tablicy TWS musimy określić liczbę jej wierszy
            int n = (int)((Xg - Xd) / h + 1);
            // utworzenie egzemplarza tablicy TWS
            TWS = new float[n + 1, 3];
            // stablicowanie wartości szeregu
            // deklaracja zmiennych pomocniczych
            float X;
            int i; // numer podprzedziału
            ushort LicznikZsumowanychWyrazów;
            for (X = Xd, i = 0; i < TWS.GetLength(0); i++, X = Xd + i * h) // nie tak: X = X +h;
            {
                TWS[i, 0] = X;
                TWS[i, 1] = ObliczenieSumySzereguPotęngowego(X, Eps, out LicznikZsumowanychWyrazów);
                TWS[i, 2] = LicznikZsumowanychWyrazów;
            }
        }

        void WpisanieWynikówDoKontrolkiDataGridView(float[,] TWS, DataGridView dgvTWS)
        {
            // wyzerowanie wierszy kontrolki DataGridView
            dgvTWS.Rows.Clear();
            // wpisywanie kolejnych wierszy tablicy TWS do kontrolki dvgTWS
            for (int i = 0; i < TWS.GetLength(0); i++)
            {
                // dodanie nowego wiersza
                dgvTWS.Rows.Add();
                // wpisanie wartości X
                dgvTWS.Rows[i].Cells[0].Value = string.Format($"{TWS[i, 0]:0.00}");
                // wpisanie wartości szeregu
                dgvTWS.Rows[i].Cells[1].Value = string.Format($"{TWS[i, 1]:0.0000}");
                // wpisanie licznika zsumowanych wyrazów
                dgvTWS.Rows[i].Cells[2].Value = string.Format($"{TWS[i, 2]:G}");
            }
        }

        void WpisanieWynikówDoKontrolkiChart(float[,] TWS, Chart chtWykresSzeregu)
        {
            // 1.formatowanie (ustawienie atrybutów) kontrolki Chart, obramowanie kontrolki Chart
            chtWykresSzeregu.BorderlineWidth = 2;
            chtWykresSzeregu.BorderlineColor = Color.Red;
            chtWykresSzeregu.BorderlineDashStyle = ChartDashStyle.DashDotDot;
            // skonfigurowanie kontrolki Chart
            // ustalenie tytułu wykresu
            chtWykresSzeregu.Titles.Add("Wykres zmian wartości szeregu S(x)");
            // umieszczenie legendy pod wykresem
            chtWykresSzeregu.Legends.FindByName("Legend1").Docking = Docking.Bottom;
            //ustawienie koloru tła 
            chtWykresSzeregu.BackColor = Color.LightSkyBlue;
            chtWykresSzeregu.ChartAreas[0].AxisX.Title = "Wartości X";
            chtWykresSzeregu.ChartAreas[0].AxisY.Title = "Wartości S(x)";
            // sformatowanie opisu osi X (kontrolki Chart)
            chtWykresSzeregu.ChartAreas[0].AxisX.LabelStyle.Format = "{0:f2}";
            chtWykresSzeregu.ChartAreas[0].AxisY.LabelStyle.Format = "{0:f2}";
            // 2.formatowanie serii danych dodanej do kontrolki Chart,
            // "wyzerowanie"serii danych kontrolki Chart
            chtWykresSzeregu.Series.Clear();
            //dodanie nowej serii danych
            chtWykresSzeregu.Series.Add("Seria 0");
            // ustalenie nazw osi układu współezędnych
            chtWykresSzeregu.Series[0].XValueMember = "X";
            chtWykresSzeregu.Series[0].XValueMember = "Y";
            // ustalenie widoczności legendy
            chtWykresSzeregu.Series[0].IsVisibleInLegend = true;
            // ustalenie nazwy legendy (opisu linii wykresu)
            chtWykresSzeregu.Series[0].Name = "Wartości szeregu potęgowego S(X)"; // legenda
            // ustalenie typu wykresu
            chtWykresSzeregu.Series[0].ChartType = SeriesChartType.Line; // liniowy
            // ustawienie koloru linii 
            chtWykresSzeregu.Series[0].Color = Color.Black;
            //ustawienie stylu linii 
            chtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.Solid;
            // ustalenie grubości linii
            chtWykresSzeregu.Series[0].BorderWidth = 1;

            /* 3. wpisania współrzędnych (X oraz Y) linii wykresu 
             szeregu (na podstawie zapisanych w tablicy TWS) */
            /* dodanie do serii danych (kontrolki Chart) współrzędnych
               punktów wykresu (wartości X oraz Wartości Y, czyli 
               wartości szeregu: S (X) */
            for (int i = 0; i < TWS.GetLength(0); i++)
            {
                chtWykresSzeregu.Series[0].Points.AddXY(TWS[i, 0], TWS[i, 1]);
            }
        }
        #endregion

        private void buttonObliczWartośćSzeregu_Click(object sender, EventArgs e)
        {

            // "zgaszanie" kontrolki errorProvider, która mogła wcześniej zapalona
            errorProvider1.Dispose();
            // pobranie danych wejściowych
            float X, Eps;
            // pobranie wartości zmiennej niezależnej X
            if (!Pobierz_X_Eps(out X, out Eps)) // (!Pobierz_X_Eps())
            {
                errorProvider1.SetError(txtX, "ERROR: w zapisie wartości zmiennej X" +
                    " wystapił niedozwolony znak ");
                // przerwanie dalszej obcługi zdarzenia Click od przycisku poleceń: buttonObliczWartośćSzeregu_Click
                return;
            }
            // ustawienie stanu braku aktywności kontrolki txtX
            {
                // będziemy tutaj gdy nie było błędu
                // pobranie danych wejściowych
                // pobranie dokładności obliczeń Eps
                if (!float.TryParse(textEps.Text, out Eps))
                {
                    errorProvider1.SetError(textEps, "ERROR: w zapisie dokładności obliczeń Eps" +
                        " wystapił niedozwolony znak ");
                    // przerwanie dalszej obcługi zdarzenia Click od przycisku poleceń: buttonObliczWartośćSzeregu_Click
                    return;
                }
                //// sprawdzenie warunku wejściowego dla Eps
                if ((Eps <= 0.0f) || (Eps >= +1.0f))
                {
                    errorProvider1.SetError(textEps, "ERROR: wartość dokładności obliczeń Eps" +
                      " musi spełniać warunek wejściowy: 0.0 < Eps < 1.0");
                    // przerwanie dalszej obcługi zdarzenia Click od przycisku poleceń: buttonObliczWartośćSzeregu_Click
                    return;
                }
                //// ustawienie stanu braku aktywności kontrolki textEps
                textEps.Enabled = false;
                // będziemy tutaj gdy nie było błędu
                // deklaracje zmiennych dla przechowania wyniku obliczeń
            }

            float SumaSzeregu;
            ushort N; // licznik zsumowanych wyrazów szeregu
            // obliczenie wartości szeregu, czyli wywołanie metody ObliczenieSumySzereguPotęngowego(float X, float Eps, out ushort LicznikWyrazów)
            SumaSzeregu = ObliczenieSumySzereguPotęngowego(X, Eps, out N);
            //wypisanie wyniku obliczeń
            txtSumaSzeregu.Text = SumaSzeregu.ToString();
            txtLicznikWyrazów.Text = N.ToString();
        }

        private void odczytanieTablicyTWSZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            /* "zgaszenie" kontrolki errorProvider, któw mogła zastać 
             zapalona podczas pobierania danych */
            errorProvider1.Dispose();
            /* sprawdzenie, czy zmienna referencyjna ma wartość null 
             (tzw. Pusta referencja do egzamplarza tablicy )*/
            if (!(TWS is null))
            {/* poinformowanie Użytkownika, że egzemlarza tablicy TWS 
              już jest utworzony i czy ma być skasowana dla wczytania elementów tablicy TWS z pliku ma być kontynuowane*/
                DialogResult OknoMessage = MessageBox.Show("UWAGA: egzemplarza tablicy TWS już istnieje! \r\nCzy bieżący egzemplarz tablicy TWS ma być skasowany i w jego miejsce ma być utworzony nowy egzemlarz, do krótkego mają zostać 'wczytane' elementy TWS z pliku? " +
                    "\r\n - kliknij przycisk poleceń 'Tak' dla potwirdzenia wczytanie elementów tablicy TWS z pliku" +
                    "\r\n - kliknij przycisk poleceń 'Nie' dla skasowania polecenia wczytania elementów tablicy TWS z pliku ",
                    "Okno ostrzeżenia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                // rozpoznanie wybrango przycisku poleceń w oknie dialogowym 'MessageBox'
                if (OknoMessage == DialogResult.Yes)
                    TWS = null; /* przypisanie wartości 'null' zmiennej
                                   referencyjnej jest sygnałem dla CLR, że 
                                   egzemplarz tablicy przypisany zmiennej
                                   referencyjnej TWS jest już niepotrzebny i 
                                   może być zwlniony automatycznie przez GC:
                                   tzw. "odśmiecacz" którego zadaniem jest usumowanie 'martwych'
                                   egzemplazy tablic i obiektów */
                else
                {
                    MessageBox.Show("Polecenie odczytania elementów tablicy TWS z pliku zostało anulowane");
                    return;
                }
            }
            // utworzenie egzemplarza okna dialowego dla wyboru pliku do odczytu
            OpenFileDialog OknoWyboruPlikuDoOdczytania = new OpenFileDialog();
            //ustawienie filtru  
            OknoWyboruPlikuDoOdczytania.Filter = "txtfiles (*.txt)|*.txt|All files (*.*)|*.*";
            // ustawienie  filtru domyślenego 
            OknoWyboruPlikuDoOdczytania.FilterIndex = 1;
            OknoWyboruPlikuDoOdczytania.RestoreDirectory = true;
            //
            OknoWyboruPlikuDoOdczytania.InitialDirectory = "D:\\";
            // wyświetlenie okna dialowego i sprawdzenie wyboru pliku
            OknoWyboruPlikuDoOdczytania.Title = "Wybór pliku dla odczytu TWS (Tablica Wartości Szeegu)";

            if (OknoWyboruPlikuDoOdczytania.ShowDialog() == DialogResult.OK)
            {
                string WierszDanych; /* dla prechowania wiersza danych
                                        (łańcucha znaków) wczytanch z pliku znakowego*/
                string[] DaneWiersa;
                ushort LicznikWierszy;
                System.IO.StreamReader PlikZnakowy = new System.IO.StreamReader(OknoWyboruPlikuDoOdczytania.FileName);
                LicznikWierszy = 0;
                while (!((WierszDanych = PlikZnakowy.ReadLine()) is null))
                {
                    LicznikWierszy++;
                    PlikZnakowy.Close();
                    TWS = new float[LicznikWierszy, 3];
                    PlikZnakowy = new System.IO.StreamReader(OknoWyboruPlikuDoOdczytania.FileName);
                    try
                    {
                        int NrWiersza = 0;
                        while (!((WierszDanych = PlikZnakowy.ReadLine()) is null))
                        {
                            DaneWiersa = WierszDanych.Split(';');
                            /* wczytanie 'spacji' z poszczególnych "części"
                               wczytanego wiersza danych*/
                            DaneWiersa[0].Trim();
                            DaneWiersa[1].Trim();
                            DaneWiersa[2].Trim();

                            TWS[NrWiersza, 0] = float.Parse(DaneWiersa[0]);
                            TWS[NrWiersza, 1] = float.Parse(DaneWiersa[1]);
                            TWS[NrWiersza, 2] = float.Parse(DaneWiersa[2]);
                            NrWiersza++;

                        }
                        WpisanieWynikówDoKontrolkiDataGridView(TWS, dgvTWS); // ref błąd
                        chtWykresSzeregu.Visible = false;
                        dgvTWS.Visible = true;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("ERROR: błąd operacji (dziłania) na pliku --> " + ex.Message);
                    }
                    finally
                    {
                        PlikZnakowy.Close();
                        PlikZnakowy.Dispose();
                    }
                }
            }
            else
            {
                MessageBox.Show("Plik do odczytu tablicy TWS nie został wybrany i obsługa polecenia: 'Odczytanie stablicowanego szeregu z pliku' nie może być zrealizowana");
            }



        }

        private void zapisanieTablicyTWSWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // sprawdzenie, czy egzemplarz tablicy TWS został już utworzony ( z wpisaniem stablicowanych wartości szeregu)
            if (TWS is null)
            {
                // egzemplarz tablicy TWS nie został jeszcze utworzony, to musimy go utworzyć
                //deklaracja zmiennych dla przechowania pobranych danych z formularza
                float Xd, Xg, h, Eps;
                if (!Pobranie_Eps_Xd_Xg_h(out Xd, out Xg, out h, out Eps))
                { // wizualizacja komunikatu o przyczynie braku realizacji wybranej pozucji
                    MessageBox.Show("UWAGA: wybrana pozycja Menu nie może byc zrealizowana " +
                        "ze względu na błąd w danych wejściowych");
                    return;
                }
                // stablicowanie wartości szeregu S(X)
                TablicowanieWartościSzeregu(Xd, Xg, h, Eps, out TWS);
            }
            // egzemplarz tablicy już jest i szereg został stablicowany
            // zapisanie tablicy TWS w pliku
            // deklaracja i utworzenie egzemplarza okna dialowego dla wyboru pliku
            SaveFileDialog OknoWyboruPlikuDoZapisu = new SaveFileDialog();
            // skonfigurowanie OknoWyboruPlikuDoZapisu
            OknoWyboruPlikuDoZapisu.Filter = "txtfiles (*.txt)|*.txt|All files (*.*)|*.*";
            OknoWyboruPlikuDoZapisu.FilterIndex = 1;
            //
            OknoWyboruPlikuDoZapisu.RestoreDirectory = true;
            //
            OknoWyboruPlikuDoZapisu.InitialDirectory = "D:\\";
            //
            OknoWyboruPlikuDoZapisu.Title = "Wybór pliku dla zapisanie tablicy TWS ()Tablica Wartości Szeegu)";
            //
            if (OknoWyboruPlikuDoZapisu.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter PlikZnakowy = new System.IO.StreamWriter(OknoWyboruPlikuDoZapisu.FileName);
                try
                {
                    for (int i = 0; i < TWS.GetLength(0); i++)
                    {
                        PlikZnakowy.Write(TWS[i, 0].ToString());
                        PlikZnakowy.Write(";");
                        PlikZnakowy.Write(TWS[i, 1].ToString());
                        PlikZnakowy.Write(";");
                        PlikZnakowy.WriteLine(TWS[i, 2].ToString());

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR!");
                }
                finally
                {
                    PlikZnakowy.Close();
                }
            }
            else
                MessageBox.Show("UWAGA!");
        }

        private void btnWizualizacjaGraficzna_Click(object sender, EventArgs e)
        {
            // "zgaszanie" kontrolki errorProvider, która mogła wcześniej zapalona
            errorProvider1.Dispose();

            float Eps, Xd, Xg, h;

            if (!Pobranie_Eps_Xd_Xg_h(out Xd, out Xg, out h, out Eps))
            {
                errorProvider1.SetError(btnWizualizacjaTabelaryczna, "ERROR: przy pobieraniu " +
                    "danych wejściowych wykryto błąd i dlatego ta funkcjonalność nie może " +
                    "być zrealizowana");
                // przerwanie obsługi zdarzenia Click: btnWizualizacjaTabelaryczna_Click
                return;
            }

            // 2) talicowanie wartości szeregu w predzieale: [Xd, Sg]
            /* sprawdzenie czy egzemplarz tablicy TWS został już utworzony i szereg
               został stablicowany*/
            if (TWS is null)
            {
                // egzemplarz tablicy TWS nie został jeszcze utworzony i szereg nie został stablicowany
                // utworzenie egzemplarza i stablicowanie szeregu
                TablicowanieWartościSzeregu(Xd, Xg, h, Eps, out TWS);
            }
            // 3) Wpisanie wyników tablicowania do kontrolki Char
            WpisanieWynikówDoKontrolkiChart(TWS, chtWykresSzeregu);
            // 4) ukrycie i obsłonięcie kontrolek dla potrzeb obsługowanego przycisku poleceń
            dgvTWS.Visible = false;
            chtWykresSzeregu.Visible = true;
            btnWizualizacjaGraficzna.Enabled = false;
        }

        private void btnWizualizacjaTabelaryczna_Click(object sender, EventArgs e)
        {
            // "zgaszanie" kontrolki errorProvider, która mogła wcześniej zapalona
            errorProvider1.Dispose();
            // pobranie dannych wejściowych z formularza: Eps, Xd,Xg,h

            // 2) Stabicowanie szeregu w podanym przedziale: [xd, Xg]

            // 3) Przepisanie danych z TWS (Tablicz wartościSzeregu) do  kontrolki DataGridVie
            // ad 1)
            // deklaracje zmiennych dla przechowania pobranych danych wejściowych z formularza
            float Eps, Xd, Xg, h;

            if (!Pobranie_Eps_Xd_Xg_h(out Xd, out Xg, out h, out Eps))
            {
                errorProvider1.SetError(btnWizualizacjaTabelaryczna, "ERROR: przy pobieraniu " +
                    "danych wejściowych wykryto błąd i dlatego ta funkcjonalność nie może " +
                    "być zrealizowana");
                // przerwanie obsługi zdarzenia Click: btnWizualizacjaTabelaryczna_Click
                return;
            }

            // 2) talicowanie wartości szeregu w predzieale: [Xd, Sg]
            /* sprawdzenie czy egzemplarz tablicy TWS został już utworzony i szereg
               został stablicowany*/
            if (TWS is null)
            {
                // egzemplarz tablicy TWS nie został jeszcze utworzony i szereg nie został stablicowany
                // utworzenie egzemplarza i stablicowanie szeregu
                TablicowanieWartościSzeregu(Xd, Xg, h, Eps, out TWS);
            }
            /* 3) wpisanie do kontrolki DataGridView (o name: dgvTWS) stablicowanych
                  wartości szeregu w przedziale: [Xd, Xg] */
            WpisanieWynikówDoKontrolkiDataGridView(TWS, dgvTWS);

            //4) obsłomięcie i ukrycie kontrolek oraz ustawienie stany braku aktywno

            // ukrycie kontrolki Chart
            chtWykresSzeregu.Visible = false;
            // obsłonięcie kontrolki DataGridView
            dgvTWS.Visible = true;
            // ustawienie stanu braku aktywności dla przycisku poleceń: btnWizualizacjaTabelaryczna
            btnWizualizacjaTabelaryczna.Enabled = false;
        }

        private void btnResetu_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void zmianaCzionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog OknoCzionki = new FontDialog();
            OknoCzionki.Font = this.Font;
            if (OknoCzionki.ShowDialog() == DialogResult.OK)
                this.Font = OknoCzionki.Font;
            OknoCzionki.Dispose();
        }

        private void ustalanieKoloruTłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // utworzenie egzemplarza palay kolorów
            ColorDialog PaleteVolume = new ColorDialog();
            // zaznachenie w PalećiColoró aktualnego koloru tłą formularza 
            PaleteVolume.Color = this.BackColor;
            // wuswietlenie PaletyVolume i "odczytanie" wyboru koloru jakigo...
            if (PaleteVolume.ShowDialog() == DialogResult.OK)
                this.BackColor = PaleteVolume.Color;
            //
            PaleteVolume.Dispose();
        }

        private void ustalenieKoloruLiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog PaleteVolume = new ColorDialog();
            PaleteVolume.Color = this.ForeColor;
            if (PaleteVolume.ShowDialog() == DialogResult.OK)
                this.ForeColor = PaleteVolume.Color;

            PaleteVolume.Dispose();
        }
    }
}
