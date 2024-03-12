internal class Program
{
    private static void Main(string[] args)
    {
        int N = 15;

        List<int> numbers = Enumerable.Range(0, N).ToList();
        Random random = new Random();

        if (N % 2 != 0)
        {
            int num = random.Next(numbers.Count());
            numbers.RemoveAt(num);
            Console.WriteLine("Delete element: " + num);
        }

        List<(int, int)> pairs = new List<(int, int)>();

        while (numbers.Count > 0)
        {
            int index1 = random.Next(numbers.Count);
            int num1 = numbers[index1];
            numbers.RemoveAt(index1);

            int index2 = random.Next(numbers.Count);
            int num2 = numbers[index2];
            numbers.RemoveAt(index2);

            pairs.Add((num1, num2));
        }

        
        foreach (var pair in pairs)
        {
            Console.WriteLine($"({pair.Item1}, {pair.Item2})");
        }

        Console.Read();
    }
}