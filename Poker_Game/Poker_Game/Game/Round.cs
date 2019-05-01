using System.Collections.Generic;

namespace Poker_Game.Game {
    public class Round {
        public int TopBidderIndex { get; set; }
        public int CycleStep { get; set; }
        public int Bets { get; set; }

        public List<Turn> Turns { get; set; }
        public List<Player> Players { get; set; }

        #region Initialization
        public Round(List<Player> players) {
            Turns = new List<Turn>();
            Players = players;
            //Players = GetActivePlayers(players);
            TopBidderIndex = 0;
            CycleStep = 0;
            Bets = 0;
        }

        private List<Player> GetActivePlayers(List<Player> players) // Returns a List of players who has not folded.
        {
            List<Player> activePlayers = new List<Player>();
            foreach(Player player in players) {
                if (player.Action != PlayerAction.Fold) {
                    activePlayers.Add(player);
                }
            }
            return activePlayers;
        }

        #endregion

        #region Actions

        public void ChangeTopBidder(int playerIndex) { // Validation needed. Cannot bet more than 3 times
            TopBidderIndex = playerIndex;
            CycleStep = 0;

            Bets++;
        }

        public void NewTurn(Player currentPlayer, int potSize) {
            Turns.Add(new Turn(currentPlayer, potSize));
        }


        #endregion

        #region Utility

        public bool IsFinished() {
            return AllChecked() || (Turns.Count > Players.Count && AllCalled()); // TODO: Rework
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
            if(Bets == 3 && CycleFinished()) {
                for (int i = 0; i < Players.Count; i++) {
                    if (Players[i].Action != PlayerAction.Call && i != TopBidderIndex) {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        private bool CycleFinished() { // One cycle is one turn for each player
            return CycleStep > Players.Count;
        }

        #endregion

    }
}
