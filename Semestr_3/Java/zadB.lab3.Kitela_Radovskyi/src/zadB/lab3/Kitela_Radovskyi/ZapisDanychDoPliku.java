package zadB.lab3.Kitela_Radovskyi;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class ZapisDanychDoPliku {

	public static void zapiszDaneDoPliku(String nazwaPliku) {
        try (DataOutputStream dos = new DataOutputStream(new FileOutputStream(nazwaPliku))) {
            String imie = "Artem & Yuliia";
            int aktualnyRok = java.time.Year.now().getValue();
            double wynikDzielenia = 50.0 / 4.0;

            dos.writeUTF(imie);
            dos.writeInt(aktualnyRok);
            dos.writeDouble(wynikDzielenia);

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static int odczytajLiczbeBajtow(String nazwaPliku) {
        try (DataInputStream dis = new DataInputStream(new FileInputStream(nazwaPliku))) {
            byte[] buffer = new byte[4096];
            int bytesRead;
            int totalBytes = 0;

            while ((bytesRead = dis.read(buffer)) != -1) {
                totalBytes += bytesRead;
            }

            return totalBytes;

        } catch (IOException e) {
            e.printStackTrace();
            return -1;
        }
    }
    
	public static void main(String[] args) {
		String nazwaPliku = "daneBinarne.txt";
        zapiszDaneDoPliku(nazwaPliku);
        int liczbaBajtow = odczytajLiczbeBajtow(nazwaPliku);
        if (liczbaBajtow != -1) {
            System.out.println("Liczba bajtów w pliku: " + liczbaBajtow);
        } else {
            System.out.println("Wystąpił błąd podczas odczytu pliku.");
        }

	}

}
