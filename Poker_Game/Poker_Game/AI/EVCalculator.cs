using System.Collections.Generic;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class EVCalculator {
        private readonly Settings _settings;
        private readonly PokerGame _pokerGame;

        public EVCalculator(PokerGame game, Settings settings) {
            _settings = settings;
            _pokerGame = game;
        }

        public List<double> CalculateMonteCarlo(List<Card> cardHand, Player player, Hand hand, Settings settings) {
            MonteCarloTrailOdds mctr = new MonteCarloTrailOdds();
            List<double> monteCarloRates = new List<double>();

            var odds = mctr.MultiThreadMonteCarlo(cardHand, hand.Street);
            var winPot = hand.Pot;
            var bet = 0;
            var call = 0;

            if (_pokerGame.CanCall() && _pokerGame.CanRaise()) {
                bet = 2 * settings.BetSize;
                call = settings.BetSize;

                var evBet = (odds.WinOdds / 100) * winPot - (odds.LoseOdds / 100) * bet;
                var evCall = (odds.WinOdds / 100) * winPot - (odds.LoseOdds / 100) * call;
                monteCarloRates.Add(evBet);
                monteCarloRates.Add(evCall);

            }

            if (_pokerGame.CanCheck() && _pokerGame.CanRaise()) {
                bet = settings.BetSize;
                call = 0;

                var evBet = (odds.WinOdds / 100) * winPot - (odds.LoseOdds / 100) * bet;
                var evCall = (odds.WinOdds / 100) * winPot - (odds.LoseOdds / 100) * call;
                monteCarloRates.Add(evBet);
                monteCarloRates.Add(evCall);

            }

            if (_pokerGame.CanCall() && !_pokerGame.CanCheck()) {
                bet = settings.BetSize;

                var evBet = (odds.WinOdds / 100) * winPot - (odds.LoseOdds / 100) * bet;
                monteCarloRates.Add(evBet);
            }

            return monteCarloRates;
        }

        public double CalculateEv(string path, List<Card> street, Player player) {
            OutsCalculator outCalc = new OutsCalculator();
            PotSizeCalculator potCalc = new PotSizeCalculator(_settings);

            double winOdds = 2 * outCalc.CompareOuts(player.Cards, street) * 0.01;
            double lossOdds = 1 - winOdds;
            double winPot = potCalc.GetPotsize(path);
            double lossPot = player.CurrentBet;

            return (winOdds * winPot) - (lossOdds * lossPot);
        }

        public double[] CalculateAll(string[] paths, List<Card> street, Player player) {
            double[] result = new double[paths.Length];
            for(int i = 0; i < paths.Length; i++) {
                result[i] = CalculateEv(paths[i], street, player);
            }

            return result;
        }

    }
}