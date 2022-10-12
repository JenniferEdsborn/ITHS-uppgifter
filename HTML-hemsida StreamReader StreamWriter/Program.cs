Print test = new Print();
test.standardWebsite();
//test.standardWebsiteArguments();
//test.styledWebsite();
//test.HTMLGenerator();

//Class to test all the different websites
class Print
{
    private string[] testCourses = new string[] { "Java", "JavaScript", "Python", "C#" };

    public void standardWebsite()
    {
        MyWebsite standardWebsite = new MyWebsite();
        standardWebsite.generate();
    }
    public void standardWebsiteArguments()
    {
        MyWebsite standardWebsiteArguments = new MyWebsite("Klass 5C", 3, testCourses);
        standardWebsiteArguments.generate();
    }
    public void styledWebsite()
    {
        HTMLGenerator styledWebsite = new HTMLGenerator("Klass 1AA", 3, testCourses);
        styledWebsite.generate();
    }
    public void HTMLGenerator()
    {
        StyledHTMLGenerator HTMLGenerator = new StyledHTMLGenerator("Klass 3C", 2, testCourses, "aquamarine");
        HTMLGenerator.generate();
    }
}


interface IWebsiteGenerator
{
    void generate();
    void courses(string[] courses);
    void handleMessages(int p, int n);
    void writeMessages();
}

class MyWebsite : IWebsiteGenerator
{
    //fields
    protected string klass;
    protected int antalMeddelanden;
    protected List<string> messages = new List<string>();

    //course data from API
    string[] myCourses = new string[] { "   C#", "daTAbaser", "WebbuTVeCkling ", "clean Code   " };

    //constructor with arguments
    public MyWebsite(string klass, int antalMeddelanden, string[] techniques)
    {
        this.klass = klass;
        this.antalMeddelanden = antalMeddelanden;
        this.myCourses = techniques;
    }
    //constructor wihtout arguments
    public MyWebsite()
    {
        this.klass = "- DEFAULT KLASSNAMN -";
        this.antalMeddelanden = 3;
    }
    public void generate()
    {
        handleMessages(1, antalMeddelanden);
        Console.WriteLine("<!DOCTYPE html>\n<html>\n<body>\n<main>");
        Console.WriteLine($"<h1>Välkomna {this.klass}!</h1>");
        if (antalMeddelanden == 0)
            Console.WriteLine("<p><b>Meddelande 1:</b> Inga nya meddelanden idag.<p>");
        else
            writeMessages();
        courses(myCourses);
        Console.WriteLine("</main>\n</body>\n</html>");
        printQuery();
    }
    public void handleMessages(int p, int n)
    {
        if (n > 0)
        {
            Console.Write($"Meddelande {p++}: ");
            string x = Console.ReadLine();
            messages.Add(x);
            handleMessages(p++, n - 1);
        }
    }
    public void writeMessages()
    {
        for (int i = 0; i < messages.Count; i++)
        {
            Console.WriteLine($"<p><b>Meddelande {i + 1}</b>: {messages[i]}</p>");
        }
    }
    public void courses(string[] courses)
    {
        foreach (var course in courses)
        {
            Console.WriteLine($"<p>Kurs i {course.Trim().ToUpper().Substring(0, 1) + course.Trim().Substring(1).ToLower()}<p/>");
        }
    }
    public void printQuery()
    {
        Console.WriteLine("Spara din hemsida i en textfil? y/n");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y")
        {
            Console.Write("Välj textfilens namn: ");
            string myName = Console.ReadLine();
            printToFile(myName);
        }
    }
    public void printToFile(string name)
    {
        FileInfo fi = new FileInfo($"{name}.txt");
        FileStream fs = fi.Open(FileMode.Append, FileAccess.Write, FileShare.None);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine($"<!DOCTYPE html>\n<html>\n<body>\n<main>\n<h1>Välkomna {this.klass}!</h1>");
        if (antalMeddelanden == 0)
            sw.WriteLine("<p><b>Meddelande 1:</b> Inga nya meddelanden idag.<p>");
        else
        {
            for (int i = 0; i < messages.Count; i++)
            {
                sw.WriteLine($"<p><b>Meddelande {i + 1}</b>: {messages[i]}</p>");
            }
        }
        foreach (var course in myCourses)
        {
            sw.WriteLine($"<p>Kurs i {course.Trim().ToUpper().Substring(0, 1) + course.Trim().Substring(1).ToLower()}<p/>");
        }
        sw.WriteLine("</main>\n</body>\n</html>");
        sw.Close();
    }
}

class HTMLGenerator : IWebsiteGenerator
{
    //fields
    protected string klass;
    protected int antalMeddelanden;
    protected List<string> messages = new List<string>();

    //data from API, default value if the user hasn't input another array of courses
    protected string[] techniques = { "   C#", "daTAbaser", "WebbuTVeCkling ", "clean Code   " };

    //constructor - create new website with new class and messages
    public HTMLGenerator(string klass, int antalMeddelanden, string[] techniques)
    {
        this.klass = klass;
        this.antalMeddelanden = antalMeddelanden;
        this.techniques = techniques;
    }
    //constructor - default values
    public HTMLGenerator()
    {
        this.klass = "1A";
        this.antalMeddelanden = 0;
        this.techniques = techniques;
    }
    public void generate()
    {
        handleMessages(1, antalMeddelanden);
        printStart();
        Console.WriteLine($"<h1>Välkomna {this.klass}!</h1>");
        if (antalMeddelanden == 0)
            Console.WriteLine("<p><b>Meddelande 1:</b> Inga nya meddelanden idag.<p>");
        else
            writeMessages();
        courses(techniques);
        Console.WriteLine("</main>\n</body>\n</html>");
        printQuery();
    }
    virtual public void printStart()
    {
        Console.WriteLine("<!DOCTYPE html>\n<html>\n<body>\n<main>");
    }
    public void courses(string[] courses)
    {
        foreach (var course in courses)
        {
            Console.WriteLine($"<p>Kurs i {course.Trim().ToUpper().Substring(0, 1) + course.Trim().Substring(1).ToLower()}<p/>");
        }
    }
    public void handleMessages(int p, int n)
    {
        if (n > 0)
        {
            Console.Write($"Meddelande {p}: ");
            string x = Console.ReadLine();
            messages.Add(x);
            handleMessages(p + 1, n - 1);
        }
    }
    public void writeMessages()
    {
        for (int i = 0; i < messages.Count; i++)
        {
            Console.WriteLine($"<p><b>Meddelande {i + 1}</b>: {messages[i]}</p>");
        }
    }
    public void printQuery()
    {
        Console.WriteLine("Spara din hemsida i en textfil? y/n");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y")
        {
            Console.Write("Välj textfilens namn: ");
            string myName = Console.ReadLine();
            printToFile(myName);
        }
    }
    virtual public void printToFile(string name)
    {
        FileInfo fi = new FileInfo($"{name}.html");
        FileStream fs = fi.Open(FileMode.Append, FileAccess.Write, FileShare.None);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine($"<!DOCTYPE html>\n<html>\n<body>\n<main>\n<h1>Välkomna {this.klass}!</h1>");
        if (antalMeddelanden == 0)
            sw.WriteLine("<p><b>Meddelande 1:</b> Inga nya meddelanden idag.<p>");
        else
        {
            for (int i = 0; i < messages.Count; i++)
            {
                sw.WriteLine($"<p><b>Meddelande {i + 1}</b>: {messages[i]}</p>");
            }
        }
        foreach (var course in techniques)
        {
            sw.WriteLine($"<p>Kurs i {course.Trim().ToUpper().Substring(0, 1) + course.Trim().Substring(1).ToLower()}<p/>");
        }
        sw.WriteLine("</main>\n</body>\n</html>");
        sw.Close();
    }
}

class StyledHTMLGenerator : HTMLGenerator
{
    private string primaryColor = "blue";

    //constructor with arguments
    public StyledHTMLGenerator(string klass, int antalMeddelanden, string[] techniques, string primaryColor)
    {
        this.klass = klass;
        this.antalMeddelanden = antalMeddelanden;
        this.techniques = techniques;
        this.primaryColor = primaryColor;
    }
    //METHOD to print start text and primary color
    override public void printStart()
    {
        Console.WriteLine("<!DOCTYPE html>\n<html>\n<body>\n<main>");
        Console.WriteLine($"p {{ color: {primaryColor}; }}");
        Console.WriteLine("</style>\n</head>\n<body>");
    }
    override public void printToFile(string name)
    {
        FileInfo fi = new FileInfo($"{name}.html");
        FileStream fs = fi.Open(FileMode.Append, FileAccess.Write, FileShare.None);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine("<!DOCTYPE html>\n<html>\n<body>\n<main>");
        sw.WriteLine($"p {{ color: {primaryColor}; }}\n</style>\n</head>\n<body>");
        sw.WriteLine($"<main>\n<h1>Välkomna {this.klass}!</h1>");
        if (antalMeddelanden == 0)
            sw.WriteLine("<p><b>Meddelande 1:</b> Inga nya meddelanden idag.<p>");
        else
        {
            for (int i = 0; i < messages.Count; i++)
            {
                sw.WriteLine($"<p><b>Meddelande {i + 1}</b>: {messages[i]}</p>");
            }
        }
        foreach (var course in techniques)
        {
            sw.WriteLine($"<p>Kurs i {course.Trim().ToUpper().Substring(0, 1) + course.Trim().Substring(1).ToLower()}<p/>");
        }
        sw.WriteLine("</main>\n</body>\n</html>");
        sw.Close();
    }
}