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

        private readonly Settings _settings;
        private readonly Player _player;
        public EVCalculator(Player player, Settings settings) {
            _player = player;
            _settings = settings;
        }


        private double CalculateEv(string path, List<Card> cardHand, List<Card> street) {
            OutsCalculator outCalc = new OutsCalculator();
            PotSizeCalculator potCalc = new PotSizeCalculator(_settings);

            double winOdds = 2 * outCalc.CompareOuts(cardHand, street) * 0.01;
            double lossOdds = 1 - winOdds;
            double winPot = potCalc.GetPotsize(path);
            double lossPot = _player.CurrentBet;

            //System.Windows.Forms.MessageBox.Show(((winOdds * winPot) - (lossOdds * lossPot)).ToString());

            return (winOdds * winPot) - (lossOdds * lossPot);
        }


        public double[] CalculateAll(string[] paths, List<Card> cardHand, List<Card> street) {
            double[] result = new double[paths.Length];
            for(int i = 0; i < paths.Length; i++) {
                result[i] = CalculateEv(paths[i], cardHand, street);
            }

            return result;
        }


    }
}
