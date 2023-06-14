using DesignPatterns.ConsoleIO;

namespace DesignPatterns.Patterns.ProxyPattern
{
    public class ProxyPatternDemo : IPattern
    {
        IConsoleIO io;

        public ProxyPatternDemo(IConsoleIO io)
        {
            this.io = io;
        }

        public void Execute()
        {
            io.PrintString("- - Proxy Pattern Demo - -");
            io.PrintString("The intent is to provide a placeholder for another object to control access to it.");
            io.PrintString("We will demo this by calling a mock-database, first with the real subject, then with a proxy.\n");

            Thread.Sleep(1000);

            io.PrintString("Client: Executing the client code with a real subject:");
            RealDatabase realDatabase = new RealDatabase();
            realDatabase.Request();
            io.PrintString("");

            Thread.Sleep(1000);
            io.PrintString("Client: Executing the same client code with a proxy:");
            DatabaseProxy proxy = new DatabaseProxy();
            proxy.Request();

            Thread.Sleep(1000);

            io.PrintString("\n- - End of Demo - -\n");
            io.PrintString("Press any button to continue.");
            io.PressAnyKey();
            io.Clear();
        }
    }
}
