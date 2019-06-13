using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Poker_Game.Game;

namespace Poker_Game.AI {
    internal class MonteCarloTrialOdds {
        private const int TotalNumberOfTrials = 10000;

        private readonly int _numberOfThreads = Environment.ProcessorCount;
        private readonly Random _rndNr = new Random();
        private List<Card> _aiHand, _street;
        public int Wins = 0, Loses = 0, Draws = 0;

        public Odds RunTrials(int numberOfTrials) {
            int x;
            int missingCardsOnStreet = 5 - _street.Count;
            int wins = 0, loses = 0, draws = 0;
            FastWinCalc winCalc = new FastWinCalc();

            for(x = 0; x < numberOfTrials; x++) {
                List<Card> trialStreet = new List<Card>(_street);
                List<Card> cardsInPlay = _street.Concat(_aiHand).ToList();

                Card newCard;
                int n;
                for(n = 0; n < missingCardsOnStreet; n++) {
                    newCard = new Card(cardsInPlay);
                    cardsInPlay.Add(newCard);
                    trialStreet.Add(newCard);
                }

                List<Card> aiTrialCards = _aiHand.Concat(trialStreet).ToList();
                List<Card> opponentTrialCards = trialStreet;

                for(n = 0; n < 2; n++) {
                    newCard = new Card(cardsInPlay);
                    cardsInPlay.Add(newCard);
                    opponentTrialCards.Add(newCard);
                }

                int result = winCalc.WhoWins(aiTrialCards, opponentTrialCards);

                if(result == 1)
                    loses++;
                else if(result == -1)
                    wins++;
                else
                    draws++;

                cardsInPlay.Clear();
                opponentTrialCards.Clear();
                aiTrialCards.Clear();
            }

            Odds results = new Odds(wins / (double) numberOfTrials * 100,
                loses / (double) numberOfTrials * 100,
                draws / (double) numberOfTrials * 100);

            Console.WriteLine("Wins: {0} , Loses: {1} , Draws: {2}", wins, loses, draws);
            PrintResults(results);
            Console.WriteLine("");

            return results;
        }

        public Odds RunTrials(int numberOfTrials, List<List<Card>> range) {
            int x, n, missingCardsOnStreet = 5 - _street.Count;
            int wins = 0, loses = 0, draws = 0, result;
            FastWinCalc winCalc = new FastWinCalc();

            int rangeSize = range.Count;

            for(x = 0; x < numberOfTrials; x++) {
                List<Card> trialStreet = new List<Card>(_street);
                List<Card> cardsInPlay = _street.Concat(_aiHand).ToList();

                for(n = 0; n < missingCardsOnStreet; n++) {
                    Card newCard = new Card(cardsInPlay);
                    cardsInPlay.Add(newCard);
                    trialStreet.Add(newCard);
                }

                List<Card> aiTrialCards = _aiHand.Concat(trialStreet).ToList();
                List<Card> opponentTrialCards = trialStreet;

                if(rangeSize > 1) {
                    x = _rndNr.Next(rangeSize);

                    opponentTrialCards.Add(range[x][0]);
                    opponentTrialCards.Add(range[x][1]);
                } else {
                    opponentTrialCards.Add(range[0][0]);
                    opponentTrialCards.Add(range[0][1]);
                }


                result = winCalc.WhoWins(aiTrialCards, opponentTrialCards);

                if(result == 1)
                    loses++;
                else if(result == -1)
                    wins++;
                else
                    draws++;

                cardsInPlay.Clear();
                opponentTrialCards.Clear();
                aiTrialCards.Clear();
            }

            Odds results = new Odds(wins / (double) numberOfTrials * 100,
                loses / (double) numberOfTrials * 100,
                draws / (double) numberOfTrials * 100);

            PrintResults(results);

            return results;
        }

        public Odds TestRunTrials(int numberOfTrials) {
            int x, n, missingCardsOnStreet = 5 - _street.Count;
            int wins = 0, loses = 0, draws = 0;
            WinConditions winCalc = new WinConditions();
            List<Player> players = new List<Player> {new Player(0, 1000), new Player(1, 1000)};
            for(x = 0; x < numberOfTrials; x++) {
                List<Card> trialStreet = new List<Card>(_street);
                List<Card> cardsInPlay = _street.Concat(_aiHand).ToList();

                for(n = 0; n < missingCardsOnStreet; n++) {
                    Card newCard = new Card(cardsInPlay);
                    cardsInPlay.Add(newCard);
                    trialStreet.Add(newCard);
                }

                List<Card> aiTrialCards = _aiHand.Concat(trialStreet).ToList();
                List<Card> opponentTrialCards = trialStreet;

                //forced to add to opponent hand
                opponentTrialCards.Add(new Card(Suit.Diamonds, Rank.King));
                opponentTrialCards.Add(new Card(Suit.Diamonds, Rank.Ace));
                players[0].Cards = opponentTrialCards;
                players[1].Cards = aiTrialCards;
                players[0].Cards.Sort();
                players[1].Cards.Sort();
                players[0].Score = winCalc.Evaluate(players[0].Cards);
                players[1].Score = winCalc.Evaluate(players[1].Cards);
                winCalc.GiveScoreHand(players[0]);
                winCalc.GiveScoreHand(players[1]);

                if(players[0].Score > players[1].Score) {
                    loses++;
                } else if(players[0].Score < players[1].Score) {
                    wins++;
                } else {
                    if(winCalc.WhoWins(players[0], players[1]) == null)
                        draws++;
                    else if(winCalc.WhoWins(players[0], players[1]).Id == 1)
                        wins++;
                    else
                        loses++;
                }

                cardsInPlay.Clear();
                opponentTrialCards.Clear();
                aiTrialCards.Clear();
            }

            Odds results = new Odds(wins / (double) numberOfTrials * 100,
                loses / (double) numberOfTrials * 100,
                draws / (double) numberOfTrials * 100);

            Console.WriteLine("Wins: {0} , Loses: {1} , Draws: {2}", wins, loses, draws);
            PrintResults(results);
            Console.WriteLine("");

            return results;
        }

        public Odds MultiThreadMonteCarlo(List<Card> hand, List<Card> street) {
            int x;
            Odds[] trialResults = new Odds[_numberOfThreads];
            Odds totalResults = new Odds(0, 0, 0);
            Thread[] workers = new Thread[_numberOfThreads];

            _aiHand = hand;
            _street = street;

            for(x = 0; x < _numberOfThreads; x++) {
                workers[x] = new Thread(() => { trialResults[x] = RunTrials(TotalNumberOfTrials / _numberOfThreads); });
                workers[x].Start();
                Thread.Sleep(100);
            }

            for(x = 0; x < _numberOfThreads; x++) {
                workers[x].Join();
                totalResults.Add(trialResults[x]);
            }

            totalResults.DivideAllBy(_numberOfThreads);

            Console.Write("\nTotal Results: ");
            PrintResults(totalResults);

            return totalResults;
        }

        public Odds MultiThreadMonteCarlo(List<Card> hand, List<Card> street, List<List<Card>> range) {
            int x;
            Odds[] trialResults = new Odds[_numberOfThreads];
            Odds totalResults = new Odds(0, 0, 0);
            Thread[] workers = new Thread[_numberOfThreads];

            _aiHand = hand;
            _street = street;

            for(x = 0; x < _numberOfThreads; x++) {
                workers[x] = new Thread(() => {
                    trialResults[x] = RunTrials(TotalNumberOfTrials / _numberOfThreads, range);
                });
                workers[x].Start();
                Thread.Sleep(100);
            }

            for(x = 0; x < _numberOfThreads; x++) {
                workers[x].Join();
                totalResults.Add(trialResults[x]);
            }

            totalResults.DivideAllBy(_numberOfThreads);

            Console.Write("\nTotal Results: ");
            PrintResults(totalResults);

            return totalResults;
        }

        public Odds TestMultiThreadMonteCarlo(List<Card> hand, List<Card> street) {
            int x;
            Odds[] trialResults = new Odds[_numberOfThreads];
            Odds totalResults = new Odds(0, 0, 0);
            Thread[] workers = new Thread[_numberOfThreads];

            _aiHand = hand;
            _street = street;

            for(x = 0; x < _numberOfThreads; x++) {
                workers[x] = new Thread(() => {
                    trialResults[x] = TestRunTrials(TotalNumberOfTrials / _numberOfThreads);
                });
                workers[x].Start();
                Thread.Sleep(100);
            }

            for(x = 0; x < _numberOfThreads; x++) {
                workers[x].Join();
                totalResults.Add(trialResults[x]);
            }

            totalResults.DivideAllBy(_numberOfThreads);

            Console.Write("\nTotal Results:  ");
            PrintResults(totalResults);

            return totalResults;
        }

        public void PrintResults(Odds results) {
            Console.WriteLine("wins: {0:0.00}%, loses; {1:0.00}%, draws: {2:0.00}%", results.WinOdds, results.LoseOdds,
                results.DrawOdds);
        }

        public struct Odds {
            public double WinOdds, LoseOdds, DrawOdds;

            public Odds(double winOdds, double loseOdds, double drawOdds) {
                WinOdds = winOdds;
                LoseOdds = loseOdds;
                DrawOdds = drawOdds;
            }

            public void Add(Odds addX) {
                WinOdds += addX.WinOdds;
                LoseOdds += addX.LoseOdds;
                DrawOdds += addX.DrawOdds;
            }

            public void DivideAllBy(double divideBy) {
                WinOdds /= divideBy;
                LoseOdds /= divideBy;
                DrawOdds /= divideBy;
            }
        }
    }
}