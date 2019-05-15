namespace Poker_Game.AI.Opponent {
    class VPIPData {
        public string PlayerName { get; }
        public int NumberCalls { get; set; }
        public int NumberOfHands { get; set; }
        public int NumberRaises { get; set; }

        public VPIPData(string playerName, int numberOfHands, int numberCalls, int numberRaises) {
            PlayerName = playerName;
            NumberCalls = numberCalls;
            NumberOfHands = numberOfHands;
            NumberRaises = numberRaises;
        }
    }
}
