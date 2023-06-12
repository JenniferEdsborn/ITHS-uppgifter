using DesignPatterns.ConsoleIO;

namespace DesignPatterns.Patterns.SingletonPattern
{
    public class SingletonPatternDemo : IPattern
    {
        private readonly IConsoleIO io;

        public SingletonPatternDemo(IConsoleIO io)
        {
            this.io = io;
        }

        public void Execute()
        {
            io.PrintString("- - Singleton Pattern Demo - -");
            io.PrintString("The purpose of the Singleton Design Pattern is to ensure that only one instance of a class is created throughout the application.\n");
            
            Singleton instance1 = Singleton.GetInstance();
            Singleton instance2 = Singleton.GetInstance();

            Thread.Sleep(1000);

            io.PrintString("We create two instances from the Singleton class, and compare them.");
            io.PrintString("If instance1 == instance 2, we get a message saying only one Singleton class has been created.");
            io.PrintString("Else, we get a message saying multiple instances has been created.\n");

            Thread.Sleep(1000);

            if (instance1 == instance2)
            {
                io.PrintString("Result: Only one instance of the Singleton class has been created.");
            }
            else
            {
                io.PrintString("Result: Multiple instances of the Singleton class have been created.");
            }

            io.PrintString("\n- - End of Demo - -\n");
            io.PrintString("Press any button to continue.");
            io.PressAnyKey();
            io.Clear();
        }
    }
}
