using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Poker_Game {
    enum Suit { Clubs, Diamond, Hearts, Spades };
    enum Rank { Jack = 11, Queen = 12, King = 13, Ace = 14 };
    class Card {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        public Image Image { get; set; }

        public void GenerateRandom() {
            throw new NotImplementedException();
        }

    }
}
