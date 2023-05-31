using Refactory_Exercise.Interfaces;
using System.Runtime.CompilerServices;

namespace Refactory_Exercise;

class Program
{
    static void Main(string[] args)
    {
        IDoubleStack doubleStack = new DoubleStack(new double[1000], 0);
        IConsoleIO consoleIO = new ConsoleIO();
        ICalculatorController controller = new CalculatorController(doubleStack, consoleIO);

        controller.StartProgram();
    }
}
