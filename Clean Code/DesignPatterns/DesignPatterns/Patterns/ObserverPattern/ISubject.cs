namespace DesignPatterns.Patterns.ObserverPattern
{
    // The subject interface declares the methos to manage subscribers
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }
}
