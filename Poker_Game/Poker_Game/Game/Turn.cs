namespace Poker_Game.Game {
    public class Turn {
        public PlayerAction Action { get; set; }
        public int Bet { get; set; }
        public int PotSize { get; set; }

        #region Initialization

        public Turn(Player player, int potSize) {
            Action = player.Action;
            Bet = player.CurrentBet;
            PotSize = potSize;
        }

        #endregion
    }
}
