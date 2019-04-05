using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    enum PlayerAction {
        Tbd, // To be decided
        Check,
        Call,
        Raise,
        Fold
    }

    class Player : IComparable, ICloneable {
        public int Id { get; set; }
        public int Stack { get; set; } // Needs validation
        public bool IsSmallBlind { get; set; }
        public bool IsBigBlind { get; set; }
        public bool HasFolded { get; set; } // Obsolete
        public List<Card> Cards { get; set; }
        public int CurrentBet { get; set; }
        public PlayerAction Action { get; set; }

        public Player(int id,  int stackSize) {
            Cards = new List<Card>();
            Stack = stackSize;
            Action = PlayerAction.Tbd;
            Reset();
        }

        public void Reset() {
            CurrentBet = 0;
            IsBigBlind = false;
            IsSmallBlind = false;
            HasFolded = false;
            Action = PlayerAction.Tbd;
            RemoveCards();
        }

        public void RemoveCards() {
            for(int i = Cards.Count - 1; i >= 0; i--) {
                Cards.Remove(Cards[i]);
            }
        }

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
            player.HasFolded = HasFolded;

            foreach(Card card in Cards) {
                player.Cards.Add((Card)card.Clone());
            }

            return player;
        }

    }
}
