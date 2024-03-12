using FactoryScript;
using FactoryScript.Interface;

internal class Programc
{
    private static void Main(string[] args)
    {
        CarFactory carFactory = new CarFactory();

        ICar tayota = carFactory.CreateCar("Tayota");
        tayota.Drive();
        tayota.Accelerate(50);
        tayota.CruiseControl(80);
        tayota.Brake();
        tayota.Stop();
        Console.WriteLine("Brand is: " + tayota.GetBrand());
        Console.WriteLine();

        ICar mazda = carFactory.CreateCar("Mazda");
        mazda.Drive();
        mazda.Accelerate(70);
        mazda.CruiseControl(100);
        mazda.Brake();
        mazda.Stop();
        Console.WriteLine("Brand is: " + mazda.GetBrand());
        Console.WriteLine();

        ICar tesla = carFactory.CreateCar("Tesla");
        tesla.Drive();
        tesla.Accelerate(100);
        tesla.CruiseControl(140);
        tesla.Brake();
        tesla.Stop();
        Console.WriteLine("Brand is: " + tesla.GetBrand());
        Console.WriteLine();

        Console.ReadLine();
    }
}