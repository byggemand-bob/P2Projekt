using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Poker_Game.Game {
    public enum Suit {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Rank {
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }


    public class Card : IComparable, ICloneable {
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        // For testing purposes only
        public Card(Suit suit, Rank rank) {
            Suit = suit;
            Rank = rank;
        }

        // MonteCarlo
        public Card(int cardValue) {
            MakeCard(cardValue);
        }

        public Card(List<Card> existingCards) {
            DrawCards(existingCards);
        }

        public Rank Rank { get; set; }
        public Suit Suit { get; private set; }
        public Image Image { get; private set; }

        public object Clone() {
            return new Card(Suit, Rank);
        }

        // Sort after rank, then suit
        public int CompareTo(object other) {
            Card otherCard = (Card) other;
            if(Rank.CompareTo(otherCard.Rank) < 0) return -1;
            if(Rank.CompareTo(otherCard.Rank) > 0) return 1;
            if(Suit.CompareTo(otherCard.Suit) < 0) return 1;
            if(Suit.CompareTo(otherCard.Suit) > 0) return -1;
            return 0;
        }

        private int DrawRandomCard() {
            return _random.Next(0, 52);
        }

        private void DrawCards(List<Card> cards) {
            MakeCard(DrawRandomCard());
            foreach(Card element in cards)
                if(element.CompareTo(this) == 0) {
                    DrawCards(cards);
                    break;
                }
        }


        public void MakeCard(int cardNumber) {
            Rank = (Rank) (cardNumber % 13 + 2);
            Suit = (Suit) (cardNumber / 13);
        }

        public void LoadImage() {
            Image = Image.FromFile(Application.StartupPath + "\\Resources\\" + Rank + Suit + ".png");
        }

        public override string ToString() {
            return Rank + " of " + Suit;
        }
    }
}