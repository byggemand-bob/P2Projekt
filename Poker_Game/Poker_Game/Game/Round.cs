using System.Collections.Generic;

namespace Poker_Game.Game {
    public class Round {
        public int Bets { get; set; }
        public List<Turn> Turns { get; set; }
        private List<Player> Players { get; set; }
        public bool UncalledRaise;
        private readonly int _maxBets;


        public Round(Settings settings, List<Player> players) {
            Turns = new List<Turn>();
            Players = players;
            Bets = 0;
            _maxBets = settings.MaxBetsPerRound;
            Players.ForEach(x => x.BetsTaken = 0);
            UncalledRaise = false;
        }

        public void NewTurn(Player currentPlayer, int potSize) {
            Turns.Add(new Turn(currentPlayer, potSize));
        }


        public bool IsFinished() {
            foreach(Player player in Players) {
                if(UncalledRaise || !(player.Action == PlayerAction.Raise || player.Action == PlayerAction.Call ||
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
            foreach(Player player in Players) {
                if(player.Action != PlayerAction.Call) {
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