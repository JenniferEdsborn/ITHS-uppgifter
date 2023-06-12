namespace DesignPatterns.Patterns.FactoryMethodPattern
{
    public class SedanCarFactory : ICarFactory
    {
        public ICar CreateCar()
        {
            return new SedanCar();
        }
    }
}
