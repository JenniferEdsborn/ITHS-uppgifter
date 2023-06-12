namespace DesignPatterns.Patterns.IteratorPattern
{
    public interface IIterator
    {
        bool HasNext();
        object Next();
    }
}
