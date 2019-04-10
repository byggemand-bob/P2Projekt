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
            do {
                for (int i = h.Deck.Count - 1; i >= 0; i--) {
                    h.Deck.Remove(h.Deck[i]);
                }
                Console.WriteLine("number of cards:" + h.Deck.Count);
                for (int i = 0; i < NumberOfCards; i++) {
                    h.Deck.Add(new Card(h.Deck));
                    //Console.ReadKey();
                }
                Console.WriteLine("number of cards:" + h.Deck.Count);

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
                for (int j = 0; j < h.Deck.Count; j++) {
                    Console.WriteLine("Players Cards:" + h.Deck[j].Rank + " " + h.Deck[j].Suit);
                }
                Console.WriteLine("");

                if (w.HasRoyalFlush(h.Deck)) {
                    royalflush++;
                } if (w.HasStraightFlush(h.Deck)) {
                    straightflush++;
                } if (w.HasFourOfAKind(h.Deck)) {
                    four++;
                } if (w.HasFullHouse(h.Deck)) {
                    fullhouse++;
                } if (w.HasFlush(h.Deck)) {
                    flush++;
                } if (w.HasStraight(h.Deck)) {
                    straight++;
                } if (w.HasThreeOfAKind(h.Deck)) {
                    three++;
                } if (w.HasTwoPairs(h.Deck)) {
                    twopair++;
                } if (w.HasPair(h.Deck))  {
                    pair++;
                } 
            } while (TAELLER != 10/*w.HasFullHouse(h.Deck) != true*/);
            stopWatch.Stop();
            Console.WriteLine("Time: " + stopWatch.ElapsedMilliseconds.ToString());
            Console.WriteLine("TÆLLER: " + TAELLER);
            Console.WriteLine("flush: " + flush);
            Console.WriteLine("four: " + four);
            Console.WriteLine("fullhouse: " + fullhouse);
            Console.WriteLine("pair: " + pair);
            Console.WriteLine("royalflush: " + royalflush);
            Console.WriteLine("straight: " + straight);
            Console.WriteLine("straightflush: " + straightflush);
            Console.WriteLine("three: " + three);
            Console.WriteLine("twopair: " + twopair);

            for (int j = 0; j < h.Deck.Count; j++) {
                Console.WriteLine("Players Cards:" + h.Deck[j].Rank + " " + h.Deck[j].Suit);
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
