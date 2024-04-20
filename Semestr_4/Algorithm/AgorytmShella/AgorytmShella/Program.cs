using AgorytmShella;

public class Program
{
    public static void Main(string[] args)
    {
       int[] randomArray = SortingAlgorithms.GenerateRandomArray(50);
        int[] sortedArray = new int[50];
        Array.Copy(randomArray, sortedArray, randomArray.Length);
        Array.Sort(sortedArray); // posortowana tablica
        int[] reversedArray = new int[50];
        Array.Copy(sortedArray, reversedArray, sortedArray.Length);
        Array.Reverse(reversedArray); // tablica posortowana w odwrotnej kolejności

        // Testowanie sortowania przez wstawianie
        int[] insertionRandom = SortingAlgorithms.CopyArray(randomArray);
        int[] insertionSorted = SortingAlgorithms.CopyArray(sortedArray);
        int[] insertionReversed = SortingAlgorithms.CopyArray(reversedArray);

        int comparisonsInsertionRandom, swapsInsertionRandom;
        SortingAlgorithms.InsertionSort(insertionRandom, out comparisonsInsertionRandom, out swapsInsertionRandom);
        Console.WriteLine("Insertion Sort - Random Array:");
        Console.WriteLine("Comparisons: " + comparisonsInsertionRandom);
        Console.WriteLine("Swaps: " + swapsInsertionRandom);

        int comparisonsInsertionSorted, swapsInsertionSorted;
        SortingAlgorithms.InsertionSort(insertionSorted, out comparisonsInsertionSorted, out swapsInsertionSorted);
        Console.WriteLine("\nInsertion Sort - Sorted Array:");
        Console.WriteLine("Comparisons: " + comparisonsInsertionSorted);
        Console.WriteLine("Swaps: " + swapsInsertionSorted);

        int comparisonsInsertionReversed, swapsInsertionReversed;
        SortingAlgorithms.InsertionSort(insertionReversed, out comparisonsInsertionReversed, out swapsInsertionReversed);
        Console.WriteLine("\nInsertion Sort - Reversed Array:");
        Console.WriteLine("Comparisons: " + comparisonsInsertionReversed);
        Console.WriteLine("Swaps: " + swapsInsertionReversed);

        // Testowanie sortowania przez wybieranie
        int[] selectionRandom = SortingAlgorithms.CopyArray(randomArray);
        int[] selectionSorted = SortingAlgorithms.CopyArray(sortedArray);
        int[] selectionReversed = SortingAlgorithms.CopyArray(reversedArray);

        int comparisonsSelectionRandom, swapsSelectionRandom;
        SortingAlgorithms.SelectionSort(selectionRandom, out comparisonsSelectionRandom, out swapsSelectionRandom);
        Console.WriteLine("\nSelection Sort - Random Array:");
        Console.WriteLine("Comparisons: " + comparisonsSelectionRandom);
        Console.WriteLine("Swaps: " + swapsSelectionRandom);

        int comparisonsSelectionSorted, swapsSelectionSorted;
        SortingAlgorithms.SelectionSort(selectionSorted, out comparisonsSelectionSorted, out swapsSelectionSorted);
        Console.WriteLine("\nSelection Sort - Sorted Array:");
        Console.WriteLine("Comparisons: " + comparisonsSelectionSorted);
        Console.WriteLine("Swaps: " + swapsSelectionSorted);

        int comparisonsSelectionReversed, swapsSelectionReversed;
        SortingAlgorithms.SelectionSort(selectionReversed, out comparisonsSelectionReversed, out swapsSelectionReversed);
        Console.WriteLine("\nSelection Sort - Reversed Array:");
        Console.WriteLine("Comparisons: " + comparisonsSelectionReversed);
        Console.WriteLine("Swaps: " + swapsSelectionReversed);
    }
    
}