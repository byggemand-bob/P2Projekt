using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.Game
{
    public class FastWinCalc
    {
        public struct WinnerResults
        {
            string winner, result;

            public WinnerResults(string WinnerName, string WinCondition)
            {
                winner = WinnerName;
                result = WinCondition;
            }
        }

        public struct evaluatedcards
        {
            public int[] cardsSummed;
            public bool hasFlush;
            public int nrOfHighestCard, valueOfHigestCard, nrOfSecoundHighestCard, ValueOfSecoundHeigestCard, highestCardInStraight;
            public Suit flushSuit;

            public evaluatedcards(List<Card> cards)
            {
                cardsSummed = new int[15];
                hasFlush = false;
                nrOfHighestCard = 0;
                valueOfHigestCard = 0;
                nrOfSecoundHighestCard = 0;
                nrOfSecoundHighestCard = 0;
                ValueOfSecoundHeigestCard = 0;
                highestCardInStraight = 0;
                flushSuit = (Suit) 0;

                EvaluationCalc(cards);
            }

            private void EvaluationCalc(List<Card> Cards)
            {
                int[] nrOfSuits = new int[4];
                int cardsInRow = 0;

                foreach(Card card in Cards)
                {
                    cardsSummed[(int)card.Rank]++;
                    nrOfSuits[(int)card.Suit]++;
                }

                for(int x = 0; x < 4; x++)
                {
                    if (nrOfSuits[x] >= 5)
                    {
                        hasFlush = true;
                        flushSuit = (Suit) x;
                    }
                }

                for(int x = 2; x < 15; x++)
                {
                    if(cardsSummed[x] > 0)
                    {
                        if(cardsSummed[x] >= nrOfHighestCard)
                        {
                            nrOfSecoundHighestCard = nrOfHighestCard;
                            ValueOfSecoundHeigestCard = valueOfHigestCard;
                            nrOfHighestCard = cardsSummed[x];
                            valueOfHigestCard = x;
                        }
                        else if(cardsSummed[x] >= nrOfSecoundHighestCard)
                        {
                            nrOfSecoundHighestCard = cardsSummed[x];
                            ValueOfSecoundHeigestCard = x;
                        }

                        cardsInRow++;
                        if(cardsInRow >= 5)
                        {
                            highestCardInStraight = x;
                        }
                    }
                    else
                    {
                        cardsInRow = 0;
                    }
                }
            }
        }

        public int WhoWins(List<Card> AiCards, List<Card> PlayerCards)
        //return -1 for ai win, 1 for player win, 0 for draw
        {
            evaluatedcards AiEvalCards = new evaluatedcards(AiCards), PlayerEvalCards = new evaluatedcards(PlayerCards);
            int aiHighestCardInStraightFlush = 0, playerHighestCardInStraightFlush = 0;

            //check for straight flush
            if (AiEvalCards.hasFlush)
            {
                if (PlayerEvalCards.hasFlush)
                {
                    //checks for straight flush
                    if (AiEvalCards.highestCardInStraight > 0)
                    {
                        hasStraightFlush(AiCards, aiHighestCardInStraightFlush);

                        if (aiHighestCardInStraightFlush > 0)
                        {
                            hasStraightFlush(PlayerCards, playerHighestCardInStraightFlush);

                            if (aiHighestCardInStraightFlush > playerHighestCardInStraightFlush)
                            {
                                return -1;
                            }
                            else if (playerHighestCardInStraightFlush > aiHighestCardInStraightFlush)
                            {
                                return 1;
                            }
                            else if(playerHighestCardInStraightFlush == aiHighestCardInStraightFlush)
                            {
                                return 0;
                            }
                        }
                    }

                    if (PlayerEvalCards.highestCardInStraight > 0)
                    {
                        hasStraightFlush(PlayerCards, playerHighestCardInStraightFlush);

                        if (playerHighestCardInStraightFlush > 0)
                        {
                            return 1;
                        }
                    }

                    //four of a kind checks
                    if(AiEvalCards.nrOfHighestCard == 4)
                    {
                        if (PlayerEvalCards.nrOfHighestCard == 4)
                        {
                            if (PlayerEvalCards.ValueOfSecoundHeigestCard > AiEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return 1;
                            }
                            else if (PlayerEvalCards.ValueOfSecoundHeigestCard < AiEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return -1;
                            }
                            return WhoHasHighCard(AiCards, PlayerCards, AiEvalCards.nrOfHighestCard, AiEvalCards.nrOfSecoundHighestCard, AiEvalCards.valueOfHigestCard, AiEvalCards.ValueOfSecoundHeigestCard);
                        }
                        return -1;
                    }

                    if (PlayerEvalCards.nrOfHighestCard == 4)
                    {
                        return 1;
                    }

                    //check for highest full house
                    if(AiEvalCards.nrOfSecoundHighestCard >= 2 && AiEvalCards.nrOfHighestCard == 3)
                    {
                        if (PlayerEvalCards.nrOfSecoundHighestCard >= 2 && PlayerEvalCards.nrOfHighestCard == 3)
                        {
                            if(PlayerEvalCards.valueOfHigestCard > AiEvalCards.valueOfHigestCard)
                            {
                                return 1;
                            }
                            else if (PlayerEvalCards.valueOfHigestCard < AiEvalCards.valueOfHigestCard)
                            {
                                return -1;
                            }
                            else if (PlayerEvalCards.ValueOfSecoundHeigestCard > AiEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return 1;
                            }
                            else if (PlayerEvalCards.ValueOfSecoundHeigestCard < AiEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return -1;
                            }
                            return 0;
                        }
                        return -1;
                    }

                    if (PlayerEvalCards.nrOfSecoundHighestCard >= 2 && PlayerEvalCards.nrOfHighestCard == 3)
                    {
                        return 1;
                    }

                    //check for highest card in flush
                    return CompareFlushes(AiCards, AiEvalCards.flushSuit, PlayerCards, PlayerEvalCards.flushSuit);
                }

                return -1;
            }

            //player straight flush, flush checked later
            if (PlayerEvalCards.hasFlush)
            {
                if (PlayerEvalCards.highestCardInStraight > 0)
                {
                    hasStraightFlush(PlayerCards, playerHighestCardInStraightFlush);

                    if(playerHighestCardInStraightFlush > 0)
                    {
                        return 1;
                    }
                }
            }

            //four of a kind checks
            if (AiEvalCards.nrOfHighestCard == 4)
            {
                if (PlayerEvalCards.nrOfHighestCard == 4)
                {
                    if (PlayerEvalCards.ValueOfSecoundHeigestCard > AiEvalCards.ValueOfSecoundHeigestCard)
                    {
                        return 1;
                    }
                    else if (PlayerEvalCards.ValueOfSecoundHeigestCard < AiEvalCards.ValueOfSecoundHeigestCard)
                    {
                        return -1;
                    }

                    return WhoHasHighCard(AiCards, PlayerCards, AiEvalCards.nrOfHighestCard, AiEvalCards.nrOfSecoundHighestCard, AiEvalCards.valueOfHigestCard, AiEvalCards.ValueOfSecoundHeigestCard);
                }
                return -1;
            }

            if (PlayerEvalCards.nrOfHighestCard == 4)
            {
                return 1;
            }

            //check for highest full house
            if (AiEvalCards.nrOfSecoundHighestCard >= 2 && AiEvalCards.nrOfHighestCard == 3)
            {
                if (PlayerEvalCards.nrOfSecoundHighestCard >= 2 && PlayerEvalCards.nrOfHighestCard == 3)
                {
                    if (PlayerEvalCards.valueOfHigestCard > AiEvalCards.valueOfHigestCard)
                    {
                        return 1;
                    }
                    else if (PlayerEvalCards.valueOfHigestCard < AiEvalCards.valueOfHigestCard)
                    {
                        return -1;
                    }
                    else if (PlayerEvalCards.ValueOfSecoundHeigestCard > AiEvalCards.ValueOfSecoundHeigestCard)
                    {
                        return 1;
                    }
                    else if (PlayerEvalCards.ValueOfSecoundHeigestCard < AiEvalCards.ValueOfSecoundHeigestCard)
                    {
                        return -1;
                    }
                    return 0;
                }
                return -1;
            }

            if (PlayerEvalCards.nrOfSecoundHighestCard >= 2 && PlayerEvalCards.nrOfHighestCard == 3)
            {
                return 1;
            }

            if (PlayerEvalCards.hasFlush)
            {
                return 1;
            }

            //checks for straight
            if (AiEvalCards.highestCardInStraight > 0 || PlayerEvalCards.highestCardInStraight > 0)
            {
                if(AiEvalCards.highestCardInStraight > PlayerEvalCards.highestCardInStraight)
                {
                    return -1;
                }
                else if(AiEvalCards.highestCardInStraight < PlayerEvalCards.highestCardInStraight)
                {
                    return 1;
                }
                return 0;
            }

            //checks for highest 3 of a kind, 2 pairs, and pair
            if (PlayerEvalCards.nrOfHighestCard > AiEvalCards.nrOfHighestCard)
            {
                return 1;
            }
            else if (PlayerEvalCards.nrOfHighestCard < AiEvalCards.nrOfHighestCard)
            {
                return -1;
            }
            else if(PlayerEvalCards.nrOfSecoundHighestCard > AiEvalCards.nrOfSecoundHighestCard)
            {
                return 1;
            }
            else if (PlayerEvalCards.nrOfSecoundHighestCard < AiEvalCards.nrOfSecoundHighestCard)
            {
                return -1;
            }

            //if both player have the same kind of hand, check who has the highest value one
            else if (PlayerEvalCards.valueOfHigestCard > AiEvalCards.valueOfHigestCard)
            {
                return 1;
            }
            else if (PlayerEvalCards.valueOfHigestCard < AiEvalCards.valueOfHigestCard)
            {
                return -1;
            }
            else if (PlayerEvalCards.ValueOfSecoundHeigestCard > AiEvalCards.ValueOfSecoundHeigestCard)
            {
                return 1;
            }
            else if (PlayerEvalCards.ValueOfSecoundHeigestCard < AiEvalCards.ValueOfSecoundHeigestCard)
            {
                return -1;
            }
            else
            {
                //Check for high cards
                return WhoHasHighCard(AiCards, PlayerCards, AiEvalCards.nrOfHighestCard, AiEvalCards.nrOfSecoundHighestCard, AiEvalCards.valueOfHigestCard, AiEvalCards.ValueOfSecoundHeigestCard);
            }
        }

        public WinnerResults OldWhoWins(List<Card> AiCards, List<Card> PlayerCards) //tester ikke high cards
        {
            evaluatedcards AiEvalCards = new evaluatedcards(AiCards), PlayerEvalCards = new evaluatedcards(PlayerCards);
            int aiHighestCardInStraightFlush = 0, playerHighestCardInStraightFlush = 0, result;
            
            //check for flushes
            if (AiEvalCards.hasFlush)
            {
                if (PlayerEvalCards.hasFlush)
                {
                    //checks for straight flush
                    if (AiEvalCards.highestCardInStraight > 0)
                    {
                        hasStraightFlush(AiCards, aiHighestCardInStraightFlush);

                        if(aiHighestCardInStraightFlush > 0)
                        {
                            hasStraightFlush(PlayerCards, playerHighestCardInStraightFlush);

                            if(aiHighestCardInStraightFlush > playerHighestCardInStraightFlush)
                            {
                                return new WinnerResults("Ai", "StraightFlush");
                            }
                            else if(playerHighestCardInStraightFlush > aiHighestCardInStraightFlush)
                            {
                                return new WinnerResults("Player", "StraightFlush");
                            }
                            else if(playerHighestCardInStraightFlush == aiHighestCardInStraightFlush)
                            {
                                return new WinnerResults("Draw", "StraightFlushs");
                            }
                        }
                    }

                    if (PlayerEvalCards.highestCardInStraight > 0)
                    {
                        hasStraightFlush(PlayerCards, playerHighestCardInStraightFlush);

                        if(playerHighestCardInStraightFlush > 0)
                        {
                            return new WinnerResults("Player", "StraightFlush");
                        }
                    }

                    //check for 4 of a kind
                    if (AiEvalCards.nrOfHighestCard == 4)
                    {
                        if (PlayerEvalCards.nrOfHighestCard == 4 && PlayerEvalCards.valueOfHigestCard >= AiEvalCards.valueOfHigestCard)
                        {
                            if (PlayerEvalCards.valueOfHigestCard == AiEvalCards.valueOfHigestCard)
                            {
                                return new WinnerResults("Draw", "Four of a kind");
                            }
                            return new WinnerResults("Player", "Four of a kind");
                        }
                        return new WinnerResults("Ai", "Four of a kind");
                    }

                    if (PlayerEvalCards.nrOfSecoundHighestCard == 4)
                    {
                        return new WinnerResults("Player", "Four of a kind");
                    }

                    //check for highest full house
                    if (AiEvalCards.nrOfHighestCard >= 3 && AiEvalCards.nrOfSecoundHighestCard >= 2)
                    {
                        if (PlayerEvalCards.nrOfHighestCard >= 3 && PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                        {
                            if(PlayerEvalCards.valueOfHigestCard > AiEvalCards.valueOfHigestCard)
                            {
                                return new WinnerResults("Player", "Full house");
                            }
                            else if(PlayerEvalCards.valueOfHigestCard < AiEvalCards.valueOfHigestCard)
                            {
                                return new WinnerResults("Ai", "Full house");
                            }
                            else if(PlayerEvalCards.ValueOfSecoundHeigestCard > AiEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return new WinnerResults("Player", "Full house");
                            }
                            else if (PlayerEvalCards.ValueOfSecoundHeigestCard < AiEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return new WinnerResults("Ai", "Full house");
                            }
                            return new WinnerResults("Draw", "Full house");
                        }
                    }

                    if (PlayerEvalCards.nrOfHighestCard >= 3 && PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                    {
                        if (PlayerEvalCards.nrOfHighestCard == 4)
                        {
                            return new WinnerResults("Player", "Four of a kind");
                        }
                        return new WinnerResults("Player", "Full House");
                    }

                    //check for highest card in flush
                    result = CompareFlushes(AiCards, AiEvalCards.flushSuit, PlayerCards, PlayerEvalCards.flushSuit);

                    if(result < 0)
                    {
                        return new WinnerResults("Ai", "Flush");
                    }
                    else if(result > 0)
                    {
                        return new WinnerResults("Player", "Flush");
                    }
                    return new WinnerResults("Draw", "Flush");
                }

                return new WinnerResults("Ai", "Flush");
            }

            if (PlayerEvalCards.hasFlush)
            {
                if(PlayerEvalCards.highestCardInStraight > 0)
                {
                    hasStraightFlush(PlayerCards, playerHighestCardInStraightFlush);

                    if (playerHighestCardInStraightFlush > 0)
                    {
                        return new WinnerResults("Player", "StraightFlush");
                    }
                }

                if(PlayerEvalCards.nrOfHighestCard >= 3)
                {
                    if (PlayerEvalCards.nrOfHighestCard == 4)
                    {
                        return new WinnerResults("Player", "Four of a kind");
                    }
                    else if(PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                    {
                        return new WinnerResults("Player", "Full house");
                    }
                }
                
                return new WinnerResults("Player", "Flush");
            }

            if (AiEvalCards.highestCardInStraight > 0 || PlayerEvalCards.highestCardInStraight > 0)
            {
                if (AiEvalCards.highestCardInStraight > PlayerEvalCards.highestCardInStraight)
                {
                    return new WinnerResults("Ai", "straight");
                }
                else if (AiEvalCards.highestCardInStraight < PlayerEvalCards.highestCardInStraight)
                {
                    return new WinnerResults("Player", "straight");
                }
                return new WinnerResults("Draw", "straight");
            }

            if (PlayerEvalCards.nrOfHighestCard > AiEvalCards.nrOfHighestCard)
            {
                if(PlayerEvalCards.nrOfHighestCard == 4)
                {
                    return new WinnerResults("Player", "Four of a kind");
                }
                else if (PlayerEvalCards.nrOfHighestCard == 3)
                {
                    if (PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                    {
                        return new WinnerResults("Player", "Full house");
                    }
                    return new WinnerResults("Player", "Three of a kind");
                }
                else if (PlayerEvalCards.nrOfHighestCard == 2)
                {
                    if (PlayerEvalCards.nrOfSecoundHighestCard == 2)
                    {
                        return new WinnerResults("Player", "Two pairs");
                    }
                    return new WinnerResults("Player", "Pair");
                }

                throw new Exception("ERROR: either the algoritm found > 4 of a kind for the player or < 0 for the Ai");
            }
            else if(PlayerEvalCards.nrOfHighestCard < AiEvalCards.nrOfHighestCard)
            {
                if (AiEvalCards.nrOfHighestCard == 4)
                {
                    return new WinnerResults("Ai", "Four of a kind");
                }
                else if (AiEvalCards.nrOfHighestCard == 3)
                {
                    if (AiEvalCards.nrOfSecoundHighestCard >= 2)
                    {
                        return new WinnerResults("Ai", "Full house");
                    }
                    return new WinnerResults("Ai", "Three of a kind");
                }
                else if (AiEvalCards.nrOfHighestCard == 2)
                {
                    if(AiEvalCards.nrOfSecoundHighestCard == 2)
                    {
                        return new WinnerResults("Ai", "Two pairs");
                    }
                    return new WinnerResults("Ai", "Pair");
                }

                throw new Exception("ERROR: either the algoritm found > 4 of a kind for the Ai or < 0 for the Player");
            }
            else
            {
                if(AiEvalCards.nrOfSecoundHighestCard >= 2)
                {
                    if (PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                    {
                        if(PlayerEvalCards.valueOfHigestCard > AiEvalCards.valueOfHigestCard)
                        {
                            if(PlayerEvalCards.nrOfHighestCard == 3)
                            {
                                return new WinnerResults("Player", "Three of a kind, with high card");
                            }
                            return new WinnerResults("Player", "Two pairs, with high card");
                        }
                        else if (PlayerEvalCards.valueOfHigestCard < AiEvalCards.valueOfHigestCard)
                        {
                            if (AiEvalCards.nrOfHighestCard == 3)
                            {
                                return new WinnerResults("Ai", "Three of a kind, with high card");
                            }
                            return new WinnerResults("Ai", "Two pairs, with high card");
                        }

                        if (AiEvalCards.nrOfHighestCard == 3)
                        {
                            return new WinnerResults("Draw", "Three of a kind");
                        }
                        return new WinnerResults("Draw", "Two pairs");

                    }

                    if (AiEvalCards.nrOfHighestCard == 3)
                    {
                        return new WinnerResults("Ai", "Full house");
                    }

                    if (AiEvalCards.nrOfHighestCard == 2)
                    {
                        return new WinnerResults("Ai", "Two pairs");
                    }
                }

                if (PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                {
                    if (AiEvalCards.nrOfHighestCard == 3)
                    {
                        return new WinnerResults("Player", "Full house");
                    }

                    if (AiEvalCards.nrOfHighestCard == 2)
                    {
                        return new WinnerResults("Player", "Two pairs");
                    }
                }

                //Check for high cards
                if (PlayerEvalCards.valueOfHigestCard > AiEvalCards.valueOfHigestCard)
                {
                    if (PlayerEvalCards.nrOfHighestCard == 4)
                    {
                        return new WinnerResults("Player", "Four of a kind, with high card");
                    }
                    else if (PlayerEvalCards.nrOfHighestCard == 3)
                    {
                        if (PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                        {
                            return new WinnerResults("Player", "Full house, with high card");
                        }
                        return new WinnerResults("Player", "Three of a kind, with high card");
                    }
                    else if (PlayerEvalCards.nrOfHighestCard == 2)
                    {
                        if (PlayerEvalCards.nrOfSecoundHighestCard == 2)
                        {
                            return new WinnerResults("Player", "Two pairs, with high card");
                        }
                        return new WinnerResults("Player", "Pair, with high card");
                    }

                    return new WinnerResults("Player", "High Card");
                }
                else if (PlayerEvalCards.valueOfHigestCard < AiEvalCards.valueOfHigestCard)
                {
                    if (AiEvalCards.nrOfHighestCard == 4)
                    {
                        return new WinnerResults("Ai", "Four of a kind");
                    }
                    else if (AiEvalCards.nrOfHighestCard == 3)
                    {
                        if (AiEvalCards.nrOfSecoundHighestCard >= 2)
                        {
                            return new WinnerResults("Ai", "Full house");
                        }
                        return new WinnerResults("Ai", "Three of a kind");
                    }
                    else if (AiEvalCards.nrOfHighestCard == 2)
                    {
                        if (AiEvalCards.nrOfSecoundHighestCard == 2)
                        {
                            return new WinnerResults("Ai", "Two pairs");
                        }
                        return new WinnerResults("Ai", "Pair");
                    }

                    return new WinnerResults("Ai", "High Card");
                }
                else if(PlayerEvalCards.nrOfHighestCard >= 2 && PlayerEvalCards.ValueOfSecoundHeigestCard > AiEvalCards.ValueOfSecoundHeigestCard)
                {
                    if(PlayerEvalCards.nrOfHighestCard == 3)
                    {
                        return new WinnerResults("Player", "Full House");
                    }
                    return new WinnerResults("Player", "Two pairs");
                }
                else if (AiEvalCards.nrOfHighestCard >= 2 && PlayerEvalCards.ValueOfSecoundHeigestCard < AiEvalCards.ValueOfSecoundHeigestCard)
                {
                    if (AiEvalCards.nrOfHighestCard == 3)
                    {
                        return new WinnerResults("Ai", "Full House");
                    }
                    return new WinnerResults("Ai", "Two pairs");
                }

                //Draw
                if (AiEvalCards.nrOfHighestCard == 4)
                {
                    return new WinnerResults("Draw", "Four of a kind");
                }
                else if (AiEvalCards.nrOfHighestCard == 3)
                {
                    if (AiEvalCards.nrOfSecoundHighestCard >= 2)
                    {
                        return new WinnerResults("Draw", "Full house");
                    }
                    return new WinnerResults("Draw", "Three of a kind");
                }
                else if (AiEvalCards.nrOfHighestCard == 2)
                {
                    if (AiEvalCards.nrOfSecoundHighestCard == 2)
                    {
                        return new WinnerResults("Draw", "Two pairs");
                    }
                    return new WinnerResults("Draw", "Pair");
                }

                return new WinnerResults("Draw", "High Card");
            }
        }

        private int WhoHasHighCard(List<Card> AiCards, List<Card> PlayerCards, int nrOfHighestValueCards, int nrOfSecoundHighestValueCards, int valueOfHighestCard, int valueOfSecoundHighestCard)
        {
            int y = 5, AiTestCard = 6, PlayerTestCard = 6;

            AiCards.Sort();
            PlayerCards.Sort();

            if(nrOfHighestValueCards > 1)
            {
                y -= nrOfHighestValueCards;
            }

            if (nrOfSecoundHighestValueCards > 1)
            {
                y -= nrOfSecoundHighestValueCards;
                
                for (int x = 0; x < y; x++) //checks for who has highest card, not incluling cards in involved in a pair, three of a kind etc.
                {
                    while ((int)PlayerCards[PlayerTestCard - x].Rank == valueOfHighestCard || (int)PlayerCards[PlayerTestCard - x].Rank == valueOfSecoundHighestCard)
                    {
                        PlayerTestCard--;
                    }

                    while ((int)AiCards[AiTestCard - x].Rank == valueOfHighestCard || (int)AiCards[AiTestCard - x].Rank == valueOfSecoundHighestCard)
                    {
                        AiTestCard--;
                    }


                    if (AiCards[AiTestCard - x].Rank > PlayerCards[PlayerTestCard - x].Rank)
                    {
                        return -1;
                    }
                    else if (AiCards[AiTestCard - x].Rank < PlayerCards[PlayerTestCard - x].Rank)
                    {
                        return 1;
                    }
                }
            }
            else
            {
                for (int x = 0; x < y; x++) //checks for who has highest card, not incluling cards in involved in a pair, three of a kind etc.
                {
                    while ((int)PlayerCards[PlayerTestCard - x].Rank == valueOfHighestCard)
                    {
                        PlayerTestCard--;
                    }

                    while ((int)AiCards[AiTestCard - x].Rank == valueOfHighestCard)
                    {
                        AiTestCard--;
                    }


                    if (AiCards[AiTestCard - x].Rank > PlayerCards[PlayerTestCard - x].Rank)
                    {
                        return -1;
                    }
                    else if (AiCards[AiTestCard - x].Rank < PlayerCards[PlayerTestCard - x].Rank)
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        private void hasStraightFlush(List<Card> cards, int Result) //needs to be rewritten to take advantage of FlushSuit in EvalCards
        {
            int ConsequtiveCardsOfSameSuitAndRank = 0;

            if (cards.Count != 7)
            {
                throw new Exception("Not enough cards");
            }

            cards.Sort();

            for(int x = 0; x > 6; x++)
            {
                if(cards[x].Suit == cards[x+1].Suit && cards[x].Rank == cards[x + 1].Rank)
                {
                    ConsequtiveCardsOfSameSuitAndRank++;
                    if(ConsequtiveCardsOfSameSuitAndRank >= 5)
                    {
                        Result = (int)cards[x + 1].Rank;
                    }
                }
            }
        }

        private int CompareFlushes(List<Card> Player1Cards, Suit Player1FlushSuit, List<Card> Player2Cards, Suit Player2FlushSuit)
        //returns 1 if player1 won, -1 if player 2 or 0 if a draw
        {
            List<Card> Player1Flush = new List<Card>(), Player2Flush = new List<Card>();

            foreach (Card card in Player1Cards)
            {
                if(card.Suit == Player1FlushSuit)
                {
                    Player1Flush.Add(card);
                }
            }

            foreach (Card card in Player2Cards)
            {
                if (card.Suit == Player2FlushSuit)
                {
                    Player2Flush.Add(card);
                }
            }

            Player1Flush.Sort();
            Player2Flush.Sort();

            int difference = Player2Flush.Count - Player1Flush.Count;

            for (int x = Player1Flush.Count - 1; x > 0; x--)
            {
                if (Player1Flush[x].Rank > Player2Flush[x + difference].Rank)
                {
                    return -1;
                }

                else if (Player1Flush[x].Rank < Player2Flush[x + difference].Rank)
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
