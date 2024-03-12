using System.Numerics;

internal class Program
{
    static BigInteger Factorial(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        else
            return n * Factorial(n - 1);
    }

    static BigInteger BinaryFactorial(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        else
            return n * BinaryFactorial(n - 2);
    }

    static BigInteger Fibonacci(int n)
    {
        if (n == 0)
            return 0;
        else if (n == 1 || n == 2)
            return 1;
        else
        {
            BigInteger a = 0, b = 1, result = 0;

            for (int i = 2; i <= n; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }

            return result;
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose your variant:");
            Console.WriteLine("1 -Faktorial");
            Console.WriteLine("2 - Factorial binarny");
            Console.WriteLine(" 3 - Fibonacci");
            Console.WriteLine("0 - exit");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 0)
                break;
            switch (answer)
            {
                case 1:
                    Console.Write("Enter a number for factorial calculation: ");
                    int factorialNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Factorial of {factorialNumber}: {Factorial(factorialNumber)}");
                    break;
                case 2:
                    Console.Write("\nEnter a number for binary factorial calculation: ");
                    int binaryFactorialNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Binary Factorial of {binaryFactorialNumber}: {BinaryFactorial(binaryFactorialNumber)}");
                    break;
                case 3:
                    Console.Write("\nEnter an index for Fibonacci sequence calculation: ");
                    int fibonacciIndex = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Fibonacci sequence at index {fibonacciIndex}: {Fibonacci(fibonacciIndex)}");
                    break;
                default:
                    Console.WriteLine("Try again!");
                    break;
            }
        }
       
    }
}