using System;
using System.Collections.Generic;

// TODO: create GetHashCode()

namespace Poker_Game.Game {
    public enum PlayerAction {
        None,
        Check,
        Call,
        Raise,
        Fold
    }

    public class Player : IComparable, ICloneable {
        public int Id { get; set; }
        public int Stack { get; set; } // Needs validation
        public int CurrentBet { get; set; }
        public bool IsSmallBlind { get; set; }
        public bool IsBigBlind { get; set; }
        public int BetsTaken { get; set; }
        public string Name { get; set; }
        public PlayerAction Action { get; set; }
        public Score Score { get; set; }
        public List<Card> Cards { get; set; }

        #region Initialization

        public Player(int id,  int stackSize) {
            Id = id;
            Cards = new List<Card>();
            Stack = stackSize;
            Action = PlayerAction.None;
            Score = Score.None;
            Reset();
        }

        #endregion

        #region Actions

        public void GetScore() {
            WinConditions winCondition = new WinConditions(); 
            Score = winCondition.Evaluate(Cards);
            // if (player.Score == otherPlayerScore)
            //      Do something;
        }

        public void Reset() { // Reset a player-state for each new hand
            CurrentBet = 0;
            IsBigBlind = false;
            IsSmallBlind = false;
            Action = PlayerAction.None;
            Score = Score.None;
            BetsTaken = 0;
            Cards.Clear();
        }


        public void DrawNewCardHand(List<Card> existingCards) {
            Cards.Clear();
            for (int i = 0; i < 2; i++) {
                Card tCard = new Card(existingCards);
                Cards.Add(tCard);
                existingCards.Add(tCard);
            }
        }

        #endregion

        #region Utility
        public int CompareTo(object other) { // Compares players
            return Id.CompareTo(((Player)other).Id);
        }

        public object Clone() { // Clones players
            Player player = new Player(Id, Stack);
            player.IsBigBlind = IsBigBlind;
            player.IsSmallBlind = IsSmallBlind;
            player.Action = Action;
            player.Stack = Stack;
            player.Id = Id;
            player.CurrentBet = CurrentBet;

            foreach(Card card in Cards) {
                player.Cards.Add((Card)card.Clone());
            }
            return player;
        }

        #endregion

    }
}
