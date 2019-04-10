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
            int NumberOfCards = 7, TAELLER = 0;
            WinConditions w = new WinConditions();
            bool overrule = false;
            do {
                foreach (Player player in players) {
                    player.Reset();
                }
                for (int i = h.Deck.Count - 1; i >= 0; i--) {
                    h.Deck.Remove(h.Deck[i]);
                }
                //for (int i = 0; i < NumberOfCards; i++) {
                //    h.Deck.Add(new Card(h.Deck));
                //}

                //royalflush
                h.Deck.Add(new Card(Suit.Clubs, Rank.Ace));
                h.Deck.Add(new Card(Suit.Diamond, Rank.King));
                h.Deck.Add(new Card(Suit.Hearts, Rank.Jack));
                h.Deck.Add(new Card(Suit.Hearts, (Rank)4));
                h.Deck.Add(new Card(Suit.Clubs, (Rank)4));
                h.Deck.Add(new Card(Suit.Spades, Rank.Queen));
                h.Deck.Add(new Card(Suit.Spades, (Rank)4));

                for (int i = 0; i < NumberOfCards; i++) {
                    players[0].Cards.Add(h.Deck[i]);
                }
                players[0].Cards.Sort();
                TAELLER++;
                //Console.WriteLine("HasRoyalflush: " + w.HasRoyalFlush(players[0].Cards));
                //for (int j = 0; j < players[0].Cards.Count; j++) {
                //    Console.WriteLine("Players Cards:" + players[0].Cards[j].Rank + " " + players[0].Cards[j].Suit);
                //}
                //if (w.HasFlush(players[0].Cards) || found == true) {
                //    found = true;
                //    Console.ReadKey();
                //}
                //Console.WriteLine("");
            } while (w.HasFullHouse(players[0].Cards) != true);
            Console.WriteLine(TAELLER);
            for (int j = 0; j < players[0].Cards.Count; j++) {
                Console.WriteLine("Players Cards:" + players[0].Cards[j].Rank + " " + players[0].Cards[j].Suit);
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
