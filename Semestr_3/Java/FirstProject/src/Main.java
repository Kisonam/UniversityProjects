import java.util.InputMismatchException;
import java.util.Scanner;

// Press Shift twice to open the Search Everywhere dialog and type `show whitespaces`,
// then press Enter. You can now see whitespace characters in your code.
public class Main {
    static boolean run = true;
    public static void printStr(String line) {
        System.out.println(line);
    }
    public static void main(String[] args) {
        Derivative derivative = new Derivative();
        Scanner scanner = new Scanner(System.in);

        do {
            derivative.menu(derivative.menu);
            derivative.operation = scanner.next();
            try {
                switch (derivative.operation) {
                    case "Op1":
                        System.out.println("a:");
                        int a = scanner.nextInt();

                        System.out.println("p:");
                        int p = scanner.nextInt();

                        derivative.simpleDer(a, p);
                        break;
                    case "Op2":
                        System.out.println("a:");
                        int aAd = scanner.nextInt();

                        System.out.println("b:");
                        int b = scanner.nextInt();

                        System.out.println("c:");
                        int c = scanner.nextInt();

                        System.out.println("exp1:");
                        int exp1 = scanner.nextInt();

                        System.out.println("exp2:");
                        int exp2 = scanner.nextInt();

                        System.out.println("exp3:");
                        int exp3 = scanner.nextInt();

                       derivative.advanceDer(aAd, b, c, exp1, exp2, exp3);
                        break;
                    case "Op3":
                        derivative.derivativeForSqrtX();
                        break;
                    case "Op4":
                        derivative.derivativeForComplexFunction();
                        break;
                    case "Op5":
                        derivative.derivativeForConstant();
                        break;
                    case "Exit":
                        System.out.println("You have exited the calculator");
                        System.exit(0);
                        run = false;
                        break;
                    default:
                        System.out.println("Invalid");
                }
            } catch (InputMismatchException e) {
                System.out.println("! - ERROR - !\n Your ERROR: " + e);
            }
        } while (run);

        scanner.close();
    }
}