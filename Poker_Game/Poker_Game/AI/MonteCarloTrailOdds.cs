using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Poker_Game.Game;

namespace Poker_Game.AI
{
    class MonteCarloTrailOdds
    {
        Random rndNr = new Random();
        private List<Card> aiHand, street;
        public int wins = 0, loses = 0, draws = 0;
        int NUMOFTHREADS = System.Environment.ProcessorCount;
        const int TotalNumberOfTrails = 250000;
        

        

        public struct Odds
        {
            public double WinOdds, LoseOdds, DrawOdds;

            public Odds(double winOdds, double loseOdds, double drawOdds)
            {
                WinOdds = winOdds;
                LoseOdds = loseOdds;
                DrawOdds = drawOdds;
            }

            public void Add(Odds AddX)
            {
                WinOdds += AddX.WinOdds;
                LoseOdds += AddX.LoseOdds;
                DrawOdds += AddX.DrawOdds;
            }

            public void DevideAllBy(double DevideBy)
            {
                WinOdds /= DevideBy;
                LoseOdds /= DevideBy;
                DrawOdds /= DevideBy;
            }
        }

        public Odds RunTrails(int NumberOfTrails)
        {
            int x, n, missingCardsOnStreet = 5 - street.Count;
            int wins = 0, loses = 0, draws = 0, result;
            FastWinCalc winCalc = new FastWinCalc();
            Card NewCard = new Card(0);
            List<Card> trailStreet = new List<Card>(), opponantTrailCards = new List<Card>(), CardsInPlay, aiTrailCards;

            for (x = 0; x < NumberOfTrails; x++)
            {
                trailStreet = new List<Card>(street);
                CardsInPlay = street.Concat(aiHand).ToList();

                for (n = 0; n < missingCardsOnStreet; n++)
                {
                    NewCard = new Card(CardsInPlay);
                    CardsInPlay.Add(NewCard);
                    trailStreet.Add(NewCard);
                }

                aiTrailCards = aiHand.Concat(trailStreet).ToList();
                opponantTrailCards = trailStreet;
                
                for (n = 0; n < 2; n++)
                {
                    NewCard = new Card(CardsInPlay);
                    CardsInPlay.Add(NewCard);
                    opponantTrailCards.Add(NewCard);
                }

                //forced to add to opponent hand
                //opponantTrailCards.Add(new Card(Suit.Diamonds, Rank.King));
                //opponantTrailCards.Add(new Card(Suit.Diamonds, Rank.Ace));

                result = winCalc.WhoWins(aiTrailCards, opponantTrailCards);

                if (result == 1)
                {
                    loses++;
                }
                else if (result == -1)
                {
                    wins++;
                }
                else
                {
                    draws++;
                }

                CardsInPlay.Clear();
                opponantTrailCards.Clear();
                aiTrailCards.Clear();
            }

            Odds Results = new Odds((double)wins / (double)NumberOfTrails * 100,
                                    (double)loses / (double)NumberOfTrails * 100,
                                    (double)draws / (double)NumberOfTrails * 100);

            PrintResults(Results);

            return Results;
        }

        public Odds RunTrails(int NumberOfTrails, List<List<Card>> Range)
        {
            int x, n, missingCardsOnStreet = 5 - street.Count;
            int wins = 0, loses = 0, draws = 0, result;
            FastWinCalc winCalc = new FastWinCalc();
            Card NewCard = new Card(0);
            List<Card> trailStreet = new List<Card>(), opponantTrailCards = new List<Card>(), CardsInPlay, aiTrailCards;
            int RangeSize;

            RangeSize = Range.Count();

            for (x = 0; x < NumberOfTrails; x++)
            {
                trailStreet = new List<Card>(street);
                CardsInPlay = street.Concat(aiHand).ToList();

                for (n = 0; n < missingCardsOnStreet; n++)
                {
                    NewCard = new Card(CardsInPlay);
                    CardsInPlay.Add(NewCard);
                    trailStreet.Add(NewCard);
                }

                aiTrailCards = aiHand.Concat(trailStreet).ToList();
                opponantTrailCards = trailStreet;

                if (RangeSize > 1)
                {
                    x = rndNr.Next(RangeSize);

                    opponantTrailCards.Add(Range[x][0]);
                    opponantTrailCards.Add(Range[x][1]);
                }
                else
                {
                    opponantTrailCards.Add(Range[0][0]);
                    opponantTrailCards.Add(Range[0][1]);
                }


                result = winCalc.WhoWins(aiTrailCards, opponantTrailCards);

                if (result == 1)
                {
                    loses++;
                }
                else if (result == -1)
                {
                    wins++;
                }
                else
                {
                    draws++;
                }

                CardsInPlay.Clear();
                opponantTrailCards.Clear();
                aiTrailCards.Clear();
            }

            Odds Results = new Odds((double)wins / (double)NumberOfTrails * 100,
                                    (double)loses / (double)NumberOfTrails * 100,
                                    (double)draws / (double)NumberOfTrails * 100);

            PrintResults(Results);

            return Results;
        }

        public Odds TestRunTrails(int NumberOfTrails)
        {
            int x, n, missingCardsOnStreet = 5 - street.Count;
            int wins = 0, loses = 0, draws = 0, result;
            WinConditions winCalc = new WinConditions();
            Card NewCard = new Card(0);
            List<Card> trailStreet = new List<Card>(), opponantTrailCards = new List<Card>(), CardsInPlay, aiTrailCards;
            List<Player> players = new List<Player>() { new Player(0, 1000), new Player(1, 1000) };
            for (x = 0; x < NumberOfTrails; x++)
            {
                trailStreet = new List<Card>(street);
                CardsInPlay = street.Concat(aiHand).ToList();

                for (n = 0; n < missingCardsOnStreet; n++)
                {
                    NewCard = new Card(CardsInPlay);
                    CardsInPlay.Add(NewCard);
                    trailStreet.Add(NewCard);
                }

                aiTrailCards = aiHand.Concat(trailStreet).ToList();
                opponantTrailCards = trailStreet;
                
                /*
                for (n = 0; n < 2; n++)
                {
                    NewCard = new Card(CardsInPlay);
                    CardsInPlay.Add(NewCard);
                    opponantTrailCards.Add(NewCard);
                }
                */


                //forced to add to opponent hand
                opponantTrailCards.Add(new Card(Suit.Diamonds, Rank.King));
                opponantTrailCards.Add(new Card(Suit.Diamonds, Rank.Ace));
                players[0].Cards = opponantTrailCards;
                players[1].Cards = aiTrailCards;
                players[0].Cards.Sort();
                players[1].Cards.Sort();
                players[0].Score = winCalc.Evaluate(players[0].Cards);
                players[1].Score = winCalc.Evaluate(players[1].Cards);
                
                if (players[0].Score > players[1].Score)
                {
                    loses++;
                }
                else if (players[0].Score < players[1].Score)
                {
                    wins++;
                } else {
                    if (winCalc.SameScore(players[0], players[1]) == null) {
                        draws++;
                    } else if (winCalc.SameScore(players[0], players[1]).Id == 1) {
                        wins++;
                    } else {
                        loses++;
                    }
                }

                CardsInPlay.Clear();
                opponantTrailCards.Clear();
                aiTrailCards.Clear();
            }

            Odds Results = new Odds((double)wins / (double)NumberOfTrails * 100,
                                    (double)loses / (double)NumberOfTrails * 100,
                                    (double)draws / (double)NumberOfTrails * 100);

            PrintResults(Results);

            return Results;
        }

        public Odds MultiThreadMonteCarlo (List<Card> Hand, List<Card> Street)
        {
            int x;
            Odds[] trailResults = new Odds[NUMOFTHREADS];
            Odds totalResults = new Odds(0, 0, 0);
            Thread[] workers = new Thread[NUMOFTHREADS];

            aiHand = Hand;
            street = Street;

            for(x = 0; x < NUMOFTHREADS; x++)
            {
                workers[x] = new Thread(() => { trailResults[x] = RunTrails(TotalNumberOfTrails / NUMOFTHREADS); });
                workers[x].Start();
                Thread.Sleep(100);
            }

            for (x = 0; x < NUMOFTHREADS; x++)
            {
                workers[x].Join();
                totalResults.Add(trailResults[x]);
            }

            totalResults.DevideAllBy(NUMOFTHREADS);

            Console.Write("\nTotal Results: ");
            PrintResults(totalResults);

            return totalResults;
        }

        public Odds MultiThreadMonteCarlo(List<Card> Hand, List<Card> Street, List<List<Card>> Range)
        {
            int x;
            Odds[] trailResults = new Odds[NUMOFTHREADS];
            Odds totalResults = new Odds(0, 0, 0);
            Thread[] workers = new Thread[NUMOFTHREADS];

            aiHand = Hand;
            street = Street;

            for (x = 0; x < NUMOFTHREADS; x++)
            {
                workers[x] = new Thread(() => { trailResults[x] = RunTrails(TotalNumberOfTrails / NUMOFTHREADS, Range); });
                workers[x].Start();
                Thread.Sleep(100);
            }

            for (x = 0; x < NUMOFTHREADS; x++)
            {
                workers[x].Join();
                totalResults.Add(trailResults[x]);
            }

            totalResults.DevideAllBy(NUMOFTHREADS);

            Console.Write("\nTotal Results: ");
            PrintResults(totalResults);

            return totalResults;
        }

        public Odds TestMultiThreadMonteCarlo(List<Card> Hand, List<Card> Street)
        {
            int x;
            Odds[] trailResults = new Odds[NUMOFTHREADS];
            Odds totalResults = new Odds(0, 0, 0);
            Thread[] workers = new Thread[NUMOFTHREADS];

            aiHand = Hand;
            street = Street;

            for (x = 0; x < NUMOFTHREADS; x++)
            {
                workers[x] = new Thread(() => { trailResults[x] = TestRunTrails(TotalNumberOfTrails / NUMOFTHREADS); });
                workers[x].Start();
                Thread.Sleep(100);
            }

            for (x = 0; x < NUMOFTHREADS; x++)
            {
                workers[x].Join();
                totalResults.Add(trailResults[x]);
            }

            totalResults.DevideAllBy(NUMOFTHREADS);

            Console.Write("\nTotal Results:  ");
            PrintResults(totalResults);

            return totalResults;
        }

        public void PrintResults(Odds results)
        {
            Console.WriteLine("wins: {0:0.00}%, loses; {1:0.00}%, draws: {2:0.00}%", results.WinOdds, results.LoseOdds, results.DrawOdds);
        }
    } 
}
