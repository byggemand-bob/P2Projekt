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
        WinConditions _winConditions = new WinConditions();


        [TestMethod]
        public void TestForHighestCard()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            cards.Add(new Card(Suit.Clubs, (Rank)2));
            cards.Add(new Card(Suit.Hearts, Rank.King));
            cards.Add(new Card(Suit.Diamonds, (Rank)4));
            cards.Add(new Card(Suit.Spades, (Rank)8));
            cards.Add(new Card(Suit.Spades, (Rank)9));
            cards.Add(new Card(Suit.Diamonds, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = (Score)Rank.King;

            // Act
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
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
            Score expected = (Score)15;

            // Act
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
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
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
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
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
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
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestForFlushSpades()
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
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestForFlushHearts()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // Flush
            cards.Add(new Card(Suit.Hearts, (Rank)2));
            cards.Add(new Card(Suit.Hearts, (Rank)8));
            cards.Add(new Card(Suit.Hearts, Rank.King));
            cards.Add(new Card(Suit.Hearts, (Rank)5));
            cards.Add(new Card(Suit.Hearts, (Rank)6));
            // Filler
            cards.Add(new Card(Suit.Clubs, Rank.Jack));
            cards.Add(new Card(Suit.Spades, Rank.Queen));
            Score expected = Score.Flush;

            // Act
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestForFullHouse()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // FullHouse
            cards.Add(new Card(Suit.Diamonds, (Rank)2));
            cards.Add(new Card(Suit.Hearts, (Rank)2));
            cards.Add(new Card(Suit.Spades, (Rank)2));
            cards.Add(new Card(Suit.Diamonds, (Rank)3));
            cards.Add(new Card(Suit.Clubs, (Rank)3));
            // Filler
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = Score.FullHouse;

            // Act
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
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
            cards.Add(new Card(Suit.Diamonds, (Rank)2));
            // Filler
            cards.Add(new Card(Suit.Spades, (Rank)6));
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = Score.FourOfAKind;

            // Act
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestForStraightFlush()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // StraightFlush
            cards.Add(new Card(Suit.Spades, (Rank)9));
            cards.Add(new Card(Suit.Spades, (Rank)8));
            cards.Add(new Card(Suit.Spades, (Rank)10));
            cards.Add(new Card(Suit.Spades, Rank.Jack));
            cards.Add(new Card(Suit.Spades, Rank.Queen));
            // Filler
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = Score.StraightFlush;

            // Act
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
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
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestAlmostFlush_GetHighestCard()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // Flush
            cards.Add(new Card(Suit.Spades, (Rank)2));
            cards.Add(new Card(Suit.Spades, (Rank)8));
            cards.Add(new Card(Suit.Spades, Rank.King));
            cards.Add(new Card(Suit.Spades, (Rank)5));
            cards.Add(new Card(Suit.Hearts, (Rank)6)); // Wrong suit for flush.
            // Filler
            cards.Add(new Card(Suit.Clubs, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = (Score)Rank.King;

            // Act
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAlmostFlush_GetPair()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // Almost Flush
            cards.Add(new Card(Suit.Spades, (Rank)2));
            cards.Add(new Card(Suit.Spades, (Rank)8));
            cards.Add(new Card(Suit.Spades, Rank.King));
            cards.Add(new Card(Suit.Spades, (Rank)5));
            cards.Add(new Card(Suit.Hearts, (Rank)6)); // Wrong suit
            // Pair
            cards.Add(new Card(Suit.Clubs, (Rank)9));
            cards.Add(new Card(Suit.Hearts, (Rank)9));
            Score expected = Score.Pair;

            // Act
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestAlmostStraight_GetHighestCard()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // Straight
            cards.Add(new Card(Suit.Clubs, (Rank)2));
            cards.Add(new Card(Suit.Hearts, (Rank)3));
            cards.Add(new Card(Suit.Spades, (Rank)4));
            cards.Add(new Card(Suit.Spades, (Rank)5));
            cards.Add(new Card(Suit.Spades, (Rank)7)); // 1 rank too high
            // Filler
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = (Score)Rank.Queen;

            // Act
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAlmostStraight_GetPair()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // Straight
            cards.Add(new Card(Suit.Clubs, (Rank)2));
            cards.Add(new Card(Suit.Hearts, (Rank)3));
            cards.Add(new Card(Suit.Spades, (Rank)4));
            cards.Add(new Card(Suit.Spades, (Rank)5));
            cards.Add(new Card(Suit.Spades, (Rank)7)); // 1 rank too high
            // Pair
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Diamonds, Rank.Jack));
            Score expected = Score.Pair;

            // Act
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestStraight_AceAsOne()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // Straight
            cards.Add(new Card(Suit.Spades, Rank.Ace));
            cards.Add(new Card(Suit.Clubs, (Rank)2));
            cards.Add(new Card(Suit.Hearts, (Rank)3));
            cards.Add(new Card(Suit.Spades, (Rank)4));
            cards.Add(new Card(Suit.Spades, (Rank)5));
            // Filler
            cards.Add(new Card(Suit.Hearts, (Rank)7));
            cards.Add(new Card(Suit.Hearts, Rank.Queen));
            Score expected = Score.Straight;

            // Act
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestStraight_AceAsFourteen()
        {
            // Arrange
            List<Card> cards = new List<Card>();
            // Straight
            cards.Add(new Card(Suit.Clubs, (Rank)10));
            cards.Add(new Card(Suit.Hearts, Rank.Jack));
            cards.Add(new Card(Suit.Spades, Rank.Queen));
            cards.Add(new Card(Suit.Spades, Rank.King));
            cards.Add(new Card(Suit.Spades, Rank.Ace));
            // Filler
            cards.Add(new Card(Suit.Hearts, (Rank)2));
            cards.Add(new Card(Suit.Hearts, (Rank)5));
            Score expected = Score.Straight;

            // Act
            Score actual = _winConditions.Evaluate(cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}