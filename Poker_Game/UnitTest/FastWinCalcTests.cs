using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker_Game.Game;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class FastWinCalcTests
    {
        public FastWinCalc WinCalc = new FastWinCalc();

        [TestMethod]
        public void FastWinCalcTest_Pair1()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)6);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Spades, (Rank)8);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            player1Cards.Add(new Card(Suit.Clubs, (Rank)4)); //has pair of 4's
            player1Cards.Add(new Card(Suit.Diamonds, Rank.King));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Diamonds, (Rank)5)); //has pair of 5's
            player2Cards.Add(new Card(Suit.Spades, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_Pair2()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)6);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Spades, (Rank)8);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            player1Cards.Add(new Card(Suit.Clubs, (Rank)4)); //has pair of 4's
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Diamonds, (Rank)4)); //has pair of 4's
            player2Cards.Add(new Card(Suit.Spades, (Rank)3));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 0;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_Pair3()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)6);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Spades, (Rank)8);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            player1Cards.Add(new Card(Suit.Clubs, (Rank)4)); //has pair of 4's
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Diamonds, (Rank)10)); //has pair of 10's
            player2Cards.Add(new Card(Suit.Spades, (Rank)3));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_Straight1()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            player1Cards.Add(new Card(Suit.Clubs, (Rank)4));
            player1Cards.Add(new Card(Suit.Clubs, Rank.Ace)); //has straight
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Diamonds, (Rank)5));
            player2Cards.Add(new Card(Suit.Spades, (Rank)5)); //has 3 of a kind
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = -1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_Straight2()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            player1Cards.Add(new Card(Suit.Clubs, (Rank)4)); // has straight
            player1Cards.Add(new Card(Suit.Clubs, Rank.Ace));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Diamonds, Rank.Ace)); // has straight
            player2Cards.Add(new Card(Suit.Diamonds, (Rank)4));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = -1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_Straight2Reversed()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            player1Cards.Add(new Card(Suit.Diamonds, Rank.Ace)); //has straight
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)4));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)4));
            player2Cards.Add(new Card(Suit.Clubs, Rank.Ace)); //has straight
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_Straight3()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, Rank.Queen);

            player1Cards.Add(new Card(Suit.Diamonds, Rank.King));
            player1Cards.Add(new Card(Suit.Diamonds, Rank.Jack)); //has straight
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)4)); //has nothing (but almost straight)
            player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_Straight4()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Spades, (Rank)4); //straight
            Card tableCard5 = new Card(Suit.Spades, (Rank)5);

            player1Cards.Add(new Card(Suit.Diamonds, Rank.King));
            player1Cards.Add(new Card(Suit.Diamonds, Rank.Jack));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Hearts, (Rank)4));
            player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 0;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_StraightFlush1()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //has full house
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)4)); //has straight flush
            player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_StraightFlush2()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)10);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)9);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Jack);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Clubs, (Rank)8)); //has straight flush
            player1Cards.Add(new Card(Suit.Clubs, (Rank)7));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)12)); //has straight flush
            player2Cards.Add(new Card(Suit.Clubs, (Rank)13));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_StraightFlush2Reversed()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)10);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)9);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Jack);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Clubs, (Rank)12)); //has straight flush
            player1Cards.Add(new Card(Suit.Clubs, (Rank)13));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)8)); //has straight flush
            player2Cards.Add(new Card(Suit.Clubs, (Rank)7));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = -1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_StraightFlush3()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Clubs, (Rank)4);
            Card tableCard5 = new Card(Suit.Clubs, (Rank)5);

            player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //has straight flush
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Hearts, (Rank)4)); //has straight flush
            player2Cards.Add(new Card(Suit.Hearts, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 0;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_StraightFlush4()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)10);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)9);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Jack);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Clubs, (Rank)2)); //has Flush
            player1Cards.Add(new Card(Suit.Clubs, (Rank)7));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)12)); //has straight flush
            player2Cards.Add(new Card(Suit.Clubs, (Rank)13));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_FlushVsFullHouse()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)7);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)5);

            player1Cards.Add(new Card(Suit.Clubs, (Rank)2)); //flush
            player1Cards.Add(new Card(Suit.Clubs, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Diamonds, (Rank)7)); //full house
            player2Cards.Add(new Card(Suit.Hearts, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_FlushVsFullHouseReversed()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)7);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)5);


            player1Cards.Add(new Card(Suit.Diamonds, (Rank)7)); //full house
            player1Cards.Add(new Card(Suit.Hearts, (Rank)5));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)2)); //flush
            player2Cards.Add(new Card(Suit.Clubs, (Rank)3));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = -1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_Flush1()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Clubs, (Rank)8);
            Card tableCard5 = new Card(Suit.Clubs, (Rank)9); //flush on street

            player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); 
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Hearts, (Rank)4)); 
            player2Cards.Add(new Card(Suit.Hearts, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 0;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_Flush2()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)11);
            Card tableCard4 = new Card(Suit.Hearts, (Rank)8);
            Card tableCard5 = new Card(Suit.Hearts, (Rank)9); //flush on street

            player1Cards.Add(new Card(Suit.Clubs, (Rank)8));
            player1Cards.Add(new Card(Suit.Clubs, (Rank)13));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)12));
            player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = -1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_Flush3()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)11);
            Card tableCard4 = new Card(Suit.Hearts, (Rank)8);
            Card tableCard5 = new Card(Suit.Hearts, (Rank)9); //flush on street

            player1Cards.Add(new Card(Suit.Clubs, (Rank)6));
            player1Cards.Add(new Card(Suit.Clubs, (Rank)7));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)14));
            player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_FlushVs4OfAKind()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)14);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Clubs, (Rank)9)); //straight
            player1Cards.Add(new Card(Suit.Clubs, (Rank)12));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Hearts, (Rank)14)); //4 of a kind
            player2Cards.Add(new Card(Suit.Diamonds, (Rank)14));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_FlushVs4OfAKindReversed()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)14);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Hearts, (Rank)14)); //4 of a kind
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)14));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);
            
            player2Cards.Add(new Card(Suit.Clubs, (Rank)9)); //straight
            player2Cards.Add(new Card(Suit.Clubs, (Rank)12));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = -1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_4OfAKind1()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard2 = new Card(Suit.Diamonds, (Rank)5);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)5); //4 of a kind
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Diamonds, (Rank)14)); //high ace
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)14)); //high ace
            player2Cards.Add(new Card(Suit.Clubs, (Rank)7));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 0;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_4OfAKind2()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard2 = new Card(Suit.Diamonds, (Rank)5);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard4 = new Card(Suit.Spades, (Rank)5); 
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Hearts, (Rank)3)); //4 of a kind of 3's
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)5)); //four of a kind of 5's
            player2Cards.Add(new Card(Suit.Clubs, (Rank)7));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_4OfAKind2Reversed()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard2 = new Card(Suit.Diamonds, (Rank)5);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard4 = new Card(Suit.Spades, (Rank)5);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Clubs, (Rank)5)); //four of a kind of 5's
            player1Cards.Add(new Card(Suit.Clubs, (Rank)7));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Hearts, (Rank)3)); //4 of a kind of 3's
            player2Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = -1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_4OfAKindVs3OfAKind()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Hearts, (Rank)14);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Hearts, (Rank)3);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //4 of a kind
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)14)); //3 of a kind
            player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = -1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_4OfAKindVs3OfAKindReversed()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Hearts, (Rank)14);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Hearts, (Rank)3);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Clubs, (Rank)14)); //3 of a kind
            player1Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //4 of a kind
            player2Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_FullHouse1()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //full house, 3 over 2
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Hearts, (Rank)2)); //full house, 2 over 3
            player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = -1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_FullHouse1Reversed()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Hearts, (Rank)2)); //full house, 2 over 3
            player1Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //full house, 3 over 2
            player2Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_FullHouse2()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //full house, 3 over 2
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Hearts, (Rank)3)); //full house, 3 over ace
            player2Cards.Add(new Card(Suit.Diamonds, (Rank)14));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_FullHouse2Reversed()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Hearts, (Rank)3)); //full house, 3 over ace
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)14));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //full house, 3 over 2
            player2Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = -1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_FullHouse3()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //Full house, 3 over 2
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Hearts, (Rank)3)); //Full house, 3 over 2
            player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 0;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_FullHouseVsPair()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //Full house 2 over 3
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Hearts, (Rank)14)); //Pair ace
            player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = -1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_FullHouseVsPairReversed()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            player1Cards.Add(new Card(Suit.Hearts, (Rank)14)); //Pair ace
            player1Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //Full house 2 over 3
            player2Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_2Pairs1()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Hearts, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3); //2 pairs, high ace

            player1Cards.Add(new Card(Suit.Diamonds, (Rank)7)); 
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)9));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)8)); 
            player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 0;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_2Pairs2()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)9);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)12);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)7);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //2pairs, 3 and 2
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)3)); //2pairs, 9 and 3
            player2Cards.Add(new Card(Suit.Clubs, (Rank)9));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_2Pairs2Reversed()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)9);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)12);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)7);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Clubs, (Rank)3)); //2pairs, 9 and 3
            player1Cards.Add(new Card(Suit.Clubs, (Rank)9));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //2pairs, 3 and 2
            player2Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = -1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_2Pairs3()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)7);
            Card tableCard3 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2); //pair 3
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //2 pair, 7 and 3
            player1Cards.Add(new Card(Suit.Diamonds, (Rank)7));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Clubs, (Rank)7)); //2 pairs, 7 and 5
            player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = 1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_2Pairs3Reversed()
        {
            // Arrange
            List<Card> player1Cards = new List<Card>();
            List<Card> player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)7);
            Card tableCard3 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2); //pair 3
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);
            
            player1Cards.Add(new Card(Suit.Clubs, (Rank)7)); //2 pairs, 7 and 5
            player1Cards.Add(new Card(Suit.Clubs, (Rank)5));
            player1Cards.Add(tableCard1);
            player1Cards.Add(tableCard2);
            player1Cards.Add(tableCard3);
            player1Cards.Add(tableCard4);
            player1Cards.Add(tableCard5);

            player2Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //2 pair, 7 and 3
            player2Cards.Add(new Card(Suit.Diamonds, (Rank)7));
            player2Cards.Add(tableCard1);
            player2Cards.Add(tableCard2);
            player2Cards.Add(tableCard3);
            player2Cards.Add(tableCard4);
            player2Cards.Add(tableCard5);

            //Expected
            int expected = -1;

            // Act
            int actual = WinCalc.WhoWins(player1Cards, player2Cards);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void FastWinCalc_FunctionTest_hasStraightFlush()
        {
             // Arrange
            List<Card> playerCards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            playerCards.Add(new Card(Suit.Clubs, (Rank)4));
            playerCards.Add(new Card(Suit.Clubs, (Rank)5));
            playerCards.Add(tableCard1);
            playerCards.Add(tableCard2);
            playerCards.Add(tableCard3);
            playerCards.Add(tableCard4);
            playerCards.Add(tableCard5);

            //Expected
            int expected = 5;

            // Act
            int actual = WinCalc.HasStraightFlush(playerCards, Suit.Clubs);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
