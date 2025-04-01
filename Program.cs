namespace ConsoleAppCG1
{
    internal class Program
    {
        //인원수, 카드 5장
        public const int N_PLAYERS = 3;
        public const int N_CARDS = 5;
        static void Main(string[] args)
        {
            Deck deck = new Deck("딜러", true);
            Deck[] players = new Deck[N_PLAYERS];

            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new Deck($"플레이어 {i + 1}");
            }
            //Deck 셔플
            deck.Shuffle();

            for (int i = 0; i < N_CARDS; i++)
            {
                for (int j = 0; j < players.Length ; j++)
                {
                    Deck p = players[j];    //별명
                    p.TakeFrom(deck, 1);
                }
            }

            foreach (var p in players)
            {
                p.SetOpenAll();
                //p.FindPair();
                p.FindStraight();
                Console.WriteLine(p.ToString());
            }
        }
    }
}
