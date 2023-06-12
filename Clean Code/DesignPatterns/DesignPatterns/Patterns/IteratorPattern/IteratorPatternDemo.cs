using DesignPatterns.ConsoleIO;

namespace DesignPatterns.Patterns.IteratorPattern
{
    public class IteratorPatternDemo : IPattern
    {
        private readonly IConsoleIO io;

        public IteratorPatternDemo(IConsoleIO io)
        {
            this.io = io;
        }
        public void Execute()
        {
            io.PrintString("- - Iterator Pattern Demo - -");
            io.PrintString("The Iterator pattern provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation.");
            io.PrintString("We will demonstrate this by iterating over a collection of numbers.\n");

            Thread.Sleep(1000);

            int[] numbers = { 1, 2, 3, 4, 5 };
            IContainer container = new MyCollection(numbers);
            IIterator iterator = container.GetIterator();

            io.PrintString("Iterating over the collection:");

            while (iterator.HasNext())
            {
                object element = iterator.Next();
                io.PrintString(element.ToString());
                Thread.Sleep(1000);
            }

            io.PrintString("\n- - End of Demo - -\n");
            io.PrintString("Press any button to continue.");
            io.PressAnyKey();
            io.Clear();
        }
    }
}
