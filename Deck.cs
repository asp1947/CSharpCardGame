using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public Card Give()
        {
            if (cards.Count == 0)
            {
                return null;
            }
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
    }


}
