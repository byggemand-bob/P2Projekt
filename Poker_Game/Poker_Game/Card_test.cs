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
            for (int i = 0; i < 100 ; i++)
            {
                Console.WriteLine("Count {0}", i);
                H.Deck.Add(Card.MakeCard(Card.DrawCards(H.Deck)));
                Console.WriteLine(Card.MakeCard(Card.DrawCards(H.Deck)).Rank); 
            }
            Console.ReadKey();
        }
    }
}
