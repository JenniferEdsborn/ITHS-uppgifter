namespace Refactory_Exercise.Interfaces;

public interface IDoubleStack
{
    int CurrentSizeOfStack { get; }

    public void Push(double value);
    public double Pop();
    public double Peek();
    public void Clear();
    public string ToString();
}
