using System.Collections.Generic;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class EVCalculator {
        private readonly Settings _settings;

        public EVCalculator(Settings settings) {
            _settings = settings;
        }

        public double CalculateMonteCarlo(List<Card> cardHand, Player player, Hand hand, Settings settings) {
            MonteCarloTrailOdds mctr = new MonteCarloTrailOdds();

            var odds = mctr.MultiThreadMonteCarlo(cardHand, hand.Street);
            var winPot = hand.Pot;
            var lossPot = 0;
            
            if(player.Action == PlayerAction.Raise || player.Action == PlayerAction.Call) {
                lossPot = settings.BetSize;
            } else if(player.Action == PlayerAction.Check) {
                lossPot = 0;
            }

            return (odds.WinOdds / 100) * winPot - (odds.LoseOdds / 100) * lossPot;
        }


        public double CalculateEv(string path, List<Card> cardHand, List<Card> street, Player player) {
            OutsCalculator outCalc = new OutsCalculator();
            PotSizeCalculator potCalc = new PotSizeCalculator(_settings);

            double winOdds = 2 * outCalc.CompareOuts(cardHand, street) * 0.01;
            double lossOdds = 1 - winOdds;
            double winPot = potCalc.GetPotsize(path);
            double lossPot = player.CurrentBet;

            return (winOdds * winPot) - (lossOdds * lossPot);
        }

        public double[] CalculateAll(string[] paths, List<Card> cardHand, List<Card> street, Player player) {
            double[] result = new double[paths.Length];
            for(int i = 0; i < paths.Length; i++) {
                result[i] = CalculateEv(paths[i], cardHand, street, player);
            }

            return result;
        }

    }
}