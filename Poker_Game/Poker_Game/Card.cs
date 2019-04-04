using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Poker_Game {
    enum Suit { Clubs, Diamond, Hearts, Spades };
    enum Rank { Jack = 11, Queen = 12, King = 13, Ace = 14 };


    class Card : ICloneable {
        static Random random = new Random();
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        public Image Image { get; set; }
        public Card(Image image, Suit suit, Rank rank) {
            Image = image;
            Suit = suit;
            Rank = rank;
        }
        private int DrawRandCard() {
            return random.Next(0, 52);
        }
        public Card DrawCards(List<Card> cards) {
            Card randCard;
        remake: //if card have already been made
            randCard = MakeCard(DrawRandCard());

            foreach(Card element in cards) {
                if(randCard.Rank == element.Rank && randCard.Suit == element.Suit) {
                    goto remake;
                }
            }
            return randCard;
        }
        public void MakeCard(int cardNumber) {
            int Rank = cardNumber % 13 + 2;
            Suit Suit = Suit.Spades;
            string cardName = Rank.ToString();
            if(Rank == 14) {
                cardName = "A";
            } else if(Rank == 11) {
                cardName = "J";
            } else if(Rank == 12) {
                cardName = "Q";
            } else if(Rank == 13) {
                cardName = "K";
            }
            if(cardNumber <= 12) {
                Suit = Suit.Clubs;
                cardName += "C";
            } else if(cardNumber <= 25) {
                Suit = Suit.Diamond;
                cardName += "D";
            } else if(cardNumber <= 38) {
                Suit = Suit.Hearts;
                cardName += "H";
            } else if(cardNumber <= 51) {
                Suit = Suit.Spades;
                cardName += "S";
            }
            Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\Resources\\" + cardName + ".png");
        }

        public object Clone() {
            return new Card(Image, Suit, Rank);
        }
    }
}
