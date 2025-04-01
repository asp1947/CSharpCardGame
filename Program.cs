namespace ConsoleAppCG1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card c = new Card(Card.Mark.Heart, 1);
            Console.WriteLine(c);
            Card c2 = new Card(Card.Mark.BlackJoker, Card.JOKER);
            Console.WriteLine(c2);
        }
    }
}
