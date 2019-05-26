using System;
using System.Collections.Generic;

namespace Poker_Game.Game
{
    public class FastWinCalc
    {
        public struct EvaluatedCards
        {
            public bool HasFlush;
            public int NrOfHighestCard, ValueOfHighestCard, NrOfSecondHighestCard, ValueOfSecondHighestCard, HighestCardInStraight;
            public Suit FlushSuit;

            public EvaluatedCards(List<Card> cards)
            {
                HasFlush = false;
                NrOfHighestCard = 0;
                ValueOfHighestCard = 0;
                NrOfSecondHighestCard = 0;
                NrOfSecondHighestCard = 0;
                ValueOfSecondHighestCard = 0;
                HighestCardInStraight = 0;
                FlushSuit = 0;

                EvaluationCalc(cards);
            }

            private void EvaluationCalc(List<Card> cards)
            {
                int[] nrOfSuits = new int[4];
                int[] cardsSummed = new int[15];
                int cardsInRow = 0;

                foreach (Card card in cards)
                {
                    cardsSummed[(int)card.Rank]++;
                    nrOfSuits[(int)card.Suit]++;
                }

                for (int x = 0; x < 4; x++)
                {
                    if (nrOfSuits[x] >= 5)
                    {
                        HasFlush = true;
                        FlushSuit = (Suit)x;
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
                        if (cardsSummed[x] >= NrOfHighestCard)
                        {
                            NrOfSecondHighestCard = NrOfHighestCard;
                            ValueOfSecondHighestCard = ValueOfHighestCard;
                            NrOfHighestCard = cardsSummed[x];
                            ValueOfHighestCard = x;
                        }
                        else if (cardsSummed[x] >= NrOfSecondHighestCard)
                        {
                            NrOfSecondHighestCard = cardsSummed[x];
                            ValueOfSecondHighestCard = x;
                        }

                        cardsInRow++;

                        if (cardsInRow >= 5)
                        {
                            HighestCardInStraight = x;
                        }
                    }
                    else
                    {
                        cardsInRow = 0;
                    }
                }
            }
        }

        public int WhoWins(List<Card> aiCards, List<Card> playerCards)
        //return -1 for ai win, 1 for player win, 0 for draw
        {
            EvaluatedCards aiEvalCards = new EvaluatedCards(aiCards), playerEvalCards = new EvaluatedCards(playerCards);

            //check for straight flush
            if (aiEvalCards.HasFlush)
            {
                if (playerEvalCards.HasFlush)
                {
                    int playerHighestCardInStraightFlush;
                    //checks for straight flush
                    if (aiEvalCards.HighestCardInStraight > 0) {
                        int aiHighestCardInStraightFlush = HasStraightFlush(aiCards, aiEvalCards.FlushSuit);

                        if (aiHighestCardInStraightFlush > 0)
                        {
                            playerHighestCardInStraightFlush = HasStraightFlush(playerCards, playerEvalCards.FlushSuit);

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

                    if (playerEvalCards.HighestCardInStraight > 0)
                    {
                        playerHighestCardInStraightFlush = HasStraightFlush(playerCards, playerEvalCards.FlushSuit);

                        if (playerHighestCardInStraightFlush > 0)
                        {
                            return 1;
                        }
                    }

                    //check for highest card in flush
                    return CompareFlushes(aiCards, aiEvalCards.FlushSuit, playerCards, playerEvalCards.FlushSuit);
                }

                if(playerEvalCards.NrOfHighestCard >= 3)
                {
                    if(playerEvalCards.NrOfHighestCard == 4)
                    {
                        return 1;
                    }
                    else if(playerEvalCards.NrOfSecondHighestCard >= 2)
                    {
                        return 1;
                    }
                }


                return -1;
            }

            //player flush check
            if (playerEvalCards.HasFlush)
            {
                //checks if player has straight flush
                if (playerEvalCards.HighestCardInStraight > 0) {
                    int playerHighestCardInStraightFlush = HasStraightFlush(playerCards, playerEvalCards.FlushSuit);

                    if (playerHighestCardInStraightFlush > 0)
                    {
                        return 1;
                    }
                }
                //check if ai has anything that beats flush

                //four of a kind checks
                if (aiEvalCards.NrOfHighestCard == 4)
                {
                    return -1;
                }

                //check for highest full house
                if (aiEvalCards.NrOfSecondHighestCard >= 2 && aiEvalCards.NrOfHighestCard == 3)
                {
                    return -1;
                }

                return 1;
            }

            //four of a kind checks
            if (aiEvalCards.NrOfHighestCard == 4)
            {
                if (playerEvalCards.NrOfHighestCard == 4)
                {
                    if (playerEvalCards.ValueOfHighestCard > aiEvalCards.ValueOfHighestCard)
                    {
                        return 1;
                    }
                    else if (playerEvalCards.ValueOfHighestCard < aiEvalCards.ValueOfHighestCard)
                    {
                        return -1;
                    }

                    return WhoHasHighCard(aiCards, playerCards, aiEvalCards.NrOfHighestCard, aiEvalCards.NrOfSecondHighestCard, aiEvalCards.ValueOfHighestCard, aiEvalCards.ValueOfSecondHighestCard);
                }
                return -1;
            }

            if (playerEvalCards.NrOfHighestCard == 4)
            {
                return 1;
            }

            //check for highest full house
            if (aiEvalCards.NrOfSecondHighestCard >= 2 && aiEvalCards.NrOfHighestCard == 3)
            {
                if (playerEvalCards.NrOfSecondHighestCard >= 2 && playerEvalCards.NrOfHighestCard == 3)
                {
                    if (playerEvalCards.ValueOfHighestCard > aiEvalCards.ValueOfHighestCard)
                    {
                        return 1;
                    }
                    else if (playerEvalCards.ValueOfHighestCard < aiEvalCards.ValueOfHighestCard)
                    {
                        return -1;
                    }
                    else if (playerEvalCards.ValueOfSecondHighestCard > aiEvalCards.ValueOfSecondHighestCard)
                    {
                        return 1;
                    }
                    else if (playerEvalCards.ValueOfSecondHighestCard < aiEvalCards.ValueOfSecondHighestCard)
                    {
                        return -1;
                    }
                    return 0;
                }
                return -1;
            }

            if (playerEvalCards.NrOfSecondHighestCard >= 2 && playerEvalCards.NrOfHighestCard == 3)
            {
                return 1;
            }

            //checks for straight
            if (aiEvalCards.HighestCardInStraight > 0 || playerEvalCards.HighestCardInStraight > 0)
            {
                if (aiEvalCards.HighestCardInStraight > playerEvalCards.HighestCardInStraight)
                {
                    return -1;
                }
                else if (aiEvalCards.HighestCardInStraight < playerEvalCards.HighestCardInStraight)
                {
                    return 1;
                }
                return 0;
            }

            //checks for highest 3 of a kind, 2 pairs, and pair
            if (playerEvalCards.NrOfHighestCard > aiEvalCards.NrOfHighestCard)
            {
                return 1;
            }
            else if (playerEvalCards.NrOfHighestCard < aiEvalCards.NrOfHighestCard)
            {
                return -1;
            }
            else if (playerEvalCards.NrOfSecondHighestCard > aiEvalCards.NrOfSecondHighestCard)
            {
                return 1;
            }
            else if (playerEvalCards.NrOfSecondHighestCard < aiEvalCards.NrOfSecondHighestCard)
            {
                return -1;
            }

            //if both player have the same kind of hand, check who has the highest value one
            else if (playerEvalCards.ValueOfHighestCard > aiEvalCards.ValueOfHighestCard)
            {
                return 1;
            }
            else if (playerEvalCards.ValueOfHighestCard < aiEvalCards.ValueOfHighestCard)
            {
                return -1;
            }
            else if (playerEvalCards.ValueOfSecondHighestCard > aiEvalCards.ValueOfSecondHighestCard)
            {
                return 1;
            }
            else if (playerEvalCards.ValueOfSecondHighestCard < aiEvalCards.ValueOfSecondHighestCard)
            {
                return -1;
            }
            else
            {
                //Check for high cards
                return WhoHasHighCard(aiCards, playerCards, aiEvalCards.NrOfHighestCard, aiEvalCards.NrOfSecondHighestCard, aiEvalCards.ValueOfHighestCard, aiEvalCards.ValueOfSecondHighestCard);
            }
        }

        private int WhoHasHighCard(List<Card> aiCards, List<Card> playerCards, int nrOfHighestValueCards, int nrOfSecoundHighestValueCards, int valueOfHighestCard, int valueOfSecoundHighestCard)
        {
            int y = 5, aiTestCard = 6, playerTestCard = 6;

            aiCards.Sort();
            playerCards.Sort();
            
            if (nrOfSecoundHighestValueCards > 1 && nrOfHighestValueCards != 4)
            {
                y -= nrOfHighestValueCards;
                y -= nrOfSecoundHighestValueCards;

                for (int x = 0; x < y; x++) //checks for who has highest card, not incluling cards involved in a pair, three of a kind etc.
                {
                    while ((int)playerCards[playerTestCard - x].Rank == valueOfHighestCard || (int)playerCards[playerTestCard - x].Rank == valueOfSecoundHighestCard)
                    {
                        playerTestCard--;
                    }

                    while ((int)aiCards[aiTestCard - x].Rank == valueOfHighestCard || (int)aiCards[aiTestCard - x].Rank == valueOfSecoundHighestCard)
                    {
                        aiTestCard--;
                    }


                    if (aiCards[aiTestCard - x].Rank > playerCards[playerTestCard - x].Rank)
                    {
                        return -1;
                    }
                    else if (aiCards[aiTestCard - x].Rank < playerCards[playerTestCard - x].Rank)
                    {
                        return 1;
                    }
                }
            }
            else if (nrOfHighestValueCards > 1)
            {
                y -= nrOfHighestValueCards;

                for (int x = 0; x < y; x++) //checks for who has highest card, not incluling cards in involved in a pair, three of a kind etc.
                {
                    while ((int)playerCards[playerTestCard - x].Rank == valueOfHighestCard)
                    {
                        playerTestCard--;
                    }

                    while ((int)aiCards[aiTestCard - x].Rank == valueOfHighestCard)
                    {
                        aiTestCard--;
                    }


                    if (aiCards[aiTestCard - x].Rank > playerCards[playerTestCard - x].Rank)
                    {
                        return -1;
                    }
                    else if (aiCards[aiTestCard - x].Rank < playerCards[playerTestCard - x].Rank)
                    {
                        return 1;
                    }
                }
            }
            else
            {
                for (int x = 0; x < y; x++) //checks for who has highest card, not incluling cards in involved in a pair, three of a kind etc.
                {
                    if (aiCards[aiTestCard - x].Rank > playerCards[playerTestCard - x].Rank)
                    {
                        return -1;
                    }
                    else if (aiCards[aiTestCard - x].Rank < playerCards[playerTestCard - x].Rank)
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        public int HasStraightFlush(List<Card> cards, Suit flushSuit)
        {
            int consecutiveCardsOfSameSuitAndRank = 0, result = 0, x = 6;
            Rank lastRank = 0;

            if (cards.Count != 7)
            {
                throw new Exception("Not enough cards");
            }

            cards.Sort();

            while (cards[x].Rank == Rank.Ace)
            {
                if (cards[x].Suit == flushSuit)
                {
                    consecutiveCardsOfSameSuitAndRank = 1;
                    lastRank = (Rank)1;
                    break;
                }
                x--;
            }

            for (x = 0; x <= 6; x++)
            {
                if (cards[x].Suit == flushSuit)
                {
                    if (cards[x].Rank == lastRank + 1)
                    {
                        consecutiveCardsOfSameSuitAndRank++;
                        lastRank = cards[x].Rank;

                        if (consecutiveCardsOfSameSuitAndRank >= 5)
                        {
                            result = (int)cards[x].Rank;
                        }
                    }
                    else
                    {
                        consecutiveCardsOfSameSuitAndRank = 1;
                        lastRank = cards[x].Rank;
                    }
                }
            }

            return result;
        }

        private int CompareFlushes(List<Card> player1Cards, Suit player1FlushSuit, List<Card> player2Cards, Suit player2FlushSuit)
        //returns -1 if player1 won, 1 if player 2 or 0 if a draw
        {
            int i = 6, n = 6;

            player1Cards.Sort();
            player2Cards.Sort();

            for (int x = 0; x < 5; x++)
            {
                while (player1Cards[i].Suit != player1FlushSuit)
                {
                    i--;
                }

                while (player2Cards[n].Suit != player2FlushSuit)
                {
                    n--;
                }
             
                if (player1Cards[i].Rank > player2Cards[n].Rank){
                    return -1;
                }
                else if (player1Cards[i].Rank < player2Cards[n].Rank){
                    return 1;
                }

                i--; n--;
            }

            return 0;
        }
    }
}
