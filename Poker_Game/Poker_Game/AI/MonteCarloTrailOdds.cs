using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Poker_Game.AI
{
    class MonteCarloTrailOdds
    {
        Random rndNr = new Random();
        private List<Card> aiHand, street, deck;
        int x;

        public MonteCarloTrailOdds(List<Card> Hand, List<Card> Street)
        {
            aiHand = Hand;
            street = Street;

            for(x = 0; x < 52; x++)
            {
                deck.Add(new Card(x));
            }
        }

        public double RunTrails(int NumberOfTrails)
        {
            int x, n, missingCardsOnStreet = 5 - street.Count, wins = 0, loses = 0, draws = 0;
            WinConditions winCalc = new WinConditions();
            Card NewCard = new Card(0);
            List<Card> trailStreet, opponantTrailCards = new List<Card>(), CardsInPlay, aiTrailCards;

            for (x = 0; x < NumberOfTrails; x++)
            {
                trailStreet = street;
                CardsInPlay = street.Concat(aiHand).ToList();

                for (n = 0; n < missingCardsOnStreet; n++)
                {
                    NewCard.DrawCards(CardsInPlay);
                    CardsInPlay.Add(NewCard);
                    trailStreet.Add(NewCard);
                }

                aiTrailCards = aiHand.Concat(trailStreet).ToList();
                opponantTrailCards = trailStreet;

                for (n = 0; n < 2; n++)
                {
                    NewCard.DrawCards(CardsInPlay);
                    CardsInPlay.Add(NewCard);
                    opponantTrailCards.Add(NewCard);
                }

                if (winCalc.Evaluate(opponantTrailCards) > winCalc.Evaluate(aiTrailCards))
                {
                    loses++;
                }
                else if (winCalc.Evaluate(opponantTrailCards) > winCalc.Evaluate(aiTrailCards))
                {
                    wins++;
                }
                else
                {
                    draws++;
                }
            }

            return wins / NumberOfTrails * 100;
        }
    } 
}
