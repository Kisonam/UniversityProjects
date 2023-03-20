using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNr1_Radovskyi61986
{
    public static class ExtremuSzeregu
    {
        public static float MinSx(float[ , ] TWS)
        { // deklaracje pomocnicza
            float AktualneMin;
            AktualneMin= TWS[ 0,1 ]; // ustalenie stanu początkowego
            // analiza kolejnych wierszy TWS i szukanie wartości mniejszej do AktualneMin
            for (int i = 0; i < TWS.GetLength(0); i++)
            {
                /* sprawdzammy, czy w i-itym wierszy TWS jest wartość
                 * mniejsza od AktualneMin, wtedy ona zostanie przypisana
                 * do AktualneMin    */
                if (AktualneMin > TWS[i, 1])
                    AktualneMin= TWS[i, 1];
            }
            return AktualneMin;
        }
        public static float MaxSx(float[,] TWS)
        { // deklaracje pomocnicza
            float AktualneMax;
            AktualneMax = TWS[0, 1]; // ustalenie stanu początkowego
            // analiza kolejnych wierszy TWS i szukanie wartości mniejszej do AktualneMin
            for (int i = 0; i < TWS.GetLength(0); i++)
            {
                /* sprawdzammy, czy w i-itym wierszy TWS jest wartość
                 * mniejsza od AktualneMin, wtedy ona zostanie przypisana
                 * do AktualneMax    */
                if (AktualneMax < TWS[i, 1])
                    AktualneMax = TWS[i, 1];
            }
            return AktualneMax;
        }
    }
}
