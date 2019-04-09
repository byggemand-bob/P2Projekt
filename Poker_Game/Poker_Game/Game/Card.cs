using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Poker_Game {
    enum Suit { Clubs, Diamond, Hearts, Spades };
    enum Rank { Jack = 11, Queen = 12, King = 13, Ace = 14 };


    class Card : IComparable, ICloneable {
        private Random _random = new Random();
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        public Image Image { get; set; }


        public Card(Suit suit, Rank rank) {
            //Image = image;
            Suit = suit;
            Rank = rank;
        }
        public Card(List<Card> existingCards) {
            DrawCards(existingCards);
        }
        private int DrawRandCard() {
            return _random.Next(0, 51);
        }
        public void DrawCards(List<Card> cards) {
        remake: //if card have already been made
            MakeCard(DrawRandCard());
            foreach(Card element in cards) {
                if(element.CompareTo(this) == 0) {
                    goto remake;
                }
            }
        }
        public void MakeCard(int cardNumber) {
            int rankInt = (cardNumber % 13) + 2;
            string cardName = rankInt.ToString();
            if(rankInt == 14) {
                cardName = "A";
            } else if(rankInt == 11) {
                cardName = "J";
            } else if(rankInt == 12) {
                cardName = "Q";
            } else if(rankInt == 13) {
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
            Rank = (Rank)rankInt;
            Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\Resources\\" + cardName + ".png");
        }


        public int CompareTo(object other) { // Sort after suit, then rank
            Card otherCard = (Card)other;
            if(Rank.CompareTo(otherCard.Rank) < 0) {
                return -1;
            } else if(Rank.CompareTo(otherCard.Rank) > 0) {
                return 1;
            } else {
                if(Suit.CompareTo(otherCard.Suit) < 0) {
                    return 1;
                } else if(Suit.CompareTo(otherCard.Suit) > 0) {
                    return -1;
                }
            }
            return 0;
        }

        public object Clone() {
            return new Card(Suit, Rank);
        }
    }
}
