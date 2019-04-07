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



            for (int i = 0; i < NumberOfCards; i++) {
                h.Deck.Add(new Card(h.Deck));
            }
            for (int i = 0; i < 2; i++) {
                players[0].Cards.Add(h.Deck[i]);
            }
            h.Deck.Sort();
            for(int j = 0; j < NumberOfCards-7; j++)
            {
                Console.WriteLine(players[0].Cards[j].Rank + " " + players[0].Cards[j].Suit);
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
