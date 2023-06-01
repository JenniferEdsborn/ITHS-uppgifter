namespace Refactory_Exercise.Interfaces
{
    public interface IConsoleIO
    {
        void Exit();
        string GetUserInput();
        bool IsNumber(string userInput);
        double ConvertToDouble(string userInput);
        void PrintString(string output);
    }
}