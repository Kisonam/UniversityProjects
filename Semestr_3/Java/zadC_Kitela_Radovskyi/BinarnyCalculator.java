package pojava.lab1.zadC_Kitela_Radovskyi;

public class BinarnyCalculator {
	public static void main(String[] args) {
		 Scanner scanner = new Scanner(System.in);

	        System.out.print("Podaj liczbę całkowitą: ");
	        int liczba = scanner.nextInt();

	        if (liczba < 0) {
	            System.out.println("Podaj liczbę nieujemną.");
	        } else {
	            displayBinaryRepresentation(liczba);
	        }

	        scanner.close();

	}
	private static void displayBinaryRepresentation(int liczba) {
       int[] binaryArray = new int[32]; 
       
       for (int i = 31; i >= 0; i--) {
           binaryArray[i] = liczba % 2; 
           liczba /= 2; 
       }

       System.out.print("Reprezentacja binarna: ");
       
       for (int bit : binaryArray) {
           System.out.print(bit);
       }
   }
}
