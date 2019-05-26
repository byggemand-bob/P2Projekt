using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker_Game.AI;
using Poker_Game.Game;

namespace UnitTest
{
    [TestClass]
    public class MonteCarloDecisionMakingUnitTest
    {
        public Settings Settings = new Settings(2, 100000, 50, "player", 2, AiMode.MonteCarlo);

        [TestMethod]
        public void RaiseAtPreflopTest()
        {
            // Arrange
            PokerGame PokerGame = new PokerGame(Settings);
            MonteCarloDecisionMaking MonteCarloDecisionMaking = new MonteCarloDecisionMaking(PokerGame);

            PokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, Rank.Ace);
            PokerGame.Players[1].Cards[1] = new Card(Suit.Diamonds, Rank.Ace);

            PlayerAction expected = PlayerAction.Raise;

            // Act
            PlayerAction actual = MonteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FoldAtPreflopTest()
        {
            // Arrange
            PokerGame PokerGame = new PokerGame(Settings);
            MonteCarloDecisionMaking MonteCarloDecisionMaking = new MonteCarloDecisionMaking(PokerGame);

            PokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, (Rank)3);
            PokerGame.Players[1].Cards[1] = new Card(Suit.Diamonds, (Rank)10);

            PlayerAction expected = PlayerAction.Fold;

            // Act
            PlayerAction actual = MonteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CallAtPreflopTest()
        {
            // Arrange
            PokerGame PokerGame = new PokerGame(Settings);
            MonteCarloDecisionMaking MonteCarloDecisionMaking = new MonteCarloDecisionMaking(PokerGame);
            PokerGame.Raise(); // Player
            PokerGame.Raise(); // AI
            PokerGame.Raise(); // Player

            PokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, (Rank)2);
            PokerGame.Players[1].Cards[1] = new Card(Suit.Diamonds, (Rank)2);

            PlayerAction expected = PlayerAction.Call;

            // Act
            PlayerAction actual = MonteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CheckAtPreflopTest()
        {
            // Arrange
            PokerGame PokerGame = new PokerGame(Settings);
            MonteCarloDecisionMaking MonteCarloDecisionMaking = new MonteCarloDecisionMaking(PokerGame);
            PokerGame.Call(); // PlayerMove -> AI can check when both players has same amount in stack. 

            PokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, (Rank)3);
            PokerGame.Players[1].Cards[1] = new Card(Suit.Clubs, (Rank)7);

            PlayerAction expected = PlayerAction.Check;

            // Act
            PlayerAction actual = MonteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void RaiseAtFlopTurnTest()
        {
            // Arrange
            PokerGame PokerGame = new PokerGame(Settings);
            MonteCarloDecisionMaking MonteCarloDecisionMaking = new MonteCarloDecisionMaking(PokerGame);
            // Preflop
            PokerGame.Call();
            PokerGame.Check();
            // Flop
            PokerGame.Check();

            PokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, Rank.Ace);
            PokerGame.Players[1].Cards[1] = new Card(Suit.Clubs, Rank.Ace);
            PokerGame.Hand.Street[0] = new Card(Suit.Clubs, Rank.Ace);
            PokerGame.Hand.Street[1] = new Card(Suit.Clubs, Rank.Jack);
            PokerGame.Hand.Street[2] = new Card(Suit.Clubs, (Rank)7);

            PlayerAction expected = PlayerAction.Raise;

            // Act
            PlayerAction actual = MonteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CallAtFlopTurnTest()
        {
            // Arrange
            PokerGame PokerGame = new PokerGame(Settings);
            MonteCarloDecisionMaking MonteCarloDecisionMaking = new MonteCarloDecisionMaking(PokerGame);
            // Preflop
            PokerGame.Call();
            PokerGame.Check();
            // Flop
            PokerGame.Raise(); //Player
            PokerGame.Raise(); // AI
            PokerGame.Raise(); // Player

            PokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, Rank.Ace);
            PokerGame.Players[1].Cards[1] = new Card(Suit.Clubs, Rank.Ace);
            PokerGame.Hand.Street[0] = new Card(Suit.Clubs, Rank.Ace);
            PokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            PokerGame.Hand.Street[2] = new Card(Suit.Clubs, (Rank)7);

            PlayerAction expected = PlayerAction.Call;

            // Act
            PlayerAction actual = MonteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CheckAtFlopTurnTest()
        {
            // Arrange
            PokerGame PokerGame = new PokerGame(Settings);
            MonteCarloDecisionMaking MonteCarloDecisionMaking = new MonteCarloDecisionMaking(PokerGame);
            // Preflop
            PokerGame.Call();
            PokerGame.Check();
            // Flop
            PokerGame.Check(); //Player

            PokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, (Rank)2);
            PokerGame.Players[1].Cards[1] = new Card(Suit.Diamonds, (Rank)8);
            PokerGame.Hand.Street[0] = new Card(Suit.Clubs, Rank.Ace);
            PokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            PokerGame.Hand.Street[2] = new Card(Suit.Clubs, (Rank)7);

            PlayerAction expected = PlayerAction.Check;

            // Act
            PlayerAction actual = MonteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FoldAtFlopTurnTest()
        {
            // Arrange
            PokerGame PokerGame = new PokerGame(Settings);
            MonteCarloDecisionMaking MonteCarloDecisionMaking = new MonteCarloDecisionMaking(PokerGame);
            // Preflop
            PokerGame.Call();
            PokerGame.Check();
            // Flop
            PokerGame.Raise(); //Player

            PokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, (Rank)2);
            PokerGame.Players[1].Cards[1] = new Card(Suit.Diamonds, (Rank)8);
            PokerGame.Hand.Street[0] = new Card(Suit.Clubs, Rank.Ace);
            PokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            PokerGame.Hand.Street[2] = new Card(Suit.Clubs, (Rank)7);

            PlayerAction expected = PlayerAction.Fold;

            // Act
            PlayerAction actual = MonteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void RaiseAtRiverTest()
        {
            // Arrange
            PokerGame PokerGame = new PokerGame(Settings);
            MonteCarloDecisionMaking MonteCarloDecisionMaking = new MonteCarloDecisionMaking(PokerGame);
            // Preflop
            PokerGame.Call();
            PokerGame.Check();
            // Flop
            PokerGame.Check();
            PokerGame.Check();
            // Turn
            PokerGame.Check();
            PokerGame.Check();
            // River
            PokerGame.Check();

            PokerGame.Players[1].Cards[0] = new Card(Suit.Spades, Rank.Ace);
            PokerGame.Players[1].Cards[1] = new Card(Suit.Spades, Rank.King);
            PokerGame.Hand.Street[0] = new Card(Suit.Spades, Rank.Queen);
            PokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            PokerGame.Hand.Street[2] = new Card(Suit.Spades, (Rank)10);
            PokerGame.Hand.Street[3] = new Card(Suit.Clubs, (Rank)9);
            PokerGame.Hand.Street[4] = new Card(Suit.Clubs, (Rank)8);

            PlayerAction expected = PlayerAction.Raise;

            // Act
            PlayerAction actual = MonteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CallAtRiverTest()
        {
            // Arrange
            PokerGame PokerGame = new PokerGame(Settings);
            MonteCarloDecisionMaking MonteCarloDecisionMaking = new MonteCarloDecisionMaking(PokerGame);
            // Preflop
            PokerGame.Call();
            PokerGame.Check();
            // Flop
            PokerGame.Check();
            PokerGame.Check();
            // Turn
            PokerGame.Check();
            PokerGame.Check();
            // River
            PokerGame.Check();
            PokerGame.Raise();
            PokerGame.Raise();

            PokerGame.Players[1].Cards[0] = new Card(Suit.Spades, Rank.Ace);
            PokerGame.Players[1].Cards[1] = new Card(Suit.Spades, Rank.King);
            PokerGame.Hand.Street[0] = new Card(Suit.Spades, Rank.Queen);
            PokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            PokerGame.Hand.Street[2] = new Card(Suit.Spades, (Rank)10);
            PokerGame.Hand.Street[3] = new Card(Suit.Clubs, (Rank)9);
            PokerGame.Hand.Street[4] = new Card(Suit.Clubs, (Rank)8);

            PlayerAction expected = PlayerAction.Call;

            // Act
            PlayerAction actual = MonteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CheckAtRiverTest()
        {
            // Arrange
            PokerGame PokerGame = new PokerGame(Settings);
            MonteCarloDecisionMaking MonteCarloDecisionMaking = new MonteCarloDecisionMaking(PokerGame);
            // Preflop
            PokerGame.Call();
            PokerGame.Check();
            // Flop
            PokerGame.Check();
            PokerGame.Check();
            // Turn
            PokerGame.Check();
            PokerGame.Check();
            // River
            PokerGame.Raise();
            PokerGame.Call();
            PokerGame.Check();

            PokerGame.Players[1].Cards[0] = new Card(Suit.Spades, Rank.Ace);
            PokerGame.Players[1].Cards[1] = new Card(Suit.Spades, Rank.King);
            PokerGame.Hand.Street[0] = new Card(Suit.Spades, Rank.Queen);
            PokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            PokerGame.Hand.Street[2] = new Card(Suit.Spades, (Rank)10);
            PokerGame.Hand.Street[3] = new Card(Suit.Clubs, (Rank)9);
            PokerGame.Hand.Street[4] = new Card(Suit.Clubs, (Rank)8);

            PlayerAction expected = PlayerAction.Check;

            // Act
            PlayerAction actual = MonteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FoldAtRiverTest()
        {
            // Arrange
            PokerGame PokerGame = new PokerGame(Settings);
            MonteCarloDecisionMaking MonteCarloDecisionMaking = new MonteCarloDecisionMaking(PokerGame);
            // Preflop
            PokerGame.Call();
            PokerGame.Check();
            // Flop
            PokerGame.Check();
            PokerGame.Check();
            // Turn
            PokerGame.Check();
            PokerGame.Check();
            // River
            PokerGame.Raise();

            PokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, (Rank)2);
            PokerGame.Players[1].Cards[1] = new Card(Suit.Diamonds, (Rank)8);
            PokerGame.Hand.Street[0] = new Card(Suit.Clubs, Rank.Ace);
            PokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            PokerGame.Hand.Street[2] = new Card(Suit.Spades, (Rank)7);
            PokerGame.Hand.Street[3] = new Card(Suit.Diamonds, (Rank)4);
            PokerGame.Hand.Street[4] = new Card(Suit.Hearts, (Rank)2);

            PlayerAction expected = PlayerAction.Fold;

            // Act
            PlayerAction actual = MonteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
