using RefactoredHemsidegenerator.Interfaces;

namespace RefactoredHemsidegenerator.Classes
{
    public class WebsiteGenerator : IWebsiteGenerator
    {
        readonly private IConsoleIO consoleIO;
        readonly private ICourseGenerator courseGenerator;
        readonly private string className = "";
        readonly private string[] welcomeMessages;

        public WebsiteGenerator(IConsoleIO consoleIO, ICourseGenerator courseGenerator, string[] welcomeMessages, string className)
        {
            this.consoleIO = consoleIO;
            this.courseGenerator = courseGenerator;
            this.className = className;
            this.welcomeMessages = welcomeMessages;
        }

        public void PrintPage()
        {
            PrintStart();
            PrintWelcome();
            PrintCourses();
            PrintEnd();
        }

        private void PrintStart()
        {
            consoleIO.PrintString("<!DOCTYPE html>\n<html>\n<body>\n<main>\n");
        }

        private void PrintWelcome()
        {
            consoleIO.PrintString($"<h1> Välkomna {this.className}! </h1>");

            foreach (var message in welcomeMessages)
            {
                consoleIO.PrintString($"\n<p><b> Meddelande: </b> {message} </p>");
            }
        }

        private void PrintCourses()
        {
            courseGenerator.TrimCourses();
            consoleIO.PrintString(courseGenerator.AddHTMLTags());
        }

        private void PrintEnd()
        {
            consoleIO.PrintString("</main>\n</body>\n</html>");
        }
    }
}
