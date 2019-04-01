using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class Game {
        public List<Player> Players {
            get {
                return Players;
            } set {
                Players = value;
            }
        }
        public List<Hand> Hands { get; set; }
        public Settings Settings { get; set; }

        // Gamestate
        public int CurrentPlayerIndex {
            get {
                return CurrentPlayerIndex;
            }
            private set {
                if(value < Settings.NumberOfPlayers && value >= 0) {
                    DealerButtonPosition = value % Settings.NumberOfPlayers;
                }
            }
        }
        public bool HandInProgress { get; set; }
        public bool RoundInProgress { get; set; }
        public int DealerButtonPosition {
            get {
                return DealerButtonPosition;
            }
            private set {
                if(value < Settings.NumberOfPlayers && value >= 0) {
                    DealerButtonPosition = value % Settings.NumberOfPlayers;
                }
            }
        }


        #region Initialization
        public Game(Settings settings) {
            Settings = settings;
            Players = initializePlayers();
            Hands = new List<Hand>();

            DealerButtonPosition = 0;
            HandInProgress = false;
            RoundInProgress = false;
            CurrentPlayerIndex = GetStartingPlayerIndex();

        }

        private List<Player> initializePlayers() {
            List<Player> players = new List<Player>();
            for(int id = 0; id < Settings.NumberOfPlayers; id++) {
                players.Add(new Player(id, Settings.StackSize));
            }
            return players;
        }
        #endregion

        #region Actions
        public void Call(object sender, EventArgs e) {
            throw new NotImplementedException();
            UpdateState();
        }

        public void Check(object sender, EventArgs e) {
            throw new NotImplementedException();

        }

        public void Fold(object sender, EventArgs e) {
            Players[CurrentPlayerIndex].HasFolded = true;
            UpdateState();
        }

        public void Raise(object sender, EventArgs e) {
            throw new NotImplementedException();
            Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].ChangeTopBidder(CurrentPlayerIndex);
        }

        #endregion

        public void UpdateState() {
            RoundInProgress = UpdateRoundProgress();
            CurrentPlayerIndex = GetNextPlayerIndex();
        }


        private bool UpdateRoundProgress() {
            return Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].IsFinished(); // Could be split up
        }


        public int GetStartingPlayerIndex() {
            return (DealerButtonPosition + 3) % Settings.NumberOfPlayers;
        }

        public int GetNextPlayerIndex() {
            int next = CurrentPlayerIndex++ % Settings.NumberOfPlayers;
            for(int i = 0; i < Settings.NumberOfPlayers - 1; i++) {
                if(!Players[next].HasFolded) {
                    return next;
                }
                next = next++ % Settings.NumberOfPlayers;
            }
            return -1;
        }


        public void StartHand() {
            Hands.Add(new Hand(Players));
            HandInProgress = true;
        }
        

        private bool IsFinished() {
            int playersLeft = 0;
            foreach(Player player in Players) {
                if(player.Stack < 1) {
                    playersLeft++;
                    if(playersLeft > 1) {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
