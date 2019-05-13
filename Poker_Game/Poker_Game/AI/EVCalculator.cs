using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.AI;
using Poker_Game.Game;

namespace Poker_Game.AI {


    class EVCalculator {

        public Settings Settings { get; set; }
        public Player Player { get; set; }
        public EVCalculator(Player player, Settings settings) {
            Player = player;
            Settings = settings;
        }
        
        
        public double CalculateEV(string path, List<Card> cardHand, List<Card> street, Player player, Settings settings) {
            OutsCalculator outCalc = new OutsCalculator();
            PotSizeCalculator potCalc = new PotSizeCalculator(settings);
            double ExpectedValue = 0;

            var WinOdds = 2 * outCalc.CompareOuts(cardHand, street);
            var LossOdds = 100 - WinOdds;
            var WinPot = potCalc.GetPotsize(path);
            var LossPot = player.CurrentBet;

            ExpectedValue = (WinOdds * WinPot) - (LossOdds * LossPot);

            return ExpectedValue;
        }


        public double[] CalculateAll(string[] paths, List<Card> cardHand, List<Card> street, Player player, Settings settings) {
            double[] result = new double[paths.Length];
            for(int i = 0; i < paths.Length; i++) {
                result[i] = CalculateEV(paths[i], cardHand, street, player, settings);
            }

            return result;
        }


    }
}
