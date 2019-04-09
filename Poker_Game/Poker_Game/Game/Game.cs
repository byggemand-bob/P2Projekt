using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class Game {
        public List<Player> Players { get; set; }
        public List<Hand> Hands { get; set; }
        public Settings Settings { get; set; }

        // Game state
        public int CurrentPlayerIndex { get; set; }
        public int DealerButtonPosition { get; set; }
        public bool HandInProgress { get; private set; }
        public bool RoundInProgress { get; private set; }

        #region Initialization
        public Game(Settings settings) {
            Settings = settings;
            Players = InitializePlayers();
            Hands = new List<Hand>();

            DealerButtonPosition = 0;
            CurrentPlayerIndex = GetStartingPlayerIndex();

            NewHand();
        }

        private List<Player> InitializePlayers() {
            List<Player> players = new List<Player>();
            for(int id = 0; id < Settings.NumberOfPlayers; id++) {
                players.Add(new Player(id, Settings.StackSize));
            }
            return players;
        }
        #endregion

        #region Actions
        public void Call() {
            Bet(CurrentPlayerIndex);
            Players[CurrentPlayerIndex].Action = PlayerAction.Call;
            UpdateState();
            Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].CycleStep++;
        }

        public void Check() {
            Players[CurrentPlayerIndex].Action = PlayerAction.Check;
            UpdateState();
            Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].CycleStep++;
        }

        public void Fold() {
            Players[CurrentPlayerIndex].Action = PlayerAction.Fold;
            Players[CurrentPlayerIndex].HasFolded = true;
            UpdateState();
            Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].CycleStep++;

        }

        public void Raise() {
            Players[CurrentPlayerIndex].Action = PlayerAction.Raise;
            Bet(CurrentPlayerIndex);

            // Create functions for this.
            Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].ChangeTopBidder(CurrentPlayerIndex);
            UpdateState();
            Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].CycleStep++;
        }

        public void NewHand() {
            if(!HandInProgress) {
                Hands.Add(new Hand(Players));
            }
        }

        public void NewRound() {
            if(!RoundInProgress) {
                Hands[Hands.Count - 1].StartRound();
            }
        }

        #endregion

        private void Bet(int playerIndex) {
            if(Players[CurrentPlayerIndex].Action == PlayerAction.Call || Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].TopBidderIndex == CurrentPlayerIndex) {
                Players[CurrentPlayerIndex].CurrentBet += Settings.BlindSize; // Not sure how much should be bet
                Players[CurrentPlayerIndex].Stack -= Settings.BlindSize;
                Hands[Hands.Count - 1].Pot += Settings.BlindSize;
            } else {
                Players[CurrentPlayerIndex].CurrentBet += 2 * Settings.BlindSize; // Not sure how much should be bet
                Players[CurrentPlayerIndex].Stack -= 2 * Settings.BlindSize; // CART optimization
                Hands[Hands.Count - 1].Pot += 2 * Settings.BlindSize;
            }
        } // Validation. Impossible to bet if money is too low

        private void UpdateState() { // WIP
            HandInProgress = IsHandInProgress();
            RoundInProgress = IsRoundInProgress();
            CurrentPlayerIndex = GetNextPlayerIndex();
        }

        private bool IsRoundInProgress() {
            return Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].IsFinished(); // Could be split up
        }

        private bool IsHandInProgress() {
            return Hands[Hands.Count - 1].IsFinished();
        }

        public int GetStartingPlayerIndex() {
            return (DealerButtonPosition + 3) % Settings.NumberOfPlayers;
        }

        private int GetNextPlayerIndex() {
            int next = CurrentPlayerIndex++ % Settings.NumberOfPlayers;
            for(int i = 0; i < Settings.NumberOfPlayers; i++) {

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
