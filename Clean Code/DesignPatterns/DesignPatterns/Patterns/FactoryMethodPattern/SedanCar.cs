using DesignPatterns.ConsoleIO;

namespace DesignPatterns.Patterns.FactoryMethodPattern
{
    public class SedanCar : ICar
    {
        public void Manifacture()
        {
            Console.WriteLine("Manifacturing a Sedan.");
        }
    }
}
