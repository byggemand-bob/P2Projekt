//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Poker_Game.Game;
//using System.IO;
//using System.Threading;

//namespace Poker_Game {
//    class MultiThreadCardTest {
//        static void Main(string[] args) {
//            int NumberOfThreads = 8;
//            Thread[] workers = new Thread[NumberOfThreads];
//            long[] results1 = new long[11];
//            long[] results2 = new long[11];
//            long[] results3 = new long[11];
//            long[] results4 = new long[11];
//            long[] results5 = new long[11];
//            long[] results6 = new long[11];
//            long[] results7 = new long[11];
//            long[] results8 = new long[11];
//            long[] Final = new long[11];
//            string path = System.Windows.Forms.Application.StartupPath + "Dataset_1.txt";
//            List<string> PrintFile = new List<string>();

//            for (int i = 0; i < 11; i++) {
//                            Final[i] = 0;
//            }

//            workers[0] = new Thread(() => { results1 = CardTestMulti(0, 1); });
//            workers[1] = new Thread(() => { results2 = CardTestMulti(1, 2); });
//            workers[2] = new Thread(() => { results3 = CardTestMulti(2, 3); });
//            workers[3] = new Thread(() => { results4 = CardTestMulti(3, 4); });
//            workers[4] = new Thread(() => { results5 = CardTestMulti(4, 6); });
//            workers[5] = new Thread(() => { results6 = CardTestMulti(6, 8); });
//            workers[6] = new Thread(() => { results7 = CardTestMulti(8, 12); });
//            workers[7] = new Thread(() => { results8 = CardTestMulti(12, 52); });

//            for (int i = 0; i < NumberOfThreads; i++) {
//                workers[i].Start();
//                Thread.Sleep(100);
//            }

//            for (int i = 0; i < NumberOfThreads; i++) {
//                workers[i].Join();
//                Thread.Sleep(100);
//            }

//            //for (int i = 0; i < 11; i++) {
//            //    Console.WriteLine("result1 " + results1[i]); 
//            //}

//            //for (int i = 0; i < 11; i++) {
//            //    Console.WriteLine("result2 " + results2[i]);
//            //}

//            for (int i = 0; i < 11; i++) {
//                Final[i] += results1[i];
//                Final[i] += results2[i];
//                Final[i] += results3[i];
//                Final[i] += results4[i];
//                Final[i] += results5[i];
//                Final[i] += results6[i];
//                Final[i] += results7[i];
//                Final[i] += results8[i];
//            }
//            //Console.WriteLine("tæller1: " + results1[10]);
//            //Console.WriteLine("tæller2: " + results2[10]);
//            //Console.WriteLine("tæller3: " + results3[10]);
//            //Console.WriteLine("tæller4: " + results4[10]);
//            //Console.WriteLine("tæller5: " + results5[10]);
//            //Console.WriteLine("tæller6: " + results6[10]);
//            //Console.WriteLine("tæller7: " + results7[10]);
//            //Console.WriteLine("tæller8: " + results8[10]);


//            PrintFile.Add("Tid: " + Final[9]);
//            PrintFile.Add("TÆLLER: " + Final[10]);
//            PrintFile.Add("royalflush: " + Final[0]);
//            PrintFile.Add("straightflush: " + Final[1]);
//            PrintFile.Add("four: " + Final[2]);
//            PrintFile.Add("fullhouse: " + Final[3]);
//            PrintFile.Add("flush: " + Final[4]);
//            PrintFile.Add("straight: " + Final[5]);
//            PrintFile.Add("three: " + Final[6]);
//            PrintFile.Add("twopair: " + Final[7]);
//            PrintFile.Add("pair: " + Final[8]);

//            File.WriteAllLines(path, PrintFile);

//            Console.WriteLine("Time: " + Final[9]);
//            Console.WriteLine("Counter: " + Final[10]);
//            Console.WriteLine("royalflush: " + Final[0]);
//            Console.WriteLine("straightflush: " + Final[1]);
//            Console.WriteLine("four: " + Final[2]);
//            Console.WriteLine("fullhouse: " + Final[3]);
//            Console.WriteLine("flush: " + Final[4]);
//            Console.WriteLine("straight: " + Final[5]);
//            Console.WriteLine("three: " + Final[6]);
//            Console.WriteLine("twopair: " + Final[7]);
//            Console.WriteLine("pair: " + Final[8]);
//            Console.WriteLine("Done!");
//            Console.ReadKey();
//        }

//            static long[] CardTestMulti(int FirstIndex, int SecoundIndex) {
//            Stopwatch stopWatch = new Stopwatch();
//            int NumberOfCards = 52, counter = 0;
//            List<Player> players = new List<Player>() { new Player(0, 1000), new Player(1, 1000) };
//            WinConditions w = new WinConditions();
//            Hand h = new Hand(players, 1);
//            long[] WinConValues = new long[11]; 
//            for (int i = FirstIndex; i < SecoundIndex; i++) {
//                for (int j = i + 1; j < NumberOfCards; j++) {
//                    for (int k = j + 1; k < NumberOfCards; k++) {
//                        for (int l = k + 1; l < NumberOfCards; l++) {
//                            for (int m = l + 1; m < NumberOfCards; m++) {
//                                for (int n = m + 1; n < NumberOfCards; n++) {
//                                    for (int o = n + 1; o < NumberOfCards; o++) {
//                                        h.Deck.Clear();

//                                        h.Deck.Add(new Card(i));
//                                        h.Deck.Add(new Card(j));
//                                        h.Deck.Add(new Card(k));
//                                        h.Deck.Add(new Card(l));
//                                        h.Deck.Add(new Card(m));
//                                        h.Deck.Add(new Card(n));
//                                        h.Deck.Add(new Card(o));

//                                        h.Deck.Sort();
//                                        counter++;

//                                        if (w.HasRoyalFlush(h.Deck)) {
//                                            WinConValues[0]++;
//                                        } else if (w.HasStraightFlush(h.Deck)) {
//                                            WinConValues[1]++;
//                                        } else if (w.HasFourOfAKind(h.Deck)) {
//                                            WinConValues[2]++;
//                                        } else if (w.HasFullHouse(h.Deck)) {
//                                            WinConValues[3]++;
//                                        } else if (w.HasFlush(h.Deck)) {
//                                            WinConValues[4]++;
//                                        } else if (w.HasStraight(h.Deck)) {
//                                            WinConValues[5]++;
//                                        } else if (w.HasThreeOfAKind(h.Deck)) {
//                                            WinConValues[6]++;
//                                        } else if (w.HasTwoPairs(h.Deck)) {
//                                            WinConValues[7]++;
//                                        } else if (w.HasPair(h.Deck)) {
//                                            WinConValues[8]++;
//                                        }
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            WinConValues[9] = stopWatch.ElapsedMilliseconds;
//            stopWatch.Stop();
//            WinConValues[10] = counter;
//            return WinConValues;
//        }
//    }
//}
