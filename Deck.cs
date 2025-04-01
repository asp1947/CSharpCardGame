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
        public void Take(Card c)
        {
            if (c == null)
                return;
            cards.Add(c);
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
