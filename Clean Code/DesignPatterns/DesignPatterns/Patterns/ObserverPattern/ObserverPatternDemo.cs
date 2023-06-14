using DesignPatterns.ConsoleIO;
using DesignPatterns.Patterns.ProxyPattern;

namespace DesignPatterns.Patterns.ObserverPattern
{
    public class ObserverPatternDemo : IPattern
    {
        IConsoleIO io;

        public ObserverPatternDemo(IConsoleIO io)
        {
            this.io = io;
        }

        public void Execute()
        {
            io.PrintString("- - Observer Pattern Demo - -");
            io.PrintString("The intent is to define a one to many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.");
            io.PrintString("We will demo this by observing a Weather Station.\n");

            Thread.Sleep(1000);

            WeatherStation weatherStation = new WeatherStation();

            WeatherObserver weatherObserver = new WeatherObserver(weatherStation);

            weatherStation.SetMeasurements(80, 65, 30);
            Thread.Sleep(1000);
            weatherStation.SetMeasurements(82, 70, 29);
            Thread.Sleep(1000);
            weatherStation.SetMeasurements(78, 90, 29);

            Thread.Sleep(1000);

            io.PrintString("\n- - End of Demo - -\n");
            io.PrintString("Press any button to continue.");
            io.PressAnyKey();
            io.Clear();
        }
    }
}
