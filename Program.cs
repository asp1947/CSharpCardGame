namespace ConsoleAppCG1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> deck = new List<Card>();

            

            for (int i = 1; i <= 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card.Mark m = (Card.Mark)j;

                    Card c = new Card(m, i);
                    Console.WriteLine(c);
                }
            }
        }
    }
}
