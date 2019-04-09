using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    enum BlindType { Time, Rounds } // namechange
    class Settings {
        public int NumberOfPlayers { get; set; }
        public int StackSize { get; set; }
        public int BlindSize { get; set; }
        public bool RoundBased { get; set; }
        public int BlindIncrease { get; set; }
        public string PlayerName { get; set; }

        public Settings(int numberOfPlayers, int stackSize, int blindSize, bool roundBased, int blindIncrease, string playerName) {
            NumberOfPlayers = numberOfPlayers;
            StackSize = stackSize;
            BlindSize = blindSize;
            RoundBased = roundBased;
            BlindIncrease = blindIncrease;
            PlayerName = playerName;
        }
    }
}