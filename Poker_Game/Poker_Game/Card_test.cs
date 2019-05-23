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
            int NumberOfCards = 5, TAELLER = 0;
            WinConditions w = new WinConditions();
            int flush = 0, straight = 0, royalflush = 0, straightflush = 0, four = 0, fullhouse = 0, three = 0, twopair = 0, pair = 0;
            int wins = 0, loss = 0, draw = 0, result = 0;
            Stopwatch stopWatch = new Stopwatch();
            string path = System.Windows.Forms.Application.StartupPath + "Dataset_1.txt";
            List<string> PrintFile = new List<string>();
            stopWatch.Start();
            FastWinCalc fw = new FastWinCalc();
            List<Card> allcards = new List<Card>();
            do {
                #region problems
                players[0].Cards.Clear();
                players[1].Cards.Clear();
                allcards.Clear();
                for (int i = 0; i < NumberOfCards; i++) {
                    allcards.Add(new Card(allcards));
                }
                players[0].Cards.Add(new Card(Suit.Diamonds, Rank.King));
                players[0].Cards.Add(new Card(Suit.Spades, Rank.Ace));
                players[0].Cards.Add(allcards[0]);
                players[0].Cards.Add(allcards[1]);
                players[0].Cards.Add(allcards[2]);
                players[0].Cards.Add(allcards[3]);
                players[0].Cards.Add(allcards[4]);
                players[1].Cards.Add(allcards[0]);
                players[1].Cards.Add(allcards[1]);
                players[1].Cards.Add(allcards[2]);
                players[1].Cards.Add(allcards[3]);
                players[1].Cards.Add(allcards[4]);
                players[1].Cards.Add(new Card(Suit.Hearts, Rank.King));
                players[1].Cards.Add(new Card(Suit.Hearts, Rank.Ace));


                //players[0].Score = w.Evaluate(players[0].Cards);
                //players[1].Score = w.Evaluate(players[1].Cards);
                //w.GiveScoreHand(players[0]);
                //w.GiveScoreHand(players[1]);
                result = fw.WhoWins(players[0].Cards, players[1].Cards);
                //if (w.WhoWins(players[0], players[1]) == null) {
                //    draw++;
                //} else if (w.WhoWins(players[0], players[1]).Id == 0) {
                //    wins++;
                //} else {
                //    loss++;
                //}
                if (result == -1) {
                    wins++;
                }else if (result == 0) {
                    draw++;
                } else if (result == 1) {
                    loss++;
                }
                TAELLER++;
                #endregion
                #region new card test
                //players[0].Cards.Add(new Card(Suit.Hearts, (Rank)8));
                //players[0].Cards.Add(new Card(Suit.Clubs, (Rank)8));
                //players[0].Cards.Add(new Card(Suit.Diamonds, (Rank)8));
                //players[0].Cards.Add(new Card(Suit.Clubs, Rank.Ace));
                //players[0].Cards.Add(new Card(Suit.Hearts, Rank.Ace));
                //players[0].Cards.Add(new Card(Suit.Diamonds, Rank.Queen));
                //players[0].Cards.Add(new Card(Suit.Diamonds, Rank.King));

                //players[1].Cards.Add(new Card(Suit.Hearts, (Rank)8));
                //players[1].Cards.Add(new Card(Suit.Clubs, (Rank)8));
                //players[1].Cards.Add(new Card(Suit.Diamonds, (Rank)8));
                //players[1].Cards.Add(new Card(Suit.Diamonds, Rank.Ace));
                //players[1].Cards.Add(new Card(Suit.Hearts, Rank.Ace));
                //players[1].Cards.Add(new Card(Suit.Diamonds, Rank.King));
                //players[1].Cards.Add(new Card(Suit.Clubs, Rank.King));


                //players[0].Cards.Sort();
                //players[1].Cards.Sort();
                //TAELLER++;
                ////for (int j = 0; j < players[0].Cards.Count; j++) {
                ////    Console.WriteLine("Players Cards:" + players[0].Cards[j].Rank + " " + players[0].Cards[j].Suit);
                ////}
                //Console.WriteLine("");

                //players[0].Score = w.Evaluate(players[0].Cards);
                //players[1].Score = w.Evaluate(players[1].Cards);
                //Console.WriteLine("player score: " + players[0].Score);

                //w.GiveScoreHand(players[0]);
                //w.GiveScoreHand(players[1]);
                //if (w.WhoWins(players[0], players[1]) != null) {
                //    Console.WriteLine("winner is: " + w.WhoWins(players[0], players[1]).Id);
                //} else {
                //    Console.WriteLine("Draw");
                //}
                #endregion
            } while (TAELLER != 10000000);

            Console.WriteLine("Wins: " + wins);
            Console.WriteLine("Loss: " + loss);
            Console.WriteLine("Draw: " + draw);

            //Console.WriteLine("Wins: " + wins/1000);
            //Console.WriteLine("Loss: " + loss/1000);
            //Console.WriteLine("Draw: " + draw/1000);

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

            //for (int j = 0; j <= players[0].ScoreHand.Count - 1; j++) {
            //    Console.WriteLine("Players Cards:" + players[0].ScoreHand[j].Rank + " " + players[0].ScoreHand[j].Suit);
            //}
            //Console.WriteLine("Done!");
            //for (int j = 0; j <= players[1].ScoreHand.Count - 1; j++) {
            //    Console.WriteLine("Players Cards:" + players[1].ScoreHand[j].Rank + " " + players[1].ScoreHand[j].Suit);
            //}
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
