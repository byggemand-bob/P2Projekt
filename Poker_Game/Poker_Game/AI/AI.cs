using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class AI {
        public Player Player { get; set; }
        public List<Hand> Hands { get; set; }
        public int Pot { get; set; }
        public Settings Settings { get; set; }

        public AI(Player player, List<Hand> hands, Settings settings) {
            Player = player;
            Hands = hands;
            Settings = settings;
        }


        public void MakeDecision() {

        }

        private double CalcFaculty(double number) {


           

            double fact, i;

            fact = number;

            for (i = number - 1; i >= 1; i--)
            {
                fact = fact * i;
            }

            return fact;

        }

        private double CalcBinomial(List<Hand> hands){
            double r, n;

            r = CalcFaculty(Hands.Count);
            n = (52 - Hands.Count);


            return n / r * (n - r);
        }
    }
}
