using System.Text;
using Refactory_Exercise.Interfaces;

namespace Refactory_Exercise;

public class DoubleStack : IDoubleStack
{
    private double[] stackDataStorage;
    private int currentSizeOfStack;

    public DoubleStack(int initialSize)
    {
        this.stackDataStorage = new double[initialSize];
        this.currentSizeOfStack = 0;
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
            throw new InvalidOperationException("Stack is empty");
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
            throw new InvalidOperationException("Stack is empty");
        }
    }

    public void Clear()
    {
        currentSizeOfStack = 0;
    }

    public override string ToString()
    {
        if (currentSizeOfStack == 0) return "[]";

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
