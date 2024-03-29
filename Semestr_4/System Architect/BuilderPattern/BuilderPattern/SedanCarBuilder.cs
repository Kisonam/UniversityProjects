using System;
namespace BuilderPattern
{
    public class SedanCarBuilder : ICarBuilder
	{
        private Car _car = new Car();

        public void BuildEngine()
        {
            _car.Engine = "v40";
        }

        public void BuildModel()
        {
            _car.Model = "Camry";
        }

        public void BuildColor()
        {
            _car.Color = "Black";
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

