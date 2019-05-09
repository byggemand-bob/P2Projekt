using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.AI.Outs;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class EVCalculator {
        public double CalculateEV(string path, List<Card> cardHand, List<Card> street) {
            OutsCalculator outCalc = new OutsCalculator();
            double ExpectedValue = 0;

            var WinOdds = 2 * outCalc.CompareOuts(cardHand, street);
            var LossOdds = 100 - WinOdds;
            return 0;
        }


        public double[] CalculateAll(string[] paths, List<Card> cardHand, List<Card> street) {
            double[] result = new double[paths.Length];
            for(int i = 0; i < paths.Length; i++) {
                result[i] = CalculateEV(paths[i], cardHand, street);
            }

            return result;
        }


    }
}
