using DesignPatterns.ConsoleIO;
using DesignPatterns.Patterns.BuilderPattern;

namespace DesignPatterns.Patterns.FactoryMethodPattern
{
    public class FactoryMethodPatternDemo : IPattern
    {
        IConsoleIO io;

        public FactoryMethodPatternDemo(IConsoleIO io)
        {
            this.io = io;
        }
        public void Execute()
        {
            io.PrintString("- - Factory Method Pattern Demo - -");
            io.PrintString("The purpose of a Factory Method Pattern is to define an interface for creating an object but let subclasses decide which class to instantiate.");
            io.PrintString("We will demo this by building some cars.\n");

            Thread.Sleep(1000);

            ICarFactory sedanFactory = new SedanCarFactory();
            Client sedanClient = new Client(sedanFactory);
            sedanClient.BuildCar();

            io.PrintString("");

            Thread.Sleep(1000);

            ICarFactory suvFactory = new SUVCarFactory();
            Client suvClient = new Client(suvFactory);
            suvClient.BuildCar();

            Thread.Sleep(1000);

            io.PrintString("\n- - End of Demo - -\n");
            io.PrintString("Press any button to continue.");
            io.PressAnyKey();
            io.Clear();
        }
    }
}
