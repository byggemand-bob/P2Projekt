using System;
using System.Collections.Generic;
using System.Drawing;
using Poker_Game;

namespace Poker_Game.Game {
    public enum Suit { Clubs, Diamonds, Hearts, Spades };
    public enum Rank { Jack = 11, Queen = 12, King = 13, Ace = 14 };


    public class Card : IComparable, ICloneable {
        //Random random = new Random();
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode()); // Hvad g�r dette?
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        public Image Image { get; set; }

        public Card(Suit suit, Rank rank) {
            Suit = suit;
            Rank = rank;
        }
        public Card(int i) {
            MakeCard(i);
        }

        public Card(List<Card> existingCards) {
            DrawCards(existingCards);
        }

        private int DrawRandomCard() {
            return _random.Next(0, 52);
        }

        public void DrawCards(List<Card> cards) {
            MakeCard(DrawRandomCard());
            foreach (Card element in cards) {
                if (element.CompareTo(this) == 0) {
                    DrawCards(cards);
                    break;
                }
            }
        }
        //public void DrawCards(List<Card> cards) {
        //    do {
        //        MakeCard(DrawRandCard());
        //    } while (cards.Contains(this));
        //}
        //public void MakeCard(int cardNumber) { // Gives cards a traditional value, such as jack, queen etc... Then an image from resources is connected to each card.
        //    int rankInt = (cardNumber % 13) + 2;
        //    Suit = (Suit)(cardNumber / 13);
        //    string cardName = rankInt.ToString();
        //    if(rankInt == 14) {
        //        cardName = "A";
        //    } else if(rankInt == 11) {
        //        cardName = "J";
        //    } else if(rankInt == 12) {
        //        cardName = "Q";
        //    } else if(rankInt == 13) {
        //        cardName = "K";
        //    }
        //    if(cardNumber <= 12) {
        //        Suit = Suit.Clubs;
        //        cardName += "C";
        //    } else if(cardNumber <= 25) {
        //        Suit = Suit.Diamonds;
        //        cardName += "D";
        //    } else if(cardNumber <= 38) {
        //        Suit = Suit.Hearts;
        //        cardName += "H";
        //    } else if(cardNumber <= 51) {
        //        Suit = Suit.Spades;
        //        cardName += "S";
        //    }
        //    Rank = (Rank)rankInt;
        //    Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\Resources\\" + Rank + Suit + ".png");
        //}

        public void MakeCard(int cardNumber) {
            Rank = (Rank)(cardNumber % 13 + 2);
            Suit = (Suit)(cardNumber / 13);
        }

        public void LoadImage() {
            Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\Resources\\" + Rank + Suit + ".png");
        }

        public int CompareTo(object other) { // Sort after rank, then suit
            Card otherCard = (Card)other;
            if (Rank.CompareTo(otherCard.Rank) < 0) { //CRASHER OFTE HER
                return -1;
            } else if(Rank.CompareTo(otherCard.Rank) > 0) { //CRASHER NOGLE GANGE HER3
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
