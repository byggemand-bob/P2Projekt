using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker_Game.Game;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class FastWinCalcTests
    {
        FastWinCalc winCalc = new FastWinCalc();

        [TestMethod]
        public void FastWinCalcTest_Pair1()
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
        public void FastWinCalcTest_Pair2()
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
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)4)); //has pair of 4's
            Player2Cards.Add(new Card(Suit.Spades, (Rank)3));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            // Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_Pair3()
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
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)10)); //has pair of 10's
            Player2Cards.Add(new Card(Suit.Spades, (Rank)3));
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
        public void FastWinCalcTest_Straight1()
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
            Player1Cards.Add(new Card(Suit.Clubs, Rank.Ace)); //has straight
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)5));
            Player2Cards.Add(new Card(Suit.Spades, (Rank)5)); //has 3 of a kind
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
        public void FastWinCalcTest_Straight2()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)4)); // has straight
            Player1Cards.Add(new Card(Suit.Clubs, Rank.Ace));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, Rank.Ace)); // has straight
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
        public void FastWinCalcTest_Straight2Reversed()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)10);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            Player1Cards.Add(new Card(Suit.Diamonds, Rank.Ace)); //has straight
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)4));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)4));
            Player2Cards.Add(new Card(Suit.Clubs, Rank.Ace)); //has straight
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
        public void FastWinCalcTest_Straight3()
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
            Player1Cards.Add(new Card(Suit.Diamonds, Rank.Jack)); //has straight
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)4)); //has nothing (but almost straight)
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
        public void FastWinCalcTest_Straight4()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Spades, (Rank)4); //straight
            Card tableCard5 = new Card(Suit.Spades, (Rank)5);

            Player1Cards.Add(new Card(Suit.Diamonds, Rank.King));
            Player1Cards.Add(new Card(Suit.Diamonds, Rank.Jack));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Hearts, (Rank)4));
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            // Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_StraightFlush1()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //has full house
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)4)); //has straight flush
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
        public void FastWinCalcTest_StraightFlush2()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)10);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)9);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Jack);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)8)); //has straight flush
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)7));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)12)); //has straight flush
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)13));
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
        public void FastWinCalcTest_StraightFlush2Reversed()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)10);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)9);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Jack);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)12)); //has straight flush
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)13));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)8)); //has straight flush
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)7));
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
        public void FastWinCalcTest_StraightFlush3()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Clubs, (Rank)4);
            Card tableCard5 = new Card(Suit.Clubs, (Rank)5);

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //has straight flush
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Hearts, (Rank)4)); //has straight flush
            Player2Cards.Add(new Card(Suit.Hearts, (Rank)5));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            // Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_StraightFlush4()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)10);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)9);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Jack);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)2)); //has Flush
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)7));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)12)); //has straight flush
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)13));
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
        public void FastWinCalcTest_FlushVsFullHouse()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)7);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)5);

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)2)); //flush
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)7)); //full house
            Player2Cards.Add(new Card(Suit.Hearts, (Rank)5));
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
        public void FastWinCalcTest_FlushVsFullHouseReversed()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)7);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)5);


            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)7)); //full house
            Player1Cards.Add(new Card(Suit.Hearts, (Rank)5));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)2)); //flush
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)3));
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
        public void FastWinCalcTest_Flush1()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
            Card tableCard4 = new Card(Suit.Clubs, (Rank)8);
            Card tableCard5 = new Card(Suit.Clubs, (Rank)9); //flush on street

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); 
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Hearts, (Rank)4)); 
            Player2Cards.Add(new Card(Suit.Hearts, (Rank)5));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            // Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_Flush2()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)11);
            Card tableCard4 = new Card(Suit.Hearts, (Rank)8);
            Card tableCard5 = new Card(Suit.Hearts, (Rank)9); //flush on street

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)8));
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)13));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)12));
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
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
        public void FastWinCalcTest_Flush3()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)11);
            Card tableCard4 = new Card(Suit.Hearts, (Rank)8);
            Card tableCard5 = new Card(Suit.Hearts, (Rank)9); //flush on street

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)6));
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)7));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)14));
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
        public void FastWinCalcTest_FlushVs4OfAKind()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)14);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)9)); //straight
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)12));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Hearts, (Rank)14)); //4 of a kind
            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)14));
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
        public void FastWinCalcTest_FlushVs4OfAKindReversed()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)14);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Hearts, (Rank)14)); //4 of a kind
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)14));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);
            
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)9)); //straight
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)12));
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
        public void FastWinCalcTest_4OfAKind1()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard2 = new Card(Suit.Diamonds, (Rank)5);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)5); //4 of a kind
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)14)); //high ace
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)14)); //high ace
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)7));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            // Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_4OfAKind2()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard2 = new Card(Suit.Diamonds, (Rank)5);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard4 = new Card(Suit.Spades, (Rank)5); 
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Hearts, (Rank)3)); //4 of a kind of 3's
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)5)); //four of a kind of 5's
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)7));
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
        public void FastWinCalcTest_4OfAKind2Reversed()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard2 = new Card(Suit.Diamonds, (Rank)5);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard4 = new Card(Suit.Spades, (Rank)5);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)5)); //four of a kind of 5's
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)7));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Hearts, (Rank)3)); //4 of a kind of 3's
            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)3));
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
        public void FastWinCalcTest_4OfAKindVs3OfAKind()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Hearts, (Rank)14);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Hearts, (Rank)3);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //4 of a kind
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)14)); //3 of a kind
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
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
        public void FastWinCalcTest_4OfAKindVs3OfAKindReversed()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Hearts, (Rank)14);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Hearts, (Rank)3);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)14)); //3 of a kind
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)5));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //4 of a kind
            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)3));
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
        public void FastWinCalcTest_FullHouse1()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //full house, 3 over 2
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Hearts, (Rank)2)); //full house, 2 over 3
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
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
        public void FastWinCalcTest_FullHouse1Reversed()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Hearts, (Rank)2)); //full house, 2 over 3
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)5));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //full house, 3 over 2
            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)3));
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
        public void FastWinCalcTest_FullHouse2()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //full house, 3 over 2
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Hearts, (Rank)3)); //full house, 3 over ace
            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)14));
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
        public void FastWinCalcTest_FullHouse2Reversed()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Hearts, (Rank)3)); //full house, 3 over ace
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)14));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //full house, 3 over 2
            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)3));
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
        public void FastWinCalcTest_FullHouse3()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //Full house, 3 over 2
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Hearts, (Rank)3)); //Full house, 3 over 2
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            // Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_FullHouseVsPair()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //Full house 2 over 3
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Hearts, (Rank)14)); //Pair ace
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
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
        public void FastWinCalcTest_FullHouseVsPairReversed()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            Player1Cards.Add(new Card(Suit.Hearts, (Rank)14)); //Pair ace
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)5));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //Full house 2 over 3
            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)3));
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
        public void FastWinCalcTest_2Pairs1()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Hearts, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3); //2 pairs, high ace

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)7)); 
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)9));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)8)); 
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)5));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            // Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void FastWinCalcTest_2Pairs2()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)9);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)12);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)7);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //2pairs, 3 and 2
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)3)); //2pairs, 9 and 3
            Player2Cards.Add(new Card(Suit.Clubs, (Rank)9));
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
        public void FastWinCalcTest_2Pairs2Reversed()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Hearts, (Rank)9);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)12);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)7);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Clubs, (Rank)3)); //2pairs, 9 and 3
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)9));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //2pairs, 3 and 2
            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)3));
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
        public void FastWinCalcTest_2Pairs3()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)7);
            Card tableCard3 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2); //pair 3
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //2 pair, 7 and 3
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)7));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)7)); //2 pairs, 7 and 5
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
        public void FastWinCalcTest_2Pairs3Reversed()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)7);
            Card tableCard3 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2); //pair 3
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);
            
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)7)); //2 pairs, 7 and 5
            Player1Cards.Add(new Card(Suit.Clubs, (Rank)5));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //2 pair, 7 and 3
            Player2Cards.Add(new Card(Suit.Diamonds, (Rank)7));
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
        public void FastWinCalcTest_()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, (Rank)14);
            Card tableCard4 = new Card(Suit.Spades, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)3);

            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)2)); //
            Player1Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card(Suit.Clubs, (Rank)4)); //
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
        public void FastWinCalc_hasStraightFlushFunctionTest()
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
