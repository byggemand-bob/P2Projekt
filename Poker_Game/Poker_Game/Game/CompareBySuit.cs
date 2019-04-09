using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class CompareBySuit : IComparer<Card> {
        public int Compare(Card x, Card y) {
            if(x.Suit.CompareTo(y.Suit) < 0) {
                return -1;
            } else if(x.Suit.CompareTo(y.Suit) > 0) {
                return 1;
            } else {
                if(x.Rank.CompareTo(y.Rank) < 0) {
                    return 1;
                } else if(x.Rank.CompareTo(y.Rank) > 0) {
                    return -1;
                }
            }

            return 0;
        } 
    }
}
