CardShuffleGame test = new CardShuffleGame();
test.RunCardGame();

public class CardShuffleGame
{
    private List<string> myList = new List<string>();
    private string[] cards = new string[] { "k", "s", "r", "h" }; //klöver, spader, ruter, hjärter
    private string[] cardType = new string[] { "Kn", "Dr", "Ku", "Es" }; //knekt, drottning, kung, ess

    private Random rnd = new Random();
    private void Fill()
    {
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 0; j < cards.Length; j++)
            {
                string card = cards[j] + i;
                myList.Add(card);
            }
        }
        for (int i = 0; i < cards.Length; i++)
        {
            for (int j = 0; j < cards.Length; j++)
            {
                string card = cards[i] + cardType[j];
                myList.Add(card);
            }

        }
    }
    private void Shuffle()
    {
        for (int i = myList.Count - 1; i > 1; i--)
        {
            int random = rnd.Next(i + 1);

            var value = myList[random];
            myList[random] = myList[i];
            myList[i] = value;
        }
    }
    private void Print()
    {
        for (int i = 0; i < 52; i++)
        {
            Console.WriteLine("Card " + (i + 1) + ": " + myList[i]);
        }
    }
    public void RunCardGame()
    {
        Fill();
        Shuffle();
        Print();
    }
}
