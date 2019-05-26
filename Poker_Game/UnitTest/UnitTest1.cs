using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker_Game.AI;
using Poker_Game.Game;

namespace UnitTest
{
    [TestClass]
    public class PokerAIMonteCarloUnitTest
    {
        public static Settings Settings = new Settings(2, 1000, 100, "player", 2, AiMode.MonteCarlo);
        public PokerGame Game = new PokerGame(Settings);

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            PokerAi pokerAi = new PokerAi(Game);
            pokerAi.PrepareNewTree();
            pokerAi.PrepareNewHand();

            // Act


            // Assert

        }
    }
}
