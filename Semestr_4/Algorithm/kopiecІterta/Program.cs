
using System;
using System.Collections.Generic;

public class MinHeap
{
    private List<int> heap;

    public MinHeap()
    {
        heap = new List<int>();
    }

    public void Insert(int val)
    {
        heap.Add(val);
        HeapifyUp(heap.Count - 1);
    }

    public void Delete(int val)
    {
        if (heap.Contains(val))
        {
            int index = heap.IndexOf(val);
            Swap(index, heap.Count - 1);
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(index);
        }
    }

    public bool Contains(int val)
    {
        return heap.Contains(val);
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (heap[parentIndex] > heap[index])
            {
                Swap(parentIndex, index);
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void HeapifyDown(int index)
    {
        while (true)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int smallest = index;

            if (leftChildIndex < heap.Count && heap[leftChildIndex] < heap[smallest])
            {
                smallest = leftChildIndex;
            }

            if (rightChildIndex < heap.Count && heap[rightChildIndex] < heap[smallest])
            {
                smallest = rightChildIndex;
            }

            if (smallest != index)
            {
                Swap(index, smallest);
                index = smallest;
            }
            else
            {
                break;
            }
        }
    }

    private void Swap(int i, int j)
    {
        int temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
}

class Program
{
    static void Main(string[] args)
    {
        MinHeap heap = new MinHeap();
        int[] elementsToInsert = { 15, 40, 30, 50, 10, 100, 40 };

        // Wstawianie elementów
        foreach (int element in elementsToInsert)
        {
            heap.Insert(element);
        }
        Console.WriteLine("Stos:");
        foreach (int item in heap)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // Sprawdzenie obecności liczby 40
        int searchedValue = 40;
        if (heap.Contains(searchedValue))
        {
            Console.WriteLine($"Liczba {searchedValue} jest w stercie.");
        }
        else
        {
            Console.WriteLine($"Liczba {searchedValue} nie jest w stercie.");
        }

        // Usunięcie elementu 10
        int elementToDelete = 10;
        heap.Delete(elementToDelete);
        Console.WriteLine($"Usunięto {elementToDelete}. Nowy stos:");
        foreach (int item in heap)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
