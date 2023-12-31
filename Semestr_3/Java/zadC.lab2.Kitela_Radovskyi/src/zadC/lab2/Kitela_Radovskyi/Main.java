package zadC.lab2.Kitela_Radovskyi;

import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);

        System.out.print("Podaj kolor w formacie #RRGGBB: ");
        String kolor = scanner.nextLine();

        int[] skladnikiKoloru = konwertujKolor(kolor);

        if (skladnikiKoloru != null) {
            System.out.println("Skladowe koloru (R, G, B):");
            for (int skladnik : skladnikiKoloru) {
                System.out.print(skladnik + " ");
            }
        }
	}
	
	private static int[] konwertujKolor(String tekst) {
        if (!tekst.matches("^#([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})$")) {
            System.err.println("Błędny format koloru. Poprawny format to '#RRGGBB'");
            return null;
        }

        int r = Integer.parseInt(tekst.substring(1, 3), 16);
        int g = Integer.parseInt(tekst.substring(3, 5), 16);
        int b = Integer.parseInt(tekst.substring(5, 7), 16);

        return new int[]{r, g, b};
    }
}
