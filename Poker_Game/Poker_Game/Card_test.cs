using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;
using System.IO;

namespace Poker_Game {
    class CardTest {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            List<Player> players = new List<Player>() { new Player(0, 1000), new Player(1, 1000) };
            int NumberOfCards = 7, TAELLER = 0;
            WinConditions w = new WinConditions();
            int flush = 0, straight = 0, royalflush = 0, straightflush = 0, four = 0, fullhouse = 0, three = 0, twopair = 0, pair = 0;
            Stopwatch stopWatch = new Stopwatch();
            string path = System.Windows.Forms.Application.StartupPath + "Dataset_1.txt";
            List<string> PrintFile = new List<string>();
            stopWatch.Start();

            do {
                //for (int i = h.Deck.Count - 1; i >= 0; i--) {
                //    h.Deck.Remove(h.Deck[i]);
                //}
                //h.Deck.Clear();
                //for (int i = 0; i < NumberOfCards; i++) {
                //    h.Deck.Add(new Card(h.Deck));
                //    Console.ReadKey();
                //}

                //royalflush
                players[0].Cards.Add(new Card(Suit.Clubs, (Rank)3));
                players[0].Cards.Add(new Card(Suit.Clubs, (Rank)5));
                players[0].Cards.Add(new Card(Suit.Clubs, (Rank)5));
                players[0].Cards.Add(new Card(Suit.Clubs, (Rank)6));
                players[0].Cards.Add(new Card(Suit.Clubs, (Rank)7));
                players[0].Cards.Add(new Card(Suit.Diamonds, (Rank)5));
                players[0].Cards.Add(new Card(Suit.Diamonds, Rank.Jack));

                players[0].Cards.Sort();
                TAELLER++;
                for (int j = 0; j < players[0].Cards.Count; j++) {
                    Console.WriteLine("Players Cards:" + players[0].Cards[j].Rank + " " + players[0].Cards[j].Suit);
                }
                Console.WriteLine("");

                players[0].Score = w.Evaluate(players[0].Cards);
                Console.WriteLine("player score: " + players[0].Score);

                w.GiveScoreHand(players[0]);

                //if (w.HasRoyalFlush(h.Deck)) {
                //    royalflush++;
                //} else if (w.HasStraightFlush(h.Deck)) {
                //    straightflush++;
                //} else if (w.HasFourOfAKind(h.Deck)) {
                //    four++;
                //} else if (w.HasFullHouse(h.Deck)) {
                //    fullhouse++;
                //} else if (w.HasFlush(h.Deck)) {
                //    flush++;
                //} else if (w.HasStraight(h.Deck)) {
                //    straight++;
                //} else if (w.HasThreeOfAKind(h.Deck)) {
                //    three++;
                //} else if (w.HasTwoPairs(h.Deck)) {
                //    twopair++;
                //} else if (w.HasPair(h.Deck)) {
                //    pair++;
                //}
            } while (false);



            //PrintFile.Add("Tid" + stopWatch.ElapsedMilliseconds.ToString());
            //PrintFile.Add("TÆLLER: " + TAELLER.ToString());
            //PrintFile.Add("royalflush: " + royalflush.ToString());
            //PrintFile.Add("straightflush: " + straightflush.ToString());
            //PrintFile.Add("four: " + four.ToString());
            //PrintFile.Add("fullhouse: " + fullhouse.ToString());
            //PrintFile.Add("flush: " + flush.ToString());
            //PrintFile.Add("straight: " + straight.ToString());
            //PrintFile.Add("three: " + three.ToString());
            //PrintFile.Add("twopair: " + twopair.ToString());
            //PrintFile.Add("pair: " + pair.ToString());

            //File.WriteAllLines(path, PrintFile);




            //Console.WriteLine("Time: " + stopWatch.ElapsedMilliseconds.ToString());
            //stopWatch.Stop();
            //Console.WriteLine("TÆLLER: " + TAELLER);
            //Console.WriteLine("royalflush: " + royalflush);
            //Console.WriteLine("straightflush: " + straightflush);
            //Console.WriteLine("four: " + four);
            //Console.WriteLine("fullhouse: " + fullhouse);
            //Console.WriteLine("flush: " + flush);
            //Console.WriteLine("straight: " + straight);
            //Console.WriteLine("three: " + three);
            //Console.WriteLine("twopair: " + twopair);
            //Console.WriteLine("pair: " + pair);

            for (int j = 0; j < players[0].ScoreHand.Count - 1; j++) {
                Console.WriteLine("Players Cards:" + players[0].ScoreHand[j].Rank + " " + players[0].ScoreHand[j].Suit);
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
