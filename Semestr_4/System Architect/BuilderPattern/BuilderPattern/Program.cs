using BuilderPattern;

internal class Program
{
    private static void Main(string[] args)
    {
        // Client code
        var carAssembler = new CarAsembler();
        var sedanCarBuilder = new SedanCarBuilder();
       

        carAssembler.SetCarBuilder(sedanCarBuilder);
        carAssembler.AssembleCar();

        var car = carAssembler.GetCar();
        car.Display();

        var universalCarBuilder = new UniversalCarBuilder();
        carAssembler.SetCarBuilder(universalCarBuilder);
        carAssembler.AssembleCar();

        car = carAssembler.GetCar();
        car.Display();

        Console.ReadLine();
    }
}