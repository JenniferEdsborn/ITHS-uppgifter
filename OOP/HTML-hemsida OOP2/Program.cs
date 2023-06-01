Print website = new Print();
website.fromInheritence();

//KLASS för att testa att skriva ut hemsidan till console
class Print
{
    private string[] courses = { "Svenska", "Matte", "Engelska" };

    //METHOD to print a website from the derived class StyledHTMLGenerator with user input
    public void fromInheritence()
    {
        StyledHTMLGenerator website = new StyledHTMLGenerator("3A", 2, courses, "red");
        website.generate();
    }
}

//INTERFACE som utgör basen för vårt hemsidebygge
interface WebsiteGenerator
{
    void printStart();
    void generate();
    void courses(string[] courses);
    void handleMessages(int p, int n);
    void writeMessages();
}


//KLASS som ärver från WebsiteGenerator, för att skapa en hemsida
class HTMLGenerator : WebsiteGenerator
{
    //fields
    private string end = "\n</main>\n</body>\n</html>";
    protected string klass;
    protected int antalMeddelanden;
    protected List<string> messages = new List<string>();

    //data from API, default value if the user hasn't input another array of courses
    protected string[] techniques = { "   C#", "daTAbaser", "WebbuTVeCkling ", "clean Code   " };

    //constructor
    //create new website with new class and messages
    public HTMLGenerator(string klass, int antalMeddelanden, string[] techniques)
    {
        this.klass = klass;
        this.antalMeddelanden = antalMeddelanden;
        this.techniques = techniques;
    }
    //constructor
    //default values
    public HTMLGenerator()
    {
        this.klass = "1A";
        this.antalMeddelanden = 0;
        this.techniques = techniques;
    }
    //METHOD to print start text
    virtual public void printStart()
    {
        Console.WriteLine("<!DOCTYPE html>\n<html>\n<body>\n<main>");
    }
    //METHOD
    //generates the website by calling functions in the correct order within this class
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
        Console.WriteLine(this.end);
    }
    //METHOD
    //cleans up the array of courses
    public void courses(string[] courses)
    {
        foreach (var course in courses)
        {
            Console.WriteLine($"<p>Kurs i {course.Trim().ToUpper().Substring(0, 1) + course.Trim().Substring(1).ToLower()}<p/>");
        }
    }
    //RECURSIVE METHOD
    //allows user to create messages to the class
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
    //METHOD
    //prints the messages to your class to console
    public void writeMessages()
    {
        for (int i = 0; i < messages.Count; i++)
        {
            Console.WriteLine($"<p><b>Meddelande {i + 1}</b>: {messages[i]}</p>");
        }
    }
}

//KLASS som ärver från HTMLGenerator, där användaren får välja primaryColor
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
    //constructor wihtout arguments
    public StyledHTMLGenerator()
    {
        this.klass = "1A";
        this.antalMeddelanden = 0;
        this.techniques = techniques;
    }
    //METHOD to print start text and primary color
    override public void printStart()
    {
        Console.WriteLine("<!DOCTYPE html>\n<html>\n<body>\n<main>");
        Console.WriteLine($"p {{ color: {primaryColor}; }}");
        Console.WriteLine("</style>\n</head>\n<body>\n");
    }
}