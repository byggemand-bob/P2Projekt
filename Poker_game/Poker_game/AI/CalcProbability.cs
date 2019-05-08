using System.Collections.Generic;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class CalcProbability {
        public Player Player { get; set; }
        public List<Card> Street { get; set; }
        public PlayerCardsInHand PlayerCardsInHands { get; set; }
        public int NumberOfOuts { get; set; }
        public List<Card> flushCards { get; set; }

       public CalcProbability(Player player, PlayerCardsInHand cardsInHands, int numberOfOuts, List<Card> flushCards) {
            Player = player;
            PlayerCardsInHands = cardsInHands;
        }

        private double CalculateProbability(Player player) {
            double unseenCards = 52 - Street.Count + player.Cards.Count;
            double cardOdds = unseenCards / NumberOfOuts;

            return cardOdds;
        }
    }
}





