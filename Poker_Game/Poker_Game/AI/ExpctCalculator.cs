using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.AI.Opponent;
using Poker_Game.Game;

namespace Poker_Game.AI
{
    class ExpctCalculator
    { /*
       public List<List<Card>> VPIPRange { get; set; }
        public OpponentData OpponentData { get; set; }
        public PokerGame Game { get; set; }
        public Player player { get; set; }
        private readonly Round _round;
        

        public ExpctCalculator(PokerGame game, List<List<Card>> vpiprange, OpponentData opponentdata) {
            VPIPRange = vpiprange;
            OpponentData = opponentdata;
            Game = game;
            _round = game.CurrentRound();
        }


        public List<List<Card>> splitVpipRange(List<List<Card>> vpiprange, OpponentData opponentdata,
            int opponentVPIPRange) {
            int splitNumber = 0;
            List<List<Card>> callRange = new List<List<Card>>();
            List<List<Card>> foldRange = new List<List<Card>>();
            List<List<Card>> splitUpCards = new List<List<Card>>();
            VpipController vc = new VpipController();

            OutsCalculator oc = new OutsCalculator();
        }



        public List<string> FindRange(int range) {
                // Should these be arrays?
                
                if (range >= 75) {
                    return new List<string> { "55+", "A2s+", "K3s+", "Q6s+", "J7s+", "T7s+", "97s+", "87s", "A4o+", "K8o+", "Q9o+", "J9o+", "T9o" };
                }

                if (range >= 50) {
                    return new List<string> { "66+", "A2s+", "K6s+", "Q8s+", "J8s+", "T8s+", "A7o+", "K9o+", "QTo+", "JTo" };
                }
                if (range >= 35) {
                    return new List<string> {"66+", "A6s+", "K9s+", "QTs+", "JTs", "ATo+", "KTo+", "QTo+", "JTo"};
                }
                if (range >= 25) {
                    return new List<string> { "77+", "A6s+", "K9s+", "QTs+", "JTs", "ATo+", "KTo+", "QJo" };
                }
                if (range >= 20) {
                    return new List<string> { "88+", "A9s+", "KTs+", "QTs+", "AJo+", "KQo" };
                }
                if (range >= 15) {
                    return new List<string> { "TT+", "AJs+", "KJs+", "QTs+", "AJo+", "KQo" };
                }

                if (range >= 10) {
                    return new List<string> { "QQ+", "AQs+", "KQs", "AQo+", "KQ" };
                }

                return new List<string>();

            }

        public List<List<Card>> parseRange(int rangeToParse, List<List<Card>> vpiprange) {

            RangeParser rp = new RangeParser();

            var opponentRaiseRange = rp.Parse(FindRange(rangeToParse)).ToList();
            var opponentCheckRange = vpiprange.Except(opponentRaiseRange).ToList();

            List<List<Card>> opponentRanges = new List<List<Card>>(opponentRaiseRange);
            opponentRanges.AddRange(opponentCheckRange);

            return opponentRanges;

        }

        public List<string> createRanges(int range, PokerGame _pokerGame, Player _player) {
                

                if (Game.CurrentRoundNumber() == 1) {
                    //Find på noget at gøre der er nemt
                }

                if (Game.CurrentRoundNumber() == 2) {
                if (_player.IsSmallBlind) { 
                    if (_pokerGame.Players[0].PreviousAction == PlayerAction.Raise) {
                        
                    }


                }


                if (Game.CurrentRoundNumber() == 3) {
                    Turn();
                }

                if (Game.CurrentRoundNumber() == 4) {
                    River();
                }
            }
        
            private PlayerAction PreFlop(PokerGame game) {
                MonteCarloDecisionMaking mcd = new MonteCarloDecisionMaking(game);
                return mcd.PreFlop();
            }

            private PlayerAction Flop(OpponentData opponentdata, Player player) {

                var BBReRaise = (opponentdata.BigBlindHands.ReRaises.Length;
                var BBRaise = opponentdata.BigBlindHands.Raises.Length;
                var BBCall = opponentdata.BigBlindHands.Calls.Length;
                var BBCheck = opponentdata.BigBlindHands.Checks.Length;
                var BBFold = opponentdata.BigBlindHands.Folds.Length;

                var SBReRaise = opponentdata.SmallBlindHands.ReRaises.Length;
                var SBRaise = opponentdata.SmallBlindHands.Raises.Length;
                var SBCall = opponentdata.SmallBlindHands.Calls.Length;
                var SBCheck = opponentdata.SmallBlindHands.Checks.Length;
                var SBFold = opponentdata.SmallBlindHands.Folds.Length;
            }

            public PlayerAction Turn() {
                //Opdel i raise/call/fold ud fra EV
            }


            private PlayerAction River() {
                //Opdel i raise/call/fold ud fra EV

            }


    


        
        // Tag procentvis inddeling baseret på raise / call / fold
        // Find vores valg baseret på EV
        // Find de kort der giver wincons der slår vores / dem vi slår og inddel
        // Find % værdier: han raiser vi vinder / taber - han caller vi vinder / taber - han folder
        // Inddel værdier i lister

        //rinse and repeat for turn og river
        //Tjek hans narrowed list af hænder mod vores, er der størst % for at vi vinder eller taber, call / fold herefter
        
        */
    }
}
