using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker_Game.AI;
using Poker_Game.Game;

namespace UnitTest {
    [TestClass]
    public class OutsCalculatorUnitTest {
        public OutsCalculator OutsCalculator = new OutsCalculator();

        [TestMethod]
        public void IsPocketFlushDraw() {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, Rank.Ace);
            Card handCard2 = new Card(Suit.Spades, Rank.King);

            Card tableCard1 = new Card(Suit.Spades, (Rank) 5);
            Card tableCard2 = new Card(Suit.Spades, (Rank) 2);
            Card tableCard3 = new Card(Suit.Spades, (Rank) 9);
            Card tableCard4 = new Card(Suit.Hearts, (Rank) 4);
            Card tableCard5 = new Card(Suit.Clubs, (Rank) 10);

            List<Card> hand = new List<Card> {
                handCard1, handCard2
            };

            List<Card> street = new List<Card> {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            int expected = 9;

            // Act
            int actual = OutsCalculator.CompareOuts(street, hand);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void IsPocketFlushDrawTest() {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, Rank.Ace);
            Card handCard2 = new Card(Suit.Spades, Rank.King);

            Card tableCard1 = new Card(Suit.Hearts, (Rank) 3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank) 2);
            Card tableCard3 = new Card(Suit.Diamonds, (Rank) 9);
            Card tableCard4 = new Card(Suit.Hearts, (Rank) 4);
            Card tableCard5 = new Card(Suit.Clubs, (Rank) 10);

            List<Card> hand = new List<Card> {
                handCard1, handCard2
            };

            List<Card> street = new List<Card> {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            int expected = 9;

            // Act
            int actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void IsTableFlushDrawTest() {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, Rank.Ace);
            Card handCard2 = new Card(Suit.Hearts, Rank.King);

            Card tableCard1 = new Card(Suit.Spades, (Rank) 3);
            Card tableCard2 = new Card(Suit.Spades, (Rank) 2);
            Card tableCard3 = new Card(Suit.Spades, (Rank) 9);
            Card tableCard4 = new Card(Suit.Spades, (Rank) 4);
            Card tableCard5 = new Card(Suit.Clubs, (Rank) 10);

            List<Card> hand = new List<Card> {
                handCard1, handCard2
            };

            List<Card> street = new List<Card> {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            int expected = 9;

            // Act
            int actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ThreeOakToFullHouseOrFourOakTest() {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, Rank.Ace); // 3x Ace
            Card handCard2 = new Card(Suit.Hearts, (Rank) 7);

            Card tableCard1 = new Card(Suit.Diamonds, Rank.Ace);
            Card tableCard2 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard3 = new Card(Suit.Diamonds, (Rank) 9);
            Card tableCard4 = new Card(Suit.Hearts, (Rank) 4);
            Card tableCard5 = new Card(Suit.Clubs, (Rank) 10);

            List<Card> hand = new List<Card> {
                handCard1, handCard2
            };

            List<Card> street = new List<Card> {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            int expected = 7;

            // Act
            int actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void PocketPairToSetTest() {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, Rank.Ace);
            Card handCard2 = new Card(Suit.Clubs, Rank.Ace);


            Card tableCard1 = new Card(Suit.Hearts, (Rank) 3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank) 2);
            Card tableCard3 = new Card(Suit.Diamonds, (Rank) 9);
            Card tableCard4 = new Card(Suit.Hearts, (Rank) 4);
            Card tableCard5 = new Card(Suit.Clubs, (Rank) 10);

            List<Card> hand = new List<Card> {
                handCard1, handCard2
            };

            List<Card> street = new List<Card> {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            int expected = 2;

            // Act
            int actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void OnePairToTwoPairTest() {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, (Rank) 2);
            Card handCard2 = new Card(Suit.Hearts, (Rank) 7);

            Card tableCard1 = new Card(Suit.Hearts, Rank.Ace);
            Card tableCard2 = new Card(Suit.Clubs, Rank.King);
            Card tableCard3 = new Card(Suit.Diamonds, Rank.Queen);
            Card tableCard4 = new Card(Suit.Hearts, (Rank) 10);
            Card tableCard5 = new Card(Suit.Clubs, (Rank) 10);

            List<Card> hand = new List<Card> {
                handCard1, handCard2
            };

            List<Card> street = new List<Card> {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            int expected = 5;

            // Act
            int actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void OneOverCardTest() {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, Rank.Ace);
            Card handCard2 = new Card(Suit.Hearts, (Rank) 7);

            Card tableCard1 = new Card(Suit.Hearts, (Rank) 3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank) 2);
            Card tableCard3 = new Card(Suit.Diamonds, (Rank) 9);
            Card tableCard4 = new Card(Suit.Hearts, (Rank) 4);
            Card tableCard5 = new Card(Suit.Clubs, (Rank) 10);

            List<Card> hand = new List<Card> {
                handCard1, handCard2
            };

            List<Card> street = new List<Card> {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            int expected = 3;

            // Act
            int actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TwoCardsOVerToOverPair() {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, Rank.Ace);
            Card handCard2 = new Card(Suit.Hearts, Rank.King);

            Card tableCard1 = new Card(Suit.Hearts, (Rank) 3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank) 2);
            Card tableCard3 = new Card(Suit.Diamonds, (Rank) 9);
            Card tableCard4 = new Card(Suit.Hearts, (Rank) 4);
            Card tableCard5 = new Card(Suit.Clubs, (Rank) 10);

            List<Card> hand = new List<Card> {
                handCard1, handCard2
            };

            List<Card> street = new List<Card> {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            int expected = 6;

            // Act
            int actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TwoPairToFullHouse() {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, Rank.Ace);
            Card handCard2 = new Card(Suit.Hearts, Rank.Ace);

            Card tableCard1 = new Card(Suit.Hearts, Rank.King);
            Card tableCard2 = new Card(Suit.Clubs, Rank.King);
            Card tableCard3 = new Card(Suit.Diamonds, (Rank) 9);
            Card tableCard4 = new Card(Suit.Hearts, (Rank) 4);
            Card tableCard5 = new Card(Suit.Clubs, (Rank) 10);

            List<Card> hand = new List<Card> {
                handCard1, handCard2
            };

            List<Card> street = new List<Card> {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            int expected = 4;

            // Act
            int actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void OnePairToSet() {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, (Rank) 2);
            Card handCard2 = new Card(Suit.Hearts, (Rank) 10);

            Card tableCard1 = new Card(Suit.Hearts, Rank.Ace);
            Card tableCard2 = new Card(Suit.Clubs, Rank.King);
            Card tableCard3 = new Card(Suit.Diamonds, Rank.Queen);
            Card tableCard4 = new Card(Suit.Hearts, Rank.Jack);
            Card tableCard5 = new Card(Suit.Clubs, (Rank) 10);

            List<Card> hand = new List<Card> {
                handCard1, handCard2
            };

            List<Card> street = new List<Card> {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            int expected = 5;

            // Act
            int actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void NoPairToPair() {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, (Rank) 2);
            Card handCard2 = new Card(Suit.Hearts, (Rank) 7);

            Card tableCard1 = new Card(Suit.Hearts, Rank.Ace);
            Card tableCard2 = new Card(Suit.Clubs, Rank.King);
            Card tableCard3 = new Card(Suit.Diamonds, Rank.Queen);
            Card tableCard4 = new Card(Suit.Hearts, Rank.Jack);
            Card tableCard5 = new Card(Suit.Clubs, (Rank) 10);

            List<Card> hand = new List<Card> {
                handCard1, handCard2
            };

            List<Card> street = new List<Card> {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            int expected = 6;

            // Act
            int actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}