namespace Poker_Game.Game {
    public class Settings {
        public int NumberOfPlayers { get; }
        public int StackSize { get; }
        public int BlindSize { get; }
        public string PlayerName { get; }
        public int MaxBetsPerRound { get; }


        #region Initialization
        public Settings(int numberOfPlayers, int stackSize, int blindSize, string playerName, int maxBetsPerRound) {
            NumberOfPlayers = numberOfPlayers;
            StackSize = stackSize;
            BlindSize = blindSize;
            PlayerName = playerName;
            MaxBetsPerRound = maxBetsPerRound;
        }

        #endregion
    }
}