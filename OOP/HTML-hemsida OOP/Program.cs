HTMLGenerator hemsida = new HTMLGenerator();

hemsida.generate();

class HTMLGenerator
{
    // variabler
    string start = "\n<>!DOCTYPE html>\n<html>\n<body>";
    string end = "</main>\n</body>\n</html>";
    string klass = "";
    List<string> messages = new List<string>();

    //data från API
    string[] techniques = { "   C#", "daTAbaser", "WebbuTVeCkling ", "clean Code   " };

    // - METOD GENERATE
    // tar användarens indata för att sedan genererar hemsidan
    public void generate()
    {
        klassNamn();
        meddelanden();
        main();
    }
    // - METOD COURSES
    // hanterar datan från API
    void courses(string[] techniques)
    {
        foreach (var kurs in techniques)
        {
            Console.WriteLine($"<p>Kurs i {kurs.Trim().ToUpper().Substring(0, 1) + kurs.Trim().Substring(1).ToLower()}<p/>");
        }
    }
    // - METOD MAIN
    // hanterar hemsidans utskrifter
    public void main()
    {
        Console.WriteLine(this.start);
        Console.WriteLine($"<h1>Välkomna {klass}!</h1>");
        for (int i = 0; i < messages.Count; i++)
        {
            Console.WriteLine($"<p><b>Meddelande {i + 1}</b>: {messages[i]}</p>");
        }
        Console.WriteLine("<main>");
        courses(techniques);
        Console.WriteLine(this.end);
    }
    // - METOD KLASSNAMN
    // tar indata om klassens namn
    public void klassNamn()
    {
        // välj vilken klass du vill välkomna
        Console.Write("Klass: ");
        klass = Console.ReadLine();
    }
    // - METOD MEDDELANDEN
    // tar indata om användarens meddelanden till klassen
    public void meddelanden()
    {
        //välj hur många meddelanden du vill ge till klassen
        Console.Write("Välj antal meddelanden: ");
        int antal = int.Parse(Console.ReadLine());
        handleMessages(1, antal);

    }
    // - METOD HANDLEMESSAGES
    // adderar användarens meddelanden till en global lista
    // rekursiv metod
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
}