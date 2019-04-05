using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class CardTest {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            List<Player> players = new List<Player>() { new Player(0, 1000), new Player(1, 1000) };
            Hand h = new Hand(players);


            for(int i = 0; i < 52; i++) {
                h.Deck.Add(new Card(h.Deck));
            }
            h.Deck.Sort();
            for(int j =0; j < 52; j++)
            {
                Console.WriteLine(h.Deck[j].Rank + " " + h.Deck[j].Suit);
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
