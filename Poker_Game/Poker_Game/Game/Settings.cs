namespace Poker_Game.Game {
    enum BlindType { Time, Rounds } // namechange
    class Settings {
        public int NumberOfPlayers { get; set; }
        public int StackSize { get; set; }
        public int BlindSize { get; set; }
        public bool RoundBased { get; set; }
        public int BlindIncrease { get; set; }
        public string PlayerName { get; set; }

        #region Initialization
        
        // Initializes the values of the settings, depending on GUI player input
        public Settings(int numberOfPlayers, int stackSize, int blindSize, bool roundBased, int blindIncrease, string playerName) {
            NumberOfPlayers = numberOfPlayers;
            StackSize = stackSize;
            BlindSize = blindSize;
            RoundBased = roundBased;
            BlindIncrease = blindIncrease;
            PlayerName = playerName;
        }

        #endregion
    }
}