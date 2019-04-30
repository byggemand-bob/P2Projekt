using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker_Game.Game;

namespace UnitTest
{
    [TestClass]
    public class PokerGameUnitTest
    {
        PokerGame Game = new PokerGame();

        [TestMethod]
        public void TestWinnerHighestCardOnTable()
        {
            // Arrange
            Player player1 = new Player(1, 100);
            Player player2 = new Player(2, 100);
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Hand hand = new Hand(players);

            Card tableCard1 = new Card(Suit.Diamond, Rank.Jack);
            Card tableCard2 = new Card(Suit.Hearts, Rank.King);
            Card tableCard3 = new Card(Suit.Spades, (Rank)4);
            Card tableCard4 = new Card(Suit.Diamond, (Rank)5);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            player1.Cards.Add(new Card(Suit.Clubs, Rank.Queen)); // HighestCard: 3
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
            
            Card tableCard1 = new Card(Suit.Diamond, Rank.Queen);
            Card tableCard2 = new Card(Suit.Hearts, Rank.King);
            Card tableCard3 = new Card(Suit.Spades, (Rank)3);
            Card tableCard4 = new Card(Suit.Diamond, (Rank)5);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            player1.Cards.Add(new Card(Suit.Clubs, (Rank)3)); // Pair of 3
            player1.Cards.Add(new Card(Suit.Spades, (Rank)2));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Clubs, (Rank)7)); // Pair of 7
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
            Card tableCard4 = new Card(Suit.Diamond, (Rank)5);
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

            Card tableCard1 = new Card(Suit.Diamond, (Rank)4);
            Card tableCard2 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard3 = new Card(Suit.Spades, (Rank)6);
            Card tableCard4 = new Card(Suit.Diamond, (Rank)7);
            Card tableCard5 = new Card(Suit.Spades, Rank.Queen);

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
            Card tableCard1 = new Card(Suit.Diamond, Rank.Queen);
            Card tableCard2 = new Card(Suit.Hearts, Rank.King);
            Card tableCard4 = new Card(Suit.Diamond, (Rank)5);
            // Combinations
            Card tableCard3 = new Card(Suit.Spades, (Rank)3);
            Card tableCard5 = new Card(Suit.Spades, (Rank)4);

            player1.Cards.Add(new Card(Suit.Clubs, (Rank)3)); // 3 of 3's
            player1.Cards.Add(new Card(Suit.Diamond, (Rank)3));
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

            Card tableCard1 = new Card(Suit.Diamond, Rank.Jack);
            Card tableCard2 = new Card(Suit.Hearts, (Rank)5);
            Card tableCard3 = new Card(Suit.Spades, (Rank)4);
            Card tableCard4 = new Card(Suit.Diamond, (Rank)4);
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

            Card tableCard1 = new Card(Suit.Diamond, Rank.Jack);
            Card tableCard2 = new Card(Suit.Hearts, Rank.King);
            Card tableCard3 = new Card(Suit.Spades, (Rank)4);
            Card tableCard4 = new Card(Suit.Diamond, (Rank)4);
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

            List<Player> expected = new List<Player> { player1, player2 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
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

            Card tableCard1 = new Card(Suit.Diamond, Rank.Queen);
            Card tableCard2 = new Card(Suit.Hearts, Rank.King);
            Card tableCard3 = new Card(Suit.Spades, (Rank)3);
            Card tableCard4 = new Card(Suit.Diamond, (Rank)5);
            Card tableCard5 = new Card(Suit.Spades, (Rank)7);

            player1.Cards.Add(new Card(Suit.Clubs, (Rank)4)); // Pair of 4
            player1.Cards.Add(new Card(Suit.Spades, (Rank)4));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Hearts, (Rank)4)); // Pair of 4
            player2.Cards.Add(new Card(Suit.Diamond, (Rank)4));
            player2.Cards.Add(tableCard1);
            player2.Cards.Add(tableCard2);
            player2.Cards.Add(tableCard3);
            player2.Cards.Add(tableCard4);
            player2.Cards.Add(tableCard5);

            List<Player> expected = new List<Player> { player1, player2 };

            // Act
            List<Player> actual = Game.GetWinners(hand);

            // Assert
            Assert.AreEqual(expected.Count, actual.Count);
        }
    }
}
