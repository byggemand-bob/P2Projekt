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
        public int totalNumberOfOutcomes;
        private int result, i, n, x, deckSize, combinedHandStreetCount;

        public CardOdds(List<Card> Street, List<Card> Hand)
        {
            street = Street;
            hand = Hand;

            combinedHandStreetCount = street.Count + hand.Count;
            deckSize = 52 - combinedHandStreetCount;
            totalNumberOfOutcomes = TotalNumberOfOutcomesCalc(street.Count);
        }

        private int TotalNumberOfOutcomesCalc(int StreetSize)
        {
            int devideBy = 1;

            result = deckSize;

            for (i = 1; i < 5 - StreetSize; i++)
            {
                result *= deckSize - i; 
            }

            for(n = 2; n <= i; n++)
            {
                devideBy *= n;
            }

            result = result / devideBy;
            result *= ((deckSize - i) * (deckSize - i - 1)) / 2;

            return result;
        }

        private int NumberOfSameCardranksInList(List<Card> TestList, Rank TestRank)
        // Counts the number of cards with the rank = TestRank in TestList.
        {
            int listsize;

            result = 0;
            listsize = TestList.Count();
            
            for(i = 0; i < listsize; i++)
            {
                if (TestList[i].Rank == TestRank)
                    result++;
            }

            return result;
        }

        public int OutcomesWhereOpponantsGetsTwoOfKind(Rank CardRank)
        // Calculates number outcomes where opponant get to of a kind of CardRank, not including 3 or 4 of a kind
        {
            int numberOfSameCardsInHand, numberOfSameCardsOnStreet, numberOfCardsInDeck;

            numberOfSameCardsInHand = NumberOfSameCardranksInList(street, CardRank);
            numberOfSameCardsOnStreet = NumberOfSameCardranksInList(hand, CardRank);
            numberOfCardsInDeck = deckSize;

            if (numberOfSameCardsOnStreet > 1)
                throw new Exception("Already 2 of a kind on street");

            if (numberOfSameCardsInHand + numberOfSameCardsOnStreet > 1)
                result = totalNumberOfOutcomes;

            else if(numberOfSameCardsOnStreet + numberOfSameCardsInHand == 1)
            {
                x = 3 * 2;
                deckSize -= 3;
                for(n = street.Count; n <= 5; n++)
                {
                    x *= deckSize;
                    deckSize--;
                }
                result = x;
            }

            else
            {
                x = 4 * 3;
                deckSize -= 4;
                for (n = street.Count; n <= 5; n++)
                {
                    x *= deckSize;
                    deckSize--;
                }
                result = x;
            }
            

            result -= FlushPossibilities();
            result -= StraightPossibilities();
            result -= PossibilitiesWhereYouStillWin();

            return result;
        }

        public int StraightPossibilities()
        {
            return result;
        }

        public int PossibilitiesWhereYouStillWin()
        {
            return result;
        }

        public int FlushPossibilities()
        {
            return result;
        }
    }
}
