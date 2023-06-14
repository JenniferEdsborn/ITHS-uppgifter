using DesignPatterns.ConsoleIO;

namespace DesignPatterns.Patterns.FacadePattern
{
    public class Memory
    {
        public void Load(long position, byte[] data)
        {
            Console.WriteLine($"Loaded data to position {position}");
        }
    }
}
