using System;
namespace BuilderPattern
{
	public class CarAsembler
	{
        private ICarBuilder _carBuilder;

            public void SetCarBuilder(ICarBuilder carBuilder)
            {
                _carBuilder = carBuilder;
            }

            public void AssembleCar()
            {
                _carBuilder.BuildEngine();
                _carBuilder.BuildModel();
                _carBuilder.BuildColor();
                _carBuilder.BuildYear();
            }

            public Car GetCar()
            {
                return _carBuilder.GetCar();
            }
    }
}

