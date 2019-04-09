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
            int NumberOfCards = 7;
            WinConditions w = new WinConditions();
            
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
                
                h.Deck.Add(new Card(Suit.Clubs, Rank.Ace));
                h.Deck.Add(new Card(Suit.Clubs, Rank.Jack));
                h.Deck.Add(new Card(Suit.Clubs, Rank.King));
                h.Deck.Add(new Card(Suit.Clubs, Rank.Queen));
                h.Deck.Add(new Card(Suit.Clubs, (Rank)10));
                h.Deck.Add(new Card(Suit.Clubs, (Rank)2));
                h.Deck.Add(new Card(Suit.Clubs, (Rank)4));

                for (int i = 0; i < NumberOfCards; i++) {
                    players[0].Cards.Add(h.Deck[i]);
                }
                players[0].Cards.Sort();
                for (int j = 0; j < 7; j++) {
                    Console.WriteLine("Players Cards:" + players[0].Cards[j].Rank + " " + players[0].Cards[j].Suit);
                }
                Console.WriteLine("HasRoyalflush: " + w.HasRoyalFlush(players[0].Cards));
                w.HasRoyalFlush(players[0].Cards);
            } while (w.HasRoyalFlush(players[0].Cards) != true);
            
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
