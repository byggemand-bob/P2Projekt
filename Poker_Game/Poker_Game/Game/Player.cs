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
        public int Id { get; private set; }
        public int Stack { get; set; }
        public int CurrentBet { get; set; }
        public bool IsSmallBlind { get; set; }
        public bool IsBigBlind { get; set; }
        public int BetsTaken { get; set; }
        public string Name { get; set; }
        public PlayerAction Action { get; set; }
        public PlayerAction PreviousAction { get; set; }
        public Score Score { get; private set; }
        public List<Card> Cards { get; set; }

        #region Initialization

        public Player(int id,  int stackSize) {
            Id = id;
            Cards = new List<Card>();
            Stack = stackSize;
            Action = PlayerAction.None;
            PreviousAction = PlayerAction.None;
            Score = Score.None;
            Reset();
        }

        #endregion

        public void GetScore() {
            WinConditions winCondition = new WinConditions(); 
            Score = winCondition.Evaluate(Cards);
        }

        public void Reset() { // Reset a player-state for each new hand
            CurrentBet = 0;
            IsBigBlind = false;
            IsSmallBlind = false;
            Action = PlayerAction.None;
            PreviousAction = PlayerAction.None;
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

        // Compares players
        public int CompareTo(object other) { 
            return Id.CompareTo(((Player)other).Id);
        }

        public object Clone() {
            Player player = new Player(Id, Stack) {
                IsBigBlind = IsBigBlind,
                IsSmallBlind = IsSmallBlind,
                Action = Action,
                PreviousAction = PreviousAction,
                Stack = Stack,
                Name = Name,
                BetsTaken = BetsTaken,
                Id = Id,
                Score = Score,
                CurrentBet = CurrentBet
            };
            player.Cards.AddRange(Cards);
            return player;
        }
    }
}
