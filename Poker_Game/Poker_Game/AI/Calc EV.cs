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
        
        public void CalcEv(Player player, Turn turns, CalcOuts getOuts, List<Card> street, PlayerCardsInHand cardsinhand, CalcFlushOuts flushouts, CalcPairOuts pairouts, CalcStraightOuts straightouts) {
            players = player;
            Turns = turns;
            CalculateOuts = getOuts;
            Street = street;
            PlayerCardsInHand = cardsinhand;
            CalcFlushOuts = flushouts;
            CalcPairOuts = pairouts;
            CalcStraightOuts = straightouts;
        }

        public double CalculateEV(Player player, Turn turns, CalcOuts getOuts, List<Card> street, PlayerCardsInHand cardsinhand, CalcFlushOuts flushouts, CalcPairOuts pairouts, CalcStraightOuts straightouts) {
            double ExpectedValue = 0;

            var WinOdds = 2 * getOuts.compareOuts(player, street, cardsinhand, flushouts, pairouts, straightouts);
            var LossOdds = 100 - WinOdds;
            ExpectedValue = 
        }


        
    }
}
