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
        public Deck(bool create_new_deck    =false)
        {
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
        public override string ToString()
        {

            string str = "";

            foreach (var item in cards)
            {
                str += item.ToString() + " ";
            }

            return str;

        }
    }


}
