package vistula.ar.l08_radovskyi_61986_chimgamev2;

import java.util.Random;

public class AlgorytmPermuntacji {
    public static int[] shuffleFisherYeats(int[] oldArray){
        Random rnd = new Random();
        int c;
        int[] newArray = oldArray;
        for (int j, i = oldArray.length - 1; i>0; i--){
            j = rnd.nextInt(i+1);
            c = newArray[j];
            newArray[j] = newArray[i];
            newArray[i] = c;
        }
        return newArray;
    }
}
