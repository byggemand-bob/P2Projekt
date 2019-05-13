using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker_Game.Game;


namespace Poker_Game.Game {
    public class PokerGame {
        public int CurrentPlayerIndex { get; private set; }
        public int DealerButtonPosition { get; set; }
        public bool HandInProgress { get; private set; }
        public bool RoundInProgress { get; private set; }
        public List<Player> Players { get; set; }
        public List<Hand> Hands { get; set; }
        public Settings Settings { get; set; }



        #region Initialization

        public PokerGame(Settings settings) {
            Settings = settings;
            Players = InitializePlayers();
            Hands = new List<Hand>();
            DealerButtonPosition = 0;
            NewHand();
            CurrentPlayerIndex = GetStartingPlayerIndex();
        }
    
        public PokerGame() { // For testing purpose only
            Hands = new List<Hand>();
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
        public void Call() { // Method used for coding a press of Call-button in GameForm.
            if (CanCall()) {
                // Needs to be cut down
                Bet(Players[CurrentPlayerIndex], Math.Abs(Players[CurrentPlayerIndex].CurrentBet - Players[(CurrentPlayerIndex + 1) % 2].CurrentBet));
                Players[CurrentPlayerIndex].Action = PlayerAction.Call;
                Players[CurrentPlayerIndex].PreviousAction = PlayerAction.Call;
                CurrentRound().UncalledRaise = false;
                NewTurn();
                UpdateState();
            }
        }

        public void Check() { // Method used for coding a press of Check-button in GameForm.
            if (CanCheck()) { // Needs fixing
                CurrentPlayer().Action = PlayerAction.Check;
                Players[CurrentPlayerIndex].PreviousAction = PlayerAction.Check;
                CurrentPlayer().BetsTaken++;
                NewTurn();
                UpdateState(); }
        }

        public void Fold() { // Method used for coding a press of Fold-button in GameForm.
            Players[CurrentPlayerIndex].Action = PlayerAction.Fold;
            Players[CurrentPlayerIndex].PreviousAction = PlayerAction.Fold;
            NewTurn();
            UpdateState();
        }

        public void Raise() { // Method used for coding a press of Raise-button in GameForm.
            if(CanRaise()) {
                // Needs to be cut down
                Bet(Players[CurrentPlayerIndex],Math.Abs(Players[CurrentPlayerIndex].CurrentBet - Players[(CurrentPlayerIndex + 1) % 2].CurrentBet)+ 2 * Settings.BlindSize);
                Players[CurrentPlayerIndex].Action = PlayerAction.Raise;
                Players[CurrentPlayerIndex].PreviousAction = PlayerAction.Raise;
                CurrentPlayer().BetsTaken++;
                CurrentRound().UncalledRaise = true;

                // Create functions for this.
                NewTurn();
                CurrentTurn().Bet = Settings.BlindSize * 2;
                UpdateState();
            }
        }

        public void NewRound() {
            if(!RoundInProgress) {
                CurrentHand().StartRound(DealerButtonPosition);
                RoundInProgress = true;
                CurrentPlayerIndex = GetStartingPlayerIndex();
            }
        }

        public void NewHand() {
            if(!HandInProgress) {
                DealerButtonPosition = ++DealerButtonPosition % Settings.NumberOfPlayers; // Separate function?
                Hands.Add(new Hand(Settings, Players, DealerButtonPosition));
                PayBlinds();
                HandInProgress = true;
            }
        }

        private void NewTurn() {
            CurrentRound().NewTurn(Players[CurrentPlayerIndex], CurrentHand().Pot);
        }
       

        #endregion

        #region GameState

        public void UpdateState() { // WIP. Split up?
            HandInProgress = IsHandInProgress();
            RoundInProgress = IsRoundInProgress();
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Settings.NumberOfPlayers;

            if(!RoundInProgress) {
                NewRound();
            }

            if(!HandInProgress) {
                RewardWinners(GetWinners(CurrentHand()));
            }
        }

        private void RewardWinners(List<Player> winners) { // TODO: Make a split of the pot if more than one player wins.
            foreach(Player player in winners) {
                player.Stack += CurrentHand().Pot / winners.Count;
            }
        }

        // TODO Cleanup. Separate.
        public List<Player> GetWinners(Hand hand) {
            WinConditions wc = new WinConditions();
            List<Player> winners = new List<Player>();
            List<Player> players = GetUnfoldedPlayers(hand.Players);

            if(players.Count == 1) {
                return players;
            }

            foreach(Player player in players) {
                player.Cards.Sort();
                player.GetScore();
                if(winners.Count == 0) {
                    winners.Add(player);
                } else if(player.Score > winners[0].Score) {
                    winners.Clear();
                    winners.Add(player);
                } else if(player.Score == winners[0].Score) {
                    Player tPlayer = wc.SameScore(winners[0], player);
                    if (tPlayer == null)
                    {
                        winners.Add(player);
                    }
                    else
                    {
                        winners.Clear();
                        winners.Add(tPlayer);
                    }
                } 
            }
            return winners;
        }

        private List<Player> GetUnfoldedPlayers(List<Player> players) {
            List<Player> playersLeft = new List<Player>();
            foreach(Player player in players) {
                if(player.Action != PlayerAction.Fold) {
                    playersLeft.Add(player);
                }
            }

            return playersLeft;
        }

        private bool IsRoundInProgress() {
            return !CurrentRound().IsFinished();
        }

        private bool IsHandInProgress() {
            return !Hands[Hands.Count - 1].IsFinished();
        }

        private int GetStartingPlayerIndex() {
            return Players[0].IsSmallBlind ? 0 : 1;
        }

        //private int GetNextPlayerIndex() {
        //    int next = ++CurrentPlayerIndex % Settings.NumberOfPlayers;
        //    for (int i = 0; i < Settings.NumberOfPlayers; i++) {
        //        if (Players[next].Action != PlayerAction.Fold) {
        //            return next;
        //        }
        //        next = ++next % Settings.NumberOfPlayers;
        //    }
        //    return -1; // TODO: Do error-handling
        //}

        #endregion

        #region Utillity

        public bool CanCheck() {
            return Players[0].CurrentBet - Players[1].CurrentBet == 0;
        }

        public bool CanCall() {
            return Players[0].CurrentBet - Players[1].CurrentBet != 0;
        }

        public bool CanRaise() {
            return CurrentPlayer().BetsTaken < Settings.MaxBetsPerRound && CurrentPlayer().Stack >= Settings.BlindSize * 2;
        }

        public int CurrentHandNumber() {
            return Hands.Count;
        }

        public int CurrentRoundNumber() {
            return Hands[CurrentHandNumber() - 1].CurrentRoundNumber();
        }

        public int CurrentTurnNumber() {
            return Hands[CurrentHandNumber() - 1].Rounds[CurrentRoundNumber() - 1].CurrentTurnNumber();
        }

        public Turn CurrentTurn() {
            return CurrentRound().Turns[CurrentTurnNumber() - 1];
        }

        public Round CurrentRound() {
            return Hands[CurrentHandNumber() - 1].Rounds[CurrentRoundNumber() - 1];
        }

        public Hand CurrentHand() {
            return Hands[CurrentHandNumber() - 1];
        }

        public Player CurrentPlayer() {
            return Players[CurrentPlayerIndex];
        }

        public bool MoneyLeft(Player player) {
            return player.Stack != 0;
        }

        #endregion

        #region Betting

        private void Bet(Player player, int amount) {
            if (player.Stack >= amount) {
                player.CurrentBet += amount;
                player.Stack -= amount;
                CurrentHand().Pot += amount;
            }
        }

        private void PayBlinds() 
        {
            for (int i = 0; i < Settings.NumberOfPlayers; i++)
            {
                if (Players[i].IsBigBlind)
                {
                    Bet(Players[i], 2 * Settings.BlindSize);
                    Players[i].Action = PlayerAction.Raise;
                    Players[i].PreviousAction = PlayerAction.Raise;
                }
                else if (Players[i].IsSmallBlind)
                {
                    Bet(Players[i], Settings.BlindSize);
                }
            }
        }

        #endregion

    }
}
