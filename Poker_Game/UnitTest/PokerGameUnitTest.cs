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
        public void TestWinnerOfHighestPair()
        {
            // Arrange
            Player player1 = new Player(0, 100);
            Player player2 = new Player(1, 100);
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

            player2.Cards.Add(new Card(Suit.Clubs, (Rank)7)); // Pair of 7
            player2.Cards.Add(new Card(Suit.Clubs, (Rank)8));

            hand.Deck.Add(tableCard1);
            hand.Deck.Add(tableCard2);
            hand.Deck.Add(tableCard3);
            hand.Deck.Add(tableCard4);
            hand.Deck.Add(tableCard5);

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
            Player player1 = new Player(0, 100);
            Player player2 = new Player(1, 100);
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

            player2.Cards.Add(new Card(Suit.Hearts, (Rank)7)); 
            player2.Cards.Add(new Card(Suit.Spades, (Rank)8));

            hand.Deck.Add(tableCard1);
            hand.Deck.Add(tableCard2);
            hand.Deck.Add(tableCard3);
            hand.Deck.Add(tableCard4);
            hand.Deck.Add(tableCard5);

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
            Player player1 = new Player(0, 100);
            Player player2 = new Player(1, 100);
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
            player1.Cards.Add(new Card(Suit.Spades, Rank.King));
            player1.Cards.Add(tableCard1);
            player1.Cards.Add(tableCard2);
            player1.Cards.Add(tableCard3);
            player1.Cards.Add(tableCard4);
            player1.Cards.Add(tableCard5);

            player2.Cards.Add(new Card(Suit.Clubs, (Rank)2)); // Straight - 4, 5, 6, 7, 8
            player2.Cards.Add(new Card(Suit.Hearts, (Rank)8)); 
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
    }
}
