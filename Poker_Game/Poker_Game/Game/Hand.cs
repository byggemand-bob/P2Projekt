using System.Collections.Generic;

namespace Poker_Game.Game {

    // This function represents each individual round of the game, one for each hand dealt
    public class Hand {
        public int Pot { get; set; }
        public List<Card> Deck { get; set; }
        public List<Card> Street { get; set; }  // optimize
        public List<Round> Rounds { get; set; }
        public List<Player> Players { get; set; }
        
        // Allocation and initialization for the various elements of a hand
        #region Initialization
        public Hand(List<Player> players, int dealerButtonPosition) {
            Pot = 0;
            Deck = new List<Card>();
            Street = new List<Card>();
            Rounds = new List<Round>();
            Players = InitializePlayers(players, dealerButtonPosition);

            //Players = GetActivePlayers(players);
            StartRound(dealerButtonPosition);
        }

        // Initialized the players, from a list of players and their positions, resets them each round, and deals a new hand of cards
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

        // Finds Active Players - stack > 0
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

        #region Actions

        //Function to start the round, which resets the actions of the previous rounds
        public void StartRound(int dealerButtonPosition) {
            UpdateStreet();
            Rounds.Add(new Round(Players));
            ResetActions();
        }

        // Function that adds cards to the street in each round
        private void UpdateStreet() {
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

        // Resets the current actions of the player
        private void ResetActions() {
            foreach(Player player in Players) {
                player.Action = PlayerAction.None;
            }
        }

        // Draws number of cards needed for the player / street
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

        #endregion

        #region Utility

        // Checks if the game has played all 5 rounds and is finished
        public bool IsFinished() {
            if(PlayersLeft() > 1) {
                return Rounds.Count == 5;
            }

            return true;
        }

        // Checks if any players are left in the game, or if they folded
        private int PlayersLeft() {
            int playersLeft = 0;
            foreach(Player player in Players) {
                if(player.Action != PlayerAction.Fold) {
                    playersLeft++;
                }
            }

            return playersLeft;
        }

        // Finds the current round number
        public int CurrentRoundNumber() {
            return Rounds.Count;
        }

        #endregion

    }
}
