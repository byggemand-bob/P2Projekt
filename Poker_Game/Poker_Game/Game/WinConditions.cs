using System.Collections.Generic;

// TODO: Make a method for when both players has no winning hand -> Slit the pot

namespace Poker_Game.Game {
    public enum Score {
        None, Pair = 15, TwoPairs, ThreeOfAKind,
        Straight, Flush, FullHouse, FourOfAKind, StraightFlush,
        RoyalFlush
    }

    public class WinConditions {

        public List<Card> DuplicateDeck(List<Card> cards) {
            List<Card> dupeCards = new List<Card>();
            foreach (Card element in cards) {
                dupeCards.Add((Card)element.Clone());
            }
            return dupeCards;
        }
        public Player WhoWins(Player player1, Player player2) {
            if (player1.Score == Score.StraightFlush) {
                return player1.ScoreHand[player1.ScoreHand.Count - 1].Rank > player2.ScoreHand[player2.ScoreHand.Count - 1].Rank ? player1 : player2;
            } else if (player1.Score == Score.FourOfAKind || player1.Score == Score.FullHouse) {
                if (player1.ScoreHand[0].Rank > player2.ScoreHand[0].Rank) {
                    return player1;
                } else if (player1.ScoreHand[0].Rank < player2.ScoreHand[0].Rank) {
                    return player2;
                } else {
                    if (player1.ScoreHand[player1.ScoreHand.Count - 2].Rank > player2.ScoreHand[player2.ScoreHand.Count - 2].Rank) {
                        return player1;
                    } else if (player1.ScoreHand[player1.ScoreHand.Count - 2].Rank < player2.ScoreHand[player2.ScoreHand.Count - 2].Rank) {
                        return player2;
                    } else {
                        return null;
                    }
                }
            } else if (player1.Score == Score.Flush) {
                return GetBestHighestCard(player1, player2);
            } else if (player1.Score == Score.Straight) {
                if (player1.ScoreHand[player1.ScoreHand.Count - 1].Rank > player2.ScoreHand[player2.ScoreHand.Count - 1].Rank) {
                    return player1;
                } else if (player1.ScoreHand[player1.ScoreHand.Count - 1].Rank < player2.ScoreHand[player2.ScoreHand.Count - 1].Rank) {
                    return player2;
                } else {
                    return null;
                }
            } else if (player1.Score == Score.ThreeOfAKind || player1.Score == Score.TwoPairs) {
                if (player1.ScoreHand[0].Rank > player2.ScoreHand[0].Rank) {
                    return player1;
                } else if (player1.ScoreHand[0].Rank < player2.ScoreHand[0].Rank) {
                    return player2;
                } else {
                    if (player1.ScoreHand[player1.ScoreHand.Count - 2].Rank > player2.ScoreHand[player2.ScoreHand.Count - 2].Rank) {
                        return player1;
                    } else if (player1.ScoreHand[player1.ScoreHand.Count - 2].Rank < player2.ScoreHand[player2.ScoreHand.Count - 2].Rank) {
                        return player2;
                    } else {
                        if (player1.ScoreHand[player1.ScoreHand.Count - 1].Rank > player2.ScoreHand[player2.ScoreHand.Count - 1].Rank) {
                            return player1;
                        } else if (player1.ScoreHand[player1.ScoreHand.Count - 1].Rank < player2.ScoreHand[player2.ScoreHand.Count - 1].Rank) {
                            return player2;
                        } else {
                            return null;
                        }
                    }
                }
            } else if (player1.Score == Score.Pair) {
                if (player1.ScoreHand[0].Rank > player2.ScoreHand[0].Rank) {
                    return player1;
                } else if (player1.ScoreHand[0].Rank < player2.ScoreHand[0].Rank) {
                    return player2;
                } else {
                    if (player1.ScoreHand[player1.ScoreHand.Count - 3].Rank > player2.ScoreHand[player2.ScoreHand.Count - 3].Rank) {
                        return player1;
                    } else if (player1.ScoreHand[player1.ScoreHand.Count - 3].Rank < player2.ScoreHand[player2.ScoreHand.Count - 3].Rank) {
                        return player2;
                    } else {
                        if (player1.ScoreHand[player1.ScoreHand.Count - 2].Rank > player2.ScoreHand[player2.ScoreHand.Count - 2].Rank) {
                            return player1;
                        } else if (player1.ScoreHand[player1.ScoreHand.Count - 2].Rank < player2.ScoreHand[player2.ScoreHand.Count - 2].Rank) {
                            return player2;
                        } else {
                            if (player1.ScoreHand[player1.ScoreHand.Count - 1].Rank > player2.ScoreHand[player2.ScoreHand.Count - 1].Rank) {
                                return player1;
                            } else if (player1.ScoreHand[player1.ScoreHand.Count - 1].Rank < player2.ScoreHand[player2.ScoreHand.Count - 1].Rank) {
                                return player2;
                            } else {
                                return null;
                            }
                        }
                    }
                } 
            } else {
                return GetBestHighestCard(player1, player2);
            }
        }
        #region ScoreHand

        public void GiveScoreHand(Player player) {

            player.ScoreHand.Clear();
            if (player.Score == Score.StraightFlush) {
                player.ScoreHand = GiveHandStraight(player);
                FixOnes(player);
            } else if (player.Score == Score.FourOfAKind) {
                GiveHandFourOfAKind(player);
                AddRemainingHighCards(player);
            } else if (player.Score == Score.FullHouse) {
                GiveHandFullHouse(player);
            } else if (player.Score == Score.Flush) {
                GiveHandFlush(player);
            } else if (player.Score == Score.Straight) {
                player.ScoreHand = GiveHandStraight(player);
                FixOnes(player);
            } else if (player.Score == Score.ThreeOfAKind) {
                GiveHandThreeOfAKind(player);
                AddRemainingHighCards(player);
            } else if (player.Score == Score.TwoPairs) {
                GiveHandAllPairs(player);
                if (player.ScoreHand.Count > 5) {
                    if (player.ScoreHand[0].Rank == player.ScoreHand[1].Rank && player.ScoreHand[2].Rank == player.ScoreHand[3].Rank && player.ScoreHand[4].Rank == player.ScoreHand[5].Rank) {
                        player.ScoreHand.Remove(player.ScoreHand[player.ScoreHand.Count - 2]);
                        player.ScoreHand.Remove(player.ScoreHand[player.ScoreHand.Count - 1]);
                    } 
                }
                AddRemainingHighCards(player);
            } else if (player.Score == Score.Pair) {
                GiveHandPair(player);
                AddRemainingHighCards(player);
            } else {
                GiveHandHighestFiveCards(player);
                player.ScoreHand.Sort();
            }
        }
        private void GiveHandHighestFiveCards(Player player) {
            for (int i = player.Cards.Count - 1; i >= 2; i--) {
                player.ScoreHand.Add(player.Cards[i]);
            }
        }
        private void AddRemainingHighCards(Player player) {
            bool cardFound;
            for (int i = player.Cards.Count - 1; i > 0; i--) {
                if (player.ScoreHand.Count >= 5) {
                    break;
                }
                cardFound = false;
                for (int j = 0; j < player.ScoreHand.Count - 1; j++) {
                    if (player.Cards[i].Rank == player.ScoreHand[j].Rank) {
                        cardFound = true;
                    }
                }
                if (!cardFound) {
                    player.ScoreHand.Add(player.Cards[i]);
                }
            }
        }
        public void GiveHandPair(Player player) {
            for (int i = player.Cards.Count - 2; i >= 0; i--) {
                if (player.Cards[i].Rank == player.Cards[i + 1].Rank) {
                    for (int j = i; j < i + 2; j++) {
                        player.ScoreHand.Add(player.Cards[j]);
                    }
                    break;
                }
            }
        }
        public void GiveHandAllPairs(Player player) {
            bool cardFound;
            for (int i = player.Cards.Count - 2; i >= 0 ; i--) {
                cardFound = false;
                for (int j = 0; j < player.ScoreHand.Count - 1; j++) {
                    if (player.Cards[i].Rank == player.ScoreHand[j].Rank) {
                        cardFound = true;
                    }
                }
                if (player.Cards[i].Rank == player.Cards[i + 1].Rank && !cardFound) {
                    for (int j = i; j < i + 2; j++) {
                        player.ScoreHand.Add(player.Cards[j]);
                    }
                }
            }
        }
        //private void GiveHandTwoPairs(Player player) {
        //    for (int i = 0; i < player.ScoreHand.Count - 1; i++) {
        //        if (player.Cards[i].Rank == player.Cards[i + 1].Rank && player.Cards[i + 1].Rank != player.Cards[i + 2].Rank) {
        //            for (int j = i; j < 2; j++) {
        //                player.ScoreHand.Add(player.Cards[j]);
        //            }
        //        }
        //    }
        //}
        public void GiveHandThreeOfAKind(Player player) {
            for (int i = 0; i < player.Cards.Count - 2; i++) {
                if (player.Cards[i].Rank == player.Cards[i + 1].Rank &&
                    player.Cards[i + 1].Rank == player.Cards[i + 2].Rank) {
                    for (int j = i; j < i + 3; j++) {
                        player.ScoreHand.Add(player.Cards[j]);
                    }
                }
            }
        }
        private void GiveHandFlush(Player player) {
            int c = 0, d = 0, h = 0, s = 0;
            foreach (Card element in player.Cards) {
                if (element.Suit == Suit.Clubs) {
                    c++;
                } else if (element.Suit == Suit.Diamonds) {
                    d++;
                } else if (element.Suit == Suit.Hearts) {
                    h++;
                } else if (element.Suit == Suit.Spades) {
                    s++;
                }
            }
            if (c > d && c > h && c > s) {
                AddCardsOfSuit(player, Suit.Clubs);
            } else if (d > c && d > h && d > s) {
                AddCardsOfSuit(player, Suit.Diamonds);
            } else if (h > c && h > d && h > s) {
                AddCardsOfSuit(player, Suit.Hearts);
            } else {
                AddCardsOfSuit(player, Suit.Spades);
            }
        }
        private void AddCardsOfSuit(Player player, Suit suit) {
            for (int i = player.Cards.Count - 1, count = 0; i >= 0; i--) {
                if (player.Cards[i].Suit == suit) {
                    player.ScoreHand.Add(player.Cards[i]);
                    count++;
                }
                if (count > 4) {
                    break;
                }
            }
        }
        private void FixOnes(Player player) {
            foreach(Card element in player.Cards) {
                if (element.Rank == (Rank)1) {
                    element.Rank = Rank.Ace;
                }
            }
        }
        public void GiveHandFullHouse(Player player) {
            GiveHandThreeOfAKind(player);
            GiveHandAllPairs(player);
            if (player.ScoreHand.Count > 5) { 
                player.ScoreHand.Remove(player.ScoreHand[player.ScoreHand.Count - 1]);
                player.ScoreHand.Remove(player.ScoreHand[player.ScoreHand.Count - 1]);
            }
        }
        private void GiveHandFourOfAKind(Player player) {
            for (int i = 0; i < player.Cards.Count - 3; i++) {
                if (player.Cards[i].Rank == player.Cards[i + 1].Rank &&
                    player.Cards[i + 1].Rank == player.Cards[i + 2].Rank &&
                    player.Cards[i + 2].Rank == player.Cards[i + 3].Rank) {
                    for (int j = i; j < i + 4; j++) {
                        player.ScoreHand.Add(player.Cards[j]); 
                    }
                }
            }
        }
        private List<Card> GiveHandStraight(Player player) {
            List<Card> cards = DuplicateDeck(player.Cards);
            cards.Sort();
            RemoveDublicateRank(cards, 0);
            for (int i = cards.Count - 5; i >= 0; i--) {
                if (cards[i].Rank + 1 == cards[i + 1].Rank &&
                    cards[i + 1].Rank + 1 == cards[i + 2].Rank &&
                    cards[i + 2].Rank + 1 == cards[i + 3].Rank &&
                    cards[i + 3].Rank + 1 == cards[i + 4].Rank) {
                    for (int j = i; j < i + 5; j++) {
                        player.ScoreHand.Add(cards[j]); 
                    }
                    return player.ScoreHand;
                }
                if (cards[i + 4].Rank == Rank.Ace) {
                    player.Cards = cards;
                    player.Cards[i + 4].Rank = (Rank)1;
                    player.Cards.Sort();
                    return GiveHandStraight(player);
                }
            }
            throw new System.Exception("duck");
        }
        #endregion

        #region Ecaluate/givescore
        // Checks if the cards in hand / on street matches the different win conditions in the game
        public Score Evaluate(List<Card> cards) {
            List<Card> sortedCards = DuplicateDeck(cards);
            sortedCards.Sort();

            if (HasRoyalFlush(sortedCards)) {
                return Score.RoyalFlush;
            } else if (HasStraightFlush(sortedCards)) {
                return Score.StraightFlush;
            } else if (HasFourOfAKind(sortedCards)) {
                return Score.FourOfAKind;
            } else if (HasFullHouse(sortedCards)) {
                return Score.FullHouse;
            } else if (HasFlush(sortedCards)) {
                return Score.Flush;
            } else if (HasStraight(sortedCards)) {
                return Score.Straight;
            } else if (HasThreeOfAKind(sortedCards)) {
                return Score.ThreeOfAKind;
            } else if (HasTwoPairs(sortedCards)) {
                return Score.TwoPairs;
            } else if (HasPair(sortedCards)) {
                return Score.Pair;
            } else {
                return GetBestCard(sortedCards);
            }
        }

        // Finds the best of 2 cards - 26/4/2019 check
        private Score GetBestCard(List<Card> sortedCards) {
            return (Score)sortedCards[sortedCards.Count - 1].Rank;
        }

        // Checks if the player has a pair - 26/4/2019 check
        public bool HasPair(List<Card> sortedCards) {
            for (int i = 0; i < sortedCards.Count - 1; i++) {
                if (sortedCards[i].Rank == sortedCards[i + 1].Rank) {
                    return true;
                }
            }
            return false;
        }

        // Check if the player has two pairs - 26/4/2019 check
        public bool HasTwoPairs(List<Card> cards) {
            List<Card> sortedCards = DuplicateDeck(cards);

            for (int i = 0; i < sortedCards.Count - 1; i++) {
                if (sortedCards[i].Rank == sortedCards[i + 1].Rank) {
                    return HasPair(RemoveUnfitRank(sortedCards, sortedCards[i].Rank));
                }
            }
            return false;
        }

        // Checks for three of a kind - 26/4/2019 check
        public bool HasThreeOfAKind(List<Card> sortedCards) {
            for (int i = 0; i < sortedCards.Count - 2; i++) {
                if (sortedCards[i].Rank == sortedCards[i + 1].Rank &&
                    sortedCards[i + 1].Rank == sortedCards[i + 2].Rank) {
                    return true;
                }
            }
            return false;
        }

        // Checks for a full house - 26/4/2019 check
        public bool HasFullHouse(List<Card> cards) {
            List<Card> sortedCards = DuplicateDeck(cards);
            for (int i = 0; i < sortedCards.Count - 2; i++) {
                if (sortedCards[i].Rank == sortedCards[i + 1].Rank &&
                    sortedCards[i + 1].Rank == sortedCards[i + 2].Rank) {
                    return HasPair(RemoveUnfitRank(sortedCards, sortedCards[i].Rank));
                }
            }
            return false;
        }

        // Checks for four of a kind - 26/4/2019 check
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

        // Checks for straight flush - 26/4/2019 check
        public bool HasStraightFlush(List<Card> cards) {
            List<Card> sortedCards = DuplicateDeck(cards);
            if (HasFlush(sortedCards)) {
                return HasStraight(FlushSuit(sortedCards));
            }
            return false;
        }

        // Checks if the player has a royal straight flush - 26/4/2019 check
        public bool HasRoyalFlush(List<Card> cards) {
            List<Card> sortedCards = DuplicateDeck(cards);
            if (HasFlush(sortedCards)) {
                FlushSuit(sortedCards);
                sortedCards.Sort(new CompareBySuit());
                for (int i = 0; i < sortedCards.Count - 4; i++) {
                    if (sortedCards[i].Rank == Rank.Ace &&
                        sortedCards[i + 1].Rank == Rank.King &&
                        sortedCards[i + 2].Rank == Rank.Queen &&
                        sortedCards[i + 3].Rank == Rank.Jack &&
                        sortedCards[i + 4].Rank == (Rank)10) {
                        return true;
                    }
                }
            }
            return false;
        }

        // Checks if the player has a straight - Bug: hvis der er 2 kort af samme rank i listen af de 5 kort der bruges til straighten, vil den ikke finde en straight
        public bool HasStraight(List<Card> cards) {
            List<Card> sortedCards = DuplicateDeck(cards);
            sortedCards.Sort();
            RemoveDublicateRank(sortedCards, 0);
            for (int i = 0; i <= sortedCards.Count - 5; i++) {
                if (sortedCards[i].Rank + 1 == sortedCards[i + 1].Rank &&
                    sortedCards[i + 1].Rank + 1 == sortedCards[i + 2].Rank &&
                    sortedCards[i + 2].Rank + 1 == sortedCards[i + 3].Rank &&
                    sortedCards[i + 3].Rank + 1 == sortedCards[i + 4].Rank) {
                    return true;
                }
                if (sortedCards[i + 4].Rank == Rank.Ace) {
                    sortedCards[i + 4].Rank = (Rank)1;
                    return HasStraight(sortedCards);
                }
            }
            return false;
        }
        public Card HasStraightAndCardReturn(List<Card> cards) {
            List<Card> sortedCards = DuplicateDeck(cards);
            sortedCards.Sort();
            RemoveDublicateRank(sortedCards, 0);
            for (int i = 0; i <= sortedCards.Count - 5; i++) {
                if (sortedCards[i].Rank + 1 == sortedCards[i + 1].Rank &&
                    sortedCards[i + 1].Rank + 1 == sortedCards[i + 2].Rank &&
                    sortedCards[i + 2].Rank + 1 == sortedCards[i + 3].Rank &&
                    sortedCards[i + 3].Rank + 1 == sortedCards[i + 4].Rank) {
                    return sortedCards[i + 4];
                }
                if (sortedCards[i + 4].Rank == Rank.Ace) {
                    sortedCards[i + 4].Rank = (Rank)1;
                    return HasStraightAndCardReturn(sortedCards);
                }
            }
            return null;
        }

        // Checks if the player has a flush - 26/4/2019 check
        public bool HasFlush(List<Card> hand) {
            int c = 0, d = 0, h = 0, s = 0;
            foreach (Card element in hand) {
                if (element.Suit == Suit.Clubs) {
                    c++;
                } else if (element.Suit == Suit.Diamonds) {
                    d++;
                } else if (element.Suit == Suit.Hearts) {
                    h++;
                } else if (element.Suit == Suit.Spades) {
                    s++;
                }
            }
            if (c > 4 || d > 4 || h > 4 || s > 4) {
                return true;
            }
            return false;
        }

        // Checks if the cards in hand / street forms a correct straight house - 26/4/2019 check
        private List<Card> FlushSuit(List<Card> cards) {
            int c = 0, d = 0, h = 0, s = 0;
            foreach (Card element in cards) {
                if (element.Suit == Suit.Clubs) {
                    c++;
                } else if (element.Suit == Suit.Diamonds) {
                    d++;
                } else if (element.Suit == Suit.Hearts) {
                    h++;
                } else if (element.Suit == Suit.Spades) {
                    s++;
                }
            }
            if (c > d && c > h && c > s) {
                return RemoveUnfitSuit(cards, Suit.Clubs);
            } else if (d > c && d > h && d > s) {
                return RemoveUnfitSuit(cards, Suit.Diamonds);
            } else if (h > c && h > d && h > s) {
                return RemoveUnfitSuit(cards, Suit.Hearts);
            } else {
                return RemoveUnfitSuit(cards, Suit.Spades);
            }
        }

        //Removes all cards which is not of a given suit - 26/4/2019 check
        private List<Card> RemoveUnfitSuit(List<Card> cards, Suit suit) {
            for (int index = cards.Count - 1; index >= 0; index--) {
                if (cards[index].Suit != suit) {
                    cards.Remove(cards[index]);
                }
            }
            return cards;
        }

        //Removes all cards which is of a given rank - 26/4/2019 check
        private List<Card> RemoveUnfitRank(List<Card> cards, Rank rank) {
            for (int index = cards.Count - 1; index >= 0; index--) {
                if (cards[index].Rank == rank) {
                    cards.Remove(cards[index]);
                }
            }
            return cards;
        }

        //Removes all dublicate ranks
        public List<Card> RemoveDublicateRank(List<Card> cards, int index) {
            if (cards.Count - 1 > index) {
                if (cards[index].Rank == cards[index + 1].Rank) {
                    cards.Remove(cards[index + 1]);
                    return RemoveDublicateRank(cards, index);
                } else {
                    return RemoveDublicateRank(cards, index + 1);
                }
            }
            return null;
        }
        #endregion

        #region Find the best in case of the SameScore
        public Player SameScore(Player player1, Player player2) {  // Missing implementation
            FastWinCalc win2 = new FastWinCalc();
            if (player1.Score == Score.RoyalFlush) {
                return null;
            } else if (player1.Score == Score.StraightFlush) {
                return BestStraight(player1, player2);
            } else if (player1.Score == Score.FourOfAKind) {
                return BestFourOfAKind(player1, player2);
            } else if (player1.Score == Score.FullHouse) {
                return BestFullHouse(player1, player2);
            } else if (player1.Score == Score.Flush) {
                return BestFlush(player1, player2);
            } else if (player1.Score == Score.Straight) {
                return BestStraight(player1, player2);
            } else if (player1.Score == Score.ThreeOfAKind) {
                return BestThreeOfAKind(player1, player2);
            } else if (player1.Score == Score.TwoPairs) {
                return BestTwoPairs(player1, player2);
            } else if (player1.Score == Score.Pair) {
                return BestPair(player1, player2);
            } else {
                return null;
            }
        }

        private Player GetBestHighestCard(Player player1, Player player2) {
            int i = player1.ScoreHand.Count - 1;
            int j = player2.ScoreHand.Count - 1;
            while (i >= 0 && j >= 0) {
                if (player1.ScoreHand[i].Rank != player2.ScoreHand[j].Rank) {
                    return player1.ScoreHand[i].Rank < player2.ScoreHand[j].Rank ? player2 : player1;
                }
                i--;
                j--;
            }
            return null;
        }
        private int GetBestHighestCard(List<Card> cards1, List<Card> cards2) {
            int i = cards1.Count - 1;
            int j = cards2.Count - 1;
            while (i >= 0 && j >= 0) {
                if (cards1[i].Rank != cards2[j].Rank) {
                    return cards1[i].Rank < cards2[j].Rank ? 0 : 1;
                }
                i--;
                j--;
            }
            return -1;
            throw new System.InvalidOperationException("Error in highest card bool edition");
        }

        //Returns the player with the best straight in case both get a straight - Bug: hvis der er 2 kort af samme rank i listen af de 5 kort der bruges til straighten, vil den ikke finde en straight
        public Player BestStraight(Player player1, Player player2) {

            if (HasStraightAndCardReturn(player1.Cards).Rank > HasStraightAndCardReturn(player2.Cards).Rank) {
                return player1;
            } else if (HasStraightAndCardReturn(player1.Cards).Rank < HasStraightAndCardReturn(player2.Cards).Rank) {
                return player2;
            } else
                return null;
            #region hideshitthatdoesntwork
            //List<Card> player1cards = DeckDuper3000(player1.Cards);
            //List<Card> player2cards = DeckDuper3000(player2.Cards);
            //player1cards.Sort();
            //player2cards.Sort();
            //RemoveDublicateRank(player1cards, 0);
            //RemoveDublicateRank(player2cards, 0);
            //for (int i = 0; i < player1cards.Count - 5; i++) {
            //    if(player1cards[i].Rank + 4 == player1cards[i + 4].Rank) {
            //        for (int j = 0; j < player2cards.Count - 5; j++) {
            //            if (player2cards[j].Rank + 4 == player2cards[j + 4].Rank) {
            //                if (player1cards[i].Rank == player2cards[j].Rank) {
            //                    return null;
            //                } else {
            //                    return (player1cards[i].Rank > player2cards[j].Rank ? player1 : player2);
            //                }
            //            }
            //        }
            //    }
            //}
            //if (player1cards[3].Rank == (Rank)5 && player1cards[player1cards.Count - 1].Rank == Rank.Ace) {
            //    if (player2cards[3].Rank == (Rank)5 && player2cards[player2cards.Count - 1].Rank == Rank.Ace) {
            //        return null;
            //    } else {
            //        return player2;
            //    }
            //}
            //if (player2cards[3].Rank == (Rank)5 && player2cards[player2cards.Count - 1].Rank == Rank.Ace) {
            //    if (player1cards[3].Rank == (Rank)5 && player1cards[player1cards.Count - 1].Rank == Rank.Ace) {
            //        return null;
            //    } else {
            //        return player1;
            //    }
            //} 
            #endregion
            throw new System.InvalidOperationException("BestStraight exited loop");
        }

        //Think it works, but need testing
        private Player BestFourOfAKind(Player player1, Player player2) {
            List<Card> player1Cards = DuplicateDeck(player1.Cards);
            List<Card> player2Cards = DuplicateDeck(player2.Cards);
            player1Cards.Sort();
            player2Cards.Sort();
            for (int i = 0; i < player1Cards.Count - 3; i++) {
                if (player1Cards[i].Rank == player1Cards[i + 1].Rank &&
                    player1Cards[i + 1].Rank == player1Cards[i + 2].Rank &&
                    player1Cards[i + 2].Rank == player1Cards[i + 3].Rank) {
                    for (int j = 0; i < player1Cards.Count - 3; j++) {
                        if (player2Cards[j].Rank == player2Cards[j + 1].Rank &&
                            player2Cards[j + 1].Rank == player2Cards[j + 2].Rank &&
                            player2Cards[j + 2].Rank == player2Cards[j + 3].Rank) {
                            if (player1Cards[i].Rank == player2Cards[j].Rank) {
                                RemoveUnfitRank(player1Cards, (player1Cards[i].Rank));
                                RemoveUnfitRank(player2Cards, (player2Cards[j].Rank));
                                GetXAmountOfHighestCard(player1Cards, 1);
                                GetXAmountOfHighestCard(player2Cards, 1);
                                if (GetBestHighestCard(player1Cards, player2Cards) == 1) {
                                    return player2;
                                } else if (GetBestHighestCard(player1Cards, player2Cards) == 0) {
                                    return player1;
                                } else {
                                    return null;
                                }
                            } else {
                                return (player1Cards[i].Rank > player2Cards[j].Rank ? player1 : player2);
                            }
                        }
                    }
                }
            }
            throw new System.InvalidOperationException();
        }

        private List<Card> GetXAmountOfHighestCard(List<Card> cards, int numberOfCards) {
            for (int i = cards.Count - numberOfCards - 1; i > 0; i--) {
                cards.Remove(cards[i]);
            }
            return cards;
        }

        //Need input on this one since it is drastically different to the bool version (HasFullHouse)
        private Player BestFullHouse(Player player1, Player player2) {
            List<Card> player1Cards = DuplicateDeck(player1.Cards);
            List<Card> player2Cards = DuplicateDeck(player2.Cards);
            player1Cards.Sort();
            player2Cards.Sort();
            if (BestThreeOfAKind(player1, player2) != null) {
                return BestThreeOfAKind(player1, player2);
            } else {
                for (int i = 0; i < player1.Cards.Count - 1; i++) {
                    if (player1.Cards[i].Rank == player1.Cards[i + 1].Rank &&
                        player1.Cards[i + 1].Rank == player1.Cards[i + 2].Rank) {
                        for (int j = 0; j < player2.Cards.Count - 1; j++) {
                            if (player2.Cards[j].Rank == player2.Cards[j + 1].Rank &&
                                player2.Cards[j + 1].Rank == player2.Cards[j + 2].Rank) {
                                Player player1Clone = (Player)player1.Clone();
                                Player player2Clone = (Player)player2.Clone();
                                player1Clone.Cards = RemoveUnfitRank(player1Clone.Cards, player1Clone.Cards[i].Rank);
                                player2Clone.Cards = RemoveUnfitRank(player2Clone.Cards, player2Clone.Cards[j].Rank);
                                
                                return BestPair(player1Clone, player2Clone);
                            }
                        }
                    }
                }
            }
            throw new System.InvalidOperationException();
        }

        private Player BestFlush(Player player1, Player player2) {
            Player player1Clone = (Player)player1.Clone();
            Player player2Clone = (Player)player2.Clone();
            FlushSuit(player1Clone.Cards);
            FlushSuit(player2Clone.Cards);
            player1Clone.Cards.Sort();
            player2Clone.Cards.Sort();
            return GetBestHighestCard(player1Clone, player2Clone);
        }

        private Player BestThreeOfAKind(Player player1, Player player2) {
            List<Card> player1Cards = DuplicateDeck(player1.Cards);
            List<Card> player2Cards = DuplicateDeck(player2.Cards);
            player1Cards.Sort();
            player2Cards.Sort();
            for (int i = 0; i < player1.Cards.Count - 1; i++) {
                if (player1.Cards[i].Rank == player1.Cards[i + 1].Rank &&
                    player1.Cards[i + 1].Rank == player1.Cards[i + 2].Rank) {
                    for (int j = 0; j < player2.Cards.Count - 1; j++) {
                        if (player2.Cards[j].Rank == player2.Cards[j + 1].Rank &&
                            player2.Cards[j + 1].Rank == player2.Cards[j + 2].Rank) {
                            if (player1.Cards[i].Rank == player2.Cards[j].Rank) {
                                player1.Cards = RemoveUnfitRank(player1Cards, (player1Cards[i].Rank));
                                player2.Cards = RemoveUnfitRank(player2Cards, (player2Cards[j].Rank));
                                player1.Cards = GetXAmountOfHighestCard(player1Cards, 2);
                                player2.Cards = GetXAmountOfHighestCard(player2Cards, 2);
                                if (GetBestHighestCard(player1Cards, player2Cards) == 1) {
                                    return player2;
                                } else if (GetBestHighestCard(player1Cards, player2Cards) == 0) {
                                    return player1;
                                } else {
                                    return null;
                                }
                            } else {
                                return (player1.Cards[i].Rank > player2.Cards[j].Rank ? player1 : player2);
                            }
                        }
                    }
                }
            }
            throw new System.InvalidOperationException();
        }

        private Player BestTwoPairs(Player player1, Player player2) {
            List<Card> player1Cards = DuplicateDeck(player1.Cards);
            List<Card> player2Cards = DuplicateDeck(player2.Cards);
            player1Cards.Sort();
            player2Cards.Sort();
            for (int i = player1Cards.Count - 1; i > 0; i--) {
                if (player1Cards[i].Rank == player1Cards[i - 1].Rank) {
                    for (int j = player2Cards.Count - 1; j > 0; j--) {
                        if (player2Cards[j].Rank == player2Cards[j - 1].Rank) {
                            if (player1Cards[i].Rank == player2Cards[j].Rank) {
                                for (int h = 0; h < player1.Cards.Count - 1; h++) {
                                    if (player1.Cards[h].Rank == player1.Cards[h + 1].Rank) {
                                        for (int k = 0; k < player2.Cards.Count - 1; k++) {
                                            if (player2.Cards[k].Rank == player2.Cards[k + 1].Rank) {
                                                if (player1.Cards[h].Rank == player2.Cards[k].Rank) {
                                                    Player player1Clone = (Player)player1.Clone();
                                                    Player player2Clone = (Player)player2.Clone();
                                                    player1Clone.Cards = RemoveUnfitRank(player1Clone.Cards, (player1Clone.Cards[i].Rank));
                                                    player2Clone.Cards = RemoveUnfitRank(player2Clone.Cards, (player2Clone.Cards[j].Rank));
                                                    player1Clone.Cards = RemoveUnfitRank(player1Clone.Cards, (player1Clone.Cards[h].Rank));
                                                    player2Clone.Cards = RemoveUnfitRank(player2Clone.Cards, (player2Clone.Cards[k].Rank));
                                                    player1Clone.Cards = GetXAmountOfHighestCard(player1Clone.Cards, 1);
                                                    player2Clone.Cards = GetXAmountOfHighestCard(player2Clone.Cards, 1);
                                                    return GetBestHighestCard(player1Clone, player2Clone); // Should check for highestCard here.
                                                } else {
                                                    return (player1.Cards[h].Rank > player2.Cards[k].Rank ? player1 : player2);
                                                }
                                            }
                                        }
                                    }
                                }
                                //Player player1clone = player1.Clone;
                                //Player player2clone = player2.Clone;
                                //RemoveUnfitRank(player1clone, (player1clone[i].Rank));
                                //RemoveUnfitRank(player2clone, (player2clone[j].Rank));
                                //return BestPair(player1clone, player2clone);
                            } else {
                                return (player1Cards[i].Rank > player2Cards[j].Rank ? player1 : player2);
                            }
                        }
                    }
                }
            }
            throw new System.InvalidOperationException();
        }

        private Player BestPair(Player player1, Player player2) {
            for (int i = player1.Cards.Count - 1; i > 0 ; i--) {
                if (player1.Cards[i].Rank == player1.Cards[i - 1].Rank) {
                    for (int j = player2.Cards.Count - 1; j > 0; j--) {
                        if (player2.Cards[j].Rank == player2.Cards[j - 1].Rank) {
                            if (player1.Cards[i].Rank == player2.Cards[j].Rank) {
                                Player player1Clone = (Player)player1.Clone();
                                Player player2Clone = (Player)player2.Clone();
                                player1Clone.Cards = GetXAmountOfHighestCard(player1Clone.Cards, 3);
                                player1Clone.Cards = GetXAmountOfHighestCard(player2Clone.Cards, 3);
                                return GetBestHighestCard(player1, player2); // Should check for highestCard here.
                            } else {
                                return (player1.Cards[i].Rank > player2.Cards[j].Rank ? player1 : player2);
                            }
                        }
                    }
                }
            }
            throw new System.InvalidOperationException("BestPair exited loop");
        } 
        #endregion
    }
}
/*
TÆLLER: 133784560
royalflush: 4324
straightflush: 37260
four: 224848
fullhouse: 3473184
flush: 4047644
straight: 6180020
three: 6461620
twopair: 31433400
pair: 58627800
 */
