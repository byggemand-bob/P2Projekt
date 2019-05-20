using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI.Opponent {
    class OpponentData {
        public string PlayerName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Hands {
            get { return Losses + Wins; }
        }
        public HandData BigBlindHands { get; set; }
        public HandData SmallBlindHands { get; set; }

        public OpponentData() {
            
        }

        public OpponentData(string playerName, int wins, int losses, HandData bigBlindHands, HandData smallBlindHands) {
            PlayerName = playerName;
            Wins = wins;
            Losses = losses;
            BigBlindHands = bigBlindHands;
            SmallBlindHands = smallBlindHands;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Wins.ToString());
            sb.AppendLine(Losses.ToString());
            sb.Append(BigBlindHands);
            sb.Append(SmallBlindHands);
            return sb.ToString();
        }
    }
}
