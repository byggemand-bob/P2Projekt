using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.AI;

namespace Poker_Game
{
    class Odds_test
    {

        static void Main()
        {
            List<Card> hand = new List<Card>();
            List<Card> street = new List<Card>();

            hand.Add(new Card(Suit.Clubs, Rank.Queen));
            hand.Add(new Card(Suit.Clubs, (Rank)10));

            street.Add(new Card(Suit.Clubs, Rank.King));
            street.Add(new Card(Suit.Spades, Rank.Jack));
            street.Add(new Card(Suit.Spades, (Rank)5));

            CardOdds cardodds = new CardOdds(street, hand);

            Console.WriteLine("{0}", cardodds.totalNumberOfOutcomes);
        }
    }
}
