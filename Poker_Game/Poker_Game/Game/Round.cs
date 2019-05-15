using System.Collections.Generic;

namespace Poker_Game.Game {
    public class Round {
        public List<Turn> Turns { get; }
        public bool UncalledRaise { get; set; }
        private List<Player> Players { get; }

        #region Initialization
        public Round(List<Player> players) {
            Turns = new List<Turn>();
            Players = players;
            Players.ForEach(x => x.BetsTaken = 0);
            UncalledRaise = false;
        }

        #endregion

        public void NewTurn(Player currentPlayer) {
            Turns.Add(new Turn(currentPlayer));
        }

        public bool IsFinished() {
            foreach(Player player in Players) {
                if(player.Action == PlayerAction.Fold) {
                    return true;
                }
                if(UncalledRaise || !(player.Action == PlayerAction.Raise || player.Action == PlayerAction.Call ||
                     player.Action == PlayerAction.Check)) {
                    return false;
                }
            }
            return true;
        }

        public int CurrentTurnNumber() {
            return Turns.Count;
        }
    }
}