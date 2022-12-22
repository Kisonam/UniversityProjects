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
        float[,] arTWS;
        const float arDgPrzedziauX = float.MinValue;
        const float arGgPrzedziauX = float.MaxValue;
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
            DialogResult arOknoMessage = MessageBox.Show("Czy rzechywicie chcesz zakąć ten " +
              "formularz i powrócić do formularza głuwnego", this.Text,
              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
            // rozpoznanie decyzji użytkownika programu
            if (arOknoMessage == DialogResult.Yes)
            {
                e.Cancel = false;

                foreach (Form arFormularz in Application.OpenForms)
                {
                    if (arFormularz.Name == "Project2_Radovskyi61986")
                    { // ukrycie bieżącego formularza
                        this.Hide();
                        // odsłonięcie znalezionego głównego formularza
                        arFormularz.Show();
                        // wyjście z metody obsługi zdarzenia FormClosing
                        return;
                    } 
                }
                /* gdy "będziemy tutaj" to będzie to oznaczało, że ktoś
                       skasował formularz główny, ale nie było na nim żadnych 
                       wyników obliczeń, tylko przyciki poleceń, to możemy go
                       odtworzyć; bez sygnalizacji błędu */
                // utworzenie nowego egzemplarza formularza głównego
                ProjectNr2_Radovskyi61986 arFormularzProjectuNr2 = new ProjectNr2_Radovskyi61986();
                // ukrycie bieżącego formularza głównego
                arFormularzProjectuNr2.Show();
                // ukrycie bieżącego formularza
                this.Hide();
            }
            else
                e.Cancel = true;
        }

        #region Metody pomocnicze dla obsługi przycisków funkcjonalnych
        float ObliczenieSumySzereguPotęngowego(float arX, float arEps, out ushort arLicznikWyrazów)
        {
            float arS = 0; // suma szeregu
            arLicznikWyrazów = 1; // licznik wyrazów szeregu
            float arw = 1.0f; // wyraz szeregu

            do
            {
                arS += arw;
                arLicznikWyrazów++;
                arw = (float)Math.Pow(arX - 2, arLicznikWyrazów) / ((arLicznikWyrazów + 5) * (float)Math.Pow(3, arLicznikWyrazów));
                //arw = arw * (arX - 2) / ((arLicznikWyrazów + 5) * 3); 
            } while (Math.Abs(arw) > arEps);

            return arS;
        }

        bool Pobierz_X_Eps(out float arX, out float arEps)
        { // dla potezeb technicznych
            arX = arEps = 0.0f;
            // pobranie wartości zmiennej niezależnej X
            if (!float.TryParse(txtX.Text, out arX))
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

            if (!float.TryParse(textEps.Text, out arEps))
            {
                errorProvider1.SetError(textEps, "ERROR: w zapisie dokładności obliczeń Eps" +
                    " wystapił niedozwolony znak ");
                // przerwanie dalszej obcługi zdarzenia Click od przycisku poleceń: buttonObliczWartośćSzeregu_Click
                return false;
            }
            // sprawdzenie warunku wejściowego dla Eps
            if ((arEps <= 0.0f) || (arEps >= +1.0f))
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

        bool Pobranie_Eps_Xd_Xg_h(out float arXd, out float arXg, out float arh, out float arEps)
        {// makieta programowa 
            arXd = arXg = arh = arEps = 0;
            if (!float.TryParse(txtD.Text, out arXd))
            {
                errorProvider1.SetError(txtD, "ERROR: w zapisie Xd wystąpił niedozwolony znak");
                // przerwanie pobirania danych
                return false;
            }
            // sprawdzenie pobirania danych 
            if ((arXd < arDgPrzedziauX) || (arXd > arGgPrzedziauX))
            {// błąd, poprawnie Xd nie należy do przedżiału zbieżniści
                errorProvider1.SetError(txtD, "ERROR: podane Xd nie należe przedziału " +
                    "zbiżności szeregu: MaxValue > Xd > MinValue");
                // przerwanie pobirania danych
                return false;
            }
            // pobranie Xg
            if (!float.TryParse(txtG.Text, out arXg))
            {
                errorProvider1.SetError(txtD, "ERROR: w zapisie Xg wystąpił niedozwolony znak");
                // przerwanie pobirania danych
                return false;
            }

            if ((arXg < arDgPrzedziauX) || (arXg > arGgPrzedziauX))
            {// błąd, poprawnie Xd nie należy do przedżiału zbieżniści
                errorProvider1.SetError(txtG, "ERROR: podane Xg nie należe przedziału " +
                    "zbiżności szeregu: MaxValue > Xg > MinValue");
                // przerwanie pobirania danych
                return false;
            }
            // spawdzenie poprawności kolejności zapisu granice
            if (arXg < arXd)
            {
                errorProvider1.SetError(txtG, "ERROR: granice przedziału zostały zapisane odwrotnie: " +
                   "musi być spełniony tzw. warunek wejściowy: Xd <= Xg");
                // przerwanie pobirania danych
                return false;
            }
            txtD.Enabled = false;
            txtG.Enabled = false;
            // pobranie przyrost h zmian wartości zmiennej niezale znaj X
            if (!float.TryParse(txtH.Text, out arh))
            {
                errorProvider1.SetError(txtH, "ERROR: w zapisie wystąpił niedozwolony znak");
                return false;
            }
            // sprawdzenie tzw. warunku wejściowego 
            if (arh >= (arXg - arXd))
            {
                errorProvider1.SetError(txtH, "ERROR: podana wartość 'h' nie spełnia warunku wejściowego: h < (Xg - Xd)");

                return false;
            }
            //
            if (!float.TryParse(textEps.Text, out arEps))
            {// jest błąd, to go sygnalizacja
                errorProvider1.SetError(textEps, "ERROR: w zapisie dokładności obliczeń Eps " +
                    "wystąpił niedozwolony znak");
                // przerwanie pobirania danych
                return false;
            }
            // sprawdzenie tzw. warunku wiejściowego dla dokładności
            if ((arEps < 0.0f) || (arEps > 1.0f))
            {

                errorProvider1.SetError(textEps, "ERROR: podana dokładność obliczeń Eps " +
                   "nie spełnia warunku wejściowego (Eps < 0.0f) || (Eps > 1.0f)");
                // przerwanie pobirania danych
                return false;
            }
            return true;
        }

        void TablicowanieWartościSzeregu(float arXd, float arXg, float arh, float arEps, out float[,] arTWS)
        {
            // dla utworzenia egzamplarza tablicy TWS musimy określić liczbę jej wierszy
            int n = (int)((arXg - arXd) / arh + 1);
            // utworzenie egzemplarza tablicy TWS
            arTWS = new float[n + 1, 3];
            // stablicowanie wartości szeregu
            // deklaracja zmiennych pomocniczych
            float X;
            int i; // numer podprzedziału
            ushort LicznikZsumowanychWyrazów;
            for (X = arXd, i = 0; i < arTWS.GetLength(0); i++, X = arXd + i * arh) // nie tak: X = X +h;
            {
                arTWS[i, 0] = X;
                arTWS[i, 1] = ObliczenieSumySzereguPotęngowego(X, arEps, out LicznikZsumowanychWyrazów);
                arTWS[i, 2] = LicznikZsumowanychWyrazów;
            }
        }

        void WpisanieWynikówDoKontrolkiDataGridView(float[,] arTWS, DataGridView ardgvTWS)
        {
            // wyzerowanie wierszy kontrolki DataGridView
            ardgvTWS.Rows.Clear();
            // wpisywanie kolejnych wierszy tablicy TWS do kontrolki dvgTWS
            for (int i = 0; i < arTWS.GetLength(0); i++)
            {
                // dodanie nowego wiersza
                ardgvTWS.Rows.Add();
                // wpisanie wartości X
                ardgvTWS.Rows[i].Cells[0].Value = string.Format($"{arTWS[i, 0]:00}");
                // wpisanie wartości szeregu
                ardgvTWS.Rows[i].Cells[1].Value = string.Format($"{arTWS[i, 1]:0.000}");
                // wpisanie licznika zsumowanych wyrazów
                ardgvTWS.Rows[i].Cells[2].Value = string.Format($"{(int)arTWS[i, 2]}");
            }
        }

        void WpisanieWynikówDoKontrolkiChart(float[,] arTWS, Chart archtWykresSzeregu)
        {
            // 1.formatowanie (ustawienie atrybutów) kontrolki Chart, obramowanie kontrolki Chart
            archtWykresSzeregu.BorderlineWidth = 2;
            archtWykresSzeregu.BorderlineColor = Color.Red;
            archtWykresSzeregu.BorderlineDashStyle = ChartDashStyle.DashDotDot;
            // skonfigurowanie kontrolki Chart
            // ustalenie tytułu wykresu
            archtWykresSzeregu.Titles.Add("Wykres zmian wartości szeregu S(x)");
            // umieszczenie legendy pod wykresem
            archtWykresSzeregu.Legends.FindByName("Legend1").Docking = Docking.Bottom;
            //ustawienie koloru tła 
            archtWykresSzeregu.BackColor = Color.LightSkyBlue;
            archtWykresSzeregu.ChartAreas[0].AxisX.Title = "Wartości X";
            archtWykresSzeregu.ChartAreas[0].AxisY.Title = "Wartości S(x)";
            // sformatowanie opisu osi X (kontrolki Chart)
            archtWykresSzeregu.ChartAreas[0].AxisX.LabelStyle.Format = "{0:f2}";
            archtWykresSzeregu.ChartAreas[0].AxisY.LabelStyle.Format = "{0:f2}";
            // 2.formatowanie serii danych dodanej do kontrolki Chart,
            // "wyzerowanie"serii danych kontrolki Chart
            archtWykresSzeregu.Series.Clear();
            //dodanie nowej serii danych
            archtWykresSzeregu.Series.Add("Seria 0");
            // ustalenie nazw osi układu współezędnych
            archtWykresSzeregu.Series[0].XValueMember = "X";
            archtWykresSzeregu.Series[0].XValueMember = "Y";
            // ustalenie widoczności legendy
            archtWykresSzeregu.Series[0].IsVisibleInLegend = true;
            // ustalenie nazwy legendy (opisu linii wykresu)
            archtWykresSzeregu.Series[0].Name = "Wartości szeregu potęgowego S(X)"; // legenda
            // ustalenie typu wykresu
            archtWykresSzeregu.Series[0].ChartType = SeriesChartType.Line; // liniowy
            // ustawienie koloru linii 
            archtWykresSzeregu.Series[0].Color = Color.Black;
            //ustawienie stylu linii 
            archtWykresSzeregu.Series[0].BorderDashStyle = ChartDashStyle.Solid;
            // ustalenie grubości linii
            archtWykresSzeregu.Series[0].BorderWidth = 1;

            /* 3. wpisania współrzędnych (X oraz Y) linii wykresu 
             szeregu (na podstawie zapisanych w tablicy TWS) */
            /* dodanie do serii danych (kontrolki Chart) współrzędnych
               punktów wykresu (wartości X oraz Wartości Y, czyli 
               wartości szeregu: S (X) */
            for (int i = 0; i < arTWS.GetLength(0); i++)
            {
                archtWykresSzeregu.Series[0].Points.AddXY(arTWS[i, 0], arTWS[i, 1]);
            }
        }
        #endregion

        private void buttonObliczWartośćSzeregu_Click(object sender, EventArgs e)
        {

            // "zgaszanie" kontrolki errorProvider, która mogła wcześniej zapalona
            errorProvider1.Dispose();
            // pobranie danych wejściowych
            float arX, arEps;
            // pobranie wartości zmiennej niezależnej X
            if (!Pobierz_X_Eps(out arX, out arEps)) // (!Pobierz_X_Eps())
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
                if (!float.TryParse(textEps.Text, out arEps))
                {
                    errorProvider1.SetError(textEps, "ERROR: w zapisie dokładności obliczeń Eps" +
                        " wystapił niedozwolony znak ");
                    // przerwanie dalszej obcługi zdarzenia Click od przycisku poleceń: buttonObliczWartośćSzeregu_Click
                    return;
                }
                //// sprawdzenie warunku wejściowego dla Eps
                if ((arEps <= 0.0f) || (arEps >= +1.0f))
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

            float arSumaSzeregu;
            ushort arN; // licznik zsumowanych wyrazów szeregu
            // obliczenie wartości szeregu, czyli wywołanie metody ObliczenieSumySzereguPotęngowego(float X, float Eps, out ushort LicznikWyrazów)
            arSumaSzeregu = ObliczenieSumySzereguPotęngowego(arX, arEps, out arN);
            //wypisanie wyniku obliczeń
            txtSumaSzeregu.Text = arSumaSzeregu.ToString();
            txtLicznikWyrazów.Text = arN.ToString();
        }

        private void odczytanieTablicyTWSZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            /* "zgaszenie" kontrolki errorProvider, któw mogła zastać 
             zapalona podczas pobierania danych */
            errorProvider1.Dispose();
            /* sprawdzenie, czy zmienna referencyjna ma wartość null 
             (tzw. Pusta referencja do egzamplarza tablicy )*/
            if (!(arTWS is null))
            {/* poinformowanie Użytkownika, że egzemlarza tablicy TWS 
              już jest utworzony i czy ma być skasowana dla wczytania elementów tablicy TWS z pliku ma być kontynuowane*/
                DialogResult OknoMessage = MessageBox.Show("UWAGA: egzemplarza tablicy TWS już istnieje! \r\nCzy bieżący egzemplarz tablicy TWS ma być skasowany i w jego miejsce ma być utworzony nowy egzemlarz, do krótkego mają zostać 'wczytane' elementy TWS z pliku? " +
                    "\r\n - kliknij przycisk poleceń 'Tak' dla potwirdzenia wczytanie elementów tablicy TWS z pliku" +
                    "\r\n - kliknij przycisk poleceń 'Nie' dla skasowania polecenia wczytania elementów tablicy TWS z pliku ",
                    "Okno ostrzeżenia", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                // rozpoznanie wybrango przycisku poleceń w oknie dialogowym 'MessageBox'
                if (OknoMessage == DialogResult.Yes)
                    arTWS = null; /* przypisanie wartości 'null' zmiennej
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
            OpenFileDialog arOknoWyboruPlikuDoOdczytania = new OpenFileDialog();
            //ustawienie filtru  
            arOknoWyboruPlikuDoOdczytania.Filter = "txtfiles (*.txt)|*.txt|All files (*.*)|*.*";
            // ustawienie  filtru domyślenego 
            arOknoWyboruPlikuDoOdczytania.FilterIndex = 1;
            arOknoWyboruPlikuDoOdczytania.RestoreDirectory = true;
            //
            arOknoWyboruPlikuDoOdczytania.InitialDirectory = "D:\\";
            // wyświetlenie okna dialowego i sprawdzenie wyboru pliku
            arOknoWyboruPlikuDoOdczytania.Title = "Wybór pliku dla odczytu TWS (Tablica Wartości Szeegu)";

            if (arOknoWyboruPlikuDoOdczytania.ShowDialog() == DialogResult.OK)
            {
                string arWierszDanych; /* dla prechowania wiersza danych
                                        (łańcucha znaków) wczytanch z pliku znakowego*/
                string[] arDaneWiersa;
                ushort arLicznikWierszy;
                System.IO.StreamReader arPlikZnakowy = new System.IO.StreamReader(arOknoWyboruPlikuDoOdczytania.FileName);
                arLicznikWierszy = 0;
                while (!((arWierszDanych = arPlikZnakowy.ReadLine()) is null))
                {
                    arLicznikWierszy++;
                    arPlikZnakowy.Close();
                    arTWS = new float[arLicznikWierszy, 3];
                    arPlikZnakowy = new System.IO.StreamReader(arOknoWyboruPlikuDoOdczytania.FileName);
                    try
                    {
                        int arNrWiersza = 0;
                        while (!((arWierszDanych = arPlikZnakowy.ReadLine()) is null))
                        {
                            arDaneWiersa = arWierszDanych.Split(';');
                            /* wczytanie 'spacji' z poszczególnych "części"
                               wczytanego wiersza danych*/
                            arDaneWiersa[0].Trim();
                            arDaneWiersa[1].Trim();
                            arDaneWiersa[2].Trim();

                            arTWS[arNrWiersza, 0] = float.Parse(arDaneWiersa[0]);
                            arTWS[arNrWiersza, 1] = float.Parse(arDaneWiersa[1]);
                            arTWS[arNrWiersza, 2] = float.Parse(arDaneWiersa[2]);
                            arNrWiersza++;

                        }
                        WpisanieWynikówDoKontrolkiDataGridView(arTWS, dgvTWS); // ref błąd
                        chtWykresSzeregu.Visible = false;
                        dgvTWS.Visible = true;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("ERROR: błąd operacji (dziłania) na pliku --> " + ex.Message);
                    }
                    finally
                    {
                        arPlikZnakowy.Close();
                        arPlikZnakowy.Dispose();
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
            if (arTWS is null)
            {
                // egzemplarz tablicy TWS nie został jeszcze utworzony, to musimy go utworzyć
                //deklaracja zmiennych dla przechowania pobranych danych z formularza
                float arXd, arXg, arh, arEps;
                if (!Pobranie_Eps_Xd_Xg_h(out arXd, out arXg, out arh, out arEps))
                { // wizualizacja komunikatu o przyczynie braku realizacji wybranej pozucji
                    MessageBox.Show("UWAGA: wybrana pozycja Menu nie może byc zrealizowana " +
                        "ze względu na błąd w danych wejściowych");
                    return;
                }
                // stablicowanie wartości szeregu S(X)
                TablicowanieWartościSzeregu(arXd, arXg, arh, arEps, out arTWS);
            }
            // egzemplarz tablicy już jest i szereg został stablicowany
            // zapisanie tablicy TWS w pliku
            // deklaracja i utworzenie egzemplarza okna dialowego dla wyboru pliku
            SaveFileDialog arOknoWyboruPlikuDoZapisu = new SaveFileDialog();
            // skonfigurowanie OknoWyboruPlikuDoZapisu
            arOknoWyboruPlikuDoZapisu.Filter = "txtfiles (*.txt)|*.txt|All files (*.*)|*.*";
            arOknoWyboruPlikuDoZapisu.FilterIndex = 1;
            //
            arOknoWyboruPlikuDoZapisu.RestoreDirectory = true;
            //
            arOknoWyboruPlikuDoZapisu.InitialDirectory = "D:\\";
            //
            arOknoWyboruPlikuDoZapisu.Title = "Wybór pliku dla zapisanie tablicy TWS ()Tablica Wartości Szeegu)";
            //
            if (arOknoWyboruPlikuDoZapisu.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter PlikZnakowy = new System.IO.StreamWriter(arOknoWyboruPlikuDoZapisu.FileName);
                try
                {
                    for (int i = 0; i < arTWS.GetLength(0); i++)
                    {
                        PlikZnakowy.Write(arTWS[i, 0].ToString());
                        PlikZnakowy.Write(";");
                        PlikZnakowy.Write(arTWS[i, 1].ToString());
                        PlikZnakowy.Write(";");
                        PlikZnakowy.WriteLine(arTWS[i, 2].ToString());

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

            float arEps, arXd, arXg, arh;

            if (!Pobranie_Eps_Xd_Xg_h(out arXd, out arXg, out arh, out arEps))
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
            if (arTWS is null)
            {
                // egzemplarz tablicy TWS nie został jeszcze utworzony i szereg nie został stablicowany
                // utworzenie egzemplarza i stablicowanie szeregu
                TablicowanieWartościSzeregu(arXd, arXg, arh, arEps, out arTWS);
            }
            // 3) Wpisanie wyników tablicowania do kontrolki Char
            WpisanieWynikówDoKontrolkiChart(arTWS, chtWykresSzeregu);
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
            float arEps, arXd, arXg, arh;

            if (!Pobranie_Eps_Xd_Xg_h(out arXd, out arXg, out arh, out arEps))
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
            if (arTWS is null)
            {
                // egzemplarz tablicy TWS nie został jeszcze utworzony i szereg nie został stablicowany
                // utworzenie egzemplarza i stablicowanie szeregu
                TablicowanieWartościSzeregu(arXd, arXg, arh, arEps, out arTWS);
            }
            /* 3) wpisanie do kontrolki DataGridView (o name: dgvTWS) stablicowanych
                  wartości szeregu w przedziale: [Xd, Xg] */
            WpisanieWynikówDoKontrolkiDataGridView(arTWS, dgvTWS);

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
            FontDialog arOknoCzionki = new FontDialog();
            arOknoCzionki.Font = this.Font;
            if (arOknoCzionki.ShowDialog() == DialogResult.OK)
                this.Font = arOknoCzionki.Font;
            arOknoCzionki.Dispose();
        }

        private void ustalanieKoloruTłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // utworzenie egzemplarza palay kolorów
            ColorDialog arPaleteVolume = new ColorDialog();
            // zaznachenie w PalećiColoró aktualnego koloru tłą formularza 
            arPaleteVolume.Color = this.BackColor;
            // wuswietlenie PaletyVolume i "odczytanie" wyboru koloru jakigo...
            if (arPaleteVolume.ShowDialog() == DialogResult.OK)
                this.BackColor = arPaleteVolume.Color;
            //
            arPaleteVolume.Dispose();
        }

        private void ustalenieKoloruLiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog arPaleteVolume = new ColorDialog();
            arPaleteVolume.Color = this.ForeColor;
            if (arPaleteVolume.ShowDialog() == DialogResult.OK)
                this.ForeColor = arPaleteVolume.Color;

            arPaleteVolume.Dispose();
        }

        private void zmianaKoloruLiniiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ColorDialog arPaleteVolume = new ColorDialog();
            arPaleteVolume.Color = this.BackColor;
            if (arPaleteVolume.ShowDialog() == DialogResult.OK)
                chtWykresSzeregu.BorderlineColor = this.BackColor;
        }

        private void ustalenieRozmiaruToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
