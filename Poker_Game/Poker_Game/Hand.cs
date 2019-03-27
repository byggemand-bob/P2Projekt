using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class Hand {
        public int Pot { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> Street { get; set; }
        public List<Round> Rounds { get; set; }

    }
}
