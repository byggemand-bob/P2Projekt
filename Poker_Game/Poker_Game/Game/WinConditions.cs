using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class WinConditions {
        private static bool isFlush(PokerHand h) {//taget fra PokerLogic
            if (h[0].suit == h[1].suit &&
                h[1].suit == h[2].suit &&
                h[2].suit == h[3].suit &&
                h[3].suit == h[4].suit)
                return true;
            return false;
        }


    }
}
