namespace Kopcowanie;

public class SortingAlgorithms
{
    public static void HeapSort(int[] array, out int comparisons, out int swaps)
    {
        comparisons = 0;
        swaps = 0;
        int n = array.Length;
        
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(array, n, i, ref comparisons, ref swaps);
        
        for (int i = n - 1; i >= 0; i--)
        {
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;
            swaps++;

            Heapify(array, i, 0, ref comparisons, ref swaps);
        }
    }

    static void Heapify(int[] array, int n, int i, ref int comparisons, ref int swaps)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        
        comparisons++;
        if (left < n && array[left] > array[largest])
            largest = left;

        comparisons++;
        if (right < n && array[right] > array[largest])
            largest = right;

        if (largest != i)
        {
            int swap = array[i];
            array[i] = array[largest];
            array[largest] = swap;
            swaps++;

            Heapify(array, n, largest, ref comparisons, ref swaps);
        }
    }
    
    public static void QuickSort(int[] array, int low, int high, out int comparisons, out int swaps)
    {
        comparisons = 0;
        swaps = 0;

        if (low < high)
        {
            int partitionIndex = Partition(array, low, high, ref comparisons, ref swaps);

            QuickSort(array, low, partitionIndex - 1, out int leftComparisons, out int leftSwaps);
            QuickSort(array, partitionIndex + 1, high, out int rightComparisons, out int rightSwaps);

            comparisons += leftComparisons + rightComparisons;
            swaps += leftSwaps + rightSwaps;
        }
    }

    static int Partition(int[] array, int low, int high, ref int comparisons, ref int swaps)
    {
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            comparisons++;
            if (array[j] < pivot)
            {
                i++;
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                swaps++;
            }
        }
        
        int temp1 = array[i + 1];
        array[i + 1] = array[high];
        array[high] = temp1;
        swaps++;

        return i + 1;
    }
}