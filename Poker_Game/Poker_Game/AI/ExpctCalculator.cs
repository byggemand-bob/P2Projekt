using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.AI.Opponent;
using Poker_Game.AI.Opponent.VPIP;
using Poker_Game.Game;

namespace Poker_Game.AI
{
    class ExpctCalculator
    {
        public List<List<Card>> VPIPRange { get; set; }
        public OpponentData OpponentData { get; set; }
        public PokerGame Game { get; set; }
        private readonly Round _round;

        public ExpctCalculator(PokerGame game, List<List<Card>> vpiprange, OpponentData opponentdata) {
            VPIPRange = vpiprange;
            OpponentData = opponentdata;
            Game = game;
            _round = game.CurrentRound();
        }

        public List<List<Card>> splitVpipRange(List<List<Card>> vpiprange, OpponentData opponentdata, int opponentVPIPRange) {
            int splitNumber = 0;
            List<List<Card>> raiseRange = new List<List<Card>>();
            List<List<Card>> callRange = new List<List<Card>>();
            List<List<Card>> foldRange = new List<List<Card>>();
            List<List<Card>> splitUpCards = new List<List<Card>>();
            VpipController vc = new VpipController();

            OutsCalculator oc = new OutsCalculator();

            rivate List<string> FindRange(int range) {
                // Should these be arrays?
                var _vpip = range;
                
                if (_vpip >= 75)
                {
                    return new List<string> { "55+", "A2s+", "K3s+", "Q6s+", "J7s+", "T7s+", "97s+", "87s", "A4o+", "K8o+", "Q9o+", "J9o+", "T9o" };
                }


                if (_vpip >= 50)
                {
                    return new List<string> { "66+", "A2s+", "K6s+", "Q8s+", "J8s+", "T8s+", "A7o+", "K9o+", "QTo+", "JTo" };
                }
                if (_vpip >= 35)
                {
                    "66+", "A6s+", "K9s+", "QTs+", "JTs", "ATo+", "KTo+", "QTo+" "JTo"
                }
                if (_vpip >= 25)
                {
                    return new List<string> { "77+", "A6s+", "K9s+", "QTs+", "JTs", "ATo+", "KTo+", "QJo" };
                }
                if (_vpip >= 20)
                {
                    return new List<string> { "88+", "A9s+", "KTs+", "QTs+", "AJo+", "KQo" };
                }
                if (_vpip >= 15)
                {
                    return new List<string> { "88+", "A9s+", "KTs+", "QTs+", "AJo+", "KQo" };
                }

                if (_vpip >= 10) ;
                {
                    
                }
                return new List<string> { "99+", "AJs+", "KQs", "AKo" };
            }



            if (Game.CurrentRoundNumber() == 1) {
                raiseRange = vc.
            }

            if (Game.CurrentRoundNumber() == 2)
            {

            }

            if (Game.CurrentRoundNumber() == 3)
            {

            }

            if (Game.CurrentRoundNumber() == 4)
            {

            }
        }

        
        // Tag procentvis inddeling baseret på raise / call / fold
        // Find vores valg baseret på EV
        // Find de kort der giver wincons der slår vores / dem vi slår og inddel
        // Find % værdier: han raiser vi vinder / taber - han caller vi vinder / taber - han folder
        // Inddel værdier i lister

        //rinse and repeat for turn og river
        //Tjek hans narrowed list af hænder mod vores, er der størst % for at vi vinder eller taber, call / fold herefter


    }
}
