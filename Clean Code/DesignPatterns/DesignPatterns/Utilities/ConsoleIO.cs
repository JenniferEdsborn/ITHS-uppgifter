namespace DesignPatterns.ConsoleIO
{
    public class ConsoleIO : IConsoleIO
    {
        public void PrintString(string output)
        {
            Console.WriteLine(output);
        }

        public string GetString()
        {
            return Console.ReadLine();
        }

        public int ConvertStringToInt(string input)
        {
            try
            {
                return Convert.ToInt32(input);
            }
            catch
            {
                Console.WriteLine("Failed to convert string input to integer.");
                return 0;
            }
        }

        public void PressAnyKey()
        {
            Console.ReadKey();
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
