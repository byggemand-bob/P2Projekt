using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Poker_Game {
    enum Score {
        None, Pair = 15, TwoPairs, ThreeOfAKind,
        Straight, Flush, FullHouse, FourOfAKind, StraightFlush,
        RoyalFlush
    }

    class WinConditions {

        public Score Evaluate(List<Card> cards) {
            List<Card> sortedCards = cards;
            sortedCards.Sort();

            if (HasRoyalFlush(sortedCards)) {
                return Score.RoyalFlush;
            } else if (HasStraightFlush(sortedCards)) {
                return Score.StraightFlush;
            } else if(HasFourOfAKind(sortedCards)) {
                return Score.FourOfAKind;
            } else if(HasFullHouse(sortedCards)) {
                return Score.FullHouse;
            } else if(HasFlush(sortedCards)) {
                return Score.Flush;
            } else if(HasStraight(sortedCards)) {
                return Score.Straight;
            } else if(HasThreeOfAKind(sortedCards)) {
                return Score.ThreeOfAKind;
            } else if(HasTwoPairs(sortedCards)) {
                return Score.TwoPairs;
            } else if (HasPair(sortedCards)) {
                return Score.Pair;
            } else {
                return Score.None;
            }
        }

        private bool HasPair(List<Card> sortedCards) {
            throw new NotImplementedException();
        }

        private bool HasTwoPairs(List<Card> sortedCards) {
            throw new NotImplementedException();
        }

        private bool HasThreeOfAKind(List<Card> sortedCards) {
            throw new NotImplementedException();
        }

        public bool HasFullHouse(List<Card> sortedCards) {
            throw new NotImplementedException();
        }

        private bool HasFourOfAKind(List<Card> sortedCards) {
            for (int i = 0; i < 4; i++) {
                if (sortedCards[i].Rank == sortedCards[i + 1].Rank &&
                    sortedCards[i + 1].Rank == sortedCards[i + 2].Rank &&
                    sortedCards[i + 2].Rank == sortedCards[i + 3].Rank) {
                    return true;
                }
            }
            return false; 
        }

        private bool HasStraightFlush(List<Card> sortedCards) {
            if (HasFlush(sortedCards)) {
                for (int i = 0; i < FlushSuit(sortedCards).Count; i++) {
                    Console.WriteLine(FlushSuit(sortedCards)[i].Rank + " " + FlushSuit(sortedCards)[i].Suit);
                }
                Console.WriteLine("");
                return HasStraight(FlushSuit(sortedCards));
            }
            return false;
        }

        private bool HasRoyalFlush(List<Card> sortedCards) {
            if (HasFlush(sortedCards)) {
                sortedCards.Sort(new CompareBySuit());
                for (int i = 0; i < 3; i++) {
                    if (sortedCards[i].Rank == Rank.Ace &&
                        sortedCards[i+1].Rank == Rank.King &&
                        sortedCards[i+2].Rank == Rank.Queen &&
                        sortedCards[i+3].Rank == Rank.Jack &&
                        sortedCards[i+4].Rank == (Rank)10) {
                        return true;
                    }
                } 
            }
            return false;
        }

        // straight is when 5 of cards are in order by rank
        private bool HasStraight(List<Card> cards) {
            int RankCounter = 0;
            cards.Sort();
            for (int i = 0; i <= cards.Count - 2; i++) {
                if (cards[i].Rank + 1 == cards[i + 1].Rank) {
                    RankCounter++;
                }
                if (cards[i + 1].Rank == Rank.Ace) {
                    cards[i + 1].Rank = (Rank)1;
                    return HasStraight(cards);
                }
            }
            if (RankCounter >= 4) {
                return true;
            }
            return false;
        }


        // flush is when 5 of the cards are of the same suit
        private bool HasFlush(List<Card> hand) {
            int C = 0, D = 0, H = 0, S = 0;
            foreach (Card element in hand) {
                if (element.Suit == Suit.Clubs) {
                    C++;
                } else if (element.Suit == Suit.Diamond) {
                    D++;
                } else if (element.Suit == Suit.Hearts) {
                    H++;
                } else if (element.Suit == Suit.Spades) {
                    S++;
                }
            }
            if (C > 4 || D > 4 || H > 4 || S > 4) {
                return true;
            }
            return false;
        }

        private List<Card> FlushSuit(List<Card> cards) {
            int C = 0, D = 0, H = 0, S = 0;
            foreach (Card element in cards) {
                if (element.Suit == Suit.Clubs) {
                    C++;
                } else if (element.Suit == Suit.Diamond) {
                    D++;
                } else if (element.Suit == Suit.Hearts) {
                    H++;
                } else if (element.Suit == Suit.Spades) {
                    S++;
                }
            }
            if (C > D && C > H && C > S) {
                return RemoveUnfitSuit(cards, Suit.Clubs);
            } else if (D > C && D > H && D > S) {
                return RemoveUnfitSuit(cards, Suit.Diamond);
            } else if (H > C && H > D && H > S) {
                return RemoveUnfitSuit(cards, Suit.Hearts);
            } else  {
                return RemoveUnfitSuit(cards, Suit.Spades);
            }
        }

        private List<Card> RemoveUnfitSuit(List<Card> cards, Suit suit) {
            for(int index = cards.Count - 1; index >= 0; index--) {
                if (cards[index].Suit != suit) {
                    cards.Remove(cards[index]);
                }
            }
            return cards;
        }
    }
}
