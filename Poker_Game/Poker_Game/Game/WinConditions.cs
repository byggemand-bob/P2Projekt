using System.Collections.Generic;

namespace Poker_Game.Game {
    enum Score {
        None, Pair = 15, TwoPairs, ThreeOfAKind,
        Straight, Flush, FullHouse, FourOfAKind, StraightFlush,
        RoyalFlush
    }

    class WinConditions {

        public List<Card> DeckDuper3000(List<Card> cards) {
            List<Card> dupeCards = new List<Card>();
            foreach (Card element in cards) {
                dupeCards.Add((Card)element.Clone());
            }
            return dupeCards;
        }

        public Score Evaluate(List<Card> cards) {
            List<Card> sortedCards = DeckDuper3000(cards);
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
                return GetBestCard(cards);
            }
        }

        private Score GetBestCard(List<Card> playerHand) {
            return (playerHand[0].Rank > playerHand[1].Rank) ? (Score)playerHand[0].Rank : (Score)playerHand[1].Rank;
        }

        public bool HasPair(List<Card> sortedCards) {
            for (int i = 0; i < sortedCards.Count - 1; i++) {
                if (sortedCards[i].Rank == sortedCards[i + 1].Rank) {
                    return true;
                }
            }
            return false;
        }

        public bool HasTwoPairs(List<Card> cards) {
            List<Card> sortedCards = DeckDuper3000(cards);

            for (int i = 0; i < sortedCards.Count - 1; i++) {
                if (sortedCards[i].Rank == sortedCards[i + 1].Rank) {
                    return HasPair(RemoveUnfitRank(sortedCards, sortedCards[i].Rank));
                }
            }
            return false;
        }

        public bool HasThreeOfAKind(List<Card> sortedCards) {
            for (int i = 0; i < sortedCards.Count - 2; i++) {
                if (sortedCards[i].Rank == sortedCards[i + 1].Rank &&
                    sortedCards[i + 1].Rank == sortedCards[i + 2].Rank ) {
                    return true;
                }
            }
            return false;
        }

        public bool HasFullHouse(List<Card> cards) {
            List<Card> sortedCards = DeckDuper3000(cards);
            for (int i = 0; i < sortedCards.Count - 1; i++) {
                if (sortedCards[i].Rank == sortedCards[i + 1].Rank) {
                    return HasThreeOfAKind(RemoveUnfitRank(sortedCards, sortedCards[i].Rank));
                }
            }
            return false;
        }

        public bool HasFourOfAKind(List<Card> sortedCards) {
            for (int i = 0; i < sortedCards.Count - 3; i++) {
                if (sortedCards[i].Rank == sortedCards[i + 1].Rank &&
                    sortedCards[i + 1].Rank == sortedCards[i + 2].Rank &&
                    sortedCards[i + 2].Rank == sortedCards[i + 3].Rank) {
                    return true;
                }
            }
            return false; 
        }

        public bool HasStraightFlush(List<Card> cards) {
            List<Card> sortedCards = DeckDuper3000(cards);
            if (HasFlush(sortedCards)) {
                return HasStraight(FlushSuit(sortedCards));
            }
            return false;
        }

        public bool HasRoyalFlush(List<Card> cards) {
            List<Card> sortedCards = DeckDuper3000(cards);
            if (HasFlush(sortedCards)) {
                FlushSuit(sortedCards);
                sortedCards.Sort(new CompareBySuit());
                for (int i = 0; i < sortedCards.Count - 4; i++) {
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

        public bool HasStraight(List<Card> cards) {
            List<Card> sortedCards = DeckDuper3000(cards);
            int RankCounter = 0;
            for (int i = 0; i <= sortedCards.Count - 2; i++) {
                if (sortedCards[i].Rank + 1 == sortedCards[i + 1].Rank) {
                    RankCounter++;
                }
                if (sortedCards[i + 1].Rank == Rank.Ace) {
                    sortedCards[i + 1].Rank = (Rank)1;
                    return HasStraight(sortedCards);
                }
            }
            if (RankCounter >= 4) {
                return true;
            }
            return false;
        }

        public bool HasFlush(List<Card> hand) {
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

        private List<Card> RemoveUnfitRank(List<Card> cards, Rank rank) {
            for (int index = cards.Count - 1; index >= 0; index--) {
                if (cards[index].Rank == rank) {
                    cards.Remove(cards[index]);
                }
            }
            return cards;
        }

        //public Player SameScore(Player player1, Player player2) {
        //    if (player1.Score == Score.RoyalFlush) {
        //        return null;
        //    } else if (player1.Score == Score.StraightFlush) {
        //        return BestStraight(player1, player2);
        //    } else if (player1.Score == Score.FourOfAKind) {
        //        return BestFourOfAKind(player1, player2);
        //    } else if (player1.Score == Score.FullHouse) {
        //        //return BestFullHouse(player1, player2);
        //    } else if (player1.Score == Score.Flush) {
        //        return BestFlush(player1, player2);
        //    } else if (player1.Score == Score.Straight) {
        //        return BestStraight(player1, player2);
        //    } else if (player1.Score == Score.ThreeOfAKind) {
        //        return BestThreeOfAKind(player1, player2);
        //    } else if (player1.Score == Score.TwoPairs) {
        //        return BestTwoPairs(player1, player2);
        //    } else if (player1.Score == Score.Pair) {
        //        return BestPair(player1, player2);
        //    }
        //    return null;
        //}
        //private Player BestStraight(Player player1, Player player2) {
        //    List<Card> player1cards = DeckDuper3000(player1.Cards);
        //    List<Card> player2cards = DeckDuper3000(player2.Cards);
        //    player1cards.Sort();
        //    player2cards.Sort();
        //    for (int i = 0; i < player1cards.Count - 5; i++) {
        //        if(player1cards[i].Rank - 5 == player1cards[i + 5].Rank) {
        //            for (int j = 0; j < player2cards.Count - 5; j++) {
        //                if (player2cards[j].Rank - 5 == player2cards[j + 5].Rank) {
        //                    return (player1cards[i].Rank > player2cards[j].Rank ? player1 : player2);
        //                }
        //            }
        //        }
        //    }
        //    return null;
        //}
        //private Player BestFourOfAKind(Player player1, Player player2) {
        //    List<Card> player1cards = DeckDuper3000(player1.Cards);
        //    List<Card> player2cards = DeckDuper3000(player2.Cards);
        //    player1cards.Sort();
        //    player2cards.Sort();
        //    for (int i = 0; i < player1cards.Count - 3; i++) {
        //        if (player1cards[i].Rank == player1cards[i + 1].Rank &&
        //            player1cards[i + 1].Rank == player1cards[i + 2].Rank &&
        //            player1cards[i + 2].Rank == player1cards[i + 3].Rank) {
        //            for (int j = 0; i < player1cards.Count - 3; j++) {
        //                if (player1cards[j].Rank == player1cards[j + 1].Rank &&
        //                    player1cards[j + 1].Rank == player1cards[j + 2].Rank &&
        //                    player1cards[j + 2].Rank == player1cards[j + 3].Rank) {
        //                    return (player1cards[i].Rank > player2cards[j].Rank ? player1 : player2);
        //                }
        //            }
        //        }
        //    }
        //    return null;
        //}
        //private Player BestFullHouse(Player player1, Player player2) {
        //    List<Card> player1cards = DeckDuper3000(player1.Cards);
        //    List<Card> player2cards = DeckDuper3000(player2.Cards);
        //    player1cards.Sort();
        //    player2cards.Sort();
        //    for (int i = 0; i < player1cards.Count - 1; i++) {
        //        if (player1cards[i].Rank == player1cards[i + 1].Rank) {
        //            for (int i = 0; i < player1cards.Count - 1; i++) {
        //                if (player1cards[i].Rank == player1cards[i + 1].Rank) {
        //                    return null;
        //                }
        //            }
        //        }
        //    }
        //    HasThreeOfAKind(RemoveUnfitRank(sortedCards, sortedCards[i].Rank));
        //    return null;
        //}
        //private Player BestFlush(Player player1, Player player2) {
        //    return null;
        //}
        //private Player BestThreeOfAKind(Player player1, Player player2) {
        //    return null;
        //}
        //private Player BestTwoPairs(Player player1, Player player2) {
        //    return null;
        //}
        //private Player BestPair(Player player1, Player player2) {
        //    return null;
        //}
    }
}
