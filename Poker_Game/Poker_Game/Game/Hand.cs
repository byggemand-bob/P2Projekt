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
        public List<Card> Street { get; set; }  // optimize
        public List<Round> Rounds { get; set; }
        public List<Player> Players { get; set; }

        #region Initialization
        public Hand(List<Player> players, int dealerButtionPosition) {
            Pot = 0;
            Deck = new List<Card>();
            Street = new List<Card>();
            Rounds = new List<Round>();
            Players = InitializePlayers(players, dealerButtionPosition);

            //Players = GetActivePlayers(players);
            StartRound(dealerButtionPosition);
        }

        private List<Player> InitializePlayers(List<Player> players, int dealerButtonPosition) {
            List<Player> initPlayers = players;
            for(int i = 0; i < initPlayers.Count; i++) {
                initPlayers[i].Reset();
                initPlayers[i].DrawNewCardHand(Deck);
                
                // Distribute blinds
                if(i == (dealerButtonPosition + 1) % initPlayers.Count) {
                    initPlayers[i].IsSmallBlind = true;
                } else if(i == (dealerButtonPosition + 2) % initPlayers.Count) {
                    initPlayers[i].IsBigBlind = true;
                }
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

        public void StartRound(int dealerButtonPosition) {
            UpdateStreet();
            Rounds.Add(new Round(Players, dealerButtonPosition));
            ResetActions();
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

        private void ResetActions() {
            foreach(Player player in Players) {
                player.Action = PlayerAction.None;
            }
        }

        private void DrawCards(int numberOfCards) {
            for (int i = 0; i < numberOfCards; i++) {
                Card newCard = new Card(Deck);
                Deck.Add(newCard);
                Street.Add(newCard);
                foreach (Player player in Players) {
                    player.Cards.Add(newCard);
                }
            }
        }

        public bool IsFinished() {         
            if(PlayersLeft() > 1) {
                if(Rounds.Count == 4) { // Corrected from == 5 to == 4
                    return true;
                }
            }

            return false;
        }

        public int CurrentRoundNumber() {
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
