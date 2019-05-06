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
            Settings settings = new Settings(2,1000,1,true, 10, "Jonas", 1);
            Hand h = new Hand(settings, players, 1);
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
                //    //Console.ReadKey();
                //}


                for (int i = 0; i < NumberOfCards; i++) {
                    for (int j = i + 1; j < NumberOfCards; j++) {
                        for (int k = j + 1; k < NumberOfCards; k++) {
                            for (int l = k + 1; l < NumberOfCards; l++) {
                                for (int m = l + 1; m < NumberOfCards; m++) {
                                    for (int n = m + 1; n < NumberOfCards; n++) {
                                        for (int o = n + 1; o < NumberOfCards; o++) {
                                            h.Deck.Clear();

                                            h.Deck.Add(new Card(i));
                                            h.Deck.Add(new Card(j));
                                            h.Deck.Add(new Card(k));
                                            h.Deck.Add(new Card(l));
                                            h.Deck.Add(new Card(m));
                                            h.Deck.Add(new Card(n));
                                            h.Deck.Add(new Card(o));

                                            h.Deck.Sort();
                                            TAELLER++;


                                            if(TAELLER % 1000000 == 1) {
                                                Console.WriteLine(TAELLER + " " + stopWatch.ElapsedMilliseconds.ToString());
                                            }


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
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //royalflush
                h.Deck.Add(new Card(Suit.Clubs, (Rank)3));
                h.Deck.Add(new Card(Suit.Clubs, (Rank)5));
                h.Deck.Add(new Card(Suit.Clubs, (Rank)5));
                h.Deck.Add(new Card(Suit.Clubs, (Rank)6));
                h.Deck.Add(new Card(Suit.Clubs, (Rank)7));
                h.Deck.Add(new Card(Suit.Diamonds, (Rank)5));
                h.Deck.Add(new Card(Suit.Diamonds, Rank.Jack));

                //h.Deck.Sort();
                //TAELLER++;
                //for (int j = 0; j < h.Deck.Count; j++) {
                //    Console.WriteLine("Players Cards:" + h.Deck[j].Rank + " " + h.Deck[j].Suit);
                //}
                //Console.WriteLine("");

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
 


            PrintFile.Add("Tid" + stopWatch.ElapsedMilliseconds.ToString());
            PrintFile.Add("TÆLLER: " + TAELLER.ToString());
            PrintFile.Add("royalflush: " + royalflush.ToString());
            PrintFile.Add("straightflush: " + straightflush.ToString());
            PrintFile.Add("four: " + four.ToString());
            PrintFile.Add("fullhouse: " + fullhouse.ToString());
            PrintFile.Add("flush: " + flush.ToString());
            PrintFile.Add("straight: " + straight.ToString());
            PrintFile.Add("three: " + three.ToString());
            PrintFile.Add("twopair: " + twopair.ToString());
            PrintFile.Add("pair: " + pair.ToString());

            File.WriteAllLines(path, PrintFile);




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
