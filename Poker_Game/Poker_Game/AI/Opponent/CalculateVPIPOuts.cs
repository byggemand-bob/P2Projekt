using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.AI.Opponent.VPIP;
using Poker_Game.Game;

namespace Poker_Game.AI.Opponent {
    class CalculateVPIPOuts {
        
        public List<List<Card>> FindOpponentRank(List<Card> Hand, List<Card> street, string playerName) {

            RangeParser rp = new RangeParser();
            OutsCalculator oc = new OutsCalculator();
            VPIPController vpc = new VPIPController(playerName);

            List<List<Card>> playerOutsRange = new List<List<Card>>();

            List<string> vpipOutsList = vpc.GetRange();

            var vpipRange = rp.Parse(vpipOutsList);

            foreach (var element in vpipRange) {

                if (oc.CompareOuts(element, street) != 0) {
                    playerOutsRange.Add(element);
                }

            }

            return playerOutsRange;
        }

    }
}