namespace Poker_Game.Game {
    class Turn {
        public PlayerAction Action { get; set; }
        public int Bet { get; set; }
        public int PotSize { get; set; }

        #region Initialization

        public Turn(Player player) {
            Action = player.Action;
            // Bet = 
        }

        #endregion
    }
}
