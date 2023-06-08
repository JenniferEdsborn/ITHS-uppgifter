using RefactoredHemsidegenerator.Interfaces;

namespace RefactoredHemsidegenerator.Classes
{
    public class ConsoleIO : IConsoleIO
    {
        public void PrintString(string output)
        {
            Console.WriteLine(output);
        }
    }
}
