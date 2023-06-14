namespace DesignPatterns.Patterns.ProxyPattern
{
    public class DatabaseProxy : IDatabase
    {
        private RealDatabase _realDatabase;

        public DatabaseProxy()
        {
            Console.WriteLine("DatabaseProxy: Initialized.");
        }

        public void Request()
        {
            if ( _realDatabase == null)
            {
                Console.WriteLine("DatabaseProxy: Initializing RealDatabase.");
                _realDatabase = new RealDatabase();
            }

            Console.WriteLine("DatabaseProxy: Forwarding request to RealDatabase.");
            _realDatabase.Request();
        }
    }
}
