package pojava.lab1.zadB_Kitela_Radovskyi;

import java.util.Scanner;

public class Choinka {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);

        System.out.print("Podaj wysokość choinki (liczbę wierszy): ");
        int wysokosc = scanner.nextInt();

        if (wysokosc <= 0) {
            System.out.println("Wysokość choinki musi być większa niż 0.");
        } else {
        	drawChoinkę(wysokosc);
        }

        scanner.close();

	}
	private static void drawChoinkę(int wysokosc) {
        for (int i = 1; i <= wysokosc; i++) {
            
            for (int j = 0; j < wysokosc - i; j++) {
                System.out.print(" ");
            }

            for (int k = 0; k < 2 * i - 1; k++) {
                System.out.print("*");
            }

            System.out.println();
        }
    }
}
