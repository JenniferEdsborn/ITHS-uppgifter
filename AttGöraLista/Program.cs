using Lista;

AttGöraLista minlista = new AttGöraLista();
minlista.Main();

namespace Lista
{
    class AttGöraLista
    {
        List<ListItem> list = new List<ListItem>();
        bool run = true;
        string input;
        string färdig = "[X]";
        string ofärdig = "[ ]";

        public void Main()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("         DIN ATT GÖRA-LISTA");
            Console.WriteLine("            - - ~ ~ - -\n");
            Console.WriteLine("1. Lägg till i listan");
            Console.WriteLine("2. Skriv ut lista");
            Console.WriteLine("3. Markera som slutförd");
            Console.WriteLine("4. Ta bort från listan");
            Console.WriteLine("5. Spara  listan");
            Console.WriteLine("6. Avsluta");
            Console.Write(">> ");
            input = Console.ReadLine();

            while (run)
            {
                try
                {
                    switch (Convert.ToInt32(input))
                    {
                        case 1:
                            Console.WriteLine("\n- - - LÄGG TILL - - -\n");
                            LäggTill();
                            break;
                        case 2:
                            Console.WriteLine("\n- - - SKRIV UT LISTA - - -");
                            SkrivUtLista();
                            break;
                        case 3:
                            Console.WriteLine("\n- - - MARKERA SOM SLTUFÖRD - - -");
                            MarkeraSomSlutförd();
                            break;
                        case 4:
                            Console.WriteLine("\n- - - TA BORT FRÅN LISTAN - - -");
                            RensaLista();
                            break;
                        case 5:
                            Console.WriteLine("\n- - - SPARA LISTAN - - -");
                            SparaListan();
                            break;
                        case 6:
                            if (list.Count > 0)
                            {
                                Console.WriteLine("Vill du spara innan du avslutar? y/n");
                                Console.Write("> ");
                                input = Console.ReadLine().ToLower();

                                if (input == "y")
                                    SparaListan();
                                else
                                {
                                    Console.WriteLine("Avslutar.");
                                    Environment.Exit(0);
                                }
                            }
                            else
                                Environment.Exit(0);                                                     
                            break;
                        default:
                            Console.WriteLine("\n FEL INPUT. Ange ett val från listan.");
                            Main();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Något gick fel med input. Försök igen.");
                    Main();
                }
            }
        }
        void LäggTill()
        {
            bool cont = true;
            Console.WriteLine("Skriv ESC när som helst för att avsluta lägg till-läget.");

            while (cont)
            {
                Console.Write("Att göra>> ");
                input = Console.ReadLine();

                if (input.Length <= 10)
                {
                    int avgörMellanrum = 13 - input.Length;

                    for (int i = 0; i < avgörMellanrum; i++)
                    {
                        input += " ";
                    }

                    list.Add(new ListItem(input, false));
                }
                else if (input.Length > 10)
                {
                    input += " ";
                    list.Add(new ListItem(input, false));
                }
                else
                {
                    Console.WriteLine("Något gick fel med input. Försök igen.");
                }

                if (input.ToUpper().Contains("ESC"))
                {
                    cont = false;
                }
            }

            list.RemoveAt(list.Count - 1);

            Delay();
        }
        public void SkrivUtLista()
        {
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Status == false)
                        Console.WriteLine($"{i + 1}. {list[i].Todo} {ofärdig}");
                    else if (list[i].Status == true)
                        Console.WriteLine($"{i + 1}. {list[i].Todo} {färdig}");
                }
            }
            else
            {
                Console.WriteLine("Din lista är tom.");
                Main();
            }

            Console.WriteLine("");
            Main();
        }
        void MarkeraSomSlutförd()
        {
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Status == false)
                        Console.WriteLine($"{i + 1}. {list[i].Todo} {ofärdig}");
                    else if (list[i].Status == true)
                        Console.WriteLine($"{i + 1}. {list[i].Todo} {färdig}");
                }
                try
                {
                    Console.Write("Val> ");
                    input = Console.ReadLine();
                    int inp = Convert.ToInt32(input) - 1;

                    if (inp <= list.Count)
                    {
                        if (list[inp].Status == false)
                        {
                            list[inp].Status = true;
                            Console.WriteLine("Ändrad till färdig.");
                        }
                        else if (list[inp].Status == true)
                        {
                            Console.WriteLine("Denna uppgift är redan markerad som klar.");
                        }
                    }
                    else
                        Console.WriteLine("Något gick fel med input.");
                }
                catch (Exception)
                {
                    Delay();
                }
            }
            Delay();
        }
        void SparaListan()
        {
            if (list.Count > 0)
            {
                Console.WriteLine("Spara listan? y/n");
                Console.Write("> ");
                input = Console.ReadLine().ToLower();

                if (input == "y")
                {
                    Console.Write("Spara som: ");
                    input = Console.ReadLine();

                    FileInfo file = new FileInfo($"{input}.txt");
                    FileStream fs = file.Open(FileMode.Append, FileAccess.Write, FileShare.Read);
                    StreamWriter sw = new StreamWriter(fs);

                    sw.WriteLine("Min att göra lista");

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Status == false)
                            sw.WriteLine($"{i + 1}. {list[i].Todo} {ofärdig}");
                        else if (list[i].Status == true)
                            sw.WriteLine($"{i + 1}. {list[i].Todo} {färdig}");
                    }

                    sw.Close();

                    Console.WriteLine("Listan sparad i samma directory som detta project.");
                    Delay();
                }
                else if (input == "n")
                {
                    Console.WriteLine("Listan sparades inte.");
                    Console.WriteLine("");
                    Main();
                }
                else
                {
                    Console.WriteLine("Något gick fel med input.");
                    Main();
                }
            }
            else
            {
                Console.WriteLine("Listan är tom.");
            }
            Main();
        }
        void RensaLista()
        {
            if (list.Count > 0)
            {
                Console.WriteLine("1. Rensa hela listan (OBS - går ej att ångra");

                int y = 2;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Status == false)
                        Console.WriteLine($"{y}. {list[i].Todo} {ofärdig}");
                    else if (list[i].Status == true)
                        Console.WriteLine($"{y}. {list[i].Todo} {färdig}");
                    y++;
                }

                try
                {
                    Console.Write("Val> ");
                    input = Console.ReadLine();
                    int inp = Convert.ToInt32(input);

                    if (inp <= list.Count + 1)
                    {
                        Console.WriteLine("Tar bort från listan.");
                        list.Remove(list[inp - 2]);
                    }
                    else if (inp == 1)
                    {
                        Console.WriteLine("Rensar listan.");
                        list.Clear();
                    }                      
                    else
                    {
                        Console.WriteLine("Något gick fel.");
                    }                      
                }
                catch (Exception)
                {
                    Console.WriteLine("Något gick fel.");
                    Delay();
                }
            }
            Delay();

        }
        void Delay()
        {
            Console.WriteLine("");
            Thread.Sleep(600);
            Console.Write(" .");
            Thread.Sleep(600);
            Console.Write(" .");
            Thread.Sleep(600);
            Console.Write(" .\n\n");
            Thread.Sleep(600);
            Main();
        }
    }

    class ListItem
    {
        public string Todo { get; set; }
        public bool Status { get; set; }

        public ListItem(string todo, bool status)
        {
            Todo = todo;
            Status = status;
        }
    }
}