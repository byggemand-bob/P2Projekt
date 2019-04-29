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
        private Card testCard1 = new Card(Suit.Clubs, (Rank)2), testCard2 = new Card(Suit.Clubs, (Rank)3);
        
        public CardOdds(List<Card> Street, List<Card> Hand)
        {
            street = Street;
            hand = Hand;

            combinedHandStreetCount = street.Count + hand.Count;
            deckSize = 52 - combinedHandStreetCount;
            totalNumberOfOutcomes = TotalNumberOfOutcomesCalc(street.Count);

            //testCard1 = new Card(Suit.Clubs, (Rank)2);
            //testCard2 = new Card(Suit.Clubs, (Rank)3);
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

        public double TotalOdds()
        {
            long totalWinScenarios = 0;

            for (x = 0; x < 52; x++)
            {
                testCard1.MakeCard(x);

                while(testCard1 == hand[0] || testCard1 == hand[1])
                {
                    x++;
                    testCard1.MakeCard(x);
                }

                for (i = 0; i < 52; i++)
                {
                    if(i == x)
                    {
                        i++;
                    }

                    testCard2.MakeCard(i);

                    while (testCard2 == hand[0] || testCard2 == hand[1])
                    {
                        i++;
                        testCard2.MakeCard(i);
                    }

                    totalWinScenarios += (long) OddsAgainst(testCard1, testCard2);

                    Console.WriteLine("{0}", totalWinScenarios);
                }
            }

            if(street.Count == 0)
            {
                return totalWinScenarios / 503417376000; //returns 0 for some reason, possibly an overflow issue
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
            if (IsAiWinning(OppanantCard1, OppanantCard2))
            {
                //205.476.480 total outcomes if both player and ai has set cards
                //58.865.400 outcomes will draw a card of matching rank of one of the 2 in hand
                //117.730.800 for both.

                //not correct! 
                return 117730800;
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
            return true;
        }
    }
}
