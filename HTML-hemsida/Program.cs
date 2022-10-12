// välj vilken klass du vill välkomna
Console.Write("Klass: ");
string klass = Console.ReadLine();

// välj hur många meddelanden du vill ge klassen
Console.Write("Välj antal meddelanden: ");
int antal = int.Parse(Console.ReadLine());

// för in dina klasspecifika meddelanden
string[] messages = new string[antal];
handleMessages(antal, 0);

//visar hemsidan
webpage();


// rekursiv metod för att hantera alla klasspecifika meddelanden och lägga dem i en array
void handleMessages(int n, int p)
{
    if (n > 0)
    {
        Console.Write($"Meddelande {p + 1}: ");
        string x = Console.ReadLine();
        messages[p] = x;
        handleMessages(n - 1, p + 1);
    }
}

//metod för att skriva ut klassnamn och meddelanden(a) till klassen
void welcome(string welcome)
{
    Console.WriteLine($"<h1>Välkomna {welcome}!</h1>");
    for (int i = 0; i < messages.Length; i++)
    {
        Console.WriteLine($"<p><b>Meddelande {i + 1}</b>: {messages[i]}</p>");
    }
}

//metod för utskrivt av hela kompletta hemsidan
void webpage()
{
    Console.WriteLine("\n<!DOCTYPE html>");
    Console.WriteLine("<html>");
    Console.WriteLine("<body>");
    welcome(klass);
    Console.WriteLine("<main>");
    Console.WriteLine("<p>Kurs om C#<p>");
    Console.WriteLine("<p>Kurs om Databaser</p>");
    Console.WriteLine("</main>");
    Console.WriteLine("</body>");
    Console.WriteLine("</html>");
}