using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class Player {
        public int Stack { get; set; }
        public bool IsSmallBlind { get; set; }
        public bool IsBigBlind { get; set; }
        public bool HasFolded { get; set; }
        public List<Card> Cards = new List<Card>();
    }
}
