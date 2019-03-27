using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    enum BlindType { Time, Rounds } // namechange
    class Settings {
        public int StackSize { get; set; }
        public int BlindSize { get; set; }
        public BlindType BlindType { get; set; }
        public int TurnTimeLimit { get; set; }
    }
}
