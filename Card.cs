using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCG1
{
    class Card
    {
        public enum Mark {Spade, Heart, Clover, Diamond, BlackJoker, ColorJoker};
        //개별 사항
        public readonly Color color;
        public readonly Mark mark; // 4종류의 카드
        public readonly int number;  // 0 ~ 13
        public readonly string name; // Spade A

        //상수
        public static readonly int JOKER = 0;
        public static readonly string MARKS = "♠♥♣◆    ";

        //공통 사항
        public static readonly string[] names = { "JOKER", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public static readonly Color[] mark2color = [Color.Black, Color.Red, Color.Black, Color.Red, Color.Black, Color.Red];

        public Card(Mark mark, int number)
        {
            this.mark = mark;
            this.number = number;


            //switch(mark)
            //{
            //    case Mark.BlackJoker:
            //    case Mark.Clover:
            //    case Mark.Spade:
            //        color = Color.Black;
            //        break;
            //    case Mark.ColorJoker:
            //    case Mark.Heart:
            //    case Mark.Diamond:
            //        color = Color.Red;
            //        break;
            //}


            //if (Mark.BlackJoker || Mark.Spade)
            //{

            //}

            color = mark2color[(int)mark];

            this.name = MARKS[(int)mark].ToString() + names[number];
        }
        //객체를 문자열로 반환하기 위한 메서드(모든 클래스에 있는 메서드)
        public override string ToString()
        {
            return name;
        }
    }
}
