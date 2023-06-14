using DesignPatterns.ConsoleIO;
using DesignPatterns.Patterns.FactoryMethodPattern;

namespace DesignPatterns.Patterns.FacadePattern
{
    public class FacadePatternDemo : IPattern
    {
        IConsoleIO io;

        public FacadePatternDemo(IConsoleIO io)
        {
            this.io = io;
        }

        public void Execute()
        {
            io.PrintString("- - Facade Pattern Demo - -");
            io.PrintString("The intent is to provide a unified interface to a set of interfaces in a subsystem.");
            io.PrintString("The facade defineas a higher-level interface thaT makes the subsystem easier to use.");
            io.PrintString("We will demo this by working a computer (the facade) with subsystems (CPU, memory, hard drive).\n");

            Thread.Sleep(1000);
      
            Computer computer = new Computer();
            computer.Start();

            Thread.Sleep(1000);

            io.PrintString("\n- - End of Demo - -\n");
            io.PrintString("Press any button to continue.");
            io.PressAnyKey();
            io.Clear();
        }
    }
}
