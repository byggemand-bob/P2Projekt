using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game
{
    class Card_test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Hand H = new Hand();
            H.Deck.Count = 0;
            Console.WriteLine(Card.MakeCard(Card.DrawCards(H.Deck)));
            Console.ReadKey();
        }
    }
}
