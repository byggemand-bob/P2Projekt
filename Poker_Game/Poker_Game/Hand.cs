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


        #region Initialization
        public Hand(List<Player> players) {
            Pot = 0;
            Deck = new List<Card>();
            Street = new List<Card>();
            Rounds = new List<Round>();
            Players = players;
            //Players = GetActivePlayers(players);
            StartRound();
        }

        private List<Player> GetActivePlayers(List<Player> players) {
            List<Player> output = new List<Player>();
            foreach(Player player in players) {
                if(player.Stack > 0) {
                    output.Add(player);
                }
            }
            return output;
        }
        #endregion

        public void StartRound() {
            Rounds.Add(new Round(Players));
        }


        private bool IsFinished() {
            throw new NotImplementedException("Needs Card-validation");
            
            //if(PlayersLeft() > 1) {
            //    if() {

            //    }
            //}
        } // TODO

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
