using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class Hand {
        public int Pot { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> Street { get; set; }
        public List<Round> Rounds { get; set; }
        public List<Player> Players { get; set; }

        public Hand(List<Player> players) {
            Pot = 0;
            Deck = new List<Card>();
            Street = new List<Card>();
            Rounds = new List<Round>();
            Players = players;
        }

        public void Start() {
            while(!IsFinished()) {

            }
        }

        private bool IsFinished() {
            if(PlayersLeft() > 1) {
                if() {

                }
            }

        }

        private int PlayersLeft() {
            int playersLeft = 0;
            foreach(Player player in Players) {
                if(!player.HasFolded) {
                    playersLeft++;
                }
            }
            return playersLeft;
        }



    }
}
