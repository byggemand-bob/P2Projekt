using System;
using System.Collections.Generic;
using System.Drawing;
using Poker_Game;

namespace Poker_Game.Game {
    enum Suit { Clubs, Diamond, Hearts, Spades };
    enum Rank { Jack = 11, Queen = 12, King = 13, Ace = 14 };


    class Card : IComparable, ICloneable {
        //Random random = new Random();
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());
        public Suit Suit { get; set; } //CRASH STACK OVERFLOW NÅR JEG IKKE SKRIVER TIL FILE OG RANDOM
        public Rank Rank { get; set; } //CRASH STACK OVERFLOW NÅR JEG IKKE SKRIVER TIL FILE OG RANDOM
        public Image Image { get; set; }

        public Card(Suit suit, Rank rank) {
            Suit = suit;
            Rank = rank;
        }
        //public Card(int i) {
        //    MakeCard(i);
        //}

        public Card(List<Card> existingCards) {
            DrawCards(existingCards);
        }

        private int DrawRandomCard() {
            return _random.Next(0, 51);
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
        public void MakeCard(int cardNumber) { // Gives cards a traditional value, such as jack, queen etc... Then an image from resources is connected to each card.
            int rankInt = (cardNumber % 13) + 2;
            //string cardName = rankInt.ToString();
            //if(rankInt == 14) {
            //    cardName = "A";
            //} else if(rankInt == 11) {
            //    cardName = "J";
            //} else if(rankInt == 12) {
            //    cardName = "Q";
            //} else if(rankInt == 13) {
            //    cardName = "K";
            //}
            if(cardNumber <= 12) {
                Suit = Suit.Clubs;
                //cardName += "C";
            } else if(cardNumber <= 25) {
                Suit = Suit.Diamond;
                //cardName += "D";
            } else if(cardNumber <= 38) {
                Suit = Suit.Hearts;
                //cardName += "H";
            } else if(cardNumber <= 51) {
                Suit = Suit.Spades;
                //cardName += "S";
            }
            Rank = (Rank)rankInt;
            //Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\Resources\\" + cardName + ".png");
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
