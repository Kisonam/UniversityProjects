using System;
namespace BuilderPattern
{
    public class UniversalCarBuilder : ICarBuilder
    {
        private Car _car = new Car();
        
        public void BuildColor()
        {
            _car.Color = "White";
        }

        public void BuildEngine()
        {
            _car.Engine = "v12";
        }

        public void BuildModel()
        {
            _car.Model = "Passat";
        }

        public void BuildYear()
        {
            _car.Year = 2020;
        }

        public Car GetCar()
        {
            return _car;
        }
    }
}

