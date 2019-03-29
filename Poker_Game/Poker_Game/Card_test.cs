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
            for (int i = 0; i < 52; i++)
            {
                H.Deck.Add(Card.DrawCards(H.Deck));
                Console.WriteLine(H.Deck[i].Rank + " " + H.Deck[i].Suit);
            }
            Console.WriteLine("Done!");
            //for (int j = 0; j < 52; j++)
            //{
            //    Card testkort = Card.MakeCard(j);

            //    Console.WriteLine("Kort er " + testkort.Suit + " " + testkort.Rank);
            //}
            //Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
