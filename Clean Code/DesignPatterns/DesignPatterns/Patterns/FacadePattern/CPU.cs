namespace DesignPatterns.Patterns.FacadePattern
{
    public class CPU
    {
        public void Freeze()
        {
            Console.WriteLine("CPU is frozen.");
        }

        public void Jump(long position)
        {
            Console.WriteLine($"Jump to position {position}");
        }

        public void Execute()
        {
            Console.WriteLine("CPU execution started.");
        }
    }
}
