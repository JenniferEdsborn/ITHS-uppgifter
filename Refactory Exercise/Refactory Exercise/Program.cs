using Refactory_Exercise.Interfaces;
using System.Runtime.CompilerServices;

namespace Refactory_Exercise;

class Program
{
    static void Main(string[] args)
    {
        IDoubleStack doubleStack = new DoubleStack(1000);
        IConsoleIO consoleIO = new ConsoleIO();
        ICalculatorController controller = new CalculatorController(doubleStack, consoleIO);

        controller.StartProgram();
    }
}
