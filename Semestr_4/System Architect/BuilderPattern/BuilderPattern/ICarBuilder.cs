using System;
namespace BuilderPattern
{
	public interface ICarBuilder
	{
		void BuildEngine();
		void BuildModel();
		void BuildColor();
		void BuildYear();
		Car GetCar();
	}
}

