package vistula.ar.l02_radovskyi_61986_kalkulator;

public class CalculateTools {

    static int calculateTools(int N1, int N2, String operator){
    int result = 0;
        switch (operator){
            case "+":
                result = N1 + N2;
                break;
            case "-":
                result = N1 - N2;
                break;
            case "*":
                result = N1 * N2;
                break;
        }
    return result;
    }
}
