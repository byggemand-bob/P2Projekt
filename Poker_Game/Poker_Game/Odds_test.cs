using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.AI;
using Poker_Game.Game;
using System.Diagnostics;

namespace Poker_Game
{
    class Odds_test
    {
       // public double test;
       // public string outputNumber;

        static void Main()
        {
            List<Card> hand = new List<Card>();
            List<Card> street = new List<Card>();
            Calculator Calc = new Calculator();
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan time;

            hand.Add(new Card(Suit.Hearts, Rank.Ace));
            hand.Add(new Card(Suit.Clubs, Rank.Ace));

            street.Add(new Card(Suit.Clubs, Rank.King));
            street.Add(new Card(Suit.Spades, Rank.Jack));
            street.Add(new Card(Suit.Spades, (Rank)5));

            MonteCarloTrailOdds MonteCarlo = new MonteCarloTrailOdds(hand, street);

            stopwatch.Start();

            //MonteCarlo.RunTrails(10000);
            //MonteCarlo.PrintResults();

            Console.WriteLine("{0}", MonteCarlo.MultiThreadMonteCarlo(40000));

            stopwatch.Stop();

            time = stopwatch.Elapsed;

            Console.WriteLine("time elapsed: {0}", String.Format("{0:00}:{1:00}.{2:00}", time.Minutes, time.Seconds, time.Milliseconds / 10));
            
            Console.ReadKey();
        }

        

    }
}
