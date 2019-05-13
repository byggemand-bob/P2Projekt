using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class FastWinCalcTest
    {
        FastWinCalc winCalc = new FastWinCalc();
        
        [TestMethod]
        public void FastWinCalcTest1()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)6);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Spades, (Rank)8);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)4)); //has pair of 4's
            Player1Cards.Add(new Card(Suit.Diamonds, Rank.King));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)5)); //has pair of 5's
            Player2Cards.Add(new Card(Suit.Spades, (Rank)5));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            // Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            // Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest2()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)4));
            Player1Cards.Add(new Card(Suit.Clubs, Rank.Ace));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)5));
            Player2Cards.Add(new Card(Suit.Spades, (Rank)5));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            // Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            // Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest3()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)4));
            Player1Cards.Add(new Card(Suit.Clubs, Rank.Ace));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, Rank.Ace));
            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)4));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            // Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            // Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest4()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            Player1Cards.Add(new Card(Suit.Diamonds, Rank.Ace));
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)4));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);
            
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)4));
            Player2Cards.Add(new Card(Suit.Clubs, Rank.Ace));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            // Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            // Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest5()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, Rank.Queen);

            Player1Cards.Add(new Card(Suit.Diamonds, Rank.King));
            Player1Cards.Add(new Card(Suit.Diamonds, Rank.Jack));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)4));
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            // Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            // Assert
            Assert.AreEqual(1, actual);
        }
        
        [TestMethod]
        public void FastWinCalcTest6()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)2));
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)4));
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            // Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            // Assert
            Assert.AreEqual(1, actual);
        }
        
        [TestMethod]
        public void FastWinCalcTest7()
        {
            int result = 0;
            
            // Arrange
            List<Card> PlayerCards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            PlayerCards.Add(new Card(Suit.Clubs, (Rank)4));
            PlayerCards.Add(new Card(Suit.Clubs, (Rank)5));
            PlayerCards.Add(tableCard1);
            PlayerCards.Add(tableCard2);
            PlayerCards.Add(tableCard3);
            PlayerCards.Add(tableCard4);
            PlayerCards.Add(tableCard5);

            // Act
            result = winCalc.hasStraightFlush(PlayerCards, Suit.Clubs);

            // Assert
            Assert.AreEqual(5, result);
        }
        
    }
}
