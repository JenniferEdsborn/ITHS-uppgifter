using RefactoredHemsidegenerator.Classes;
using RefactoredHemsidegenerator.Interfaces;

namespace RefactoredHemsidegenerator;

class Program
{
    static void Main(string[] args)
    {
        string className = "klass A";
        string[] courses = { "   C#", "daTAbaser", "WebbuTVeCkling ", "clean Code   " };
        string[] welcomeMessages = { "Glöm inte att övning ger färdighet!", "Öppna boken på sida 257." };

        IConsoleIO consoleIO = new ConsoleIO();
        ICourseGenerator courseGenerator = new CourseGenerator(courses);
        IWebsiteGenerator websiteGenerator = new WebsiteGenerator(consoleIO, courseGenerator, welcomeMessages, className);

        websiteGenerator.PrintPage();
    }
}