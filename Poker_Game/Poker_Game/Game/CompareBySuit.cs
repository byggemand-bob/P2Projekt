using System;
using System.Collections.Generic;

namespace Poker_Game.Game {
    public class CompareBySuit : IComparer<Card> {
        public int Compare(Card x, Card y) {
            if(x == null || y == null) {
                throw new ArgumentNullException(x == null ? "x" : "y");
            }

            if(x.Suit.CompareTo(y.Suit) < 0) {
                return -1;
            }
            if(x.Suit.CompareTo(y.Suit) > 0) {
                return 1;
            }
            if(x.Rank.CompareTo(y.Rank) < 0) {
                return 1;
            }
            if(x.Rank.CompareTo(y.Rank) > 0) {
                return -1;
            }

            return 0;
        }
    }
}
