﻿using System;
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
        public void FastWinCalcTest_()
        {
            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card(Suit.Clubs, (Rank)3);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)2);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Ace);
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
