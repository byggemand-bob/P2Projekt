namespace Poker_Game.Game {
    public class Turn {
        public PlayerAction Action { get; }
        public int Id { get; }

        #region Initialization
        public Turn(Player player) {
            Action = player.Action;
            Id = player.Id;
        }

        #endregion
    }
}
