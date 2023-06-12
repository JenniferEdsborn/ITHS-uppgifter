namespace DesignPatterns.ConsoleIO
{
    public interface IConsoleIO
    {
        void Clear();
        int ConvertStringToInt(string input);
        string GetString();
        void PressAnyKey();
        void PrintString(string output);
    }
}