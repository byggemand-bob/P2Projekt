using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker_Game.Game;
using Poker_Game;


namespace UnitTest
{
    [TestClass]
    public class PokerGameUnitTest
    {
        public Settings Settings;
        public PokerGame Game;

        public void CreatePropperties()
        {
            Settings = new Settings(2, 1000, 50, true, 50, "bob", 2);
            Game = new PokerGame(Settings);
        }

        [TestMethod]
        public void TestNumberOfPlayers()
        {
            // Arrange
            CreatePropperties();
            int expected = 2;

            // Act
            int actual = Game.Players.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestRoundIncrements()
        {
            // Arrange
            CreatePropperties();
            // Round 1
            Game.Call();
            Game.Check();
            // Round 2
            Game.Check();
            Game.Check();
            // Round 3
            Game.Check();
            Game.Check();
            // Round 4
            Game.Check();
            Game.Check();
            // Round 5
            Game.Check();
            Game.Check();

            var expected = 5;

            // Act
            var actual = Game.Hands[Game.CurrentHandNumber() - 1].CurrentRoundNumber();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestHandIncrements()
        {
            // Arrange
            CreatePropperties();
            // Hand 1
            // Round 1
            Game.Call();
            Game.Check();
            // Round 2
            Game.Check();
            Game.Check();
            // Round 3
            Game.Check();
            Game.Check();
            // Round 4
            Game.Check();
            Game.Check();
            // Round 5
            Game.Check();
            Game.Check();

            Game.NewHand();

            // Hand 2
            // Round 1
            Game.Call();
            Game.Check();
            // Round 2
            Game.Check();
            Game.Check();
            // Round 3
            Game.Check();
            Game.Check();
            // Round 4
            Game.Check();
            Game.Check();
            // Round 5
            Game.Check();
            Game.Check();
            var expected = 2;

            // Act
            var actual = Game.CurrentHandNumber();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestWinnerIfPlayerFolds()
        {
            // Arrange
            CreatePropperties();
            // Round 1
            Game.Call();
            Game.Check();
            // Round 2
            Game.Fold();

            var expected = Game.Players[1].Id;

            // Act
            var actual = Game.GetWinners(Game.Hands[Game.CurrentHandNumber() - 1]);

            // Assert
            Assert.AreEqual(expected, actual[0].Id);
        }


        [TestMethod] 
        public void TestRaiseFunctionallity()
        {
            // Arrange
            CreatePropperties();
            // Round 1
            Game.Raise();
            Game.Call();
            Game.Check();

            var expected = 400;
            
            // Act
            var actual = Game.Hands[Game.CurrentHandNumber() - 1].Pot;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}