using System;
using FactoryScript.Interface;

namespace FactoryScript.CarClases
{
    public class Tesla : ICar
    {
        public void Accelerate(float speed)
        {
            Console.WriteLine($"Your speed now is {speed} km");
        }

        public void Brake()
        {
            Console.WriteLine("Tesla is breaking");
        }

        public void CruiseControl(float speed)
        {
            Console.WriteLine($"Cruise control {speed} km, you will drive with this speed!");
        }

        public void Drive()
        {
            Console.WriteLine("You start driving");
        }

        public string GetBrand()
        {
            return "Tesla";
        }

        public void Stop()
        {
            Console.WriteLine("Car is stopping");
        }
    }
}

