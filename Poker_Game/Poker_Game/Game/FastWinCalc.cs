using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.Game
{
    class FastWinCalc
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
                        flushSuit = (Suit) nrOfSuits[x];
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

        public WinnerResults WhoWins(List<Card> AiCards, List<Card> PlayerCards)
        {
            evaluatedcards AiEvalCards = new evaluatedcards(AiCards), PlayerEvalCards = new evaluatedcards(AiCards);
            int aiHighestCardInStraightFlush = 0, playerHighestCardInStraightFlush = 0;

            if (AiEvalCards.hasFlush)
            {
                if (PlayerEvalCards.hasFlush)
                {
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
                            else
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

                    if(AiEvalCards.nrOfHighestCard >= 3 && AiEvalCards.nrOfSecoundHighestCard >= 2)
                    {
                        if (PlayerEvalCards.nrOfHighestCard >= 3 && PlayerEvalCards.nrOfSecoundHighestCard >= 2)
                        {
                            if(AiEvalCards.nrOfHighestCard == 4)
                            {
                                if (PlayerEvalCards.nrOfHighestCard == 4 && PlayerEvalCards.valueOfHigestCard >= AiEvalCards.valueOfHigestCard)
                                {
                                    if(PlayerEvalCards.valueOfHigestCard == AiEvalCards.valueOfHigestCard)
                                    {
                                        return new WinnerResults("Draw", "Four of a kind");
                                    }
                                    return new WinnerResults("Player", "Four of a kind");
                                }
                                return new WinnerResults("Ai", "Four of a kind");
                            }

                            if(PlayerEvalCards.nrOfSecoundHighestCard == 4)
                            {
                                return new WinnerResults("Player", "Four of a kind");
                            }

                            //impliment check for highest full house
                        }

                        if(AiEvalCards.nrOfHighestCard == 4)
                        {
                            return new WinnerResults("Ai", "Four of a kind");
                        }
                        return new WinnerResults("Ai", "Full House");
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

            if(PlayerEvalCards.nrOfHighestCard > AiEvalCards.nrOfHighestCard)
            {
                //player Wins Return correct value
                return new WinnerResults("Player", "...");
            }
            else if(PlayerEvalCards.nrOfHighestCard < AiEvalCards.nrOfHighestCard)
            {
                //Ai Wins Return correct value
                return new WinnerResults("Ai", "...");
            }
            else
            {
                //Draw
                return new WinnerResults("Draw", "...");
            }
        }

        private void hasStraightFlush(List<Card> cards, int Result) //needs to be rewritten to take advantage of FlushSuit in EvalCards
        {
            int ConsequtiveCardsOfSameSuitAndRank = 0;

            if (cards.Count != 7)
            {
                throw new Exception("Not enough cards");
            }

            cards.Sort();

            for(int x = 0; x < 6; x++)
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

        private int CompareFlushes()
        {
            return 0;
        }
    }
}
