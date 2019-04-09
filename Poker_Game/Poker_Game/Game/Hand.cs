using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class Hand {
        public int Pot { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> Street { get; set; } // Obsolete
        public List<Round> Rounds { get; set; }
        public List<Player> Players { get; set; }
        

        #region Initialization
        public Hand(List<Player> players) {
            Pot = 0;
            Deck = new List<Card>();
            Street = new List<Card>();
            Rounds = new List<Round>();
            Players = InitializePlayers(players);

            //Players = GetActivePlayers(players);
            StartRound();
        }

        private List<Player> InitializePlayers(List<Player> players) {
            List<Player> initPlayers = players;
            foreach (Player player in initPlayers) {
                player.Reset();
                player.DrawNewCardHand(Deck);
            }

            return initPlayers;
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
            UpdateStreet();
            Rounds.Add(new Round(Players));
        }

        public void UpdateStreet() {
            switch (Rounds.Count) {
                case 1: // Flop
                    DrawCards(3);
                    break;
                case 2: // Turn
                    DrawCards(1);
                    break;
                case 3: // River
                    DrawCards(1);
                    break;
                default:
                    // do something?
                break;
            }
        }

        private void DrawCards(int numberOfCards) {
            for (int i = 0; i < numberOfCards; i++) {
                Card newCard = new Card(Deck);
                Deck.Add(newCard);
                foreach (Player player in Players) {
                    player.Cards.Add(newCard);
                }
            }
        }

        public bool IsFinished() {         
            if(PlayersLeft() > 1) {
                if(Rounds.Count == 5) {
                    return true;
                }
            }

            return false;
        }

        public int RoundNumber() {
            return Rounds.Count;
        }

        private int PlayersLeft() {
            int playersLeft = 0;
            foreach(Player player in Players) {
                if(player.Action != PlayerAction.Fold) {
                    playersLeft++;
                }
            }

            return playersLeft;
        }

    }
}
