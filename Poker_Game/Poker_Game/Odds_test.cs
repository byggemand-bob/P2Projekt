﻿using System;
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
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan time;

            hand.Add(new Card(Suit.Hearts, Rank.Ace));
            hand.Add(new Card(Suit.Clubs, Rank.Ace));

            //street.Add(new Card(Suit.Clubs, Rank.King));
            //street.Add(new Card(Suit.Spades, (Rank)5));
            //street.Add(new Card(Suit.Spades, Rank.Jack));

            MonteCarloTrailOdds MonteCarlo = new MonteCarloTrailOdds();

            Console.WriteLine("Function 1: \n");

            stopwatch.Start();

            MonteCarlo.MultiThreadMonteCarlo(hand, street);

            stopwatch.Stop();

            time = stopwatch.Elapsed;

            Console.WriteLine("\ntime elapsed: {0}", String.Format("{0:00}:{1:00}.{2:00}", time.Minutes, time.Seconds, time.Milliseconds / 10));



            
            Console.WriteLine("\n------------------------------------------------------- \nFunction 2: \n");




            stopwatch.Reset();
            

            stopwatch.Start();

            MonteCarlo.TestMultiThreadMonteCarlo(hand, street);

            stopwatch.Stop();

            time = stopwatch.Elapsed;

            Console.WriteLine("\ntime elapsed: {0}", String.Format("{0:00}:{1:00}.{2:00}", time.Minutes, time.Seconds, time.Milliseconds / 10));
            

            Console.WriteLine("\n\nExpected value: wins: 87,23%, loses; 11,51%, draws: 1.26%");
            
            Console.ReadKey();
        }

        public static string PutDot(double inputNumber)
        {
            string outputNumber;

            outputNumber = inputNumber.ToString("#,##0");

            return outputNumber;
        }

    }
}
