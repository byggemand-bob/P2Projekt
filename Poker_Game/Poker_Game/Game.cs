using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class Game {
        public bool IsFinished = false;
        public int DealerButtonPosition {
            get {
                return DealerButtonPosition;
            } set {
                if(value < Players.Count && value >= 0) {
                    DealerButtonPosition = value % Settings.NumberOfPlayers;
                }
            }
        }
        public List<Player> Players {
            get {
                return Players;
            } set {
                Players = value;
            }
        }
        public List<Hand> Hands { get; set; }
        public Settings Settings { get; set; }

        #region Initialization
        public Game(Settings settings) {
            Settings = settings;
            Players = initializePlayers();
            Hands = new List<Hand>();
            DealerButtonPosition = 0;
        }

        private List<Player> initializePlayers() {
            List<Player> players = new List<Player>();
            for(int i = 0; i < Settings.NumberOfPlayers; i++) {
                players.Add(new Player(Settings.StackSize));
            }
            return players;
        }
        #endregion


        public void Start() {
            while(!IsFinished) { // Mulig optimering. Fjern IsFininshed og byt ud med IsGameover()
                Hands.Add(new Hand());
                Hands[Hands.Count - 1].Start();
                IsFinished = IsGameOver();
            }
        }

        private bool IsGameOver() {
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
