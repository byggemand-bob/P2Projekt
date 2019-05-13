using System.Collections.Generic;

namespace Poker_Game.Game {
    public class Round {
        public int Bets { get; set; }
        public List<Turn> Turns { get; set; }
        private List<Player> Players { get; set; }

        private readonly int _maxBets;

        #region Initialization
        public Round(Settings settings, List<Player> players) {
            Turns = new List<Turn>();
            Players = players;
            Bets = 0;
            _maxBets = settings.MaxBetsPerRound;
            Players.ForEach(x => x.BetsTaken = 0);
        }


        #endregion

        #region Actions

        public void NewTurn(Player currentPlayer, int potSize) {
            Turns.Add(new Turn(currentPlayer, potSize));
        }


        #endregion

        #region Utility

        public bool IsFinished() {
            foreach(Player player in Players) {
                if(!(player.Action == PlayerAction.Raise || player.Action == PlayerAction.Call ||
                     player.Action == PlayerAction.Check)) {
                    return false;
                }
            }

            return true;
        }

        private bool AllChecked() {
            foreach (Player player in Players) {
                if (player.Action != PlayerAction.Check) {
                    return false;
                }
            }

            return true;
        }

        private bool AllCalled() {
            for(int i = 0; i < Players.Count; i++) {
                if(Players[i].Action != PlayerAction.Call) {
                    return false;
                }
            }

            return true;
        }

        public int CurrentTurnNumber() {
            return Turns.Count;
        }


        

        #endregion

    }
}
