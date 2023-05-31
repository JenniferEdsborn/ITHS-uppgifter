using Refactory_Exercise.Interfaces;

namespace Refactory_Exercise;

public class ConsoleIO : IConsoleIO
{
    public void Exit()
    {
        Environment.Exit(0);
    }
    
    public string GetUserInput()
    {
        try
        {
            return Console.ReadLine().Trim().ToLower();
        }
        catch (Exception ex)
        {
            return " ";
        }
    }

    public bool IsNumber(string userInput)
    {
        return double.TryParse(userInput, out _);
    }

    public double ConvertToDouble(string userInput)
    {
        try
        {
            return Convert.ToDouble(userInput);
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    public void PrintString(string output)
    {
        try
        {
            Console.WriteLine(output);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
