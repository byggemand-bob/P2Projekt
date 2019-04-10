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

            DealerButtonPosition = 1;
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


        //Validation needed
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
                HandInProgress = true;
            }
        }

        public void NewRound() {
            if(!RoundInProgress) {
                Hands[Hands.Count - 1].StartRound();
                RoundInProgress = true;
            }
        }

        #endregion

        // Validation. Impossible to bet if money is too low
        

        #region GameState

        private void UpdateState() { // WIP
            HandInProgress = IsHandInProgress();
            RoundInProgress = IsRoundInProgress();
            CurrentPlayerIndex = GetNextPlayerIndex();

            if(!RoundInProgress && !HandInProgress) {
                NewRound();
            }
        }

        private bool IsRoundInProgress() {
            return !Hands[Hands.Count - 1].Rounds[Hands[Hands.Count - 1].Rounds.Count - 1].IsFinished(); // Could be split up
        }

        private bool IsHandInProgress() {
            return !Hands[Hands.Count - 1].IsFinished();
        }

        private int GetStartingPlayerIndex() {
            return (DealerButtonPosition + 3) % Settings.NumberOfPlayers;
        }

        private int GetNextPlayerIndex() {
            int next = ++CurrentPlayerIndex % Settings.NumberOfPlayers;
            for(int i = 0; i < Settings.NumberOfPlayers; i++) {
                if(!Players[next].HasFolded) {
                    return next;
                }
                next = ++next % Settings.NumberOfPlayers;
            }
            return -1;
        }


        #endregion


        #region Utillity

        public int CurrentHandNumber() {
            return Hands.Count;
        }

        public bool IsFinished() {
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

        private void Bet(int amount) {
            if(Players[CurrentPlayerIndex].Stack >= amount) {
                Players[CurrentPlayerIndex].CurrentBet += amount;
                Players[CurrentPlayerIndex].Stack -= amount;
                Hands[Hands.Count - 1].Pot += amount;
            } else {
                // Not enough money
                //TODO: Do something
            }
        }


        #endregion





    }
}
