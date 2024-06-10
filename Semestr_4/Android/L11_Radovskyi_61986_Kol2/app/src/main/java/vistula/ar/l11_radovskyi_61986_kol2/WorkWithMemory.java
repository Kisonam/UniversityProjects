package vistula.ar.l11_radovskyi_61986_kol2;


import android.content.Context;
import java.io.FileOutputStream;
import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;

public class WorkWithMemory {
    private final String filenameAR = "Memory";

    public void createMemoryFile(Context context) {
        String fileContentsAR = " ";
        FileOutputStream fosAr = null;

        try {
            fosAr = context.openFileOutput(filenameAR, Context.MODE_PRIVATE);
            fosAr.write(fileContentsAR.getBytes());
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (fosAr != null) {
                try {
                    fosAr.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    public void saveToFile(Context context, String name, String surname, String town) {
        String fileContents = "Name: " + name + "\nSurname: " + surname + "\nTown: " + town;
        FileOutputStream fos = null;

        try {
            fos = context.openFileOutput(filenameAR, Context.MODE_PRIVATE);
            fos.write(fileContents.getBytes());
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (fos != null) {
                try {
                    fos.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    public String readFromFile(Context context) {
        StringBuilder stringBuilder = new StringBuilder();
        FileInputStream fis = null;

        try {
            fis = context.openFileInput(filenameAR);
            InputStreamReader inputStreamReader = new InputStreamReader(fis);
            BufferedReader bufferedReader = new BufferedReader(inputStreamReader);
            String line;

            while ((line = bufferedReader.readLine()) != null) {
                stringBuilder.append(line).append("\n");
            }
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            if (fis != null) {
                try {
                    fis.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }

        return stringBuilder.toString();
    }
}
