using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

// TODO: create GetHashCode()



namespace Poker_Game {
    enum PlayerAction {
        None,
        Check,
        Call,
        Raise,
        Fold
    }

    class Player : IComparable, ICloneable {
        public int Id { get; set; }
        public int Stack { get; set; } // Needs validation
        public int CurrentBet { get; set; }

        public bool IsSmallBlind { get; set; }
        public bool IsBigBlind { get; set; }

        public PlayerAction Action { get; set; }
        public Score Score { get; set; }

        public List<Card> Cards { get; set; }

        #region Initialization

        public Player(int id,  int stackSize) {
            Cards = new List<Card>();
            Stack = stackSize;
            Action = PlayerAction.None;
            Score = Score.None;
            Reset();
        }

        #endregion

        #region Actions

        public void GetScore() {
            WinConditions wc = new WinConditions();
            Score = wc.Evaluate(Cards);
        }

        public void Reset() {
            CurrentBet = 0;
            IsBigBlind = false;
            IsSmallBlind = false;
            Action = PlayerAction.None;
            Score = Score.None;
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
        public int CompareTo(object other) {
            return Id.CompareTo(((Player)other).Id);
        }

        public object Clone() {
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
