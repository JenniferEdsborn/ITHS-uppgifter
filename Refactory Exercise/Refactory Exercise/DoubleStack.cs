using System.Text;
using Refactory_Exercise.Interfaces;

namespace Refactory_Exercise;

public class DoubleStack : IDoubleStack
{
    private double[] stackDataStorage;
    private int currentSizeOfStack;

    public DoubleStack(double[] stackDataStorage, int currentSizeOfStack)
    {
        this.stackDataStorage = stackDataStorage;
        this.currentSizeOfStack = currentSizeOfStack;
    }

    public int CurrentSizeOfStack
    {
        get { return currentSizeOfStack; }
    }

    public void Push(double userInput)
    {
        stackDataStorage[currentSizeOfStack++] = userInput;
    }

    public double Pop()
    {
        if (currentSizeOfStack > 0)
        {
            return stackDataStorage[--currentSizeOfStack];
        }
        else
        {
            Console.WriteLine("stack empty, returning 0");
            return 0;
        }
    }

    public double Peek()
    {
        if (currentSizeOfStack > 0)
        {
            return stackDataStorage[currentSizeOfStack - 1];
        }
        else
        {
            Console.WriteLine("stack empty, returning 0");
            return 0;
        }
    }

    public void Clear()
    {
        currentSizeOfStack = 0;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append('[');

        for (int i = currentSizeOfStack - 1; ; i--)
        {
            stringBuilder.Append(stackDataStorage[i]);
            if (i == 0)
            {
                return stringBuilder.Append(']').ToString();
            }
            else
            {
            stringBuilder.Append(", ");
            }
        }
    }

}
