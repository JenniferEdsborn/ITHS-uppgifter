namespace DesignPatterns.Patterns.ProxyPattern
{
    public class RealDatabase : IDatabase
    {
        public void Request()
        {
            Console.WriteLine("RealDatabase: Handling Request.");
        }
    }
}
