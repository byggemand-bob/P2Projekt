using System;
using System.Collections.Generic;

namespace Poker_Game.Game
{
    public class FastWinCalc
    {
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
                flushSuit = (Suit)0;

                EvaluationCalc(cards);
            }

            private void EvaluationCalc(List<Card> Cards)
            {
                int[] nrOfSuits = new int[4];
                int cardsInRow = 0;

                foreach (Card card in Cards)
                {
                    cardsSummed[(int)card.Rank]++;
                    nrOfSuits[(int)card.Suit]++;
                }

                for (int x = 0; x < 4; x++)
                {
                    if (nrOfSuits[x] >= 5)
                    {
                        hasFlush = true;
                        flushSuit = (Suit)x;
                    }
                }

                if (cardsSummed[14] > 0)
                {
                    cardsInRow++;
                }

                for (int x = 2; x < 15; x++)
                {
                    if (cardsSummed[x] > 0)
                    {
                        if (cardsSummed[x] >= nrOfHighestCard)
                        {
                            nrOfSecoundHighestCard = nrOfHighestCard;
                            ValueOfSecoundHeigestCard = valueOfHigestCard;
                            nrOfHighestCard = cardsSummed[x];
                            valueOfHigestCard = x;
                        }
                        else if (cardsSummed[x] >= nrOfSecoundHighestCard)
                        {
                            nrOfSecoundHighestCard = cardsSummed[x];
                            ValueOfSecoundHeigestCard = x;
                        }

                        cardsInRow++;

                        if (cardsInRow >= 5)
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
                        aiHighestCardInStraightFlush = hasStraightFlush(AiCards, AiEvalCards.flushSuit);

                        if (aiHighestCardInStraightFlush > 0)
                        {
                            playerHighestCardInStraightFlush = hasStraightFlush(PlayerCards, PlayerEvalCards.flushSuit);

                            if (aiHighestCardInStraightFlush > playerHighestCardInStraightFlush)
                            {
                                return -1;
                            }
                            else if (playerHighestCardInStraightFlush > aiHighestCardInStraightFlush)
                            {
                                return 1;
                            }
                            else if (playerHighestCardInStraightFlush == aiHighestCardInStraightFlush)
                            {
                                return 0;
                            }
                        }
                    }

                    if (PlayerEvalCards.highestCardInStraight > 0)
                    {
                        playerHighestCardInStraightFlush = hasStraightFlush(PlayerCards, PlayerEvalCards.flushSuit);

                        if (playerHighestCardInStraightFlush > 0)
                        {
                            return 1;
                        }
                    }

                    //check for highest card in flush
                    return CompareFlushes(AiCards, AiEvalCards.flushSuit, PlayerCards, PlayerEvalCards.flushSuit);
                }

                if(PlayerEvalCards.nrOfHighestCard >= 3)
                {
                    if(PlayerEvalCards.nrOfHighestCard == 4)
                    {
                        return 1;
                    }
                    else if(PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                    {
                        return 1;
                    }
                }


                return -1;
            }

            //player flush check
            if (PlayerEvalCards.hasFlush)
            {
                //checks if player has straight flush
                if (PlayerEvalCards.highestCardInStraight > 0)
                {
                    playerHighestCardInStraightFlush = hasStraightFlush(PlayerCards, PlayerEvalCards.flushSuit);

                    if (playerHighestCardInStraightFlush > 0)
                    {
                        return 1;
                    }
                }
                //check if ai has anything that beats flush

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

                return 1;
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

            //checks for straight
            if (AiEvalCards.highestCardInStraight > 0 || PlayerEvalCards.highestCardInStraight > 0)
            {
                if (AiEvalCards.highestCardInStraight > PlayerEvalCards.highestCardInStraight)
                {
                    return -1;
                }
                else if (AiEvalCards.highestCardInStraight < PlayerEvalCards.highestCardInStraight)
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
            else if (PlayerEvalCards.nrOfSecoundHighestCard > AiEvalCards.nrOfSecoundHighestCard)
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

        private int WhoHasHighCard(List<Card> AiCards, List<Card> PlayerCards, int nrOfHighestValueCards, int nrOfSecoundHighestValueCards, int valueOfHighestCard, int valueOfSecoundHighestCard)
        {
            int y = 5, AiTestCard = 6, PlayerTestCard = 6;

            AiCards.Sort();
            PlayerCards.Sort();

            if (nrOfHighestValueCards > 1)
            {
                y -= nrOfHighestValueCards;
            }

            if (nrOfSecoundHighestValueCards > 1)
            {
                y -= nrOfSecoundHighestValueCards;

                for (int x = 0; x < y; x++) //checks for who has highest card, not incluling cards involved in a pair, three of a kind etc.
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
            else if (nrOfHighestValueCards > 1)
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
            else
            {
                for (int x = 0; x < y; x++) //checks for who has highest card, not incluling cards in involved in a pair, three of a kind etc.
                {
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

        public int hasStraightFlush(List<Card> cards, Suit FlushSuit) //needs to be rewritten to take advantage of FlushSuit in EvalCards
        {
            int ConsequtiveCardsOfSameSuitAndRank = 0, Result = 0, x = 6;
            Rank lastRank = 0;

            if (cards.Count != 7)
            {
                throw new Exception("Not enough cards");
            }

            cards.Sort();

            while (cards[x].Rank == Rank.Ace)
            {
                if (cards[x].Suit == FlushSuit)
                {
                    ConsequtiveCardsOfSameSuitAndRank = 1;
                    lastRank = (Rank)1;
                    break;
                }
                x--;
            }

            for (x = 0; x <= 6; x++)
            {
                if (cards[x].Suit == FlushSuit)
                {
                    if (cards[x].Rank == lastRank + 1)
                    {
                        ConsequtiveCardsOfSameSuitAndRank++;
                        lastRank = cards[x].Rank;

                        if (ConsequtiveCardsOfSameSuitAndRank >= 5)
                        {
                            Result = (int)cards[x].Rank;
                        }
                    }
                    else
                    {
                        ConsequtiveCardsOfSameSuitAndRank = 1;
                        lastRank = cards[x].Rank;
                    }
                }
            }

            return Result;
        }

        private int CompareFlushes(List<Card> Player1Cards, Suit Player1FlushSuit, List<Card> Player2Cards, Suit Player2FlushSuit)
        //returns -1 if player1 won, 1 if player 2 or 0 if a draw
        {
            int i = 6, n = 6;

            Player1Cards.Sort();
            Player2Cards.Sort();

            for (int x = 0; x < 5; x++)
            {
                while (Player1Cards[i].Suit != Player1FlushSuit)
                {
                    i--;
                }

                while (Player2Cards[n].Suit != Player2FlushSuit)
                {
                    n--;
                }

                if (Player1Cards[i].Rank > Player2Cards[n].Rank)
                {
                    return -1;
                }
                else if (Player1Cards[i].Rank < Player2Cards[n].Rank)
                {
                    return 1;
                }

                i--; n--;
            }

            return 0;
        }
    }
}
