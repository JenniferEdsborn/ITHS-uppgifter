namespace DesignPatterns.Patterns.FactoryMethodPattern
{
    public class SUVCarFactory : ICarFactory
    {
        public ICar CreateCar()
        {
            return new SUVCar();
        }
    }
}
