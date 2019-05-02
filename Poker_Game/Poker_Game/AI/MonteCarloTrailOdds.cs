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

        public void RunTrails(int NumberOfTrails)
        {
            int x, n, missingCardsOnStreet = 5 - street.Count;
            WinConditions winCalc = new WinConditions();
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

                if (winCalc.Evaluate(opponantTrailCards) > winCalc.Evaluate(aiTrailCards))
                {
                    loses++;
                }
                else if (winCalc.Evaluate(opponantTrailCards) < winCalc.Evaluate(aiTrailCards))
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

            Console.WriteLine("wins: {0}, draws: {1}, loses: {2}", wins, draws, loses);
        }

        public double MultiThreadMonteCarlo (int NumberOfTrails)
        {
            int wins = 1, x;
            Thread[] workers = new Thread[NUMOFTHREADS];

            for(x = 0; x < NUMOFTHREADS; x++)
            {
                //workers[x] = new Thread();
            }

            return wins / NumberOfTrails * 100;
        }

        public double DrawResults()
        {
            return (double)draws / (double)(wins + draws + loses) * 100;
        }

        public double LoseResults()
        {
            return (double)loses / (double)(wins + draws + loses) * 100;
        }

        public double WinResults()
        {
            return (double)wins / (double)(wins + draws + loses) * 100;
        }

        public void PrintResults()
        {
            Console.WriteLine("total games: {0}, wins: {4}/{1:0.00}%, loses; {5}/{2:0.00}%, draws: {6}/{3:0.00}%", (wins + draws + loses), WinResults(), LoseResults(), DrawResults(), wins, loses, draws);
        }
    } 
}
