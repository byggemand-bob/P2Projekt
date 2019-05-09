using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class OutsCalculator {
        public int CompareOuts(List<Card> cardHand, List<Card> street) {
            if(HasFlushChance(cardHand) && HasStraightChance(cardHand)) {
                return GetFlushOuts(cardHand, street) + GetStraightOuts(cardHand, street);
            }
            if(HasFlushChance(cardHand) && HasStraightChance(cardHand) == false) {
                return GetFlushOuts(cardHand, street);
            }
            if(HasFlushChance(cardHand) == false && HasStraightChance(cardHand)) {
                return GetStraightOuts(cardHand, street);
            }
            if(HasPair(cardHand) && !HasFlushChance(cardHand)) {
                return GetPairOuts(cardHand, street);
            }

            //TODO We need to add more conditions 

            return 0;
        }
        private int GetRankDifference(List<Card> cardHand) {
            return Math.Abs(cardHand[0].Rank - cardHand[1].Rank);
        }

        private bool HasFlushChance(List<Card> cardHand) {
            return cardHand[0].Suit == cardHand[1].Suit;
        }

        private bool HasStraightChance(List<Card> cardHand) {
            return Math.Abs(cardHand[1].Rank - cardHand[0].Rank) <= 3;
        }

        private bool HasPair(List<Card> cardHand) {
            return cardHand[0].Rank == cardHand[1].Rank;
        }

        #region StraightOuts
        private int GetStraightOuts(List<Card> cardHand, List<Card> street) {
            //Checks for cards that are in range of a straight compared to the players hand

            WinConditions wc = new WinConditions();
            List<Card> straightCards = new List<Card> { cardHand[0], cardHand[1] };
            int cardRange = GetRankDifference(cardHand);

            // Inside straight chance

            if(cardRange == 4) {
                foreach(var element in street) {
                    if(element.Rank >= street.Min(s => s.Rank) && (element.Rank <= street.Max(s => s.Rank))) {
                        straightCards.Add(element);
                    }
                }
            } else if(cardRange == 3) {
                foreach(var element in street) {
                    if(element.Rank >= street.Min(s => s.Rank) && element.Rank <= street.Max(s => s.Rank) ||
                        element.Rank >= street.Min(s => s.Rank - 1) ||
                        element.Rank <= street.Max(s => s.Rank + 1)) {
                        straightCards.Add(element);
                    }
                }
            } else if(cardRange == 2) {
                foreach(var element in street) {
                    if(element.Rank >= street.Min(s => s.Rank) &&
                        element.Rank <= street.Max(s => s.Rank) ||
                        element.Rank >= street.Min(s => s.Rank - 2) ||
                        element.Rank <= street.Max(s => s.Rank + 2)) {
                        straightCards.Add(element);
                    }
                }
            } else if(cardRange == 1) { // Open ended connector
                foreach(var element in street) {
                    if(element.Rank >= street.Min(s => s.Rank) &&
                        element.Rank <= street.Max(s => s.Rank) ||
                        element.Rank >= street.Min(s => s.Rank - 3) ||
                        element.Rank <= street.Max(s => s.Rank + 3)) {
                        straightCards.Add(element);
                    }
                }
            }

            wc.RemoveDublicateRank(straightCards, 0); // TODO: FIX
            return 5 - straightCards.Count;

            return 0;
        }
        #endregion

        #region FlushOuts

        private int GetFlushOuts(List<Card> cardHand, List<Card> street) {
            var flushCards = street
                .Where(x => x.Suit == cardHand[0].Suit)
                .OrderBy(x => x.Rank);

            return 13 /*Cards in a suit*/ - (flushCards.Count() + cardHand.Count);
        }

        #endregion

        #region PairOuts
        private int GetPairOuts(List<Card> cardHand, List<Card> street) {
            int countOfAKind = 0, equalsInStreet = 0, multiplePairCount = 0;
            List<Card> equalsToCardInHand = new List<Card>();
            List<Card> equalCardsOnTable = new List<Card>();
            List<Card> pairCards = new List<Card>();

            foreach(var element in street) {
                if(element.Rank == cardHand[0].Rank) {
                    countOfAKind++;
                    equalsToCardInHand.Add(element);
                }
            }

            // Skal kunne tage forbehold for flere forskellige par på streeten

            for(int i = 0; i < street.Count; i++) {
                for(int j = 0; j < street.Count; j++) {
                    if(street[i].Rank == street[j].Rank) {
                        equalCardsOnTable.Add(street[i]);
                    }
                }
            }

            pairCards.AddRange(equalsToCardInHand);
            pairCards.AddRange(equalCardsOnTable);

            //Tjekker om kortene er ens
            for(int k = 0; k < pairCards.Count; k++) {
                for(int l = 1; l < pairCards.Count; l++) {
                    if(pairCards[k].Rank != pairCards[l].Rank) {
                        multiplePairCount++;
                    }
                }
            }


            if(countOfAKind == 0 && equalsInStreet == 0) {
                // 1 par - hvor mange odds har man her? Vel ligeså meget de 3 kort på floppet, da hver kan rammes 2x mere for et fuldt hus? Men måske det er for langt at se frem?
                return 2;
            } else if(countOfAKind == 1 && equalsInStreet == 0) {
                // Tre ens
                return 7;
            } else if(countOfAKind == 0 && equalsInStreet == 1) {
                // To par
                return 4;
            } else if(countOfAKind == 1 && equalsInStreet == 1) {
                // Full house

            } else if(countOfAKind == 2 && equalsInStreet == 1) {
                // Fire ens
                // Fuld ild!!
            } else if(countOfAKind == 1 && equalsInStreet > 2) {
                // 3 ens, 2 par på streeten
                // Call / Raise
            } else if(countOfAKind == 0 && equalsInStreet == 3 && multiplePairCount > 1) {
                foreach(var element in equalCardsOnTable) {
                    if(cardHand[0].Rank < element.Rank) {
                        //Pairs on table are higher than hours, so we can only get split pot, or loose to a better pair
                        // Check / Fold
                    }
                }
            }

            return 0;
        }

        #endregion
    }
}