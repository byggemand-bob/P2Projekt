using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    enum PlayerAction {
        TBD, // To be decided
        Check,
        Call,
        Raise,
        Fold
    }

    class Player : IComparable, ICloneable {
        public int ID { get; set; }
        public int Stack {
            get {
                return Stack;
            }
            set {
                if(value > 100 && value < int.MaxValue / 2) { // Minimum and maximum stacksizes not defined yet
                    Stack = value;
                } else {
                    throw new ArgumentOutOfRangeException("{0} is not an accepted value for this property.", value.ToString());
                }
            }
        }
        public bool IsSmallBlind { get; set; }
        public bool IsBigBlind { get; set; }
        public bool HasFolded { get; set; } // Obsolete
        public List<Card> Cards { get; set; }
        public int CurrentBet { get; set; }
        public PlayerAction Action { get; set; }

        public Player(int id,  int stackSize) {
            Cards = new List<Card>();
            Stack = stackSize;
            Action = PlayerAction.TBD;
            Reset();
        }

        public void Reset() {
            CurrentBet = 0;
            IsBigBlind = false;
            IsSmallBlind = false;
            HasFolded = false;
        }


        public int CompareTo(object other) {
            return ID.CompareTo(((Player)other).ID);
        }

        public object Clone() {
            Player player = new Player(ID, Stack);
            player.IsBigBlind = IsBigBlind;
            player.IsSmallBlind = IsSmallBlind;
            player.Action = Action;
            player.Stack = Stack;
            player.ID = ID;
            player.CurrentBet = CurrentBet;
            player.HasFolded = HasFolded;

            foreach(Card card in Cards) {
                player.Cards.Add((Card)card.Clone());
            }

            return player;
        }

    }
}
