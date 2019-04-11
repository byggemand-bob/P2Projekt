using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.AI
{
    class CardOdds
    {
        public List<Card> street, hand;
        private Calculator calc = new Calculator();
        public ulong totalNumberOfOutcomes, combinedHandStreetCount, numberOfLoseingOutcomes;

        public CardOdds(List<Card> Street, List<Card> Hand)
        {
            street = Street;
            hand = Hand;

            combinedHandStreetCount = (ulong)street.Count + (ulong)hand.Count;
            totalNumberOfOutcomes = calc.Binomial(52 - combinedHandStreetCount, 7 - combinedHandStreetCount);
        }


    }
}
