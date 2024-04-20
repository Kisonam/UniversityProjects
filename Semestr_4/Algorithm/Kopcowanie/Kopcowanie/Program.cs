using Kopcowanie;

internal class Program
{
    
    public static void Main(string[] args)
    {
        int[] array = new int[50];

        Random rand = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(100);
        }

        Console.WriteLine("Tablica przed sortowaniem:");
        PrintArray(array);

        int[] heapSortArray = new int[array.Length];
        array.CopyTo(heapSortArray, 0);

        int[] quickSortArray = new int[array.Length];
        array.CopyTo(quickSortArray, 0);

        int heapSortComparisons, heapSortSwaps;
        SortingAlgorithms.HeapSort(heapSortArray, out heapSortComparisons, out heapSortSwaps);

        Console.WriteLine("\nTablica po sortowaniu przez kopcowanie:");
        PrintArray(heapSortArray);
        Console.WriteLine("Liczba operacji porównania: " + heapSortComparisons);
        Console.WriteLine("Liczba operacji zamiany miejscami: " + heapSortSwaps);

        int quickSortComparisons, quickSortSwaps;
        SortingAlgorithms.QuickSort(quickSortArray, 0, quickSortArray.Length - 1, out quickSortComparisons, out quickSortSwaps);

        Console.WriteLine("\nTablica po sortowaniu szybkim:");
        PrintArray(quickSortArray);
        Console.WriteLine("Liczba operacji porównania: " + quickSortComparisons);
        Console.WriteLine("Liczba operacji zamiany miejscami: " + quickSortSwaps);

        Console.ReadLine();
    }
    
    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}