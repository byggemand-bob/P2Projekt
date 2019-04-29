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
        private int i, n, x, deckSize, combinedHandStreetCount, result;
        private Card testCard1, testCard2;

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

        /* Old attempt
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
            int numberOfSameRanksInPlay, numberOfSameCardsOnStreet, numberOfCardsInDeck;
            ulong outcomes;

            numberOfSameRanksInPlay = 4 - NumberOfSameCardranksInList(hand, CardRank);
            numberOfSameCardsOnStreet = NumberOfSameCardranksInList(street, CardRank);
            numberOfCardsInDeck = deckSize;

            if (numberOfSameCardsOnStreet > 1)
            {
                throw new Exception("Already 2 of a kind on street");
            }
            
            outcomes = (ulong) numberOfSameRanksInPlay * (ulong)(numberOfSameRanksInPlay - 1);
            deckSize -= numberOfSameRanksInPlay;

            for (n = street.Count; n < 5; n++)
            {
                outcomes *= (ulong) deckSize;
                deckSize--;
            }

            outcomes /= (ulong) (7 - street.Count) * (ulong) (6 - street.Count) / 2;

            result = x;

            Console.WriteLine("{0}", outcomes);

            result -= FlushPossibilities();
            result -= StraightPossibilities();
            result -= PossibilitiesWhereYouStillWin();

            return result;
        }

        public int StraightPossibilities()
        {
            return 0;
        }

        public int PossibilitiesWhereYouStillWin()
        {
            return 0;
        }

        public int FlushPossibilities()
        {
            return 0;
        }
        end of Old Attempt section*/

        public int TotalOdds()
        {
            int totalWinScenarios = 0;

            for (x = 0; x < 52; x++)
            {
                for(i = 0; i < 52; i++)
                {
                    if(i == x)
                    {
                        i++;
                    }
                    testCard1.MakeCard(x);
                    testCard2.MakeCard(i);

                    totalWinScenarios += OddsAgainst(testCard1, testCard2);
                }
            }

            return 0;
        }

        public int OddsAgainst(Card OppanantCard1, Card OppanantCard2)
        {
            if(street.Count == 0)
            {
                return OddsAgainstPreFlop(OppanantCard1, OppanantCard2);
            }
            if (street.Count == 3)
            {
                return OddsAgainstPostFlop(OppanantCard1, OppanantCard2);
            }
            if (street.Count == 4)
            {
                return OddsAgainstDuringRiver(OppanantCard1, OppanantCard2);
            }

            return 0;
        }

        private int OddsAgainstPreFlop(Card OppanantCard1, Card OppanantCard2)
        {
            bool isAiWinning;

            isAiWinning = IsAiWinning(OppanantCard1, OppanantCard2);

            if (isAiWinning)
            {

            }

            else
            {

            }

            return 0;
        }

        private int OddsAgainstPostFlop(Card OppanantCard1, Card OppanantCard2)
        {
            return 0;
        }

        private int OddsAgainstDuringRiver(Card OppanantCard1, Card OppanantCard2)
        {
            return 0;
        }

        private bool IsAiWinning(Card OppanantCard1, Card OppanantCard2)
        {
            return false;
        }
    }
}
