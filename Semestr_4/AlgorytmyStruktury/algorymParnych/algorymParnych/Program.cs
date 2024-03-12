class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the first number:");
        int number1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the second number:");
        int number2 = int.Parse(Console.ReadLine());

        FindCommonDivisors(number1, number2);
    }

    static void FindCommonDivisors(int a, int b)
    {
        var divisorsA = FindDivisors(a);

        var divisorsB = FindDivisors(b);

        var commonDivisors = FindCommonDivisors(divisorsA, divisorsB);

        Console.WriteLine($"Common divisors of {a} and {b}: {string.Join(", ", commonDivisors)}");
    }

    static int[] FindDivisors(int number)
    {
        var divisors = new List<int>();
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                divisors.Add(i);
            }
        }
        return divisors.ToArray();
    }

    static int[] FindCommonDivisors(int[] divisorsA, int[] divisorsB)
    {
        var commonDivisors = new List<int>();
        foreach (var divisorA in divisorsA)
        {
            if (Array.IndexOf(divisorsB, divisorA) != -1)
            {
                commonDivisors.Add(divisorA);
            }
        }
        return commonDivisors.ToArray();
    }
}