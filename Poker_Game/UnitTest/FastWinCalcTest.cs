﻿using System;
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

        [TestMethod]
        public void FastWinCalcTest8()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)1, (Rank)13);
            Card tableCard2 = new Card((Suit)1, (Rank)8);
            Card tableCard3 = new Card((Suit)0, (Rank)14);
            Card tableCard4 = new Card((Suit)3, (Rank)13);
            Card tableCard5 = new Card((Suit)2, (Rank)5);

            Player1Cards.Add(new Card((Suit)1, (Rank)9));
            Player1Cards.Add(new Card((Suit)3, (Rank)10));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)3, (Rank)3));
            Player2Cards.Add(new Card((Suit)3, (Rank)8));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest9()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)1, (Rank)2);
            Card tableCard2 = new Card((Suit)3, (Rank)3);
            Card tableCard3 = new Card((Suit)1, (Rank)6);
            Card tableCard4 = new Card((Suit)1, (Rank)5);
            Card tableCard5 = new Card((Suit)0, (Rank)10);

            Player1Cards.Add(new Card((Suit)0, (Rank)8));
            Player1Cards.Add(new Card((Suit)2, (Rank)8));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)2, (Rank)5));
            Player2Cards.Add(new Card((Suit)2, (Rank)9));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest10()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)0, (Rank)6);
            Card tableCard2 = new Card((Suit)1, (Rank)7);
            Card tableCard3 = new Card((Suit)3, (Rank)11);
            Card tableCard4 = new Card((Suit)1, (Rank)3);
            Card tableCard5 = new Card((Suit)1, (Rank)2);

            Player1Cards.Add(new Card((Suit)2, (Rank)10));
            Player1Cards.Add(new Card((Suit)1, (Rank)9));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)2, (Rank)14));
            Player2Cards.Add(new Card((Suit)0, (Rank)14));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest11()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)0, (Rank)3);
            Card tableCard2 = new Card((Suit)3, (Rank)5);
            Card tableCard3 = new Card((Suit)2, (Rank)10);
            Card tableCard4 = new Card((Suit)1, (Rank)2);
            Card tableCard5 = new Card((Suit)0, (Rank)2);

            Player1Cards.Add(new Card((Suit)0, (Rank)13));
            Player1Cards.Add(new Card((Suit)0, (Rank)12));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)2, (Rank)3));
            Player2Cards.Add(new Card((Suit)2, (Rank)4));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest12()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)3, (Rank)14);
            Card tableCard2 = new Card((Suit)3, (Rank)8);
            Card tableCard3 = new Card((Suit)3, (Rank)13);
            Card tableCard4 = new Card((Suit)1, (Rank)2);
            Card tableCard5 = new Card((Suit)0, (Rank)2);

            Player1Cards.Add(new Card((Suit)0, (Rank)13));
            Player1Cards.Add(new Card((Suit)3, (Rank)10));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)0, (Rank)6));
            Player2Cards.Add(new Card((Suit)2, (Rank)12));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest13()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)3, (Rank)8);
            Card tableCard2 = new Card((Suit)3, (Rank)10);
            Card tableCard3 = new Card((Suit)1, (Rank)5);
            Card tableCard4 = new Card((Suit)3, (Rank)14);
            Card tableCard5 = new Card((Suit)3, (Rank)12);

            Player1Cards.Add(new Card((Suit)2, (Rank)4));
            Player1Cards.Add(new Card((Suit)1, (Rank)10));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)2, (Rank)8));
            Player2Cards.Add(new Card((Suit)0, (Rank)4));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest14()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)3, (Rank)4);
            Card tableCard2 = new Card((Suit)2, (Rank)2);
            Card tableCard3 = new Card((Suit)0, (Rank)2);
            Card tableCard4 = new Card((Suit)2, (Rank)10);
            Card tableCard5 = new Card((Suit)2, (Rank)6);

            Player1Cards.Add(new Card((Suit)0, (Rank)14));
            Player1Cards.Add(new Card((Suit)0, (Rank)9));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)3, (Rank)5));
            Player2Cards.Add(new Card((Suit)0, (Rank)10));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest15()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)2, (Rank)4);
            Card tableCard2 = new Card((Suit)0, (Rank)5);
            Card tableCard3 = new Card((Suit)3, (Rank)10);
            Card tableCard4 = new Card((Suit)2, (Rank)10);
            Card tableCard5 = new Card((Suit)3, (Rank)9);

            Player1Cards.Add(new Card((Suit)0, (Rank)11));
            Player1Cards.Add(new Card((Suit)3, (Rank)2));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)1, (Rank)3));
            Player2Cards.Add(new Card((Suit)3, (Rank)3));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest16()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)1, (Rank)8);
            Card tableCard2 = new Card((Suit)1, (Rank)7);
            Card tableCard3 = new Card((Suit)0, (Rank)13);
            Card tableCard4 = new Card((Suit)3, (Rank)13);
            Card tableCard5 = new Card((Suit)0, (Rank)5);

            Player1Cards.Add(new Card((Suit)0, (Rank)14));
            Player1Cards.Add(new Card((Suit)2, (Rank)14));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)3, (Rank)14));
            Player2Cards.Add(new Card((Suit)3, (Rank)12));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest17()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)3, (Rank)5);
            Card tableCard2 = new Card((Suit)2, (Rank)10);
            Card tableCard3 = new Card((Suit)3, (Rank)14);
            Card tableCard4 = new Card((Suit)3, (Rank)3);
            Card tableCard5 = new Card((Suit)0, (Rank)9);

            Player1Cards.Add(new Card((Suit)3, (Rank)11));
            Player1Cards.Add(new Card((Suit)3, (Rank)6));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)2, (Rank)11));
            Player2Cards.Add(new Card((Suit)0, (Rank)4));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest18()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)1, (Rank)7);
            Card tableCard2 = new Card((Suit)3, (Rank)4);
            Card tableCard3 = new Card((Suit)2, (Rank)7);
            Card tableCard4 = new Card((Suit)0, (Rank)7);
            Card tableCard5 = new Card((Suit)1, (Rank)5);

            Player1Cards.Add(new Card((Suit)1, (Rank)13));
            Player1Cards.Add(new Card((Suit)3, (Rank)6));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)1, (Rank)10));
            Player2Cards.Add(new Card((Suit)2, (Rank)3));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest19()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)2, (Rank)12);
            Card tableCard2 = new Card((Suit)0, (Rank)7);
            Card tableCard3 = new Card((Suit)3, (Rank)3);
            Card tableCard4 = new Card((Suit)2, (Rank)13);
            Card tableCard5 = new Card((Suit)3, (Rank)14);

            Player1Cards.Add(new Card((Suit)1, (Rank)8));
            Player1Cards.Add(new Card((Suit)1, (Rank)6));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)2, (Rank)6));
            Player2Cards.Add(new Card((Suit)3, (Rank)10));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest20()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)0, (Rank)10);
            Card tableCard2 = new Card((Suit)0, (Rank)9);
            Card tableCard3 = new Card((Suit)2, (Rank)2);
            Card tableCard4 = new Card((Suit)1, (Rank)5);
            Card tableCard5 = new Card((Suit)0, (Rank)5);

            Player1Cards.Add(new Card((Suit)3, (Rank)7));
            Player1Cards.Add(new Card((Suit)3, (Rank)12));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)3, (Rank)4));
            Player2Cards.Add(new Card((Suit)1, (Rank)11));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest21()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)2, (Rank)7);
            Card tableCard2 = new Card((Suit)1, (Rank)4);
            Card tableCard3 = new Card((Suit)1, (Rank)13);
            Card tableCard4 = new Card((Suit)3, (Rank)10);
            Card tableCard5 = new Card((Suit)1, (Rank)3);

            Player1Cards.Add(new Card((Suit)2, (Rank)12));
            Player1Cards.Add(new Card((Suit)2, (Rank)2));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)0, (Rank)7));
            Player2Cards.Add(new Card((Suit)0, (Rank)4));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest22()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)2, (Rank)4);
            Card tableCard2 = new Card((Suit)0, (Rank)4);
            Card tableCard3 = new Card((Suit)2, (Rank)10);
            Card tableCard4 = new Card((Suit)3, (Rank)9);
            Card tableCard5 = new Card((Suit)1, (Rank)9);

            Player1Cards.Add(new Card((Suit)2, (Rank)6));
            Player1Cards.Add(new Card((Suit)1, (Rank)7));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)0, (Rank)13));
            Player2Cards.Add(new Card((Suit)2, (Rank)12));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest23()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)3, (Rank)4);
            Card tableCard2 = new Card((Suit)2, (Rank)2);
            Card tableCard3 = new Card((Suit)3, (Rank)5);
            Card tableCard4 = new Card((Suit)1, (Rank)13);
            Card tableCard5 = new Card((Suit)1, (Rank)9);

            Player1Cards.Add(new Card((Suit)1, (Rank)6));
            Player1Cards.Add(new Card((Suit)2, (Rank)4));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)3, (Rank)14));
            Player2Cards.Add(new Card((Suit)2, (Rank)13));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest24()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)2, (Rank)5);
            Card tableCard2 = new Card((Suit)0, (Rank)10);
            Card tableCard3 = new Card((Suit)1, (Rank)6);
            Card tableCard4 = new Card((Suit)0, (Rank)4);
            Card tableCard5 = new Card((Suit)1, (Rank)8);

            Player1Cards.Add(new Card((Suit)1, (Rank)4));
            Player1Cards.Add(new Card((Suit)0, (Rank)9));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)2, (Rank)12));
            Player2Cards.Add(new Card((Suit)0, (Rank)11));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest25()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)1, (Rank)9);
            Card tableCard2 = new Card((Suit)3, (Rank)7);
            Card tableCard3 = new Card((Suit)2, (Rank)3);
            Card tableCard4 = new Card((Suit)1, (Rank)10);
            Card tableCard5 = new Card((Suit)1, (Rank)11);

            Player1Cards.Add(new Card((Suit)2, (Rank)6));
            Player1Cards.Add(new Card((Suit)3, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)3, (Rank)14));
            Player2Cards.Add(new Card((Suit)1, (Rank)4));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest26()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)0, (Rank)9);
            Card tableCard2 = new Card((Suit)2, (Rank)9);
            Card tableCard3 = new Card((Suit)2, (Rank)4);
            Card tableCard4 = new Card((Suit)1, (Rank)4);
            Card tableCard5 = new Card((Suit)2, (Rank)5);

            Player1Cards.Add(new Card((Suit)1, (Rank)14));
            Player1Cards.Add(new Card((Suit)2, (Rank)11));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)3, (Rank)10));
            Player2Cards.Add(new Card((Suit)2, (Rank)3));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest27()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)0, (Rank)2);
            Card tableCard2 = new Card((Suit)1, (Rank)2);
            Card tableCard3 = new Card((Suit)1, (Rank)6);
            Card tableCard4 = new Card((Suit)0, (Rank)4);
            Card tableCard5 = new Card((Suit)2, (Rank)4);

            Player1Cards.Add(new Card((Suit)1, (Rank)4));
            Player1Cards.Add(new Card((Suit)2, (Rank)14));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)1, (Rank)10));
            Player2Cards.Add(new Card((Suit)2, (Rank)8));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest28()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)2, (Rank)8);
            Card tableCard2 = new Card((Suit)3, (Rank)7);
            Card tableCard3 = new Card((Suit)3, (Rank)4);
            Card tableCard4 = new Card((Suit)2, (Rank)4);
            Card tableCard5 = new Card((Suit)2, (Rank)7);

            Player1Cards.Add(new Card((Suit)0, (Rank)5));
            Player1Cards.Add(new Card((Suit)3, (Rank)8));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)1, (Rank)6));
            Player2Cards.Add(new Card((Suit)3, (Rank)3));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest29()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)2, (Rank)12);
            Card tableCard2 = new Card((Suit)0, (Rank)7);
            Card tableCard3 = new Card((Suit)2, (Rank)13);
            Card tableCard4 = new Card((Suit)2, (Rank)5);
            Card tableCard5 = new Card((Suit)1, (Rank)7);

            Player1Cards.Add(new Card((Suit)0, (Rank)10));
            Player1Cards.Add(new Card((Suit)1, (Rank)6));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)1, (Rank)12));
            Player2Cards.Add(new Card((Suit)3, (Rank)14));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest30()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)1, (Rank)6);
            Card tableCard2 = new Card((Suit)3, (Rank)5);
            Card tableCard3 = new Card((Suit)2, (Rank)13);
            Card tableCard4 = new Card((Suit)1, (Rank)2);
            Card tableCard5 = new Card((Suit)3, (Rank)13);

            Player1Cards.Add(new Card((Suit)2, (Rank)8));
            Player1Cards.Add(new Card((Suit)0, (Rank)3));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)2, (Rank)7));
            Player2Cards.Add(new Card((Suit)1, (Rank)13));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest31()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)2, (Rank)12);
            Card tableCard2 = new Card((Suit)3, (Rank)6);
            Card tableCard3 = new Card((Suit)1, (Rank)13);
            Card tableCard4 = new Card((Suit)2, (Rank)8);
            Card tableCard5 = new Card((Suit)1, (Rank)10);

            Player1Cards.Add(new Card((Suit)0, (Rank)14));
            Player1Cards.Add(new Card((Suit)3, (Rank)13));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)1, (Rank)6));
            Player2Cards.Add(new Card((Suit)3, (Rank)8));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest32()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)1, (Rank)3);
            Card tableCard2 = new Card((Suit)1, (Rank)4);
            Card tableCard3 = new Card((Suit)0, (Rank)3);
            Card tableCard4 = new Card((Suit)2, (Rank)2);
            Card tableCard5 = new Card((Suit)3, (Rank)12);

            Player1Cards.Add(new Card((Suit)1, (Rank)13));
            Player1Cards.Add(new Card((Suit)3, (Rank)7));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)0, (Rank)11));
            Player2Cards.Add(new Card((Suit)0, (Rank)13));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest33()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)0, (Rank)7);
            Card tableCard2 = new Card((Suit)1, (Rank)14);
            Card tableCard3 = new Card((Suit)1, (Rank)6);
            Card tableCard4 = new Card((Suit)1, (Rank)5);
            Card tableCard5 = new Card((Suit)0, (Rank)6);

            Player1Cards.Add(new Card((Suit)0, (Rank)14));
            Player1Cards.Add(new Card((Suit)1, (Rank)13));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)1, (Rank)8));
            Player2Cards.Add(new Card((Suit)1, (Rank)7));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest34()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)3, (Rank)11);
            Card tableCard2 = new Card((Suit)1, (Rank)4);
            Card tableCard3 = new Card((Suit)3, (Rank)8);
            Card tableCard4 = new Card((Suit)0, (Rank)2);
            Card tableCard5 = new Card((Suit)3, (Rank)12);

            Player1Cards.Add(new Card((Suit)3, (Rank)6));
            Player1Cards.Add(new Card((Suit)1, (Rank)7));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)2, (Rank)13));
            Player2Cards.Add(new Card((Suit)1, (Rank)14));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest35()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)0, (Rank)13);
            Card tableCard2 = new Card((Suit)1, (Rank)13);
            Card tableCard3 = new Card((Suit)2, (Rank)12);
            Card tableCard4 = new Card((Suit)1, (Rank)9);
            Card tableCard5 = new Card((Suit)0, (Rank)11);

            Player1Cards.Add(new Card((Suit)1, (Rank)6));
            Player1Cards.Add(new Card((Suit)0, (Rank)4));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)2, (Rank)5));
            Player2Cards.Add(new Card((Suit)2, (Rank)10));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void FastWinCalcTest36()
        {

            // Arrange
            List<Card> Player1Cards = new List<Card>();
            List<Card> Player2Cards = new List<Card>();

            Card tableCard1 = new Card((Suit)2, (Rank)9);
            Card tableCard2 = new Card((Suit)3, (Rank)13);
            Card tableCard3 = new Card((Suit)1, (Rank)7);
            Card tableCard4 = new Card((Suit)2, (Rank)4);
            Card tableCard5 = new Card((Suit)0, (Rank)6);

            Player1Cards.Add(new Card((Suit)0, (Rank)10));
            Player1Cards.Add(new Card((Suit)1, (Rank)8));
            Player1Cards.Add(tableCard1);
            Player1Cards.Add(tableCard2);
            Player1Cards.Add(tableCard3);
            Player1Cards.Add(tableCard4);
            Player1Cards.Add(tableCard5);

            Player2Cards.Add(new Card((Suit)1, (Rank)10));
            Player2Cards.Add(new Card((Suit)1, (Rank)13));
            Player2Cards.Add(tableCard1);
            Player2Cards.Add(tableCard2);
            Player2Cards.Add(tableCard3);
            Player2Cards.Add(tableCard4);
            Player2Cards.Add(tableCard5);

            //Act
            int actual = winCalc.WhoWins(Player1Cards, Player2Cards);

            //Assert
            Assert.AreEqual(-1, actual);
        }
    }
}
