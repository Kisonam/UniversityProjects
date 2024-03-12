using System;
using FactoryScript.CarClases;
using FactoryScript.Interface;

namespace FactoryScript
{
	public class CarFactory
	{
		public ICar CreateCar(string brand)
		{
			switch (brand)
			{
				case "Mazda":
					return new Mazda();
				case "Tayota":
					return new Tayota();
				case "Tesla":
					return new Tesla();
				default:
                    throw new ArgumentException("Unsupported car brand.");
            }
		}
	}
}

