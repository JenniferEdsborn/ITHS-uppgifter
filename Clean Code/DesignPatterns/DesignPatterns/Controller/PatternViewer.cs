using DesignPatterns.ConsoleIO;
using DesignPatterns.Patterns;

namespace DesignPatterns.Controller
{
    public class PatternViewer
    {
        private readonly IConsoleIO io;
        private readonly PatternFactory patternFactory;

        private List<string> patterns;

        public PatternViewer(IConsoleIO io, PatternFactory patternFactory)
        {
            this.io = io;
            this.patternFactory = patternFactory;
            patterns = patterns = new List<string> { "Singleton", "Factory Method", "Iterator", "Facade", "Proxy", "Observer", "Builder" };
        }

        public void ChoosePattern()
        {
            while(true)
            {
                io.PrintString("Choose what pattern to try!");

                for (int i = 0; i < patterns.Count; i++)
                {
                    io.PrintString((i+1) + " - " + patterns[i]);
                }

                string userInputString = io.GetString();
                int userInputInt = io.ConvertStringToInt(userInputString);

                if (userInputInt >= 1 && userInputInt <= patterns.Count)
                {
                    string selectedPattern = patterns[userInputInt -1];
                    RunPattern(selectedPattern);
                }
                else
                {
                    io.PrintString("Invalid selection. Please try again.");
                }
            }
        }

        public void RunPattern(string patternName)
        {
            IPattern pattern = patternFactory.CreatePattern(patternName);
            pattern.Execute();
        }
    }
}
