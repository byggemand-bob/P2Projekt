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
        const int NUMOFTHREADS = 4;

        public MonteCarloTrailOdds(List<Card> Hand, List<Card> Street)
        {
            aiHand = Hand;
            street = Street;
        }

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

                result = winCalc.WhoWinsV3(aiTrailCards, opponantTrailCards);

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

        public Odds MultiThreadMonteCarlo (int NumberOfTrails)
        {
            int x;
            Odds[] trailResults = new Odds[NUMOFTHREADS];
            Odds totalResults = new Odds(0, 0, 0);
            Thread[] workers = new Thread[NUMOFTHREADS];

            for(x = 0; x < NUMOFTHREADS; x++)
            {
                workers[x] = new Thread(() => { trailResults[x] = RunTrails(NumberOfTrails / 4); });
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

        public Odds TestMultiThreadMonteCarlo(int NumberOfTrails)
        {
            int x;
            Odds[] trailResults = new Odds[NUMOFTHREADS];
            Odds totalResults = new Odds(0, 0, 0);
            Thread[] workers = new Thread[NUMOFTHREADS];

            for (x = 0; x < NUMOFTHREADS; x++)
            {
                workers[x] = new Thread(() => { trailResults[x] = TestRunTrails(NumberOfTrails / NUMOFTHREADS); });
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
