using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI
{
    class CalcEV
    {
        public Player players { get; set; }
        public Turn Turns { get; set; }
        public List<Card> Street { get; set; }
        public PlayerCardsInHand PlayerCardsInHand { get; set; }
        public int numberOfOuts { get; set; }
        public WinConditions WinConditions { get; set; }
        public CalcFlushOuts CalcFlushOuts { get; set; }
        public CalcPairOuts CalcPairOuts { get; set; }
        public CalcStraightOuts CalcStraightouts { get; set; }
        public CalcOuts CalculateOuts { get; set; }
        
        public void CalcEv(Player player, Turn turns, CalcOuts getOuts, List<Card> street, PlayerCardsInHand cardsInHand, CalcFlushOuts flushOuts, CalcPairOuts pairOuts, CalcStraightOuts straightOuts) {
            players = player;
            Turns = turns;
            CalculateOuts = getOuts;
            Street = street;
            PlayerCardsInHand = cardsInHand;
            CalcFlushOuts = flushOuts;
            CalcPairOuts = pairOuts;
            CalcStraightOuts = straightOuts;
        }

        public double CalculateEV(Player player, Turn turns, CalcOuts getOuts, List<Card> street, PlayerCardsInHand cardsInHand, CalcFlushOuts flushOuts, CalcPairOuts pairoOuts, CalcStraightOuts straightOuts) {
            double ExpectedValue = 0;

            var WinOdds = 2 * getOuts.compareOuts(player, street, cardsInHand, flushOuts, pairoOuts, straightOuts);
            var LossOdds = 100 - WinOdds;
            ExpectedValue = 
        }


        
    }
}
