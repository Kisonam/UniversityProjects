import java.util.Scanner;

public class Derivative {
    public int a, p;
    public int adv_a, adv_b, adv_c;
    public String menu = "\nOp1 - simpleDer\nOp2 - advanceDer\nOp3 - Zad1\nOp4 - Zad2\nOp5 - Zad3\nExit\nYour variant: ";
    public String operation;
    public static Scanner scanner = new Scanner(System.in);

    public void simpleDer(int a, int p) {
        int calculation = a * p;
        int exp = p - 1;
        String line = "df = df(" + a + "x^" + p + ") = " + calculation + "x^" + exp;
        Main.printStr(line);
    }
    public void advanceDer(int a, int b, int c, int exp1, int exp2, int exp3) {
        int calc01 = exp1 * a;
        int exp1_res = exp1 - 1;
        int calc02 = exp2 * b;
        int exp2_res = exp2 - 1;
        int calc03 = exp3 * c;
        int exp3_res = exp3 - 1;

        String part01 = "df = " + calc01 + "x^" + exp1_res + " + " + calc02 + "x^" + exp2_res + " + " + calc03 + "x^" + exp3_res;
        String part02 = calc01 + "x^" + exp1_res + " + " + calc02 + "x^" + exp2_res + " + " + calc03 + "x^" + exp3_res;
        Main.printStr(part01 + " = " + part02);
    }
    public void derivativeForSqrtX() {
        // Pochodna funkcji: y = 15√𝑥
        double coefficient = 15;
        double exp = (double) 1 / 2;
        double resultCoefficient = coefficient * exp;
        String line = "y = 15√x\ndf = " + resultCoefficient + "x^" + exp;
        Main.printStr(line);
    }
    public void derivativeForComplexFunction() {
        // Pochodna funkcji: y = 3√𝑥 + 2𝑥^8 + 12𝑥^6
        double coefficient1 = 3;
        double exp1 = (double) 1 / 3;
        double coefficient2 = 2;
        double exp2 = 8;
        double coefficient3 = 12;
        double exp3 = 6;

        double resultCoefficient1 = coefficient1 * exp1;
        double resultCoefficient2 = coefficient2 * exp2;
        double resultCoefficient3 = coefficient3 * exp3;

        String line = "y = 3√x+ 2x^8 + 12x^6\ndf = " + resultCoefficient1 + "x^" + exp1 + " + " + resultCoefficient2 + "x^" + exp2 + " + " + resultCoefficient3 + "x^" + exp3;
        Main.printStr(line);
    }
    public void derivativeForConstant() {
        // Pochodna funkcji: y = 3 / 𝑥^5
        int coefficient = 3;
        int exp = -5;

        int resultCoefficient = coefficient * exp;

        String line = "y = 3 / x^5 \ndf = " + resultCoefficient + "x^" + exp;
        Main.printStr(line);
    }
    public void menu(String menu) {
        System.out.println(menu);
    }
}
