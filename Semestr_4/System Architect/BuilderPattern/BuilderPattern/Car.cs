using System;
namespace BuilderPattern
{
	public class Car
	{
		public string? Model { get; set; }
		public string? Engine { get; set; }
		public string? Color { get; set; }
		public int Year { get; set; }

		public void Display()
		{
			Console.WriteLine($"Your car was created in {Year} year. " +
				$"\n In this car {Engine} engine. " +
				$"\n {Color} color. " +
				$"\n Model is: {Model}");
		}
    }
}

