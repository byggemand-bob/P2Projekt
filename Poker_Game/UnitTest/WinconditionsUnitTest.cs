using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker_Game.Game;
using System.Collections.Generic;

namespace UnitTest

    /* • Forventet opførsel ved forskelligt input.
            • Hvordan håndteres lovligt input?
            • Hvordan håndteres ulovligt input
          Flere test cases per metode under test
        • Kræver en specifikation. */
{
    [TestClass]
    public class WinconditionsUnitTest
    {
        WinConditions winConditions = new WinConditions();

        [TestMethod]
        public void TestForHighestCard()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            cards.Add(new Card(Suit.Clubs, (Rank)2));
            cards.Add(new Card(Suit.Hearts, Rank.King));
            cards.Add(new Card(Suit.Diamond, (Rank)4));
            cards.Add(new Card(Suit.Spades, (Rank)8));
            cards.Add(new Card(Suit.Spades, (Rank)9));
            cards.Add(new Card(Suit.Diamond, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = (Score) Rank.King;

            // Act
            Score score = winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(score, expected);
        }
        [TestMethod]
        public void TestForPair()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // Pair
            cards.Add(new Card(Suit.Clubs, (Rank)2));
            cards.Add(new Card(Suit.Hearts, (Rank)2));
            // Filler
            cards.Add(new Card(Suit.Hearts, (Rank)3));
            cards.Add(new Card(Suit.Spades, (Rank)8));
            cards.Add(new Card(Suit.Spades, (Rank)9));
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = (Score) 15;

            // Act
            Score score = winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(score, expected);
        }

        [TestMethod]
        public void TestForTwoPairs()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // Pairs
            cards.Add(new Card(Suit.Clubs, (Rank)2));
            cards.Add(new Card(Suit.Hearts, (Rank)2));
            cards.Add(new Card(Suit.Hearts, (Rank)3));
            cards.Add(new Card(Suit.Spades, (Rank)3));
            // Filler
            cards.Add(new Card(Suit.Spades, (Rank)9));
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = Score.TwoPairs;

            // Act
            Score score = winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, score);
        }

        [TestMethod]
        public void TestForThreeOfAKind()
        {
            // Arrange
            List<Card> cards = new List<Card>();
                // Three of a kind
            cards.Add(new Card(Suit.Clubs, (Rank)2));
            cards.Add(new Card(Suit.Hearts, (Rank)2));
            cards.Add(new Card(Suit.Spades, (Rank)2));
                // Filler
            cards.Add(new Card(Suit.Spades, (Rank)8));
            cards.Add(new Card(Suit.Spades, (Rank)9));
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = Score.ThreeOfAKind;

            // Act
            Score score = winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(score, expected);
        }

        [TestMethod]
        public void TestForStraight()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // Straight
            cards.Add(new Card(Suit.Clubs, (Rank)2));
            cards.Add(new Card(Suit.Hearts, (Rank)3));
            cards.Add(new Card(Suit.Spades, (Rank)4));
            cards.Add(new Card(Suit.Spades, (Rank)5));
            cards.Add(new Card(Suit.Spades, (Rank)6));
            // Filler
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = Score.Straight;

            // Act
            Score score = winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(score, expected);
        }

        [TestMethod]
        public void TestForFlush()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // Flush
            cards.Add(new Card(Suit.Spades, (Rank)2));
            cards.Add(new Card(Suit.Spades, (Rank)8));
            cards.Add(new Card(Suit.Spades, Rank.King));
            cards.Add(new Card(Suit.Spades, (Rank)5));
            cards.Add(new Card(Suit.Spades, (Rank)6));
            // Filler
            cards.Add(new Card(Suit.Clubs, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = Score.Flush;

            // Act
            Score score = winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(score, expected);
        }

        [TestMethod]
        public void TestForFullHouse()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // FullHouse
            cards.Add(new Card(Suit.Clubs, (Rank)2));
            cards.Add(new Card(Suit.Hearts, (Rank)2));
            cards.Add(new Card(Suit.Spades, (Rank)2));
            cards.Add(new Card(Suit.Spades, (Rank)3));
            cards.Add(new Card(Suit.Clubs, (Rank)3));
            // Filler
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = Score.FullHouse;

            // Act
            Score score = winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(score, expected);
        }

        [TestMethod]
        public void TestForFourOfAKind()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // Straight
            cards.Add(new Card(Suit.Clubs, (Rank)2));
            cards.Add(new Card(Suit.Hearts, (Rank)2));
            cards.Add(new Card(Suit.Spades, (Rank)2));
            cards.Add(new Card(Suit.Diamond, (Rank)2));
            // Filler
            cards.Add(new Card(Suit.Spades, (Rank)6));
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = Score.FourOfAKind;

            // Act
            Score score = winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(score, expected);
        }

        [TestMethod]
        public void TestForStraightFlush()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // StraightFlush
            cards.Add(new Card(Suit.Spades, (Rank)9));
            cards.Add(new Card(Suit.Spades, (Rank)8));
            cards.Add(new Card(Suit.Spades, (Rank) 10));
            cards.Add(new Card(Suit.Spades, Rank.Jack));
            cards.Add(new Card(Suit.Spades, Rank.Queen));
            // Filler
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = Score.StraightFlush;

            // Act
            Score score = winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(score, expected);
        }

        [TestMethod] 
        public void TestForRoyalFlush()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // StraightFlush
            cards.Add(new Card(Suit.Spades, (Rank)10));
            cards.Add(new Card(Suit.Spades, Rank.Ace));
            cards.Add(new Card(Suit.Spades, Rank.King));
            cards.Add(new Card(Suit.Spades, Rank.Jack));
            cards.Add(new Card(Suit.Spades, Rank.Queen));
            // Filler
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = Score.RoyalFlush;

            // Act
            Score score = winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(score, expected);
        }
    }
}