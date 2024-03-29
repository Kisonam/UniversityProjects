using StosKolejka;

internal class Program
{
    private static void Main(string[] args)
    {
        Queue queue = new Queue();
        queue.Enqueue("Artem", "Rad");
        queue.Enqueue("Yian", "Overczenko");
        //queue.Enqueue("Artem", "Overczenko");
        Console.WriteLine("Usuwanie z kolejki: " + queue.Dequeue());
        Console.WriteLine("Usuwanie z kolejki: " + queue.Dequeue());
        Console.WriteLine("Czy kolejka jest pusta? " + queue.IsEmpty());

        Console.Read();
    }
}