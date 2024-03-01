package zadA.lab2.Kitela_Radovskyi;

import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);

        System.out.print("Podaj ciąg znaków: ");
        String input = scanner.nextLine();

        String reversed = odwrocString(input);

        System.out.println("Odwrócony ciąg znaków: " + reversed);
        System.out.println("Koniec!");
	}
	
	private static String odwrocString(String str) {
        StringBuilder reversed = new StringBuilder();
        for (int i = str.length() - 1; i >= 0; i--) {
            reversed.append(str.charAt(i));
        }
        return reversed.toString();
    }

}
