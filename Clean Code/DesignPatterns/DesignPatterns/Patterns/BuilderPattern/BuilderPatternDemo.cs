using DesignPatterns.ConsoleIO;
using System.IO;
using System.Threading;

namespace DesignPatterns.Patterns.BuilderPattern
{
    public class BuilderPatternDemo : IPattern
    {
        private readonly IConsoleIO io;
        private IHouseBuilder? builder;

        public BuilderPatternDemo(IConsoleIO io)
        {
            this.io = io;
        }
        public void Execute()
        {
            io.PrintString("- - Builder Pattern Demo - -");
            io.PrintString("The purpose of a Builder Design Pattern is to separate the construction of a complex object from its representation.");
            io.PrintString("By doing this, the same construction process can create different representations.");
            io.PrintString("We will demo this by building some houses.\n");

            Thread.Sleep(1000);

            BuildAndPrintHouseDetails<CottageBuilder>("CottageBuilder");

            Thread.Sleep(1000);

            BuildAndPrintHouseDetails<MansionBuilder>("MansionBuilder");

            Thread.Sleep(1000);

            BuildAndPrintHouseDetails<CastleBuilder>("CastleBuilder");

            Thread.Sleep(1000);

            io.PrintString("- - End of Demo - -\n");
            io.PrintString("Press any button to continue.");
            io.PressAnyKey();
            io.Clear();
        }

        private House BuildHouse<T>() where T : IHouseBuilder, new()
        {
            IHouseBuilder builder = new T();
            HouseBuilderDirector director = new HouseBuilderDirector(builder);
            director.BuildHouse();
            return director.GetHouse();
        }

        private void PrintHouseDetails(House house)
        {
            io.PrintString($"Foundation: {house.Foundation}");
            io.PrintString($"Structure: {house.Structure}");
            io.PrintString($"Roof: {house.Roof}\n");
        }

        private void BuildAndPrintHouseDetails<T>(string builderName) where T : IHouseBuilder, new()
        {
            io.PrintString($"Calling the {builderName}:\n");
            House house = BuildHouse<T>();
            PrintHouseDetails(house);
        }
    }
}
