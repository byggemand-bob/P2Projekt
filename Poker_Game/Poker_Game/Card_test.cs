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
            Hand h = new Hand(players);
            int NumberOfCards = 7, TAELLER = 0;
            WinConditions w = new WinConditions();
            int flush = 0, straight = 0, royalflush = 0, straightflush = 0, four = 0, fullhouse = 0, three = 0, twopair = 0, pair = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int goal = 100;
            do {
                for (int i = h.Deck.Count - 1; i >= 0; i--) {
                    h.Deck.Remove(h.Deck[i]);
                }
                for (int i = 0; i < NumberOfCards; i++) {
                    h.Deck.Add(new Card(h.Deck));
                    //Console.ReadKey();
                }

                ////royalflush
                //h.Deck.Add(new Card(Suit.Clubs, Rank.Ace));
                //h.Deck.Add(new Card(Suit.Diamond, Rank.Queen));
                //h.Deck.Add(new Card(Suit.Hearts, Rank.Ace));
                //h.Deck.Add(new Card(Suit.Hearts, (Rank)2));
                //h.Deck.Add(new Card(Suit.Clubs, (Rank)3));
                //h.Deck.Add(new Card(Suit.Spades, Rank.Queen));
                //h.Deck.Add(new Card(Suit.Spades, (Rank)4));

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
                } else if (w.HasPair(h.Deck))  {
                    pair++;
                } 
            } while (TAELLER != goal/*w.HasFullHouse(h.Deck) != true*/);
            stopWatch.Stop();
            Console.WriteLine("Time: " + stopWatch.ElapsedMilliseconds.ToString());
            Console.WriteLine("TÆLLER: " + TAELLER);
            Console.WriteLine("royalflush: " + royalflush / goal * 100);
            Console.WriteLine("straightflush: " + straightflush / goal * 100);
            Console.WriteLine("four: " + four / goal * 100);
            Console.WriteLine("fullhouse: " + fullhouse / goal * 100);
            Console.WriteLine("flush: " + flush/ goal * 100);
            Console.WriteLine("straight: " + straight / goal * 100);
            Console.WriteLine("three: " + three / goal * 100);
            Console.WriteLine("twopair: " + twopair / goal * 100);
            Console.WriteLine("pair: " + pair / goal * 100);

            for (int j = 0; j < h.Deck.Count; j++) {
                Console.WriteLine("Players Cards:" + h.Deck[j].Rank + " " + h.Deck[j].Suit);
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
