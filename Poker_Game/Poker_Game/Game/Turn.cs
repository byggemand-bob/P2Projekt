namespace Poker_Game.Game {
    public class Turn {
        public PlayerAction Action { get; }

        #region Initialization
        public Turn(Player player) {
            Action = player.Action;
        }

        #endregion
    }
}
