package zadA.lab3.Kitela_Radovskyi;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class ZnakiJava {
	
	public static int[] liczZnakiSlowa(String nazwaPliku) {
        int[] wyniki = new int[3];

        try (BufferedReader br = new BufferedReader(new FileReader(nazwaPliku))) {
            int znak;
            boolean czyBialyZnak = false;
            boolean czyNoweSlowo = true;

            while ((znak = br.read()) != -1) {
                // Liczenie wszystkich znaków
                wyniki[0]++;

                // Liczenie białych znaków
                if (Character.isWhitespace(znak)) {
                    wyniki[1]++;
                    czyBialyZnak = true;
                } else {
                    czyBialyZnak = false;
                }

                // Liczenie słów
                if (!czyBialyZnak && czyNoweSlowo) {
                    wyniki[2]++;
                    czyNoweSlowo = false;
                } else if (czyBialyZnak) {
                    czyNoweSlowo = true;
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        return wyniki;
	}
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		 String nazwaPliku = "sciezka/do/twojego/pliku.txt";
	        int[] wyniki = liczZnakiSlowa(nazwaPliku);

	        System.out.println("Liczba znaków: " + wyniki[0]);
	        System.out.println("Liczba białych znaków: " + wyniki[1]);
	        System.out.println("Liczba słów: " + wyniki[2]);
	}

}
