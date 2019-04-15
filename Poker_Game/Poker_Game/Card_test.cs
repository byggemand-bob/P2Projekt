using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class CardTest {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            List<Player> players = new List<Player>() { new Player(0, 1000), new Player(1, 1000) };
            Hand h = new Hand(players, 1);
            int NumberOfCards = 7, TAELLER = 0;
            WinConditions w = new WinConditions();
            int flush = 0, straight = 0, royalflush = 0, straightflush = 0, four = 0, fullhouse = 0, three = 0, twopair = 0, pair = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int goal = 1000000;
            do {
                //for (int i = h.Deck.Count - 1; i >= 0; i--) {
                //    h.Deck.Remove(h.Deck[i]);
                //}
                h.Deck.Clear();
                //Console.WriteLine(TAELLER);
                for (int i = 0; i < NumberOfCards; i++) {
                    h.Deck.Add(new Card(h.Deck));
                    //Console.ReadKey();
                }

                ////royalflush
                //h.Deck.Add(new Card(Suit.Clubs, Rank.Ace));
                //h.Deck.Add(new Card(Suit.Clubs, Rank.Queen));
                //h.Deck.Add(new Card(Suit.Clubs, Rank.King));
                //h.Deck.Add(new Card(Suit.Clubs, (Rank)10));
                //h.Deck.Add(new Card(Suit.Spades, (Rank)3));
                //h.Deck.Add(new Card(Suit.Clubs, Rank.Jack));
                //h.Deck.Add(new Card(Suit.Diamond, Rank.Jack));

                h.Deck.Sort();
                TAELLER++;
                //for (int j = 0; j < h.Deck.Count; j++) {
                //    Console.WriteLine("Players Cards:" + h.Deck[j].Rank + " " + h.Deck[j].Suit);
                //}
                //Console.WriteLine("");

                if (w.HasRoyalFlush(h.Deck)) {
                    royalflush++;
                } else if (w.HasStraightFlush(h.Deck)) {
                    straightflush++;
                } else if (w.HasFourOfAKind(h.Deck)) {
                    four++;
                } else if (w.HasFullHouse(h.Deck)) {
                    fullhouse++;
                } else if (w.HasFlush(h.Deck)) {
                    flush++;
                } else if (w.HasStraight(h.Deck)) {
                    straight++;
                } else if (w.HasThreeOfAKind(h.Deck)) {
                    three++;
                } else if (w.HasTwoPairs(h.Deck)) {
                    twopair++;
                } else if (w.HasPair(h.Deck)) {
                    pair++;
                }
            } while (royalflush < 1);
            Console.WriteLine("Time: " + stopWatch.ElapsedMilliseconds.ToString());
            stopWatch.Stop();
            Console.WriteLine("TÆLLER: " + TAELLER);
            Console.WriteLine("royalflush: " + royalflush);
            Console.WriteLine("straightflush: " + straightflush);
            Console.WriteLine("four: " + four);
            Console.WriteLine("fullhouse: " + fullhouse);
            Console.WriteLine("flush: " + flush);
            Console.WriteLine("straight: " + straight);
            Console.WriteLine("three: " + three);
            Console.WriteLine("twopair: " + twopair);
            Console.WriteLine("pair: " + pair);

            for (int j = 0; j < h.Deck.Count; j++) {
                Console.WriteLine("Players Cards:" + h.Deck[j].Rank + " " + h.Deck[j].Suit);
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
