﻿using System.Collections.Generic;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class EVCalculator {
        private readonly Settings _settings;
        private readonly PokerGame _pokerGame;

        public EVCalculator(PokerGame game, Settings settings) {
            _settings = settings;
            _pokerGame = game;
        }

        public List<double> CalculateMonteCarlo(List<Card> cardHand, Hand hand, Settings settings) {
            MonteCarloTrailOdds mctr = new MonteCarloTrailOdds();
            List<double> monteCarloRates = new List<double>();

            var odds = mctr.MultiThreadMonteCarlo(cardHand, hand.Street);
            var winOdds = odds.WinOdds;
            var lossOdds = odds.LoseOdds;
            
            monteCarloRates.Add(winOdds);
            monteCarloRates.Add(lossOdds);

            return monteCarloRates;
        }

        public double CalculateEv(string path, List<Card> street, Player player, Settings settings) {
            OutsCalculator outCalc = new OutsCalculator();
            PotSizeCalculator potCalc = new PotSizeCalculator(_settings);

            double winOdds = 2 * outCalc.CompareOuts(player.Cards, street) * 0.01;
            double lossOdds = 1 - winOdds;
            double winPot = potCalc.GetPotsize(path);
            double lossPot = settings.BetSize;

            return (winOdds * winPot) - (lossOdds * lossPot);
        }

        public double[] CalculateAll(string[] paths, List<Card> street, Player player, Settings settings) {
            double[] result = new double[paths.Length];
            for(int i = 0; i < paths.Length; i++) {
                result[i] = CalculateEv(paths[i], street, player, settings);
            }

            return result;
        }

    }
}