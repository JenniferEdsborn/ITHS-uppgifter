using System.ComponentModel.DataAnnotations;

namespace DesignPatterns.Patterns.ObserverPattern
{
    // Concrete observer
    public class WeatherObserver : IObserver
    {
        private int _temperature;
        private int _humidity;
        private int _pressure;
        private ISubject _weatherStation;

        public WeatherObserver(ISubject weatherStation)
        {
            _weatherStation = weatherStation;
            weatherStation.RegisterObserver(this);
        }

        public void Update(int temperature, int humidity, int pressure)
        {
            this._temperature = temperature;
            this._humidity = humidity;
            this._pressure = pressure;
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"Current conditions: {_temperature}F degrees and {_humidity}% humidity and pressure is {_pressure}.");
        }
    }
}
