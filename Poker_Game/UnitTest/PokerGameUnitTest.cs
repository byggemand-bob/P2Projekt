using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker_Game.AI;
using Poker_Game.Game;

namespace UnitTest {
    [TestClass]
    public class PokerGameUnitTest {
        public PokerGame Game;
        public Settings Settings;

        public void CreateProperties() {
            Settings = new Settings(2, 1000, 50, "bob", 1, AiMode.MonteCarlo);
            Game = new PokerGame(Settings);
        }

        [TestMethod]
        public void TestNumberOfPlayers() {
            // Arrange
            CreateProperties();
            int expected = 2;

            // Act
            int actual = Game.Players.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestRoundIncrements() {
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

            int expected = 5;

            // Act
            int actual = Game.Hand.CurrentRoundNumber();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestWinnerIfPlayerFolds() {
            // Arrange
            CreateProperties();
            // Round 1
            Game.Call();
            // Round 2
            Game.Fold();

            int expected = Game.Players[0].Id;

            // Act
            List<Player> actual = Game.GetWinners(Game.Hand);

            // Assert
            Assert.AreEqual(expected, actual[0].Id);
        }


        [TestMethod]
        public void TestRaiseFunctionality() {
            // Arrange
            CreateProperties();
            // Round 1
            Game.Raise();
            Game.Call();

            int expected = 400;

            // Act
            int actual = Game.Hand.Pot;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}