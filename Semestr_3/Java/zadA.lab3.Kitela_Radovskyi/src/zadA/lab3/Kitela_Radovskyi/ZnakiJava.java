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
                wyniki[0]++;

                if (Character.isWhitespace(znak)) {
                    wyniki[1]++;
                    czyBialyZnak = true;
                } else {
                    czyBialyZnak = false;
                }

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
		String nazwaPliku = "src/sometext.txt";
        int[] wynik = liczZnakiSlowa(nazwaPliku);

        if (wynik != null) {
            System.out.println("Liczba znaków: " + wynik[0]);
            System.out.println("Liczba białych znaków: " + wynik[1]);
            System.out.println("Liczba słów: " + wynik[2]);
        }

}}
