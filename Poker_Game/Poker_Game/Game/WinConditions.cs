using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class WinConditions {
        // flush is when all of the suits are the same
        private bool IsFlush(List<Card> table, List<Card> hand) {
            int C = 0, D = 0, H = 0, S = 0;
            foreach (Card element in table) {
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

        //// make sure the rank differs by one
        //// we can do this since the Hand is 
        //// sorted by this point
        //private static bool IsStraight(PokerHand h) {
        //    if (h[0].Rank == h[1].Rank - 1 &&
        //        h[1].Rank == h[2].Rank - 1 &&
        //        h[2].Rank == h[3].Rank - 1 &&
        //        h[3].Rank == h[4].Rank - 1)
        //        return true;
        //    // special case cause ace ranks lower
        //    // than 10 or higher
        //    if (h[1].Rank == global::Rank.Ten &&
        //        h[2].Rank == global::Rank.Jack &&
        //        h[3].Rank == global::Rank.Queen &&
        //        h[4].Rank == global::Rank.King &&
        //        h[0].Rank == global::Rank.Ace)
        //        return true;
        //    return false;
        //}

        //// must be flush and straight and
        //// be certain cards. No wonder I have
        //private static bool IsRoyalFlush(PokerHand h) {
        //    if (IsStraight(h) && IsFlush(h) &&
        //          h[0].Rank == global::Rank.Ace &&
        //          h[1].Rank == global::Rank.Ten &&
        //          h[2].Rank == global::Rank.Jack &&
        //          h[3].Rank == global::Rank.Queen &&
        //          h[4].Rank == global::Rank.King)
        //        return true;
        //    return false;
        //}

        //private static bool IsStraightFlush(PokerHand h) {
        //    if (IsStraight(h) && IsFlush(h))
        //        return true;
        //    return false;
        //}

        ///*
        // * Two choices here, the first four cards
        // * must match in rank, or the second four
        // * must match in rank. Only because the hand
        // * is sorted
        // */
        //private static bool IsFourOfAKind(PokerHand h) {
        //    if (h[0].Rank == h[1].Rank &&
        //        h[1].Rank == h[2].Rank &&
        //        h[2].Rank == h[3].Rank)
        //        return true;
        //    if (h[1].Rank == h[2].Rank &&
        //        h[2].Rank == h[3].Rank &&
        //        h[3].Rank == h[4].Rank)
        //        return true;
        //    return false;
        //}

        ///*
        // * two choices here, the pair is in the
        // * front of the hand or in the back of the
        // * hand, because it is sorted
        // */
        //private static bool IsFullHouse(PokerHand h) {
        //    if (h[0].Rank == h[1].Rank &&
        //        h[2].Rank == h[3].Rank &&
        //        h[3].Rank == h[4].Rank)
        //        return true;
        //    if (h[0].Rank == h[1].Rank &&
        //        h[1].Rank == h[2].Rank &&
        //        h[3].Rank == h[4].Rank)
        //        return true;
        //    return false;
        //}

        ///*
        // * three choices here, first three cards match
        // * middle three cards match or last three cards
        // * match
        // */
        //private static bool IsThreeOfAKind(PokerHand h) {
        //    if (h[0].Rank == h[1].Rank &&
        //        h[1].Rank == h[2].Rank)
        //        return true;
        //    if (h[1].Rank == h[2].Rank &&
        //        h[2].Rank == h[3].Rank)
        //        return true;
        //    if (h[2].Rank == h[3].Rank &&
        //        h[3].Rank == h[4].Rank)
        //        return true;
        //    return false;
        //}

        ///*
        // * three choices, two pair in the front,
        // * separated by a single card or
        // * two pair in the back
        // */
        //private static bool IsTwoPair(PokerHand h) {
        //    if (h[0].Rank == h[1].Rank &&
        //        h[2].Rank == h[3].Rank)
        //        return true;
        //    if (h[0].Rank == h[1].Rank &&
        //        h[3].Rank == h[4].Rank)
        //        return true;
        //    if (h[1].Rank == h[2].Rank &&
        //        h[3].Rank == h[4].Rank)
        //        return true;
        //    return false;
        //}

        ///*
        // * 4 choices here
        // */
        //private static bool IsJacksOrBetter(PokerHand h) {
        //    if (h[0].Rank == h[1].Rank &&
        //        h[0].IsJacksOrBetter())
        //        return true;
        //    if (h[1].Rank == h[2].Rank &&
        //        h[1].IsJacksOrBetter())
        //        return true;
        //    if (h[2].Rank == h[3].Rank &&
        //        h[2].IsJacksOrBetter())
        //        return true;
        //    if (h[3].Rank == h[4].Rank &&
        //        h[3].IsJacksOrBetter())
        //        return true;
        //    return false;
        //}

        //// must be in order of hands and must be
        //// mutually exclusive choices
        //public static Pokerscore Score(PokerHand h) {
        //    if (IsRoyalFlush(h))
        //        return Pokerscore.RoyalFlush;
        //    else if (IsStraightFlush(h))
        //        return Pokerscore.StraightFlush;
        //    else if (IsFourOfAKind(h))
        //        return Pokerscore.FourOfAKind;
        //    else if (IsFullHouse(h))
        //        return Pokerscore.FullHouse;
        //    else if (IsFlush(h))
        //        return Pokerscore.Flush;
        //    else if (IsStraight(h))
        //        return Pokerscore.Straight;
        //    else if (IsThreeOfAKind(h))
        //        return Pokerscore.ThreeOfAKind;
        //    else if (IsTwoPair(h))
        //        return Pokerscore.TwoPair;
        //    else if (IsJacksOrBetter(h))
        //        return Pokerscore.JacksOrBetter;
        //    else
        //        return Pokerscore.None;
        //}
    }
}
