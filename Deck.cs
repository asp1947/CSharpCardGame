using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCG1
{
    class Deck
    {
        private List<Card> cards = new List<Card>();
        private string name;

        public Deck(string name, bool create_new_deck    =false)
        {
            this.name = name;

            if (create_new_deck)
            {
                CreateNewDeck();
            }

            
        }
        private void CreateNewDeck()
        {
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card.Mark m = (Card.Mark)j;
                    Card c = new Card(m, i);
                    cards.Add(c);

                    //Console.WriteLine(c);
                }
            }
            cards.Add(new Card(Card.Mark.BlackJoker, Card.JOKER));
            cards.Add(new Card(Card.Mark.ColorJoker, Card.JOKER));
        }
        //Setter 함수
        public void SetName(string name)
        {
            this.name = name;
        }
        //외부 정보 제공, Getter 함수
        public string GetName()
        {
            return name;
        }

        //https://holjjack.tistory.com/313 참조
        public void Shuffle()
        {
            Random rand = new Random();
            cards = cards.OrderBy(_ => rand.Next()).ToList();
        }

        public Card GetCardAt(int idx)
        {
            if (cards.Count-1 < idx)
                return null;

            return cards[idx];
        }
        public void SetOpenAll(bool IsOpen = true)
        {
            foreach (var c in cards)
            {
                c.SetOpen(IsOpen);
            }
        }

        public Card Give()
        {
            if (cards.Count == 0)
                return null;
            Card c = cards[0];
            cards.RemoveAt(0);

            return c;
        }
        public bool Take(Card c)
        {
            if (c == null)
                return false;
            cards.Add(c);
            return true;
        }

        public bool TakeFrom(Deck d, int cnt)
        {
            if (d.cards.Count < cnt)
                return false;
            for (int i = 0; i < cnt; i++)
            {
                cards.Add(d.Give());
            }
            return true;
        }

        public bool GiveTo(Deck d, int cnt)
        {
            if (cards.Count < cnt)
                return false;
            for (int i = 0; i < cnt; i++)
            {
                d.cards.Add(Give());
            }
            return true;
        }
        


        public override string ToString()
        {

            string str = name + ":";

            foreach (var item in cards)
            {
                str += item.ToString() + " ";
            }

            return str;

        }

        public void FindPair()
        {
            int[] cnts = new int[14];
            foreach (var c in cards)
            {
                cnts[c.number]++;
            }

            foreach (var item in cnts)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            string[] strpairs = { "", "", "pair", "triple", "four card", "??"};
            int[] npairs = [6];

            for (int i = 1; i < 13; i++)
            {
                int c = cnts[i];
                if (cnts[i] < 2)
                    continue;
                npairs[c]++;
                Console.WriteLine($"{i}:{strpairs[c]}");

            }
            if (npairs[4] == 1)
                Console.WriteLine("four card");
            else if (npairs[3] == 1)
            {
                if (npairs[2] == 1)
                    Console.WriteLine("full house");
                else
                    Console.WriteLine("triple");
            }
            else if (npairs[2] == 2)
                Console.WriteLine("two pair");
            else if (npairs[2] == 1)
                Console.WriteLine("one pair");
        }


        public void FindStraight()
        {
            int[] cnts = new int[14];
            foreach (var c in cards)
            {
                cnts[c.number]++;
            }

            foreach (var item in cnts)
            {
                Console.Write(item + " ");
            }
            
            Console.WriteLine();

            for (int i = 1; i <= 13; i++)
            {
                int sum = 0;
                for (int j = 0; j < 5; j++)
                {
                    int idx = i + j;
                    if (idx > 13)   //12 -> 13 -> A
                        idx -=13;

                    
                    sum = cnts[idx] != 1 ? 0 : sum +1;
                }
                if (sum == 5)
                {
                    bool royal = (i == 10);
                    int[] nmarks = new int[4];

                    foreach (var c in cards)
                    {
                        nmarks [(int)c.mark]++;
                    }
                    bool Flush = false;
                    for (int j = 0; j < nmarks.Length; j++)
                    {
                        if (nmarks[j] == 5)
                            Flush = true;
                    }
                    if (Flush) { 
                        if (royal)
                            Console.WriteLine("Royal Straight Flush");
                        else
                            Console.WriteLine("Straight Flush");
                    }
                    else
                        Console.WriteLine("Straight");
                }
            }
        }
    }


}
