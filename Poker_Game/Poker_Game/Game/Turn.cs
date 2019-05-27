namespace Poker_Game.Game {
    public class Turn {
        #region Initialization

        public Turn(Player player) {
            Action = player.Action;
        }

        #endregion

        public PlayerAction Action { get; }
    }
}