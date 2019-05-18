using System;
using System.Collections.Generic;

namespace Poker_Game.Game {

    // This function represents each individual round of the game, one for each hand dealt
    public class Hand {
        public int Pot { get; set; }
        public List<Card> Street { get; }  
        public List<Round> Rounds { get; }
        public List<Player> Players { get; }

        private readonly List<Card> _deck;

        // Allocation and initialization for the various elements of a hand
        #region Initialization

        // for testing purpose only
        public Hand(List<Player> players) {
            Players = players;
            _deck = new List<Card>();
            Street = new List<Card>();
        }
        
        public Hand(List<Player> players, int dealerButtonPosition) {
            Pot = 0;
            _deck = new List<Card>();
            Street = new List<Card>();
            Rounds = new List<Round>();
            Players = InitializePlayers(players, dealerButtonPosition);

            //Players = GetActivePlayers(players);
            StartRound();
        }

        // Initialized the players, from a list of players and their positions, resets them each round, and deals a new hand of cards
        private List<Player> InitializePlayers(List<Player> players, int dealerButtonPosition) {
            List<Player> initPlayers = players;
            for(int i = 0; i < initPlayers.Count; i++) {
                initPlayers[i].Reset();
                initPlayers[i].DrawNewCardHand(_deck);
                
                // Distribute blinds
                if(i == (dealerButtonPosition + 1) % initPlayers.Count) {
                    initPlayers[i].IsSmallBlind = true;
                } else if(i == (dealerButtonPosition + 2) % initPlayers.Count) {
                    initPlayers[i].IsBigBlind = true;
                }
            }

            return initPlayers;
        }

        #endregion
        
        //Function to start the round, which resets the actions of the previous rounds
        public void StartRound() {
            Rounds.Add(new Round(Players));
            UpdateStreet();
            ResetActions();
        }

        // Function that adds cards to the street in each round
        private void UpdateStreet() {
            switch (Rounds.Count) {
                case 1: // PreFlop
                    break;
                case 2: // Flop
                    DrawCards(3);
                    break;
                case 3: // Turn
                    DrawCards(1);
                    break;
                case 4: // River
                    DrawCards(1);
                    break;
                case 5: // Showdown
                    break;
                default:
                    throw new Exception("There are not supposed to be this amount of rounds.");
            }
        }

        // Resets the current actions of the player
        private void ResetActions() {
            foreach(Player player in Players) {
                player.Action = PlayerAction.None;
            }
        }

        // Draws number of cards needed for the player / street
        public void DrawCards(int numberOfCards) {
            for (int i = 0; i < numberOfCards; i++) {
                Card newCard = new Card(_deck);
                _deck.Add(newCard);
                Street.Add(newCard);
                foreach (Player player in Players) {
                    player.Cards.Add(newCard);
                }
            }
        }

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

        // Returns the current round number
        public int CurrentRoundNumber() {
            return Rounds.Count;
        }


    }
}
