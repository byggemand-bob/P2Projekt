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
        private int result, i, n, deckSize, combinedHandStreetCount;

        public CardOdds(List<Card> Street, List<Card> Hand)
        {
            street = Street;
            hand = Hand;

            combinedHandStreetCount = street.Count + hand.Count;
            deckSize = 52 - combinedHandStreetCount;
            totalNumberOfOutcomes = TotalNumberOfOutcomescalc(street.Count);
        }

        private int TotalNumberOfOutcomescalc(int StreetSize)
        {
            int devideBy = 1;

            result = deckSize;

            for (i = 1; i < 5 - StreetSize; i++)
            {
                result *= deckSize - i; 
            }

            Console.WriteLine("{0}", i);

            for(n = 2; n <= i; n++)
            {
                devideBy *= n;
            }

            Console.WriteLine("{0}", n);

            result = result / devideBy;
            result *= ((deckSize - i) * (deckSize - i - 1)) / 2;

            return result;
        }

        private int NumberOfSameCardranksInList(List<Card> TestList, Rank TestCard)
        {
            int listsize;

            result = 0;
            listsize = TestList.Count();
            
            for(i = 0; i < listsize; i++)
            {
                if (TestList[i].Rank == TestCard)
                    result++;
            }

            return result;
        }

        public int OutcomeswhereOpponantsGetsTwoOfKind(Rank CardRank)
        {
            int numberOfSameCardsInPlay;

            numberOfSameCardsInPlay = NumberOfSameCardranksInList(street, CardRank);



            return result;
        }
    }
}
