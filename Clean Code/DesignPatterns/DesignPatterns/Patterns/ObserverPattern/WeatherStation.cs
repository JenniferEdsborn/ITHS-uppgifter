namespace DesignPatterns.Patterns.ObserverPattern
{
    // Concrete Subject
    public class WeatherStation : ISubject
    {
        private List<IObserver> _observers;
        private int _temperature;
        private int _humidity;
        private int _pressure;

        public WeatherStation()
        {
            _observers = new List<IObserver>();
        }
        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_temperature, _humidity, _pressure);
            }
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements(int temperature, int humidity, int pressure)
        {
            this._temperature = temperature;
            this._humidity = humidity;
            this._pressure = pressure;
            MeasurementsChanged();
        }
    }
}
