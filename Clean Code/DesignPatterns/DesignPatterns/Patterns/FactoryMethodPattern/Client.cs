namespace DesignPatterns.Patterns.FactoryMethodPattern
{
    public class Client
    {
        private ICarFactory factory;

        public Client(ICarFactory factory)
        {
            this.factory = factory;
        }

        public void BuildCar()
        {
            ICar car = factory.CreateCar();
            car.Manifacture();
        }
    }
}
