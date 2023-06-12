using DesignPatterns.ConsoleIO;
using DesignPatterns.Patterns;
using DesignPatterns.Patterns.BuilderPattern;
using DesignPatterns.Patterns.FactoryMethodPattern;
using DesignPatterns.Patterns.IteratorPattern;
using DesignPatterns.Patterns.SingletonPattern;

namespace DesignPatterns.Controller
{
    public class PatternFactory
    {
        private readonly IConsoleIO io;

        public PatternFactory(IConsoleIO io)
        {
            this.io = io;
        }

        public IPattern CreatePattern(string patternName)
        {
            switch (patternName)
            {
                case "Singleton":
                    return new SingletonPatternDemo(io);
                case "Factory Method":
                    return new FactoryMethodPatternDemo(io);
                case "Iterator":
                    return new IteratorPatternDemo(io);
                //case "Facade":
                //    return new FacadePatternDemo(io);
                //case "Proxy":
                //    return new ProxyPatternDemo(io);
                //case "Observer":
                //    return new ObserverPatternDemo(io);
                case "Builder":
                    return new BuilderPatternDemo(io);
                default:
                    throw new ArgumentException("Invalid pattern name");
            }
        }
    }
}
