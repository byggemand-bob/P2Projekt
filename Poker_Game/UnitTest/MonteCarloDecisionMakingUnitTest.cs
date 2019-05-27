using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker_Game.AI;
using Poker_Game.Game;

namespace UnitTest {
    [TestClass]
    public class MonteCarloDecisionMakingUnitTest {
        public Settings Settings = new Settings(2, 100000, 50, "player", 1, AiMode.MonteCarlo);

        [TestMethod]
        public void RaiseAtPreflopTest() {
            // Arrange
            PokerGame pokerGame = new PokerGame(Settings);
            MonteCarloEvDecisionMaking monteCarloDecisionMaking = new MonteCarloEvDecisionMaking(pokerGame);

            pokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, Rank.Ace);
            pokerGame.Players[1].Cards[1] = new Card(Suit.Diamonds, Rank.Ace);

            PlayerAction expected = PlayerAction.Raise;

            // Act
            PlayerAction actual = monteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FoldAtPreflopTest() {
            // Arrange
            PokerGame pokerGame = new PokerGame(Settings);
            MonteCarloEvDecisionMaking monteCarloDecisionMaking = new MonteCarloEvDecisionMaking(pokerGame);

            pokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, (Rank) 3);
            pokerGame.Players[1].Cards[1] = new Card(Suit.Diamonds, (Rank) 10);

            PlayerAction expected = PlayerAction.Fold;

            // Act
            PlayerAction actual = monteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CallAtPreflopTest() {
            // Arrange
            PokerGame pokerGame = new PokerGame(Settings);
            MonteCarloEvDecisionMaking monteCarloDecisionMaking = new MonteCarloEvDecisionMaking(pokerGame);
            pokerGame.Raise(); // Player
            pokerGame.Raise(); // AI
            pokerGame.Raise(); // Player

            pokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, (Rank) 2);
            pokerGame.Players[1].Cards[1] = new Card(Suit.Diamonds, (Rank) 2);

            PlayerAction expected = PlayerAction.Call;

            // Act
            PlayerAction actual = monteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CheckAtPreflopTest() {
            // Arrange
            PokerGame pokerGame = new PokerGame(Settings);
            MonteCarloEvDecisionMaking monteCarloDecisionMaking = new MonteCarloEvDecisionMaking(pokerGame);
            pokerGame.Call(); // PlayerMove -> AI can check when both players has same amount in stack. 

            pokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, (Rank) 3);
            pokerGame.Players[1].Cards[1] = new Card(Suit.Clubs, (Rank) 7);

            PlayerAction expected = PlayerAction.Check;

            // Act
            PlayerAction actual = monteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void RaiseAtFlopTurnTest() {
            // Arrange
            PokerGame pokerGame = new PokerGame(Settings);
            MonteCarloEvDecisionMaking monteCarloDecisionMaking = new MonteCarloEvDecisionMaking(pokerGame);
            // Preflop
            pokerGame.Call();
            pokerGame.Check();
            // Flop
            pokerGame.Check();

            pokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, Rank.Ace);
            pokerGame.Players[1].Cards[1] = new Card(Suit.Clubs, Rank.Ace);
            pokerGame.Hand.Street[0] = new Card(Suit.Clubs, Rank.Ace);
            pokerGame.Hand.Street[1] = new Card(Suit.Clubs, Rank.Jack);
            pokerGame.Hand.Street[2] = new Card(Suit.Clubs, (Rank) 7);

            PlayerAction expected = PlayerAction.Raise;

            // Act
            PlayerAction actual = monteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CallAtFlopTurnTest() {
            // Arrange
            PokerGame pokerGame = new PokerGame(Settings);
            MonteCarloEvDecisionMaking monteCarloDecisionMaking = new MonteCarloEvDecisionMaking(pokerGame);
            // Preflop
            pokerGame.Call();
            pokerGame.Check();
            // Flop
            pokerGame.Raise(); //Player
            pokerGame.Raise(); // AI
            pokerGame.Raise(); // Player

            pokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, Rank.Ace);
            pokerGame.Players[1].Cards[1] = new Card(Suit.Clubs, Rank.Ace);
            pokerGame.Hand.Street[0] = new Card(Suit.Clubs, Rank.Ace);
            pokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            pokerGame.Hand.Street[2] = new Card(Suit.Clubs, (Rank) 7);

            PlayerAction expected = PlayerAction.Call;

            // Act
            PlayerAction actual = monteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CheckAtFlopTurnTest() {
            // Arrange
            PokerGame pokerGame = new PokerGame(Settings);
            MonteCarloEvDecisionMaking monteCarloDecisionMaking = new MonteCarloEvDecisionMaking(pokerGame);
            // Preflop
            pokerGame.Call();
            pokerGame.Check();
            // Flop
            pokerGame.Check(); //Player

            pokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, (Rank) 2);
            pokerGame.Players[1].Cards[1] = new Card(Suit.Diamonds, (Rank) 8);
            pokerGame.Hand.Street[0] = new Card(Suit.Clubs, Rank.Ace);
            pokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            pokerGame.Hand.Street[2] = new Card(Suit.Clubs, (Rank) 7);

            PlayerAction expected = PlayerAction.Check;

            // Act
            PlayerAction actual = monteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FoldAtFlopTurnTest() {
            // Arrange
            PokerGame pokerGame = new PokerGame(Settings);
            MonteCarloEvDecisionMaking monteCarloDecisionMaking = new MonteCarloEvDecisionMaking(pokerGame);
            // Preflop
            pokerGame.Call();
            pokerGame.Check();
            // Flop
            pokerGame.Raise(); //Player

            pokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, (Rank) 2);
            pokerGame.Players[1].Cards[1] = new Card(Suit.Diamonds, (Rank) 8);
            pokerGame.Hand.Street[0] = new Card(Suit.Clubs, Rank.Ace);
            pokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            pokerGame.Hand.Street[2] = new Card(Suit.Clubs, (Rank) 7);

            PlayerAction expected = PlayerAction.Fold;

            // Act
            PlayerAction actual = monteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void RaiseAtRiverTest() {
            // Arrange
            PokerGame pokerGame = new PokerGame(Settings);
            MonteCarloEvDecisionMaking monteCarloDecisionMaking = new MonteCarloEvDecisionMaking(pokerGame);
            // Preflop
            pokerGame.Call();
            pokerGame.Check();
            // Flop
            pokerGame.Check();
            pokerGame.Check();
            // Turn
            pokerGame.Check();
            pokerGame.Check();
            // River
            pokerGame.Check();

            pokerGame.Players[1].Cards[0] = new Card(Suit.Spades, Rank.Ace);
            pokerGame.Players[1].Cards[1] = new Card(Suit.Spades, Rank.King);
            pokerGame.Hand.Street[0] = new Card(Suit.Spades, Rank.Queen);
            pokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            pokerGame.Hand.Street[2] = new Card(Suit.Spades, (Rank) 10);
            pokerGame.Hand.Street[3] = new Card(Suit.Clubs, (Rank) 9);
            pokerGame.Hand.Street[4] = new Card(Suit.Clubs, (Rank) 8);

            PlayerAction expected = PlayerAction.Raise;

            // Act
            PlayerAction actual = monteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CallAtRiverTest() {
            // Arrange
            PokerGame pokerGame = new PokerGame(Settings);
            MonteCarloEvDecisionMaking monteCarloDecisionMaking = new MonteCarloEvDecisionMaking(pokerGame);
            // Preflop
            pokerGame.Call();
            pokerGame.Check();
            // Flop
            pokerGame.Check();
            pokerGame.Check();
            // Turn
            pokerGame.Check();
            pokerGame.Check();
            // River
            pokerGame.Check(); // Player
            pokerGame.Raise(); // AI
            pokerGame.Raise(); // Player

            pokerGame.Players[1].Cards[0] = new Card(Suit.Spades, Rank.Ace);
            pokerGame.Players[1].Cards[1] = new Card(Suit.Spades, Rank.King);
            pokerGame.Hand.Street[0] = new Card(Suit.Spades, Rank.Queen);
            pokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            pokerGame.Hand.Street[2] = new Card(Suit.Spades, (Rank) 10);
            pokerGame.Hand.Street[3] = new Card(Suit.Clubs, (Rank) 9);
            pokerGame.Hand.Street[4] = new Card(Suit.Clubs, (Rank) 8);

            PlayerAction expected = PlayerAction.Call;

            // Act
            PlayerAction actual = monteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CheckAtRiverTest() {
            // Arrange
            PokerGame pokerGame = new PokerGame(Settings);
            MonteCarloEvDecisionMaking monteCarloDecisionMaking = new MonteCarloEvDecisionMaking(pokerGame);
            // Preflop
            pokerGame.Call();
            pokerGame.Check();
            // Flop
            pokerGame.Check();
            pokerGame.Check();
            // Turn
            pokerGame.Check();
            pokerGame.Check();
            // River
            pokerGame.Raise();
            pokerGame.Call();
            pokerGame.Check();

            pokerGame.Players[1].Cards[0] = new Card(Suit.Spades, Rank.Ace);
            pokerGame.Players[1].Cards[1] = new Card(Suit.Spades, Rank.King);
            pokerGame.Hand.Street[0] = new Card(Suit.Spades, Rank.Queen);
            pokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            pokerGame.Hand.Street[2] = new Card(Suit.Spades, (Rank) 10);
            pokerGame.Hand.Street[3] = new Card(Suit.Clubs, (Rank) 9);
            pokerGame.Hand.Street[4] = new Card(Suit.Clubs, (Rank) 8);

            PlayerAction expected = PlayerAction.Check;

            // Act
            PlayerAction actual = monteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void FoldAtRiverTest() {
            // Arrange
            PokerGame pokerGame = new PokerGame(Settings);
            MonteCarloEvDecisionMaking monteCarloDecisionMaking = new MonteCarloEvDecisionMaking(pokerGame);
            // Preflop
            pokerGame.Call();
            pokerGame.Check();
            // Flop
            pokerGame.Check();
            pokerGame.Check();
            // Turn
            pokerGame.Check();
            pokerGame.Check();
            // River
            pokerGame.Raise();

            pokerGame.Players[1].Cards[0] = new Card(Suit.Clubs, (Rank) 2);
            pokerGame.Players[1].Cards[1] = new Card(Suit.Diamonds, (Rank) 8);
            pokerGame.Hand.Street[0] = new Card(Suit.Clubs, Rank.Ace);
            pokerGame.Hand.Street[1] = new Card(Suit.Spades, Rank.Jack);
            pokerGame.Hand.Street[2] = new Card(Suit.Spades, (Rank) 7);
            pokerGame.Hand.Street[3] = new Card(Suit.Diamonds, (Rank) 4);
            pokerGame.Hand.Street[4] = new Card(Suit.Hearts, (Rank) 2);

            PlayerAction expected = PlayerAction.Fold;

            // Act
            PlayerAction actual = monteCarloDecisionMaking.GetNextAction();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}