using System;

namespace Project1_Radovskyi61986
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo WybranaFunkcjonalniość;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine("\n\n\tProgram \"Project1_Radovskyi61986\" umożliwia wielokrotne wielokrotne\n" +
                    "\t obliczanie wartości wybranych wielkości matematycznych");

                Console.WriteLine("\n\nMENU  funkcjonalne  programu:");

                Console.WriteLine("\nA. Laboratorium Nr 1: Kalkulator obliczeń");
                Console.WriteLine("B. Project Nr 1: Kalkulator obliczeń");
                Console.WriteLine("X. Zakończenie (wyjście z) programu");

                Console.Write("\n\nNaciśnięciem odpowiedniego klawisza wybierz jedną z oferowanych funkcjolność:");


                WybranaFunkcjonalniość = Console.ReadKey();

                if (WybranaFunkcjonalniość.Key == ConsoleKey.A)
                {
                    //realizacja Kalkulatora na zajęciach laboratoryjnych
                    KalkulatorObliczeńLaboratoryjnychNr1();
                }
                else if (WybranaFunkcjonalniość.Key == ConsoleKey.B)
                {
                    //realizacja Kalkulatora na zajęciach laboratoryjnych
                    KalkulatorObliczeńProjectuNr1();
                }
                else if (WybranaFunkcjonalniość.Key != ConsoleKey.X)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\tERROR: Naciśnąłeś niedozwolony 'klawizs'");
                    Console.ReadKey();
                }


            }
            while (WybranaFunkcjonalniość.Key != ConsoleKey.X);

            Console.ReadKey();
        }
        #region deklaracja głównych metodów 
        static void KalkulatorObliczeńLaboratoryjnychNr1()
        {
            ConsoleKeyInfo WybranaFunkcjonalniość;

            do
            {
                Console.WriteLine("\n\n\t\tKalkulator laboratoryjny");

                Console.WriteLine("\n\n\tMENU funkcjonalne Kalkulatora laboratoryjnego: ");
                Console.WriteLine("\n\tA. Obliczenie sumy wyrazów ciągu liczbowego");
                Console.WriteLine("\n\tB. Obliczenie ilośczynu wyrazów ciągu liczbowego");
                Console.WriteLine("\n\tC. Obliczenie średniej wyrazów arytmetycznej ciągu liczbowego");
                Console.WriteLine("\n\tD. Wyznaczanie pierwiastków równania kwadratowego");
                Console.WriteLine("\n\tE. Obliczanie wartości wielomianu n-tego stopnia");
                Console.WriteLine("\n\tF. Konwersja liczby z systemu dziesiętnego na dwójkowy");
                Console.WriteLine("\n\tX. Zakończenie (wyjście z) Kalkulatora obliczeń z zajęć laboratorynych");

                Console.Write("\n\n\tNaćiśnięciem odpowidniego klawisza (A,B," +
                    "C,...,X) wybierz jedną z oferowanych funkcjonalności");

                WybranaFunkcjonalniość = Console.ReadKey();


                switch (WybranaFunkcjonalniość.Key)
                {
                    case ConsoleKey.A:
                        // sekwencja instrukcji onliczenia sumy wyrazów ciągu liczbowego
                        Console.WriteLine("\n\n\tWYBRANO: A. Obliczenie sumy wyrazów" +
                            " ciągu liczbowego");

                        //deklaracja zmiennej dla przechowania liczności ciągu liczbowego
                        ushort n;
                        // deklaracja zmiennej Suma dla przechowania obliczonej sumy wyrazów ciągu liczbowego
                        float Suma;
                        //obliczenie sumy arytmetycznej wyrazów ciągu liczbowego
                        SumaWyrazówCiąguLiczbowego(out Suma, out n);
                        // wypisanie wyniku obliczeń w notacji stałopozycyjnej (fixed-point)

                        Console.WriteLine("\n\tWYNIKI OBLICZEŃ: obliczona suma" +
                            $" arytmetyczna wyrazów ciągu liczbowego o liczności n = {n}" +
                            $" jest równa: {Suma,8:F2}");
                        /* wypisanie wyniku obliczeń w notacji naukowej (postać wykładnicza),
                         w której jedna cyfra zawsze poprzedza znak dziesiętny (czyli kropkę: .)*/

                        Console.WriteLine("\n\tWYNIKI OBLICZEŃ! obliczona suma " +
                            "arytmetyczna wyrazów ciągu liczbowego o liczności" +
                            $" n = {n} jest równa: {Suma,8:E2}");
                        /* wypisanie wyniku obliczeń w najbardziej notacji zwięzłej
                         (dobieranej automatycznie na podstawie wartości zmiennej) */

                        Console.WriteLine("\n\tWYNIKI OBLICZEŃ! obliczona suma " +
                            "arytmetyczna wyrazów ciągu liczbowego o liczności" +
                            $" n = {n} jest równa: {Suma,8:G2}");
                        break;
                    case ConsoleKey.B:
                        // sekwencja instrukcji onliczenia iloczynu wyrazów ciągu liczbowego
                        Console.WriteLine("\n\n\tWYBRANO: B. Obliczenie iloczynu wyrazów ciągu liczbowego");
                        /* dodatkowe uściślenia:
                         1) kolejność wczytywania danych wejściowych: n a1 a2 ... an
                         2) warunek wejściowe ("nakładany" na dane wejściowe): n>0
                         3) typ danych wczytywanych danych wejściowych:
                            n, liczoność ciągu liczbowego: liczba naturalna (ushort)
                            a1 a2 . . . an, wyrazy ciągu liczbowego: liczby rzeczywiste*/
                        // deklaracje zminnych dla przechowania wyników
                        // deklaracje zmiennej Iloczyn dla przechowania obliczonego iloczynu wyrazów ciągu liczbowego

                        float Iloczyn; // dla prechowania iloczynu
                        // onliczenie iloczynu wyraazów ciągu liczbowego: wynil będzie przekazany przez nazwę metody
                        Iloczyn = IloczynWyrazówCiąguLiczbowego(); // wywołanie metody
                        // wypisanie wyniku obliczeń w notacji stałopozycyjnej (fixed-point)
                        Console.WriteLine("\n\tWYNIKI OBLICZEŃ: obliczony iloczyn " +
                            $"wyrazów ciągu liczbowego jest równy {Iloczyn,8:F2}");
                        /* wypisanie wyniku obliczeń w  notacji naukowej (postać 
                           wykładnicza), w której jedna cyfra zawsze poprzedza znak
                           dziesiętny (czyli kropkę: . ) */
                        Console.WriteLine("\n\tWYNIKI OBLICZEŃ: obliczony iloczyn " +
                            $"wyrazów ciągu liczbowego jest równy {Iloczyn,8:E2}");

                        Console.WriteLine("\n\tWYNIKI OBLICZEŃ: obliczony iloczyn " +
                            $"wyrazów ciągu liczbowego jest równy {Iloczyn,8:G}");

                        break;
                    case ConsoleKey.C:
                        // sekwencja instrukcji obliczania średniej arytmetycznej wyrazów ciągu liczbowego
                        Console.WriteLine("\n\n\tWYBRANO: C. Obliczenie średniej wyrazów arytmetycznej ciągu liczbowego");
                        /* dodatkowe uściślenia:
                         1) kolejność wczytania danych wejściowych: n a1 a2 ... an
                         2) warunek wejściowe ("nakładany" na dane wejściowye): n > 0
                         3) typ danych wczytywanych danych wejściowych:
                            n, liczność ciągu liczbowego: liczba naturalna (ushort)
                            a1 a2 . . . an, wyrazy ciągu liczbowego: liczby rzeczywiste (float)*/

                        /* ushort n; deklaracja zmiennej n (liczność ciągu
                           liczbowego) jest już zapisana w obsłudze 'case
                           ConsoleKey.A' i już jej nie powtarzamy w obsłudze
                           pozostałych 'case' danej instrukcij switch   */

                        /* deklaracja zmiennej dla przchowania obliczenia obliczonej
                           średniej arytmetycznej wyrazów ciągu liczbowego */
                        float ŚredniaArytmetyczna;
                        // obliczenie średniej arytmetycznej
                        ŚredniaArytmetyczna = ŚredniaArytmetycznaWyrazówCiąguLiczbowego(out n);
                        // wyisanie wyniku obliczeń w notacji stałopozycyjnej (fixed-point)
                        Console.WriteLine("\n\tWYNIKI OBLICZEŃ: onliczona średnia arytmetyczna wyrazów ciągu liczbowego o liczności " +
                            $"n = {n} jest równa: {ŚredniaArytmetyczna,8:F2}");
                        /* wypisanie wyniku obliczeń w notacji naukowej (postać
                           wykładnicza), w której jedna cyfra zawsze poprzedza znak
                           dziesiętny (czyli kropkę: . )    */
                        Console.WriteLine("\n\tWYNIKI OBLICZEŃ: onliczona średnia arytmetyczna wyrazów ciągu liczbowego o liczności " +
                            $"n = {n} jest równa: {ŚredniaArytmetyczna,8:E2}");
                        /* wypisanie wyniku obliczeń w najbardziej notacji zwięzłej
                           (dobieranej automatycznie na podstawie wartości zmiennej)    */
                        Console.WriteLine("\n\tWYNIKI OBLICZEŃ: onliczona średnia arytmetyczna wyrazów ciągu liczbowego o liczności " +
                            $"n = {n} jest równa: {ŚredniaArytmetyczna,8:G}");
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("\n\n\tWYBRANO: D. Wyznaczanie pierwiastków równania kwadratowego");
                        // deklaracje zmiennych programu
                        float a, b, c;
                        // wypisanie metryki programu
                        Console.WriteLine("\n\n\t\t\tProgram wyznacza pierwiastki równania kwadratowego");
                        // obliczenie pierwiastków równania kwadratowego
                        PierwiastkieRównaniaKwadratowe(out a, out b, out c);

                        break;
                    case ConsoleKey.E:
                        Console.WriteLine("\n\n\tWYBRANO: E. Obliczanie wartości wielomianu n-tego stopnia");
                        float Wx; // Obliczona wartość wielomianu
                        float X; // wczytana wartość zmiennej niezależnej: typu float
                        //ushort n; //stopień wielomianu jest już zadeklarowana w case ConsoleKey.A:
                        // wywołanie metody obliczania wartości wielomianu według schematu Hornera
                        ObliczenieWartościWielomianu(out Wx, out X, out n);
                        // Wypisanie wyników obliczeń
                        // wypisanie wyniku obliczeń w notacji stałopozycyjnej (fixed-point)
                        Console.WriteLine($"\n\n\tWYNIKI: obliczona wartość wielomianu n = {n}-ego stopnia " +
                            $"dla zmiennej niezależnej X = {X,6:E2}, jest równa: {Wx,8:F3}");
                        //inne formaty wypisywania wartości typu 'float'
                        /* wypisanje wyniku obliczeń w notacji  naukowej (postać wykładnicza),
                           w której jedna cyfra zawsze poprzedza znak dziesiętny (czyli kropkę: . )*/
                        Console.WriteLine($"\n\n\tWYNIKI: obliczona wartość wielomianu n = {n}-ego stopnia " +
                            $"dla zmiennej niezależnej X = {X,6:E2}, jest równa: {Wx,8:E3}");
                        // wypisanie wyniku obliczeń w najbardziej natacji (naukowiej lub stałopozycyjnej)
                        Console.WriteLine($"\n\n\tWYNIKI: obliczona wartość wielomianu n = {n}-ego stopnia " +
                            $"dla zmiennej niezależnej X = {X,6:G}, jest równa: {Wx,8:G}");
                        break;
                    case ConsoleKey.F:
                        // potwierdzenie wyboru funkcjonalniści F.
                        Console.WriteLine("\n\n\tWYBRANO: F. Konwersja liczby z systemu dziesiętnego na dwójkowy");
                        /* dekomponujemy zadanie obsługi funkcjonalniści F.
                           1) konwersja znakowego zapisu liczby naturalnej (ushort) w systemie dziesiętnym na wartość
                           2) konwersja wartości liczby naturalnej (ushort) na znakowy zapis liczby w systemie dwójkowym*/
                        // realizacja komponentu ad 1)
                        string ZZL; // ZZL - Znakowy Zapis Liczby
                                    // deklaracja zmiennej dla przechowania wartości liczby po konwersji
                        ushort LiczbaPoKonwersji;
                        // wczytanie liczby znakowej do konwersji na wartość
                        Console.Write("\n\n\tPodaj liczbę (w systemie dziesiętnym) do konwersji: ");

                        // wczytanie liczby do konwersji
                        ZZL = Console.ReadLine();
                        // usunięcie zbędnych "białych znaków" (spacja, znak tabulacji )
                        ZZL = ZZL.Trim(); //123
                                          // konwersja znakowego zapisu liczby na wartość przez wywołanie metody

                        LiczbaPoKonwersji = KonwersjaZnakowejLiczbyNaWartość(ZZL);
                        // dla celów testoych wypisujemy liczbę po konwersji przy użyciu metody WriteLine
                        Console.WriteLine("\n\n\tTRACE: Liczba po konwersji: " + ZZL.ToString());

                        //realizacja komponentu ad 2.
                        ushort LiczbaDoKonwersji = LiczbaPoKonwersji;
                        // Komwersja wartości (liczby ushort) na znakowy zapis w systemie dwójkowym
                        KonwersacjaLiczbyNaturalnejNaBinarna(LiczbaDoKonwersji, out ZZL);

                        // wypisanie wyników konwersji
                        Console.WriteLine("\n\n\tWYNIK KONWERSJI: Wartość liczby po konwersji ze znakowego " +
                            $"jej zapisu w dziesiętnym systemie liczbowym: {LiczbaPoKonwersji}, która po konwersji na system " +
                            $"dwójkowy (binarny) ma następujący zapis znakowy: {ZZL}");
                        break;
                    default:
                        // jest błąd: Użytkownik nacisnął "zły" klawisz
                        Console.WriteLine("\n\tERROR: nacisnąłe niedozwolony klawisz " +
                            "(znak) - nie ma takiej funkcjonalności w MENU programu");
                        break;
                }
                // chwilowe zatrzymanie programu
                Console.WriteLine("\n\tDla kontynuacji obliczeń naciśnij dowolny klawisz ...");
                Console.ReadKey();
            }
            while (WybranaFunkcjonalniość.Key != ConsoleKey.X);
        }
        static void KalkulatorObliczeńProjectuNr1()
        {
            ConsoleKeyInfo WybranaFunkcjonalniość;

            do
            {
                Console.Clear();
                Console.WriteLine("\n\n\t\tProjekt Nr 1: Kalkulator obliczeń");

                Console.WriteLine("\n\n MENU funkcjonalne Kalkulatora");
                Console.WriteLine(" A. Obliczenie średniej harmomicznej wyrażow ciągu liczbowego");
                Console.WriteLine(" B. Obliczenie średniej kwadratowej wyrażow ciągu liczbowego");
                Console.WriteLine(" C. Obliczenie średniej potęgowej (średniej uogólnionej)" +
                    " wyrażow ciągu liczbowego");
                Console.WriteLine(" D. Obliczenie średniej geometrycznej wyrażow ciągu liczbowego");
                Console.WriteLine(" E. Obliczenie ceny jednostki paszy (według średniej ważonej) składającej się\n" +
                    " (utworzonej, skomponowanej)  z kilku składników");
                Console.WriteLine(" F. Obliczenie wartości wielomianu n-tego stopnia według schematu Hernera");
                Console.WriteLine(" G. Konwersja liczby całkowitej zapisanej znakowo w systemie liczbowym o podanej\n" +
                    " podstawie liczenia na wartość i jej wypisanie znakowo w innym systemie liczbowym\n" +
                    " o podanej podstawie liczenia");
                Console.WriteLine(" X. Zakończenie (wyjście z) 'Kalkulatora obliczeń zadania projektowego Nr 1'");

                Console.WriteLine("\n Naćiśnięciem odpowidniego klawisza wybierz jedną z oferowanych funkcjonalności");


                WybranaFunkcjonalniość = Console.ReadKey();

                switch (WybranaFunkcjonalniość.Key)
                {
                    case ConsoleKey.A:
                        {
                            Console.Clear();

                            Console.WriteLine("\n\n\tWYBRANO:  A. Obliczenie średniej harmomicznej " +
                                "wyrażow ciągu liczbowego");

                            float Śr = 0; // deklaracje zmiennej średniej harmomicznej i n liczb
                            int n; // deklaracje zmiennej liczb

                            Console.Write("\n\tPodaj liczność n liczb: ");
                            while (!int.TryParse(Console.ReadLine(), out n))
                            {
                                Console.WriteLine("\n\tERROR: w zapisie " +
                                                "wystąpił niedozwolony znak!!!");
                                // wypisanie zaproszenia do podania liczności ciągu liczbowego n
                                Console.Write("\n\tPodaj ponownie n: ");
                            }

                            Śr = ObliczenieŚredniejHarmomicznej(out Śr, n);
                            
                            Console.WriteLine("\n\tWYNIKI OBLICZEŃ: obliczona Średnia harmoniczna" +
                           $" licznośc n = {n} , jest równa: {Śr}");

                            Console.ReadKey();

                        }
                        break;
                    case ConsoleKey.B:
                        {
                            Console.Clear();

                            Console.WriteLine("\n\n\tWYBRANO:  B. Obliczenie średniej kwadratowej wyrażow ciągu liczbowego");

                            Console.WriteLine("\n\tPodaj ile liczb chcesz użyć do średniej kwadratowej:");
                            int n = Convert.ToInt32(Console.ReadLine());
                            double result = ŚredniaKwadratowaCiągu(n);

                            Console.WriteLine("\n\tWYNIKI OBLICZEŃ: średniej kwadratowej wyrażow ciągu liczbowego " +
                                $"n = {n} jest równa: {result}");

                            Console.ReadKey();

                        }
                        break;
                    case ConsoleKey.C:
                        {
                            Console.Clear();

                            Console.WriteLine("\n\n\tWYBRANO: C. Obliczenie średniej potęgowej (średniej uogólnionej)" +
                                " wyrażow ciągu liczbowego");

                            Console.Write("\n\tPodaj ile liczb chcesz użyć do średniej kwadratowej:");
                            int n = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\n\tPodaj stopień korzenia:");
                            double b = Convert.ToDouble(Console.ReadLine());

                            double result = ŚredniaPotęgowaCiągu(n, b);

                            Console.WriteLine("\n\tWYNIKI OBLICZEŃ: średniej potęgowej wyrażow ciągu liczbowego " +
                                                $"n = {n} jest równa: {result}");

                            Console.ReadKey();
                        }
                        break;
                    case ConsoleKey.D:
                        {
                            Console.Clear();

                            Console.WriteLine("\n\n\tWYBRANO:  D. Obliczenie średniej geometrycznej wyrażow ciągu liczbowego");

                            Console.Write("\n\tPodaj ile liczb chcesz użyć do średniej geometrycznej: ");
                            int n = Convert.ToInt32(Console.ReadLine());

                            double result = ŚredniaGeometrycznaCiągu(n);

                            Console.WriteLine("\n\tWYNIKI OBLICZEŃ: średniej geometrycznej wyrażow ciągu liczbowego " +
                                $"n = {n} jest równa: {result,1:F}");

                            Console.ReadKey();
                        }
                        break;
                    case ConsoleKey.E: //
                        {
                            Console.Clear();

                            Console.WriteLine("\n\n\tWYBRANO: E. Obliczenie ceny jednostki paszy (według średniej ważonej)\n" +
                                " składającej się (utworzonej, skomponowanej)  z kilku składników");

                            Console.WriteLine("\n\tPodaj illość składników: ");
                            int n = Convert.ToInt32(Console.ReadLine());

                            float result = ObliczenieCenyJednostki(n);

                            Console.WriteLine("\n\tWYNIKI OBLICZEŃ: ceny jednostki paszy " +
                                              $"n = {n} jest równa: {result, 1:F}");


                            Console.ReadKey();
                        }
                        break;
                    case ConsoleKey.F: //
                        {
                            Console.Clear();

                            Console.WriteLine("\n\n\tWYBRANO: F. Obliczenie wartości wielomianu n-tego stopnia według schematu Hernera");

                            float Wx; // Obliczona wartość wielomianu
                            float X; // wczytana wartość zmiennej niezależnej: typu float
                            ushort n;
                            // wywołanie metody obliczania wartości wielomianu według schematu Hornera
                            ObliczenieWartościWielomianu(out Wx, out X, out n);
                            // Wypisanie wyników obliczeń
                            // wypisanie wyniku obliczeń w notacji stałopozycyjnej (fixed-point)
                            Console.WriteLine($"\n\n\tWYNIKI: obliczona wartość wielomianu n = {n}-ego stopnia " +
                                $"dla zmiennej niezależnej X = {X,6:E2}, jest równa: {Wx,8:F3}");
                            //inne formaty wypisywania wartości typu 'float'
                            /* wypisanje wyniku obliczeń w notacji  naukowej (postać wykładnicza),
                               w której jedna cyfra zawsze poprzedza znak dziesiętny (czyli kropkę: . )*/
                            Console.WriteLine($"\n\n\tWYNIKI: obliczona wartość wielomianu n = {n}-ego stopnia " +
                                $"dla zmiennej niezależnej X = {X,6:E2}, jest równa: {Wx,8:E3}");
                            // wypisanie wyniku obliczeń w najbardziej natacji (naukowiej lub stałopozycyjnej)
                            Console.WriteLine($"\n\n\tWYNIKI: obliczona wartość wielomianu n = {n}-ego stopnia " +
                                $"dla zmiennej niezależnej X = {X,6:G}, jest równa: {Wx,8:G}");
                        }
                        break;
                    case ConsoleKey.G: //
                        {
                            Console.WriteLine("\n\n\tWYBRANO: Konwersja liczby całkowitej zapisanej znakowo w systemie liczbowym o podanej\n" +
                                " podstawie liczenia na wartość i jej wypisanie znakowo w innym systemie liczbowym\n" +
                                "  o podanej podstawie liczenia");


                        }
                        break;
                }

            } while (WybranaFunkcjonalniość.Key != ConsoleKey.X);
        }
        #endregion
        //deklaracje metod dla potreb projektowanego programu: Projekt Nr 1
        #region Deklaracje metod obsługi funkcjonalności Kalkulator laboratoryjnego
        private static void SumaWyrazówCiąguLiczbowego(out float suma, out ushort n)
        {
            /* przez parametr formalny:
                - n bębzie przesłana liczność ciągu liczbowego
                - S będzie przesłana obliczona suma wyrazuw ciągu liczbowego*/
            float a;

            do
            {
                Console.Write("\n\tPodaj liczność ciągu liczbowego n: ");
            } while (!ushort.TryParse(Console.ReadLine(), out n));

            suma = 0.0f;

            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine($"\n\tPodaj {i}-ą wartość wyrazu ciągu liczbowego: ");
                while (!float.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine($"\n\tERROR: w zapisie {i} - go wyrazu ciągu " +
                        $"liczbowego wystąpił niedozwolony znak!");
                    Console.Write($"\n\tPodaj ponownie wartość {i} -go wyrazu ciągu" +
                        "liczbowego");
                }
                suma = +a; // lub: S+= a; gdzie += jest tzw.
            }
        }
        private static float IloczynWyrazówCiąguLiczbowego()
        {
            // deklaracje lokalne dla przechowania danych
            ushort n; // Liczność ciągu liczbowego 
            float a; // wczytana wartość wyrazu ciągu liczbowego
            float Iloczyn; // wynik obliczeń: iloczyn wyrazów ciągu liczbowego
            // wczytanie liczności ciągu liczbowego
            /* na liczność ciągu liczbowego "nałożony" jest warunek wejściowy: n > 0 i
               dlatego zastosujemy wetodę ushort.TryParce(Console.ReadLine(), out n)*/
            // wypisanie zaproszenia do podania liczności ciągu liczbowego n
            Console.Write("\n\tPodaj liczność ciągu liczbowego n: ");
            while (!ushort.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("\n\tERROR: w zapisie liczności ciągu " +
                    "liczbowego wystąpił niedozwolony znak!!!");
                // wypisanie zaproszenia do podania liczności ciągu liczbowego n
                Console.Write("\n\tPodaj ponownie liczność ciągu liczboweg n: ");

            }

            // obliczenie iloczynu wyrazów ciągu liczbowego według wzoru iteracyjnego
            Iloczyn = 1.0f;
            /* iteracyjne obliczanie iloczynu wyrazów ciągu liczbowego
             * UWAGA: gdy n będzie równe 0, to nastąpi zakończenie instrukcji 'for
              już na samym początku gdyż wyrażenie: i <= n przyjmie wartość 'false*/
            for (int i = 0; i <= n; i++)
            {//wczytanie i-tej wartości wyrazu ciągu liczbowego
                Console.Write($"\n\tPodaj {i}-ą wartość wyrazu ciągu liczbowego: ");
                while (!float.TryParse(Console.ReadLine(), out a))
                { // sygnalizacja błędu
                    Console.WriteLine($"\n\tERROR: w zapisie {i} -go wyrazu ciągu " +
                        "liczbowego wystapił niedozwolony znak!!!");
                    // wypisanie zapeoszenia do ponownego podania liczności ciągu liczbowego
                    Console.Write($"\n\tPodaj ponowie wartość {i}-go wyrazu ciągu liczbowego:");
                }
                Iloczyn *= a; // lub: Iloczyn = Iloczyn * a;
            }
            // zwrotne (przez nazwę metody) przekazanie wyniku obliczeń
            return Iloczyn;
        }
        private static float ŚredniaArytmetycznaWyrazówCiąguLiczbowego(out ushort n)
        {
            float Suma;
            // obliczenie sumy arytmetycznej wyazów ciągu liczbowego
            SumaWyrazówCiąguLiczbowego(out Suma, out n);
            /* obliczenie średniej arytmetycznej i jej zwrotne przekazanie do
             miejsca wywołania metody ŚredniaArytmetycznaWyrazówCiąguLiczbowego*/
            return Suma / n;
        }
        private static void PierwiastkieRównaniaKwadratowe(out float a, out float b, out float c)
        {
            // wczytanie danuch wejściowych: warunek wejściowy a != 0.0

            do
            {
                //wczytanie wartości współczynnika a
                //wypisanie zaproszenia do podania wartości współczynnika
                Console.Write("\n\tPodaj wartości współczynika a: ");
                a = float.Parse(Console.ReadLine());
                // sprawdzenie warunku wejściowego: a == 0
                if (a == 0.0f)
                {
                    // sygnał dźwiekowy dla Użytkownika, że coś jest 
                    Console.Beep(200, 500);
                    Console.WriteLine("\n\tERROR: Wartośc współczynnika" +
                        " muśi być różna od zera !!!");
                }
            } while (a == 0.0f);
            // wczytanie wartości współczynnika b
            // wypisanie zaproszenia do podania wartości współczynnika
            Console.Write("\n\tPodaj wartości współczynika b: ");
            b = float.Parse(Console.ReadLine());

            // wczytanie wartości współczynnika c
            // wypisanie zaproszenia do podania wartości współczynnika
            Console.Write("\n\tPodaj wartości współczynika c: ");
            c = float.Parse(Console.ReadLine());
            // deklaracja zmiennych dla  obliczanych wartisci
            float Delta, X1, X2, X1_2;
            // obliczenie Delty
            Delta = b * b - 4.0f * a * c;
            // Wypisanie Delty
            Console.WriteLine($"\n\tObliczona wartość Delty = {Delta}");

            // obliczenie wartości pierwiastków równania kwadratowego
            if (Delta > 0.0f)
            {
                X1 = (-b - (float)Math.Sqrt(Delta)) / (2.0f * a);
                X2 = (-b + (float)Math.Sqrt(Delta)) / (2.0f * a);
                // wypisanie wyniku obliczeń
                Console.WriteLine("\n\t Równanie ma dwa pierwiastki rzeczywiste:\n");
                Console.WriteLine($"\t X1 = {X1,8:F2} \t X2 = {X2,8:F2} \t Delta = {Delta,8:F4}");
            }
            else
            {
                if (Delta < 0.0)
                    Console.WriteLine("\n\tRównanie o podanych współczynnikach" +
                        " nie ma pierwiastków rzeczywistych!\n" +
                        $"\t\tDelta = {Delta,8:F2}");
                else
                {//Delta jest równa zero
                    X1_2 = -b / (2.0f * a);
                    // Wyprowadzenie wyników obliczeń
                    Console.WriteLine("\n\t Równanie ma jeden pierwiastek podwójny:\n");
                    Console.WriteLine($"\n\n\tWYNIKI: X1_2 = {X1_2}");
                    Console.WriteLine($"\t X1_2 = {X1_2,6:E3} \t Delta = {Delta,8:E2}");
                }
            }
        }
        private static void ObliczenieWartościWielomianu(out float Wx, out float X, out ushort n)
        {/* pomocnicze (na etap uruchamiania programu) przypisanie wartości "testowych"
            wyjściowym parametrom formulnym */
            Wx = X = 0.0F; n = 0;
            // wczytanie stopnia wielomianu
            Console.Write("\n\n\tPodaj stopień wielomianu: ");
            while (!ushort.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("\n\n\tERROR: w podanej wartości stopnia wielomianu wystąpił niedozwolony znak");
                Console.Write("\n\n\tPodaj ponownie stopień wielomianu: ");
            }
            // wczytanie wartości zminnej niezależnej X
            Console.Write("\n\n\tPodaj wartości zmiennej niezależnej X: ");
            while (!float.TryParse(Console.ReadLine(), out X))
            {
                Console.WriteLine("\n\n\tERROR: w podanej wartości zmiennej niezależnej X wystąpił niedozwolony znak");
                Console.Write("\n\n\tPodaj ponownie wartości zmiennej niezależnej X: ");
            }
            float a; //deklaracja pomocnicza dla przechowania wartości wczytanego współczynnika wielomianu
            Wx = 0.0F; //warunek brzegowy (początkowy)
            // iteracyjne obliczanie wartości wielomianu według schematu Hornera
            for (int i = n; i >= 0; i--)
            {
                Console.Write($"\n\tPodaj wartość {i} -go współczynnika Wielomianu: ");
                while (!float.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine($"\n\n\tERROR: w zapisie wartości {i} -go współczynnika wielomianu wystąpił niedozwolony znak");
                    Console.Write($"\n\tPodaj ponownie wartość {i}-go współczynnika wielomianu: ");
                }
                // iteracyjne obliczanie wartości wielomianu według schematu Hornera
                Wx = Wx * X + a;
            }
        }
        static void KonwerterLiczb()
        {
            ConsoleKeyInfo WybranaFunkcjonalność;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;

            do
            {
                Console.Clear();
                // wypisanie Metryki i menu Konwertera liczb
                Console.WriteLine("\n\n\tMENU funkcjonalne Konwertera liczb: ");
                Console.WriteLine("\n\tA. korwersja znkowego  zapisu liczby (w systemie dziesiętnym)" +
                    "\n\t\t na  znakowy zapis liczb w systemie binarnym");
                Console.WriteLine("\n\tB. Konwersja liczby naturalnej (w sustemie szesnastkowej " +
                    "\n\t\t na  znakowy zapis liczb w systemie trzynastkowym");
                Console.WriteLine("\n\tC. Konwersja liczby stałopozycyjnej ((bez znaku), zapisanej w systemie dziesiętnym, na liczbę \n\t stałopozycyjną zapisaną w systemie dwójkowym");

                Console.WriteLine("\n\tX. Zakończenie Konwertora liczb");
                // wypisanie odpowiedzi dla Użytkownika: co ma teraz zrobić
                Console.Write("\n\tNaciśni odpowiedni klawisz (A, B ... X) dla wybrania wymaganej funkcjonalności: ");
                // wcytanie kodu naciśniętego klawisza
                WybranaFunkcjonalność = Console.ReadKey();


                //rozpoznanie kodu naciśniętego klawisza
                if (WybranaFunkcjonalność.Key == ConsoleKey.A)
                {
                    //deklaracja zmiennych dla przechowania wyników
                    string ZZLD, ZZLB;
                    // wcytanie liczby do konwersji
                    Console.Write("\n\tPodaj znakowy zapis liczby (w systemie szisiętnym) do konwersji: ");
                    ZZLD = Console.ReadLine();
                    //wywołanie metody dla konwersji liczby ZZLD na liczbę ZZLB
                    KonwersjaLiczbyZZLDnaLiczbęZZLB(ZZLD, out ZZLB);
                    // wypisanie wyniku konwersji
                    /*Console.WriteLine("\n\n\tWYNIK KONWERSJI: wczytana znakowo liczba do konwersji: " +
                        $"{ZZLD} jest rónoważna (pod względem wartości) znakowemu zapisowi tej liczby " +
                        $"w systemie dwójkowym(binarnym): {ZZLB}");*/
                    // chwilowe zatrzymanie programu
                    Console.WriteLine("\n\n\tDla kontynacji działania programu naciśnij dowolny klawisz");
                    Console.ReadLine();
                }
                else if (WybranaFunkcjonalność.Key == ConsoleKey.B)
                {/*B. Konwersja liczby naturalnej (w sustemie szesnastkowej " +
                na  znakowy zapis liczb w systemie rrzynastkowym*/
                    string ZZL16, ZZL13;
                    KonwerterLiczby16NaLiczbę13(out ZZL16, out ZZL13);
                    // wypisanie wyników konwersji 
                    Console.WriteLine($"\n\n\tWYNIKI Konwersji: wczytana liczby do konwersji: {ZZL16} " +
                        $"odpowiada liczbie po konwersji (w systemie binarnej): {ZZL13}");

                }
                else if (WybranaFunkcjonalność.Key == ConsoleKey.C)
                {
                    Console.WriteLine("\n\n\tWybrałeś konwersję: C. Konwersja liczby" +
                           " stałopozycyjnej ((bez znaku), zapisanej w systemie " +
                             "dziesiętnym, na \n\t\t\t\tliczbę stałopozycyjną zapisaną w systemie dwójkowym");

                    // deklaracje podstaw systemów liczbowych
                    const byte p = 10;
                    const byte q = 2;
                    // dodatkowe deklaracje lokalne
                    ushort Lc; // Lc - część całkowita liczby do konwersji na wartość
                    float Lu; // Lu - część ułamkowa liczby do konwersji na wartość
                    string[] DwieCzęściLiczbyStałopozycyjnej; /* tablica dla 
                                                           * przechowania znakowego zapisu części całkowitej i
                                                             ułamkowej liczby stałopozycyjnej do konwersji na
                                                             wartość */
                    // wczytanie liczby stałopozycyjnej do konwersji np. 23,56
                    Console.Write("\n\tPodaj liczbę stałopozycyjną (z kropką lub" +
                    " przecinkiem) do konwersji: ");
                    /* wczytanie liczby stałopozycyjnej i jej podzielenie na część
                     * całkowitą i ułamkową, co zostanie zapisane w tablicy
                     * DwieCzęściLiczbyStałopozycyjnej */
                    DwieCzęściLiczbyStałopozycyjnej = Console.ReadLine().Split(new char[] { '.', ',' });
                    // konwersja części całkowitej wczytanej liczby stałopozycyjnej (do konwersji)
                    string ZZL = DwieCzęściLiczbyStałopozycyjnej[0]; // pobranie części całkowitej 
                    ZZL = ZZL.TrimStart(); // usunięcie spacji przed zapisem liczby stałopozycyjnej
                                           // konwersja części całkowitej na wartość
                    int N = ZZL.Length; /* określenie liczby cyfr w znakowym zapisie
                                     * części całkowitej liczby do konwersji */

                    char Cyfra;
                    // konwersja cyfrowego zapisu liczby na wartość według schematu Hornera
                    Lc = 0; // początkowy stan obliczeń (warunek brzegowy) schematu iteracyjnego

                    for (int i = 0; i < N; i++)
                    {
                        Cyfra = ZZL[i]; // pobranie i-tej cyfry części całkowitej liczby do konwersji
                                        // sprawdzenie czy jest to cyfra w dziesiętnym systemie liczbowym
                        if ((Cyfra >= '0') && (Cyfra <= '9'))
                            Lc = (ushort)(Lc * p + ((byte)Cyfra - (byte)'0'));
                        else
                        {
                            Console.WriteLine("\n\n\tERROR: w zapisie liczby do" +
                           "konwersji wystąpił niedozwolony znak");
                            // chwilowe zatrzymanie programu
                            Console.WriteLine("\n\tDla kontynuacji obliczeń naciśnij" +
                            "dowolny klawisz...");

                            Console.ReadKey();
                            // wyjście z metody konwersji
                            return;
                        }
                    } // od for
                      // kontrolne wypisanie wartości liczby po konwersji na zapis znakowy
                    Console.WriteLine($"\n\n\tTRACE: Wyznaczona wartość części całkowitej liczby: {Lc}");
                    // deklaracja uzupełniająca dla potrzeb konwersji części ułamkowej liczby
                    float LiczbaFloat; // dla liczby liczby stałopozyjnej po konwersji na wartość

                    /* sprawdzenie, czy wczytana liczba miała część ułamkową, gdyż
                    tylko wtedy tablica DwieCzęściLiczbyStałopozycyjnej będzie
                    miała 2 pozycje: w pierwszej będzie znakowy zapis części całkowitej
                    liczby, a w drugiej będzie znakowy zapis jej części ułamkowej */

                    if (DwieCzęściLiczbyStałopozycyjnej.Length == 2) // true, gdy była część ułamkowa liczby
                    {// pobranie części ułamkowej liczby stałopozycyjnej do konwersji
                        ZZL = DwieCzęściLiczbyStałopozycyjnej[1];
                        ZZL = ZZL.TrimEnd();  // usunięcie spacji po części ułamkowej liczbie

                        N = ZZL.Length; // określenie liczby cyfr w znakowym zapisie liczby do konwersji
                                        // iteracyjne wyznaczenie wartości części ułamkowej liczby według schematu Hornera
                        Lu = 0.0F; // początkowy stan obliczeń (warunek brzegowy) schematu iteracyjnego
                        float JednaDziesiąta = 1.0F / p; // pomocniczo, dla minimalizacji działań w instrukcji 'for'

                        for (int i = N - 1; i >= 0; i--)
                        {// pobieramy cyfry od "końca"
                            Cyfra = ZZL[i]; // pobranie i-tej cyfry liczby do konwersji
                                            // sprawdzenie, czy jest to cyfra dziesiętnego systemu liczbowego
                            if ((Cyfra >= '0') && (Cyfra <= '9'))
                                Lu = (float)(Lu * JednaDziesiąta + ((byte)Cyfra - (byte)'0'));
                            else
                            {
                                Console.WriteLine("\n\n\tERROR: w zapisie liczby do konwersji " +
                                    "wystąpił niedozwolony znak");
                                // chwilowe zatrzymanie programu
                                Console.WriteLine("\n\tDla kontynuacji obliczeń" +
                                                    "naciśnij dowolny klawisz...");
                                Console.ReadKey();
                                // wyjście z Konwertera liczb
                                return;
                            }
                        } // od for
                          // końcowe wyznaczenie części ułamkowej Lu liczby do konwersji
                        Lu = Lu * JednaDziesiąta; // JednaDziesiąta = 1.0F / 10F;
                                                  // kontrolny wypis liczby po kropce
                        Console.WriteLine($"\n\n\tTRACE: Wartość części ułamkowej liczby: Lu = {Lu}");
                        // złożenie części całkowitej Lc z częścią ułamkową Lu liczby do konwersji
                        LiczbaFloat = (float)Lc + Lu;

                    }
                    else // gdy była to liczba tylko całkowita, to przyjmujemy, że część ułamkowa jest róna zero
                    {
                        Lu = 0.0F; LiczbaFloat = (float)Lc + Lu;
                    }
                    // Kontrolne wypisanie wyniku konwersji liczby stałopozycyjnej na wartość
                    Console.WriteLine($"\n\tTRACE: wartość liczby stałopozycyjnej po konwersji na wartość: {LiczbaFloat,6:F3}");

                }
                else if (WybranaFunkcjonalność.Key != ConsoleKey.X)
                {
                    Console.WriteLine("\n\tERROR: nacisnąłe niedozwolony klawisz " +
                                "(znak) - nie ma takiej funkcjonalności");
                }
                Console.WriteLine("\n\n\tDla kontynacji działania programu naciśnij dowolny klawisz");
                Console.ReadLine();

            } while (WybranaFunkcjonalność.Key != ConsoleKey.X);
        }

        private static void KonwersjaLiczbyZZLDnaLiczbęZZLB(string zZLD, out string zZLB)
        {
            throw new NotImplementedException();
        }

        private static ushort KonwersjaZnakowejLiczbyNaWartość(string ZZL)
        {
            //deklaracje
            ushort L; // wartość liczby po konwersji
            int N; // liczba cyfr w ZZL
            byte p = 10; // podstawa systemu liczbowego dla liczby zapisanej w ZZL

            char Cyfra;
            // określenie (obczytanie) liczby cyfr w ZZL
            N = ZZL.Length;
            // konwersja ZZL na wartość według schematu Hornera
            L = 0; // warunek brzegowy
            for (byte i = 0; i < N; i++)
            {//pobranie i-tej cyfry z ZZL
                Cyfra = ZZL[i];
                // sprawdzenie, czy to jest na pewno cyfra: 0 1 ... 9
                if ((Cyfra >= '0') && (Cyfra <= '9'))
                    L = (ushort)(L * p + ((byte)Cyfra - (byte)'0'));
                else
                { // sygnalizacja błędu
                    Console.WriteLine("\n\n\tERROR: w podanym zapisie " +
                        "liczby do konwersji wystąpił niedozwolony znak");
                    // chwilowe zatrymmanie programu
                    Console.WriteLine("\n\tDla zakończenia działania programu naciśnij dowolny klawisz!");
                    Console.ReadKey();
                    //zakończenie konwersji
                    return 0;
                }

            }
            // zwrotne przekazanie wyniku konwersji
            return L;
        }
        // deklaracja 
        static void KonwersacjaLiczbyNaturalnejNaBinarna(ushort L, out string ZZL)
        {// dla celów testowych przypisujemy domyślną wartość parametrowi wyjąściowenu

            // deklaracje zmiennych dla potrzeb konwersji liczby L na jej znakowy zapis w systemie dwójkowym
            byte Reszta;
            string SchowekReszt = ""; // tutaj będą przechowywane reszty z dzielenia
            int Licznik = 0; // dla liczenia reszt z dzielenia
            byte q = 2; // podstawa dwójkowego systemu liczbowego

            while (L > 0)
            {
                //obliczenie reszty
                Reszta = (byte)(L % q); // % to jest operacja MODULO
                // przechowanie reszty
                SchowekReszt = SchowekReszt + (char)(Reszta + (byte)'0');
                Licznik++; // zwiększenie licznika reszt
                // obliczenie wyniku dzielenia całkowitego
                L = (ushort)(L / q);
            }
            // odwrócenie znakowego zapisu reszt z dzielenia
            ZZL = "";
            for (int i = Licznik - 1; i >= 0; i--)
            {
                ZZL = ZZL + SchowekReszt[i];
            }
        }
        static void KonwerterLiczby16NaLiczbę13(out string ZZL16, out string ZZL13)
        {
            ZZL13 = "";
            ZZL16 = "";

            //deklaracja pomocnicze
            byte p = 16;
            byte g = 13;
            //wypisanie Metryki konwertera 
            Console.WriteLine("\n\n\t\tKonwerter liczb z zapisanych znakowo w systemie szesnastkowym " +
                "na liczbie w systemie trynastkowym");

            // wypisanie zaproszenia dla podania liczby konwersji
            Console.Write("Podaj znakowy zapis liczby do konwersji w systemie szesnastkowym: ");
            ZZL16 = Console.ReadLine();
            // usunięcie zbędnych  tzw Biąłych znaków
            ZZL16 = ZZL16.Trim();
            // określenie liczby cyfr wczytanej liczby do konwersji
            int N = ZZL16.Length;
            // ustalenie marunku brzegowego dla konwersji znakowego zapisu liczby na wartość
            int L = 0;
            char Cyfra;
            for (int i = 0; i < N; i++)
            {// wybranie z ZZL16 i-tej cyfry 
                Cyfra = ZZL16[i];
                // sprawdzenie, czy to jest na pewno cyfra: 0 1 ... 9
                if ((Cyfra >= '0') && (Cyfra <= '9'))
                {
                    L = L * p + ((byte)Cyfra - (byte)'0');      
                 }
                else
                {   
                    Cyfra = Char.ToUpper(Cyfra);
                    //
                    if ((Cyfra <= 'A') && (Cyfra <= 'F'))
                    {
                        L = L * p + ((byte)Cyfra - (byte)'A') + 10;
                    }
                    else
                    {
                        // sygnalizacja błędu
                        Console.WriteLine("\n\n\tERROR: w podanym zapisie " +
                            "liczby do konwersji wystąpił niedozwolony znak");
                        // chwilowe zatrymmanie programu
                        Console.WriteLine("\n\tDla zakończenia działania programu naciśnij dowolny klawisz!");
                        Console.ReadKey();
                    }

                }
            }
            Console.WriteLine("\n\n\tDla kontynacji działania programu naciśnij dowolny klawisz");
            Console.ReadLine();
        }
        #endregion
        #region  Deklaracje metod obsługi funkcjonalności Kalkulator Projectowego Nr1
        static float ObliczenieŚredniejHarmomicznej(out float Śr, int n)
        {
            int liczba;
            Śr = 0;

            for (int i = 0; i <= n; i++)
            {
                Console.Write($"\n\tPodaj {i}-j element liczb: ");
                liczba = Convert.ToInt32(Console.ReadLine());

                Śr += (1 / liczba);
            }
            Śr = n / Śr;
            return Śr;
        } // -
        static double ŚredniaKwadratowaCiągu(int n)
        {
            double a = 0;
            double pow = 2;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"\n\tPodaj a {i + 1} :");
                a += Math.Pow(Convert.ToDouble(Console.ReadLine()), pow);
            }

            double result = Math.Sqrt(a / n);

            return result;

        } // +
        static double ŚredniaPotęgowaCiągu(int n, double b) // +
        {
            double a = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"\n\tPodaj a {i + 1} :");
                a += Math.Pow(Convert.ToDouble(Console.ReadLine()), b);

            }
            double result = Math.Pow((a / n), 1 / b);

            return result;
        }
        static double ŚredniaGeometrycznaCiągu(int n) // +
        {

            double multiplying = 1;
            double result;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"\n\tPodaj dodatni liczby a{i + 1}: ");
                multiplying *= Convert.ToDouble(Console.ReadLine());
            }

            result = Math.Pow(multiplying, 1.0 / n);

            return result;

        }
        static float ObliczenieCenyJednostki(int n)
        {

            float cena;
            float liczbaKg;

            float c = 0;
            float m = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"\n\tPodaj cenu składnika {i + 1}-go: ");
                cena = Convert.ToInt32(Console.ReadLine());

                Console.Write($"\n\tPodaj liczbu Kg {i + 1}-go: ");
                liczbaKg = Convert.ToInt32(Console.ReadLine());

                float cc = cena * liczbaKg;
                Console.WriteLine($"\n\tCena całego {i + 1}-go składnika: {cc} ");


                c += cena * liczbaKg;// c = c + (cena * liczbuKg)
                m += liczbaKg;
            }

            return c / m; 
        }// +

        #endregion
    }
}
