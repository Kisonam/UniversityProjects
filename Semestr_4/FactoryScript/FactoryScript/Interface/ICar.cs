using System;
namespace FactoryScript.Interface
{
	public interface ICar
	{
		void Drive();
		void CruiseControl(float speed);
		void Accelerate(float speed);
		void Brake();
        void Stop();
		string GetBrand();
    }
}

