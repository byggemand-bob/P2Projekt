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

                if(cardsSummed[14] > 0)
                {
                    cardsInRow++;
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
                            else if(playerHighestCardInStraightFlush == aiHighestCardInStraightFlush)
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

            //player flush check
            if (PlayerEvalCards.hasFlush)
            {
                //checks if player has straight flush
                if (PlayerEvalCards.highestCardInStraight > 0)
                {
                    playerHighestCardInStraightFlush = hasStraightFlush(PlayerCards, PlayerEvalCards.flushSuit);

                    if(playerHighestCardInStraightFlush > 0)
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
        
        public int WhoHasHighCard(List<Card> AiCards, List<Card> PlayerCards, int nrOfHighestValueCards, int nrOfSecoundHighestValueCards, int valueOfHighestCard, int valueOfSecoundHighestCard)
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
            else if(nrOfHighestValueCards > 1)
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

            while(cards[x].Rank == Rank.Ace)
            {
                if(cards[x].Suit == FlushSuit)
                {
                    ConsequtiveCardsOfSameSuitAndRank++;
                    lastRank = (Rank)1;
                    break;
                }
                x--;
            }

            for(x = 0; x <= 6; x++)
            {
                if(cards[x].Suit == FlushSuit)
                {
                    if(cards[x].Rank == lastRank + 1)
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
                        ConsequtiveCardsOfSameSuitAndRank = 0;
                        lastRank = cards[x].Rank;
                    }
                }
            }

            return Result;
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

        public int WhoWinsV3(List<Card> AiCards, List<Card> PlayerCards) 
        //function can be optimized by removeing checks for 4 of a kind when we know x player has a flush, as haveing both should be impossible
        
        //return -1 for ai win, 1 for player win, 0 for draw
        {
            evaluatedcards AiEvalCards = new evaluatedcards(AiCards), PlayerEvalCards = new evaluatedcards(PlayerCards);
            int aiHighestCardInStraightFlush = 0, playerHighestCardInStraightFlush = 0;

            if (AiEvalCards.hasFlush)
            {
                if (PlayerEvalCards.hasFlush)
                {
                    //check for straight flush
                    if (AiEvalCards.highestCardInStraight > 0)
                    {
                        aiHighestCardInStraightFlush = hasStraightFlush(AiCards, AiEvalCards.flushSuit);

                        if(aiHighestCardInStraightFlush > 0)
                        {
                            if(PlayerEvalCards.highestCardInStraight > 0)
                            {
                                playerHighestCardInStraightFlush = hasStraightFlush(PlayerCards, PlayerEvalCards.flushSuit);

                                if(playerHighestCardInStraightFlush > 0)
                                {
                                    if(playerHighestCardInStraightFlush > aiHighestCardInStraightFlush)
                                    {
                                        return 1;
                                    }
                                    else if(playerHighestCardInStraightFlush < aiHighestCardInStraightFlush)
                                    {
                                        return -1;
                                    }
                                    else
                                    {
                                        return 0;
                                    }
                                }
                            }

                            return -1;
                        }
                    }

                    if(PlayerEvalCards.highestCardInStraight > 0)
                    {
                        playerHighestCardInStraightFlush = hasStraightFlush(PlayerCards, PlayerEvalCards.flushSuit);

                        if(playerHighestCardInStraightFlush > 0)
                        {
                            return 1;
                        }
                    }
                    //straight flush check end

                    //checks for 4 of a kind, or a hull house
                    if(AiEvalCards.nrOfHighestCard >= 3)
                    {
                        if(AiEvalCards.nrOfHighestCard == 4)
                        {
                            if(PlayerEvalCards.nrOfHighestCard == 4)
                            {
                                if(AiEvalCards.valueOfHigestCard > PlayerEvalCards.valueOfHigestCard)
                                {
                                    return -1;
                                }
                                else if(AiEvalCards.valueOfHigestCard < PlayerEvalCards.valueOfHigestCard)
                                {
                                    return 1;
                                }
                                else
                                {
                                    return WhoHasHighCard(AiCards, PlayerCards, AiEvalCards.nrOfHighestCard, AiEvalCards.nrOfSecoundHighestCard, AiEvalCards.valueOfHigestCard, AiEvalCards.ValueOfSecoundHeigestCard);
                                }
                            }
                            return -1;
                        }

                        if(AiEvalCards.nrOfSecoundHighestCard >= 2)
                        {
                            if(PlayerEvalCards.nrOfHighestCard == 4)
                            {
                                return 1;
                            }
                            else if(PlayerEvalCards.nrOfHighestCard == 3 && PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                            {
                                if(AiEvalCards.valueOfHigestCard > PlayerEvalCards.valueOfHigestCard)
                                {
                                    return -1;
                                }
                                else if(AiEvalCards.valueOfHigestCard < PlayerEvalCards.valueOfHigestCard)
                                {
                                    return 1;
                                }
                                else if(AiEvalCards.ValueOfSecoundHeigestCard > PlayerEvalCards.ValueOfSecoundHeigestCard)
                                {
                                    return -1;
                                }
                                else if (AiEvalCards.ValueOfSecoundHeigestCard < PlayerEvalCards.ValueOfSecoundHeigestCard)
                                {
                                    return 1;
                                }
                                return 0;
                            }
                        }
                    }

                    if(PlayerEvalCards.nrOfHighestCard >= 3)
                    {
                        if(PlayerEvalCards.nrOfHighestCard == 4 || PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                        {
                            return 1;
                        }
                    }
                    //end of check for 4 of a kind, or fullhouse

                    //if nothing above is true check for highest flush
                    return CompareFlushes(AiCards, AiEvalCards.flushSuit, PlayerCards, PlayerEvalCards.flushSuit);
                }
                //from here only Ai has flush, checks if Player has anything that trumps a flush

                //checks for 4 of a kind a hull house, for player before declareing ai winner
                if(PlayerEvalCards.nrOfHighestCard >= 3)
                {
                    if(PlayerEvalCards.nrOfHighestCard == 4)
                    {
                        if(AiEvalCards.nrOfHighestCard == 4)
                        {
                            if(AiEvalCards.valueOfHigestCard > PlayerEvalCards.valueOfHigestCard)
                            {
                                return -1;
                            }
                            else if (AiEvalCards.valueOfHigestCard < PlayerEvalCards.valueOfHigestCard)
                            {
                                return 1;
                            }
                            else
                            {
                                return WhoHasHighCard(AiCards, PlayerCards, AiEvalCards.nrOfHighestCard, AiEvalCards.nrOfSecoundHighestCard, AiEvalCards.valueOfHigestCard, AiEvalCards.ValueOfSecoundHeigestCard);
                            }
                        }

                        return 1;
                    }

                    if(PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                    {
                        if(AiEvalCards.nrOfHighestCard == 4)
                        {
                            return -1;
                        }
                        else if(AiEvalCards.nrOfHighestCard == 3 && AiEvalCards.nrOfSecoundHighestCard >= 2)
                        {
                            if (AiEvalCards.valueOfHigestCard > PlayerEvalCards.valueOfHigestCard)
                            {
                                return -1;
                            }
                            else if (AiEvalCards.valueOfHigestCard < PlayerEvalCards.valueOfHigestCard)
                            {
                                return 1;
                            }
                            else if (AiEvalCards.ValueOfSecoundHeigestCard > PlayerEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return -1;
                            }
                            else if (AiEvalCards.ValueOfSecoundHeigestCard < PlayerEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return 1;
                            }
                            return 0;
                        }

                        return 1;
                    }
                }
                //end of 4 of a kind, and fullhouse checks

                //since nothing above was true, Ai is declared the winner with a flush
                return -1;
            }

            if (PlayerEvalCards.hasFlush)
            {
                //check if ai has 4 of a kind or full house, before declareing Player winner with a flush
                if(AiEvalCards.nrOfHighestCard >= 3)
                {
                    if(AiEvalCards.nrOfHighestCard == 4)
                    {
                        if(PlayerEvalCards.nrOfHighestCard == 4)
                        {
                            if(AiEvalCards.valueOfHigestCard > PlayerEvalCards.valueOfHigestCard)
                            {
                                return -1;
                            }
                            else if (AiEvalCards.valueOfHigestCard < PlayerEvalCards.valueOfHigestCard)
                            {
                                return 1;
                            }
                            else
                            {
                                return WhoHasHighCard(AiCards, PlayerCards, AiEvalCards.nrOfHighestCard, AiEvalCards.nrOfSecoundHighestCard, AiEvalCards.valueOfHigestCard, AiEvalCards.ValueOfSecoundHeigestCard);
                            }
                        }
                        return -1;
                    }

                    if(AiEvalCards.nrOfSecoundHighestCard >= 2)
                    {
                        if(PlayerEvalCards.nrOfHighestCard == 4)
                        {
                            return 1;
                        }
                        else if(PlayerEvalCards.nrOfHighestCard == 3 && PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                        {
                            if (AiEvalCards.valueOfHigestCard > PlayerEvalCards.valueOfHigestCard)
                            {
                                return -1;
                            }
                            else if (AiEvalCards.valueOfHigestCard < PlayerEvalCards.valueOfHigestCard)
                            {
                                return 1;
                            }
                            else if (AiEvalCards.ValueOfSecoundHeigestCard > PlayerEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return -1;
                            }
                            else if (AiEvalCards.ValueOfSecoundHeigestCard < PlayerEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return 1;
                            }
                            return 0;
                        }
                        return -1;
                    }
                }
                //end of checks for 4 of a kind, or fullhouse

                //since nothing above was true, then the player wins with a flush
                return 1;
            }

            if(AiEvalCards.highestCardInStraight > 0)
            {
                if(PlayerEvalCards.highestCardInStraight > 0)
                {
                    //checks for 4 of a kind, or a hull house
                    if (AiEvalCards.nrOfHighestCard >= 3)
                    {
                        if (AiEvalCards.nrOfHighestCard == 4)
                        {
                            if (PlayerEvalCards.nrOfHighestCard == 4)
                            {
                                if (AiEvalCards.valueOfHigestCard > PlayerEvalCards.valueOfHigestCard)
                                {
                                    return -1;
                                }
                                else if (AiEvalCards.valueOfHigestCard < PlayerEvalCards.valueOfHigestCard)
                                {
                                    return 1;
                                }
                                else
                                {
                                    return WhoHasHighCard(AiCards, PlayerCards, AiEvalCards.nrOfHighestCard, AiEvalCards.nrOfSecoundHighestCard, AiEvalCards.valueOfHigestCard, AiEvalCards.ValueOfSecoundHeigestCard);
                                }
                            }
                            return -1;
                        }

                        if (AiEvalCards.nrOfSecoundHighestCard >= 2)
                        {
                            if (PlayerEvalCards.nrOfHighestCard == 4)
                            {
                                return 1;
                            }
                            else if (PlayerEvalCards.nrOfHighestCard == 3 && PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                            {
                                if (AiEvalCards.valueOfHigestCard > PlayerEvalCards.valueOfHigestCard)
                                {
                                    return -1;
                                }
                                else if (AiEvalCards.valueOfHigestCard < PlayerEvalCards.valueOfHigestCard)
                                {
                                    return 1;
                                }
                                else if (AiEvalCards.ValueOfSecoundHeigestCard > PlayerEvalCards.ValueOfSecoundHeigestCard)
                                {
                                    return -1;
                                }
                                else if (AiEvalCards.ValueOfSecoundHeigestCard < PlayerEvalCards.ValueOfSecoundHeigestCard)
                                {
                                    return 1;
                                }
                                return 0;
                            }
                        }
                    }

                    if (PlayerEvalCards.nrOfHighestCard >= 3)
                    {
                        if (PlayerEvalCards.nrOfHighestCard == 4 || PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                        {
                            return 1;
                        }
                    }
                    //end of checks for 4 of a kind or full house

                    //compare straights
                    if(AiEvalCards.highestCardInStraight > PlayerEvalCards.highestCardInStraight)
                    {
                        return -1;
                    }
                    else if(AiEvalCards.highestCardInStraight < PlayerEvalCards.highestCardInStraight)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }

                //check if Player has something that trumps the Ai's straight, not includeing a flush which we already have checked that it doesn have
                if(PlayerEvalCards.nrOfHighestCard >= 3)
                {
                    if(PlayerEvalCards.nrOfHighestCard == 4)
                    {
                        if(AiEvalCards.nrOfHighestCard == 4)
                        {
                            if(AiEvalCards.valueOfHigestCard > PlayerEvalCards.valueOfHigestCard)
                            {
                                return -1;
                            }
                            else if(AiEvalCards.valueOfHigestCard < PlayerEvalCards.valueOfHigestCard)
                            {
                                return 1;
                            }
                            else
                            {
                                return WhoHasHighCard(AiCards, PlayerCards, AiEvalCards.nrOfHighestCard, AiEvalCards.nrOfSecoundHighestCard, AiEvalCards.valueOfHigestCard, AiEvalCards.ValueOfSecoundHeigestCard);
                            }
                        }

                        return 1;
                    }

                    if(PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                    {
                        if(AiEvalCards.nrOfHighestCard == 4)
                        {
                            return -1;
                        }
                        else if(AiEvalCards.nrOfHighestCard == 3 && AiEvalCards.nrOfSecoundHighestCard >= 2)
                        {
                            if (AiEvalCards.valueOfHigestCard > PlayerEvalCards.valueOfHigestCard)
                            {
                                return -1;
                            }
                            else if (AiEvalCards.valueOfHigestCard < PlayerEvalCards.valueOfHigestCard)
                            {
                                return 1;
                            }
                            else if (AiEvalCards.ValueOfSecoundHeigestCard > PlayerEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return -1;
                            }
                            else if (AiEvalCards.ValueOfSecoundHeigestCard < PlayerEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return 1;
                            }
                            return 0;
                        }

                        return 1;
                    }
                }

                //since nothing above was true Ai wins with a Straight;
                return -1;
            }

            if(PlayerEvalCards.highestCardInStraight > 0)
            {
                //checks if ai has something that trumps a straight, not includeing flush or straigh as we already checked for this earlier
                if (AiEvalCards.nrOfHighestCard >= 3)
                {
                    if(AiEvalCards.nrOfHighestCard == 4)
                    {
                        if(PlayerEvalCards.nrOfHighestCard == 4)
                        {
                            if(AiEvalCards.valueOfHigestCard > PlayerEvalCards.valueOfHigestCard)
                            {
                                return -1;
                            }
                            if (AiEvalCards.valueOfHigestCard < PlayerEvalCards.valueOfHigestCard)
                            {
                                return 1;
                            }
                            return WhoHasHighCard(AiCards, PlayerCards, AiEvalCards.nrOfHighestCard, AiEvalCards.nrOfSecoundHighestCard, AiEvalCards.valueOfHigestCard, AiEvalCards.ValueOfSecoundHeigestCard);
                        }
                        return -1;
                    }

                    else if(AiEvalCards.nrOfSecoundHighestCard >= 2)
                    {
                        if(PlayerEvalCards.nrOfSecoundHighestCard == 4)
                        {
                            return 1;
                        }
                        else if(PlayerEvalCards.nrOfSecoundHighestCard == 3 && PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                        {
                            if (AiEvalCards.valueOfHigestCard > PlayerEvalCards.valueOfHigestCard)
                            {
                                return -1;
                            }
                            else if (AiEvalCards.valueOfHigestCard < PlayerEvalCards.valueOfHigestCard)
                            {
                                return 1;
                            }
                            else if (AiEvalCards.ValueOfSecoundHeigestCard > PlayerEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return -1;
                            }
                            else if (AiEvalCards.ValueOfSecoundHeigestCard < PlayerEvalCards.ValueOfSecoundHeigestCard)
                            {
                                return 1;
                            }
                            return 0;
                        }
                    }
                }

                //since nothing above was true Player wins with a Straight
                return 1;
            }

            //since we know that Ai and Player neither have a flush or a Straight we can check for highs number of same rank cards.
            if(AiEvalCards.nrOfHighestCard > PlayerEvalCards.nrOfHighestCard)
            {
                return -1;
            }
            else if(AiEvalCards.nrOfHighestCard < PlayerEvalCards.nrOfHighestCard)
            {
                return 1;
            }
            else if(AiEvalCards.nrOfSecoundHighestCard > PlayerEvalCards.nrOfSecoundHighestCard)
            {
                return -1;
            }
            else if(AiEvalCards.nrOfSecoundHighestCard < PlayerEvalCards.nrOfSecoundHighestCard)
            {
                return 1;
            }

            //since we both player have the same number of same ranks, we'll check who has the highest value of same ranks
            if(AiEvalCards.valueOfHigestCard > PlayerEvalCards.valueOfHigestCard)
            {
                return -1;
            }
            else if(AiEvalCards.valueOfHigestCard < PlayerEvalCards.valueOfHigestCard)
            {
                return 1;
            }
            else if(AiEvalCards.ValueOfSecoundHeigestCard > PlayerEvalCards.ValueOfSecoundHeigestCard)
            {
                return -1;
            }
            else if(AiEvalCards.ValueOfSecoundHeigestCard < PlayerEvalCards.ValueOfSecoundHeigestCard)
            {
                return 1;
            }

            //because nothing above decided the result it comes down to highest card
            return WhoHasHighCard(AiCards, PlayerCards, AiEvalCards.nrOfHighestCard, AiEvalCards.nrOfSecoundHighestCard, AiEvalCards.valueOfHigestCard, AiEvalCards.ValueOfSecoundHeigestCard);
        }
    }
}
