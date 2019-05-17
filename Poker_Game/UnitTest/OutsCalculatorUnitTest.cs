using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker_Game.Game;
using Poker_Game;
using Poker_Game.AI;

namespace UnitTest
{
    [TestClass]
    public class OutsCalculatorUnitTest
    {
        public OutsCalculator OutsCalculator = new OutsCalculator();

        [TestMethod]
        public void HasFlushChanceAndHasStraightChanceTest()
        {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, Rank.Ace); // Flush chance and straight chance on hand
            Card handCard2 = new Card(Suit.Spades, Rank.King);

            Card tableCard1 = new Card(Suit.Hearts, (Rank) 5);
            Card tableCard2 = new Card(Suit.Clubs, (Rank) 2);
            Card tableCard3 = new Card(Suit.Diamonds, (Rank) 9);
            Card tableCard4 = new Card(Suit.Hearts, (Rank) 4);
            Card tableCard5 = new Card(Suit.Spades, (Rank) 10);

            List<Card> hand = new List<Card>
            {
                handCard1, handCard2, tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };
             
            List<Card> street = new List<Card>
            {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            var expected = (13 - (7 + 1)) + (-2); // Flush outs + straight outs

            // Act
            var actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasFlushChanceAndNotStraightChanceTest()
        {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, Rank.Ace); // Flush chance on hand, not straight chance
            Card handCard2 = new Card(Suit.Spades, (Rank) 10);

            Card tableCard1 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Diamonds, (Rank)9);
            Card tableCard4 = new Card(Suit.Hearts, (Rank)4);
            Card tableCard5 = new Card(Suit.Spades, (Rank) 8);

            List<Card> hand = new List<Card>
            {
                handCard1, handCard2, tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            List<Card> street = new List<Card>
            {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            var expected = (13 - (1 + 7)); // Flush outs (13 - (Same suit in street as hand + number of cards in hands))

            // Act
            var actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasStraightChanceNotFlushChanceTest()
        {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, Rank.Ace); // Straight chance on hands, not flush chance
            Card handCard2 = new Card(Suit.Clubs, Rank.Jack);

            Card tableCard1 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Diamonds, (Rank)9);
            Card tableCard4 = new Card(Suit.Hearts, (Rank)4);
            Card tableCard5 = new Card(Suit.Spades, (Rank)8);

            List<Card> hand = new List<Card>
            {
                handCard1, handCard2, tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            List<Card> street = new List<Card>
            {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            var expected = (5 - 7); // 5 - number of straightCards

            // Act
            var actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasPocketPairTest()
        {
            // Arrange
            Card handCard1 = new Card(Suit.Spades, Rank.Ace); // Flush chance on hand, not straight chance
            Card handCard2 = new Card(Suit.Hearts, (Rank)5);

            Card tableCard1 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Diamonds, (Rank)9);
            Card tableCard4 = new Card(Suit.Hearts, (Rank)4);
            Card tableCard5 = new Card(Suit.Spades, (Rank)8);

            List<Card> hand = new List<Card>
            {
                handCard1, handCard2, tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            List<Card> street = new List<Card>
            {
                tableCard1, tableCard2, tableCard3, tableCard4, tableCard5
            };

            var expected = 2;

            // Act
            var actual = OutsCalculator.CompareOuts(hand, street);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
