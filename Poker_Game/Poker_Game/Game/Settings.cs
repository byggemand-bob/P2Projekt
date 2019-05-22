using Poker_Game.AI;

namespace Poker_Game.Game {
    public class Settings {
        public int NumberOfPlayers { get; }
        public int StackSize { get; }
        public int BlindSize { get; }
        public int BetSize { get; set; }
        public string PlayerName { get; }
        public int MaxBetsPerRound { get; }
        public AiMode EvaluationStyle { get; }

        #region Initialization
        public Settings(int numberOfPlayers, int stackSize, int blindSize, string playerName, int maxBetsPerRound, AiMode evalStyle) {
            NumberOfPlayers = numberOfPlayers;
            StackSize = stackSize;
            BlindSize = blindSize;
            PlayerName = playerName;
            MaxBetsPerRound = maxBetsPerRound;
            BetSize = 2 * BlindSize;
            EvaluationStyle = evalStyle;
        }

        #endregion
    }
}