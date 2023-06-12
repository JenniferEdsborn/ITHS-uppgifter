using DesignPatterns.ConsoleIO;
using DesignPatterns.Controller;

IConsoleIO io = new ConsoleIO();
PatternFactory patternFactory = new PatternFactory(io);
PatternViewer patternViewer = new PatternViewer(io, patternFactory);

patternViewer.ChoosePattern();