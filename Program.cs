namespace ConsoleAppCG1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck("새카드", true);
            Deck p1 = new Deck("플레이어1");
            Deck p2 = new Deck("플레이어2");
            Console.WriteLine(deck);
            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Card c = deck.Give();
            p1.Take(c);
            
            //p2.Take(deck.Give());
            p2.TakeFrom(deck, 3);
            
            p2.GiveTo(p1, 1);

            Console.WriteLine(deck);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
    }
}
