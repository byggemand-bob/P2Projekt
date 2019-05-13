using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker_Game.Game;

namespace UnitTest
{
    [TestClass]
    public class MultiblePlayersWinconditionUnitTest
    {
        PokerGame Game = new PokerGame();

        [TestMethod]
        public void TestWinnerHighestCardOnTable()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player> { player1, player2 };
            Hand hand = new Hand(players);

            Card tableCard1 = new Card(Suit.Diamonds, Rank.Jack);
            Card tableCard2 = new Card(Suit.Hearts, Rank.King);
            Card tableCard3 = new Card(Suit.Spades, (Rank)4);
            Card tableCard4 = new Card(Suit.Diamonds, (Rank)5);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            player1.Cards.Add(new Card(Suit.Clubs, Rank.Queen)); // HighestCard: Queen
            player1.Cards.Add(new Card(Suit.Spades, (Rank)2));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Clubs, (Rank)8)); // HighestCard: 10
            player2.Cards.Add(new Card(Suit.Clubs, (Rank)10));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player1 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected.Count, actual.Count);
        }


        [TestMethod]
        public void TestWinnerOfHighestPair()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Hand hand = new Hand(players);

            Card tableCard1 = new Card(Suit.Diamonds, Rank.Queen);
            Card tableCard2 = new Card(Suit.Hearts, Rank.King);
            Card tableCard3 = new Card(Suit.Spades, (Rank)3);
            Card tableCard4 = new Card(Suit.Diamonds, (Rank)5);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);
            // Pair of 3
            player1.Cards.Add(new Card(Suit.Clubs, (Rank)3)); 
            player1.Cards.Add(new Card(Suit.Spades, (Rank)2));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);
            // Pair of 7 
            player2.Cards.Add(new Card(Suit.Clubs, (Rank)7)); 
            player2.Cards.Add(new Card(Suit.Clubs, (Rank)8));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player2 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected.Count, actual.Count);
        }


        [TestMethod]
        public void TestWinnerOfHighestFlush()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Hand hand = new Hand(players);

            Card tableCard1 = new Card(Suit.Spades, Rank.Queen);
            Card tableCard2 = new Card(Suit.Spades, Rank.King);
            Card tableCard3 = new Card(Suit.Spades, (Rank)3);
            Card tableCard4 = new Card(Suit.Diamonds, (Rank)5);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            player1.Cards.Add(new Card(Suit.Clubs, (Rank)3));
            player1.Cards.Add(new Card(Suit.Spades, (Rank)10));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Hearts, (Rank)7));
            player2.Cards.Add(new Card(Suit.Spades, (Rank)8));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player1 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected.Count, actual.Count);
        }


        [TestMethod]
        public void TestWinnerOfHighestStraight()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Hand hand = new Hand(players);

            Card tableCard1 = new Card(Suit.Diamonds, (Rank)4);
            Card tableCard2 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard3 = new Card(Suit.Spades, (Rank)6);
            Card tableCard4 = new Card(Suit.Diamonds, (Rank)7);
            Card tableCard5 = new Card(Suit.Spades, (Rank)5);

            player1.Cards.Add(new Card(Suit.Clubs, (Rank)3)); // Straight - 3, 4, 5, 6, 7
            player1.Cards.Add(new Card(Suit.Spades, Rank.Jack));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Clubs, (Rank)8)); // Straight - 4, 5, 6, 7, 8
            player2.Cards.Add(new Card(Suit.Hearts, Rank.King));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player2 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected.Count, actual.Count);
        }


        [TestMethod]
        public void TestWinnerOfHighestThreeOfAKind()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Hand hand = new Hand(players);
            // Filler
            Card tableCard1 = new Card(Suit.Diamonds, Rank.Queen);
            Card tableCard2 = new Card(Suit.Hearts, Rank.King);
            Card tableCard4 = new Card(Suit.Diamonds, (Rank)5);
            // Combinations
            Card tableCard3 = new Card(Suit.Spades, (Rank)3);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            player1.Cards.Add(new Card(Suit.Clubs, (Rank)3)); // 3 of 3's
            player1.Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Clubs, (Rank)4)); // 3 of 4's
            player2.Cards.Add(new Card(Suit.Hearts, (Rank)4));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player2 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected.Count, actual.Count);
        }


        [TestMethod]
        public void TestWinnerOfHighestCardOnHandWithSamePairOnTable()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Hand hand = new Hand(players);

            Card tableCard1 = new Card(Suit.Diamonds, Rank.Jack);
            Card tableCard2 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard3 = new Card(Suit.Spades, (Rank)4);
            Card tableCard4 = new Card(Suit.Diamonds, (Rank)4);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            player1.Cards.Add(new Card(Suit.Clubs, (Rank)3)); // HighestCard: Ace
            player1.Cards.Add(new Card(Suit.Spades, Rank.Ace));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Clubs, (Rank)6)); // HighestCard: 10
            player2.Cards.Add(new Card(Suit.Clubs, (Rank)10));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player1 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected.Count, actual.Count);
        }


        [TestMethod]
        public void TestWinnerOfHighestCardWithSamePairOnTable()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Hand hand = new Hand(players);

            Card tableCard1 = new Card(Suit.Diamonds, Rank.Jack);
            Card tableCard2 = new Card(Suit.Hearts, Rank.King);
            Card tableCard3 = new Card(Suit.Spades, (Rank)4);
            Card tableCard4 = new Card(Suit.Diamonds, (Rank)4);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            player1.Cards.Add(new Card(Suit.Clubs, (Rank)3)); // HighestCard: 3
            player1.Cards.Add(new Card(Suit.Spades, (Rank)2));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Clubs, (Rank)6)); // HighestCard: 10
            player2.Cards.Add(new Card(Suit.Clubs, (Rank)10));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player2 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected.Count, actual.Count);
        }


        [TestMethod]
        public void TestWinnerSameScoresPair()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Hand hand = new Hand(players);

            Card tableCard1 = new Card(Suit.Diamonds, Rank.Queen);
            Card tableCard2 = new Card(Suit.Hearts, Rank.King);
            Card tableCard3 = new Card(Suit.Spades, (Rank)3);
            Card tableCard4 = new Card(Suit.Diamonds, (Rank)5);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            player1.Cards.Add(new Card(Suit.Clubs, (Rank)4)); // Pair of 4
            player1.Cards.Add(new Card(Suit.Spades, (Rank)4));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Hearts, (Rank)4)); // Pair of 4
            player2.Cards.Add(new Card(Suit.Diamonds, (Rank)4));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player1, player2 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected.Count, actual.Count);
        }


        [TestMethod]
        public void TestWinnerHighestFourOfAKind()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Hand hand = new Hand(players);
            // Filler
            Card tableCard1 = new Card(Suit.Diamonds, Rank.Queen);
            // Combinations
            Card tableCard2 = new Card(Suit.Hearts, (Rank)3);
            Card tableCard3 = new Card(Suit.Spades, (Rank)3);
            Card tableCard4 = new Card(Suit.Hearts, (Rank)4);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            player1.Cards.Add(new Card(Suit.Clubs, (Rank)3)); // 4 of 3's
            player1.Cards.Add(new Card(Suit.Diamonds, (Rank)3));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Clubs, (Rank)4)); // 4 of 4's
            player2.Cards.Add(new Card(Suit.Hearts, (Rank)4));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player2 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected.Count, actual.Count);
        }


        [TestMethod]
        public void TestWinnerHighestTwoPair()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Hand hand = new Hand(players);
            // Filler
            Card tableCard1 = new Card(Suit.Diamonds, Rank.Jack);
            // 2 Pairs
            Card tableCard2 = new Card(Suit.Hearts, (Rank)4);
            Card tableCard3 = new Card(Suit.Spades, (Rank)5);
            Card tableCard4 = new Card(Suit.Diamonds, (Rank)6);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            player1.Cards.Add(new Card(Suit.Clubs, (Rank)5)); // Pair of 5's and 6's
            player1.Cards.Add(new Card(Suit.Spades, (Rank)6));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Clubs, (Rank)7)); // Pair of 4's and 7's
            player2.Cards.Add(new Card(Suit.Clubs, (Rank)4));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player2 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected.Count, actual.Count);
        }


        [TestMethod]
        public void TestWinnerHighestFullHouseSamePairTwo()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Hand hand = new Hand(players);
            // 3 of a kind
            Card tableCard1 = new Card(Suit.Diamonds, Rank.Jack);
            Card tableCard2 = new Card(Suit.Hearts, Rank.Jack);
            Card tableCard3 = new Card(Suit.Spades, (Rank)8);
            // Filler for pair
            Card tableCard4 = new Card(Suit.Diamonds, Rank.King);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            player1.Cards.Add(new Card(Suit.Clubs, Rank.King)); // Full house - 2x Jack + 3x King
            player1.Cards.Add(new Card(Suit.Spades, Rank.King));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Clubs, (Rank)7));  // FullHouse - 2x Jack + 3x 7
            player2.Cards.Add(new Card(Suit.Clubs, (Rank)7));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player1 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected.Count, actual.Count);
        }


        [TestMethod]
        public void TestWinnerHighestFullHouseSameThreeOfAKind()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Hand hand = new Hand(players);
            // 3 of a kind
            Card tableCard1 = new Card(Suit.Diamonds, Rank.Jack);
            Card tableCard2 = new Card(Suit.Hearts, Rank.Jack);
            Card tableCard3 = new Card(Suit.Spades, Rank.Jack);
            // Filler for pair
            Card tableCard4 = new Card(Suit.Diamonds, (Rank)2);
            Card tableCard5 = new Card(Suit.Spades, (Rank)8);

            player1.Cards.Add(new Card(Suit.Clubs, Rank.King)); // Full house - 2x Jack + 3x King
            player1.Cards.Add(new Card(Suit.Spades, Rank.King));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Clubs, (Rank)7));  // FullHouse - 2x Jack + 3x 7
            player2.Cards.Add(new Card(Suit.Clubs, (Rank)7));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player1 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected.Count, actual.Count);
        }


        [TestMethod]
        public void TestWinnerHighestCardSameTwoPair()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Hand hand = new Hand(players);

            Card tableCard1 = new Card(Suit.Spades, Rank.Ace);
            Card tableCard2 = new Card(Suit.Clubs, (Rank)6);
            Card tableCard3 = new Card(Suit.Clubs, Rank.Jack);
            Card tableCard4 = new Card(Suit.Hearts, (Rank)6);
            Card tableCard5 = new Card(Suit.Hearts, (Rank)4);

            player1.Cards.Add(new Card(Suit.Diamonds, (Rank)4)); 
            player1.Cards.Add(new Card(Suit.Spades, Rank.Jack));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Spades, (Rank)2)); 
            player2.Cards.Add(new Card(Suit.Hearts, Rank.Jack));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player1 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected.Count, actual.Count);
        }
    }
}