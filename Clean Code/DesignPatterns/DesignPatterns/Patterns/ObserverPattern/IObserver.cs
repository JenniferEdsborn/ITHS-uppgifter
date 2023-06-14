namespace DesignPatterns.Patterns.ObserverPattern
{
    // The observer interface declares the update method, used by subjects
    public interface IObserver
    {
        void Update(int temperature, int humidity, int pressure);
    }
}
