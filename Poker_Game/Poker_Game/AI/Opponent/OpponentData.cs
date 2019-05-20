using System.Text;

namespace Poker_Game.AI.Opponent {
    class OpponentData {
        public string PlayerName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Hands {
            get { return BigBlindHands.Hands + SmallBlindHands.Hands; }
        }
        public HandData BigBlindHands { get; set; }
        public HandData SmallBlindHands { get; set; }

        public OpponentData(string playerName) {
            PlayerName = playerName;
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
