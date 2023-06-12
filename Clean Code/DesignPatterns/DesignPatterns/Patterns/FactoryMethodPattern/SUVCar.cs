using DesignPatterns.ConsoleIO;

namespace DesignPatterns.Patterns.FactoryMethodPattern
{
    public class SUVCar : ICar
    {
        public void Manifacture()
        {
            Console.WriteLine("Manifacturing a SUV.");
        }
    }
}
