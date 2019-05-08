using System;
using System.Collections.Generic;
using System.Drawing;

namespace Poker_Game.Game {
    public enum Suit { Clubs, Diamonds, Hearts, Spades };
    public enum Rank { Jack = 11, Queen = 12, King = 13, Ace = 14 };

    public class Card : IComparable, ICloneable {
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());
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

        public void MakeCard(int cardNumber) {
            Rank = (Rank)(cardNumber % 13 + 2);
            Suit = (Suit)(cardNumber / 13);
        }

        public void LoadImage() {
            Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\Resources\\" + Rank.ToString() + Suit.ToString() + ".png");
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

        public override bool Equals(object obj) {
            if(this.GetHashCode() != ((Card)obj).GetHashCode()) {
                return false;
            }
            return this.Rank == ((Card) obj).Rank && this.Suit == ((Card) obj).Suit;
        }

        public override int GetHashCode() {
            return (int)this.Rank + (int)this.Suit;
        }

        public object Clone() {
            return new Card(Suit, Rank);
        }
    }
}
