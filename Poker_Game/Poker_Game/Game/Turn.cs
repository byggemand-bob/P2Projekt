namespace Poker_Game.Game {
    public class Turn {
        public PlayerAction Action { get; set; }
        public int Bet { get; set; }
        public int PotSize { get; set; }
        public int Id { get; set; }
        public int Stack { get; set; }


        #region Initialization

        public Turn(Player player, int potSize) {
            Action = player.Action;
            Bet = 0;
            Id = player.Id;
            PotSize = potSize;
            Stack = player.Stack;
        }

        #endregion
    }
}
