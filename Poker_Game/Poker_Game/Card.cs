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
        static Random random = new Random();
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        public Image Image { get; set; }
        public Card(Image image, Suit suit, Rank rank)
        {
            Image = image;
            Suit = suit;
            Rank = rank;
        }
        private static int DrawRandCard() {
            return random.Next(0, 52);
        }
        public static int DrawCards(List<Card> cards) {
            int randCard = 0;
            remake: //if card have already been made
            randCard = DrawRandCard();
            if (cards != null) {
                foreach (Card element in cards) {
                    if (MakeCard(randCard) == element) {
                        goto remake;
                    }
                }
            }
            return randCard;
        }
        public static Card MakeCard(int cardNumber) {
            int Rank = cardNumber % 13 + 2;
            int Suit = cardNumber % 4;
            string cardName = Rank.ToString();
            if (Rank == 14 ){
                cardName = "A";
            } else if (Rank == 11) {
                cardName = "J";
            } else if (Rank == 12) {
                cardName = "Q";
            } else if (Rank == 13) {
                cardName = "K";
            }
            if (Suit == 0) {
                cardName = cardName + "C";
            } else if (Suit == 1) {
                cardName = cardName + "D";
            } else if (Suit == 2) {
                cardName = cardName + "H";
            } else if (Suit == 3) {
                cardName = cardName + "S";
            }
            var temp_card = new Card((Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\Deck_of_cards\\" + cardName + ".png")), (Suit)Suit, (Rank)Rank);
            return temp_card;
        }
    }
}
