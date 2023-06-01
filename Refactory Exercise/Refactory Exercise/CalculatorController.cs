using Refactory_Exercise.Interfaces;
using System;

namespace Refactory_Exercise
{
    public class CalculatorController : ICalculatorController
    {
        private readonly IDoubleStack doubleStack;
        private readonly IConsoleIO consoleIO;

        public CalculatorController(IDoubleStack doubleStack, IConsoleIO consoleIO)
        {
            this.doubleStack = doubleStack;
            this.consoleIO = consoleIO;
        }

        public void StartProgram()
        {
            consoleIO.PrintString("Welcome to the RNP Calculator.");
            consoleIO.PrintString("Commands:\nQ to quit\nC to Clear\n");
            consoleIO.PrintString("Input numbers and + - * /\n");

            RunCalculatorRPN();
        }

        public void RunCalculatorRPN()
        {
            while(true)
            {
                consoleIO.PrintString(doubleStack.ToString());

                string userInput = consoleIO.GetUserInput();
                
                if (consoleIO.IsNumber(userInput))
                {
                    doubleStack.Push(consoleIO.ConvertToDouble(userInput));
                    continue;
                }

                if (userInput.Length == 0)
                {
                    continue;
                }

                switch (userInput[0])
                {
                    case '+':
                        doubleStack.Push(doubleStack.Pop() + doubleStack.Pop());
                        break;
                    case '*':
                        doubleStack.Push(doubleStack.Pop() * doubleStack.Pop());
                        break;
                    case '-':
                        double valueToSubtract = doubleStack.Pop();
                        doubleStack.Push(doubleStack.Pop() - valueToSubtract);
                        break;
                    case '/':
                        double valueToDivide = doubleStack.Pop();
                        doubleStack.Push(doubleStack.Pop() / valueToDivide);
                        break;
                    case 'c':
                        doubleStack.Clear();
                        break;
                    case 'q':
                        consoleIO.Exit();
                        break;
                    default:
                        Console.WriteLine("Illegal command, ignored");
                        break;
                }
            } 
        }
    }
}
