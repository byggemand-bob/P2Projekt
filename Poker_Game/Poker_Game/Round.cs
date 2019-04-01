using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class Round {
        public List<Turn> Turns { get; set; }
        public List<Player> Players { get; set; }
        private int TopBidderIndex {
            get {
                return TopBidderIndex;
            }
            set {
                if(TopBidderIndex < Players.Count && TopBidderIndex >= 0) {
                    TopBidderIndex = value;
                } else {
                    throw new ArgumentException(value + " is not an allowed value");
                }
            }
        }
        private int CycleStep;

        #region Initialization
        public Round(List<Player> players) {
            Turns = new List<Turn>();
            Players = players;
            //Players = GetActivePlayers(players);
            TopBidderIndex = 0;
            CycleStep = 0;
        }

        private List<Player> GetActivePlayers(List<Player> players) {
            List<Player> output = new List<Player>();
            foreach(Player player in players) {
                if(player.Action != PlayerAction.Fold) {
                    output.Add(player);
                }
            }
            return output;
        }

        #endregion


        public void ChangeTopBidder(int playerIndex) {
            for(int i = 0; i < Players.Count; i++) {
                if(Players[i].CompareTo(Players[playerIndex]) == 0) {
                    TopBidderIndex = i;
                }
            }
        }


        public bool IsFinished() {
            throw new NotImplementedException();
        }

        private bool CycleFinished() {
            throw new NotImplementedException();
        }


    }

}
