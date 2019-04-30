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
        private int deckSize, combinedHandStreetCount, result;
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

        public string PutDot(double inputNumber)
        {
          string outputNumber;

          outputNumber = inputNumber.ToString("#,##0.00");

          return outputNumber;
        }

        private int TotalNumberOfOutcomesCalc(int StreetSize)
        {
            int devideBy = 1, n, i;

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
            int x, i;
            long totalWinScenarios = 0;

            for (x = 0; x < 52; x++)
            {
                testCard1.MakeCard(x);

                while(testCard1 == hand[0] || testCard1 == hand[1])
                {
                    x++;
                    testCard1.MakeCard(x);
                }

                for (i = x + 1; i < 52; i++)
                {
                    testCard2.MakeCard(i);

                    while (testCard2 == hand[0] || testCard2 == hand[1])
                    {
                        i++;
                        testCard2.MakeCard(i);
                    }

                    totalWinScenarios += (long) OddsAgainst(testCard1, testCard2);

                    Console.WriteLine("{0}", PutDot(totalWinScenarios));
                }
            }

            if(street.Count == 0)
            {
                return (double) totalWinScenarios / (double) 2097572400;
            }

            return 0;
        }

        public int OddsAgainst(Card OpponentCard1, Card OpponentCard2)
        {
            if(street.Count == 0)
            {
                return OddsAgainstPreFlop(OpponentCard1, OpponentCard2);
            }
            if (street.Count == 3)
            {
                return OddsAgainstPostFlop(OpponentCard1, OpponentCard2);
            }
            if (street.Count == 4)
            {
                return OddsAgainstDuringRiver(OpponentCard1, OpponentCard2);
            }

            return 0;
        }

        private int OddsAgainstPreFlop(Card OpponentCard1, Card OpponentCard2)
        //all numbers are incorrect!!! they only calculate the odds for the loser to draw a matching card to one in its hand
        {
            int sharedCards;

            //1.712.304 combinations of outcomes if both player an ai has a specefic set of cards.
            //1.225 number of 2 card combinations from a deck of 50 cards
            //1.712.304 x 1225 = 2.097.572.400

            //1.086.088 outcomes where the opponant doesn't draw an additional matching card

            if (IsAiWinning(OpponentCard1, OpponentCard2) == 1)
            {
                sharedCards = NumberOfSharedRanksInHandsForOpponant(OpponentCard1, OpponentCard2);

                //checks if the opponant has cards with ranks matching the ai's cards
                if (sharedCards > 0)
                {
                    //checks if the opponant has a pocket pair
                    if (OpponentCard1.Rank == OpponentCard2.Rank)
                    {
                        if(sharedCards == 5)
                        {
                            return 1712304;
                        }
                        else if(sharedCards == 3)
                        {
                            return 1533939;
                        }
                        return 1370754;
                    }

                    if(sharedCards == 1)
                    {
                        return 962598;
                    }
                    else if(sharedCards == 2)
                    {
                        return 1086008;
                    }
                }

                return 850668;
            }

            else if(IsAiWinning(OpponentCard1, OpponentCard2) == -1)
            {
                sharedCards = NumberOfSharedRanksInHandsForAi(OpponentCard1, OpponentCard2);

                if (sharedCards > 0)
                {
                    if (hand[0].Rank == hand[1].Rank)
                    {
                        if (sharedCards == 5)
                        {
                            return 0;
                        }
                        else if (sharedCards == 3)
                        {
                            return 178365;
                        }
                        return 341550;
                    }

                    if (sharedCards == 1)
                    {
                        return 749706;
                    }
                    else if (sharedCards == 2)
                    {
                        return 626296;
                    }
                }

                return 861630;
            }

            //placeholder number
            return 856152;
        }

        private int NumberOfSharedRanksInHandsForOpponant(Card OpponentCard1, Card OpponentCard2)
        {
            int x;

            x = 0;

            if (OpponentCard1.Rank == OpponentCard2.Rank)
                x++;

            if (OpponentCard1.Rank == hand[0].Rank)
                x++;

            if (OpponentCard1.Rank == hand[1].Rank)
                x++;

            if (OpponentCard2.Rank == hand[0].Rank)
                x++;

            if (OpponentCard2.Rank == hand[1].Rank)
                x++;

            return x;
        }

        private int NumberOfSharedRanksInHandsForAi(Card OpponentCard1, Card OpponentCard2)
        {
            int x;

            x = 0;

            if (hand[0].Rank == hand[1].Rank)
                x++;

            if (OpponentCard1.Rank == hand[0].Rank)
                x++;

            if (OpponentCard1.Rank == hand[1].Rank)
                x++;

            if (OpponentCard2.Rank == hand[0].Rank)
                x++;

            if (OpponentCard2.Rank == hand[1].Rank)
                x++;

            return x;
        }

        private int OddsAgainstPostFlop(Card OpponentCard1, Card OpponentCard2)
        {
            return 0;
        }

        private int OddsAgainstDuringRiver(Card OpponentCard1, Card OpponentCard2)
        {
            return 0;
        }

        private int IsAiWinning(Card OpponentCard1, Card OpponentCard2)
        //return -1 if false, 1 if true and return 0 if they are even
        {
            //bool AiWinning;

            //if the street is currently empty
            if (street.Count == 0)
            {
                //checks if the opponant or ai has a pocket pair, and if both does returns the one with the highs ranked pair
                if (OpponentCard1.Rank == OpponentCard2.Rank)
                {
                    if(hand[0].Rank == hand[1].Rank)
                    {
                        if(hand[0].Rank < OpponentCard1.Rank)
                        {
                            return -1;
                        }
                        return 1;
                    }
                    return -1;
                }

                if (hand[0].Rank == hand[1].Rank)
                {
                    return 1;
                }

                if(hand[0].Rank < hand[1].Rank)
                {
                    if(hand[1].Rank < OpponentCard1.Rank || hand[1].Rank < OpponentCard2.Rank)
                    {
                        return -1;
                    }
                    else if(hand[1].Rank > OpponentCard1.Rank || hand[1].Rank > OpponentCard2.Rank)
                    {
                        return 1;
                    }
                    return 0;
                }

                if (hand[0].Rank < OpponentCard1.Rank || hand[0].Rank < OpponentCard2.Rank)
                {
                    return -1;
                }
                else if (hand[0].Rank > OpponentCard1.Rank || hand[0].Rank > OpponentCard2.Rank)
                {
                    return 1;
                }
                return 0;
            }

            return 0;
        }
    }
}
