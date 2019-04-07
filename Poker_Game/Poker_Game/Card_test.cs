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
            int NumberOfCards = 9;



            for(int i = 0; i < NumberOfCards; i++) {
                h.Deck.Add(new Card(h.Deck));
            }
            h.Deck.Sort();
            for(int j =0; j < NumberOfCards; j++)
            {
                Console.WriteLine(h.Deck[j].Rank + " " + h.Deck[j].Suit);
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
