namespace AgorytmShella;

public class SortingAlgorithms
{
    public static void InsertionSort(int[] arr, out int comparisons, out int swaps)
    {
        comparisons = 0;
        swaps = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                comparisons++;
                arr[j + 1] = arr[j];
                j--;
                swaps++;
            }
            arr[j + 1] = key;
        }
    }
    
    public static void SelectionSort(int[] arr, out int comparisons, out int swaps)
    {
        comparisons = 0;
        swaps = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                comparisons++;
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                swaps++;
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }
    }
    
    public static int[] GenerateRandomArray(int length)
    {
        int[] arr = new int[length];
        Random rand = new Random();
        for (int i = 0; i < length; i++)
        {
            arr[i] = rand.Next(100); // zakres losowych wartości od 0 do 99
        }
        return arr;
    }

 
    public static int[] CopyArray(int[] arr)
    {
        int[] copy = new int[arr.Length];
        Array.Copy(arr, copy, arr.Length);
        return copy;
    }
}