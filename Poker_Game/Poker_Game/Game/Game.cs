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

        #region Actions
        public void Call() {
            if((Players[CurrentRound().TopBidderIndex].CurrentBet - Players[CurrentPlayerIndex].CurrentBet) != 0) {
                // Needs to be cut down
                Bet(Players[CurrentPlayerIndex],Players[CurrentRound().TopBidderIndex].CurrentBet - Players[CurrentPlayerIndex].CurrentBet);
                Players[CurrentPlayerIndex].Action = PlayerAction.Call;
                UpdateState();
                CurrentRound().CycleStep++;
            }
        }

        public void Check() {
            if(CanCheck()) { // Fix this
                Players[CurrentPlayerIndex].Action = PlayerAction.Check;
                UpdateState();
                CurrentRound().CycleStep++;
            }
        }

        public void Fold() {
            Players[CurrentPlayerIndex].Action = PlayerAction.Fold;
            Players[CurrentPlayerIndex].HasFolded = true;
            UpdateState();
            CurrentRound().CycleStep++;

        }

        public void Raise() {
            if(CurrentRound().Bets != 3) {
                // Needs to be cut down
                Bet(Players[CurrentPlayerIndex], (Players[CurrentRound().TopBidderIndex].CurrentBet - Players[CurrentPlayerIndex].CurrentBet) + (2 * Settings.BlindSize));
                Players[CurrentPlayerIndex].Action = PlayerAction.Raise;

                // Create functions for this.
                CurrentRound().ChangeTopBidder(CurrentPlayerIndex);
                UpdateState();
                CurrentRound().CycleStep++;
            }
        }

        public void NewHand() {
            if(!HandInProgress) {
                Hands.Add(new Hand(Players, DealerButtonPosition));
                PayBlinds();
                HandInProgress = true;
            }
        }

        public void NewRound() {
            if(!RoundInProgress) {
                Hands[Hands.Count - 1].StartRound(DealerButtonPosition);
                RoundInProgress = true;
            }
        }

        #endregion

        #region GameState

        private void UpdateState() { // WIP
            HandInProgress = IsHandInProgress();
            RoundInProgress = IsRoundInProgress();
            CurrentPlayerIndex = GetNextPlayerIndex();

            if(!RoundInProgress) {
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
            return -1; // TODO: Do error-handling
        }

        public bool CanCheck() {
            if() {
                return true;
            }

            return false;
        }


        #endregion
        
        #region Utillity

        public int CurrentHandNumber() {
            return Hands.Count;
        }

        public int CurrentRoundNumber() {
            return Hands[CurrentHandNumber() - 1].CurrentRoundNumber();
        }

        public Round CurrentRound() {
            return Hands[CurrentHandNumber() - 1].Rounds[CurrentRoundNumber() - 1];
        }

        public Hand CurrentHand() {
            return Hands[CurrentHandNumber() - 1];
        }

        public bool IsFinished() { // Checks if players still has $ in stack
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




        #endregion

        #region Betting

        private void Bet(Player player, int amount) {
            if(player.Stack >= amount) {
                player.CurrentBet += amount;
                player.Stack -= amount;
                CurrentHand().Pot += amount;
            } else {
                // Not enough money
                // TODO: Do something
            }
        }

        private void PayBlinds() {
            foreach(Player player in Players) {
                if(player.IsBigBlind) {
                    Bet(player, 2 * Settings.BlindSize);
                } else if(player.IsSmallBlind) {
                    Bet(player, Settings.BlindSize);
                }
            }
        }


        #endregion



    }
}
