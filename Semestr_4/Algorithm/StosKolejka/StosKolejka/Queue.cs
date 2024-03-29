using System;
namespace StosKolejka
{
	public class Queue
	{
        private Node? front;
        private Node? rear;

        public bool IsEmpty()
        {
            return front == null;
        }

        public void Enqueue(string name, string surname)
        {
            Node newNode = new Node((name, surname));
            if (IsEmpty())
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }
        }

        public (string, string) Dequeue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Kolejka jest pusta");
                return ("", ""); // Możesz zwrócić inny domyślny wynik lub rzucić wyjątek
            }
            (string, string) data = front.Data;
            if (front == rear)
            {
                front = null;
                rear = null;
            }
            else
            {
                front = front.Next;
            }
            return data;
        }
    }
}

