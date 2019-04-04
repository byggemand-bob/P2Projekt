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
            Bet(CurrentPlayerIndex);
            Players[CurrentPlayerIndex].Action = PlayerAction.Call;
            UpdateState();
            Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].CycleStep++;
        }

        public void Check(object sender, EventArgs e) {
            Players[CurrentPlayerIndex].Action = PlayerAction.Check;
            UpdateState();
            Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].CycleStep++;
        }

        public void Fold(object sender, EventArgs e) {
            Players[CurrentPlayerIndex].Action = PlayerAction.Fold;
            Players[CurrentPlayerIndex].HasFolded = true;
            UpdateState();
            Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].CycleStep++;

        }

        public void Raise(object sender, EventArgs e) {
            Players[CurrentPlayerIndex].Action = PlayerAction.Raise;
            Bet(CurrentPlayerIndex);

            // Create functions for this.
            Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].ChangeTopBidder(CurrentPlayerIndex);
            UpdateState();
            Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].CycleStep++;
        }

        public void NewHand() {
            Hands.Add(new Hand(Players));
            HandInProgress = true;
        }




        #endregion

        private void Bet(int playerIndex) {
            if(Players[CurrentPlayerIndex].Action == PlayerAction.Call || Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].TopBidderIndex == CurrentPlayerIndex) {
                Players[CurrentPlayerIndex].CurrentBet += Settings.BlindSize; // Not sure how much should be bet
                Players[CurrentPlayerIndex].Stack -= Settings.BlindSize;
                Hands[Hands.Count - 1].Pot += Settings.BlindSize;
            } else {
                Players[CurrentPlayerIndex].CurrentBet += 2 * Settings.BlindSize; // Not sure how much should be bet
                Players[CurrentPlayerIndex].Stack -= 2 * Settings.BlindSize;
                Hands[Hands.Count - 1].Pot += 2 * Settings.BlindSize;
            }
        }

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
