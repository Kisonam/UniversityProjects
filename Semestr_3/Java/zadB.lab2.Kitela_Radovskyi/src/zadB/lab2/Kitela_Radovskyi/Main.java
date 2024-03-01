package zadB.lab2.Kitela_Radovskyi;

import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);

        System.out.print("Podaj tekst do zaszyfrowania: ");
        String tekst = scanner.nextLine();

        System.out.print("Podaj liczbę przesunięcia (n): ");
        int przesuniecie = scanner.nextInt();

        String zaszyfrowanyTekst = szyfrCezar(tekst, przesuniecie);

        System.out.println("Zaszyfrowany tekst: " + zaszyfrowanyTekst);
        System.out.println("Koniec! ");
	}
	
	private static String szyfrCezar(String tekst, int przesuniecie) {
        StringBuilder zaszyfrowanyTekst = new StringBuilder();

        for (int i = 0; i < tekst.length(); i++) {
            char znak = tekst.charAt(i);

            if (znak != ' ') {
                char zaszyfrowanyZnak = (char) ('a' + (znak - 'a' + przesuniecie) % 26);
                zaszyfrowanyTekst.append(zaszyfrowanyZnak);
            } else {
                zaszyfrowanyTekst.append(' ');
            }
        }
        return zaszyfrowanyTekst.toString();
    }
}
