using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // Spørg Mikkel om decimal er den bedste datatype
        private decimal CalcBinomial(int currentBet, int pot) {
            int possibleBet = currentBet + 2 * Settings.BlindSize;

                


            

        }
    }
}
