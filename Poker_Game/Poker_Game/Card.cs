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
        private static int DrawRandCard() {
            return random.Next(0, 52);
        }
        public static int DrawnCards(List<Card> cards) {
            int randCard = 0;
            remake: //if card have already been made
            randCard = DrawRandCard();
            foreach (Card element in cards) {
                if (randCard == element.number) {
                    goto remake;
                }
            }
            return randCard;
        }
        private Card MakeCard(int cardNumber) {
            string cardName;
            Card temp_card = new Card();
            int Rank = cardNumber % ????;
            //cardName = c.ToString();
            if (Rank == 14 {
                cardName = "A";
            } else if (counter_ranks == 11) {
                cardName = "J";
            } else if (counter_ranks == 12) {
                cardName = "Q";
            } else if (counter_ranks == 13) {
                cardName = "K";
            }
            if (counter_suits == 0) {
                cardName = cardName + "C";
            } else if (counter_suits == 1) {
                cardName = cardName + "D";
            else if (counter_suits == 2) {
                cardName = cardName + "H";
            } else if (counter_suits == 3) {
                cardName = cardName + "S";
            }
            Deck[counter] = new Card((Image.FromFile(Application.StartupPath + "\\Deck_of_cards\\" + cardName + ".png")), Suit.Spades, Rank.Ace);
            counter++;
            }
            return temp_card;
        }
    }
}
