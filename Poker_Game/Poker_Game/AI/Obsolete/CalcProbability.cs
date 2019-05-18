using System.Collections.Generic;
using Poker_Game.Game;

namespace Poker_Game.AI.Obsolete
{
    class CalcProbability
    {
        public Player Player { get; set; }
        public List<Card> Street { get; set; }
        public int NumberOfOuts { get; set; }
        

        public CalcProbability(Player player, int numberOfOuts, List<Card> flushcards) {
            Player = player;
        }

        private double CalculateProbability(Player player) {

            double unseenCards = 52 - Street.Count + player.Cards.Count;
            double cardOdds = unseenCards / NumberOfOuts;

            return cardOdds;
        }
    }
}





