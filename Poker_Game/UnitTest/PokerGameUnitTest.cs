using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker_Game.Game;
using Poker_Game;
using Poker_Game.AI;


namespace UnitTest
{
    [TestClass]
    public class PokerGameUnitTest
    {
        public Settings Settings;
        public PokerGame Game;

        public void CreateProperties()
        {
            Settings = new Settings(2, 1000, 50, "bob", 1, AiMode.MonteCarlo);
            Game = new PokerGame(Settings);
        }

        [TestMethod]
        public void TestNumberOfPlayers()
        {
            // Arrange
            CreateProperties();
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
            CreateProperties();
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
            var actual = Game.Hand.CurrentRoundNumber();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void TestWinnerIfPlayerFolds()
        {
            // Arrange
            CreateProperties();
            // Round 1
            Game.Call();
            // Round 2
            Game.Fold();

            var expected = Game.Players[0].Id;

            // Act
            var actual = Game.GetWinners(Game.Hand);

            // Assert
            Assert.AreEqual(expected, actual[0].Id);
        }


        [TestMethod]
        public void TestRaiseFunctionality()
        {
            // Arrange
            CreateProperties();
            // Round 1
            Game.Raise();
            Game.Call();

            var expected = 400;

            // Act
            var actual = Game.Hand.Pot;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
