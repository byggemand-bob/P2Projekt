using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;


namespace Poker_Game.AI {
    class AIName {
        public string Name { get; set; }
        public double PreCalls { get; set; }

        public double PreRaises { get; set; }

        public int Hands { get; set; }

        public double VPIP { get; set; }

        public double PFR { get; set; }

        public PokerGame Game { get; set; }


        private const int VPIPThreshold = 50;




        public void GeOpponent(string playerName) {
            VPIPReader reader = new VPIPReader(playerName);

            if(reader.HasExistingData()) {
                ExistingOpponent(reader);
            } else {
                NewOppenent(playerName);
            }
        }

        private void ExistingOpponent(VPIPReader reader) {
            VPIPData data = reader.ReadData();
            Name = data.PlayerName;
            PreRaises = data.NumberRaises;
            PreCalls = data.NumberCalls;
            Hands = data.NumberOfHands;
            VPIP = Hands / (PreCalls + PreRaises);
            PFR = Hands / PreRaises;
        }

        private void NewOppenent(string playerName) {
            Name = playerName;
            PreRaises = 0;
            PreCalls = 0;
            Hands = 0;
            VPIP = Hands / (PreCalls + PreRaises);
            PFR = Hands / PreRaises;
        }


        public double GetPFR() {
            return PFR;
        }

        public List<string> UpdateName(List<Turn> turns) {
            //PreRaises += GetRaise(turns);
            //PreCalls += GetCall(turns);

            PreCalls += GetNumberOf(PlayerAction.Call, turns);
            PreRaises += GetNumberOf(PlayerAction.Call, turns);
            Hands += 1;
            VPIP = (PreCalls + PreRaises) / Hands;
            PFR = PreRaises / Hands;

            // Should these be arrays?
            if(Hands < VPIPThreshold) {
                return new List<string>() { "66+", "A2s+", "K6s+", "Q8s+", "J8s+", "T8s+", "A7o+", "K9o+", "QTo+", "JTo" };
            } else if(VPIP >= 75) {
                return new List<string>() { "22+", "A2s+", "K2s+", "Q2s+", "J2s+", "T2s+", "92s+", "83s+", "73s+", "63s+", "52s+", "43s", "A2o+", "K2o+", "Q2o+", "J4o+", "T6o+", "96o+", " 86o+", "75o+", "65o" };
            } else if(VPIP >= 50) {
                return new List<string>() { "33+", "A2s+", "K2s+", "Q2s+", "J4s+", "T6s+", "96s+", "86s+", "76s", "65s", "A2o+", "K5o+", "Q7o+", "J7o+", "T8o+", "98o" };
            } else if(VPIP >= 35) {
                return new List<string>() { "55+", "A2s+", "K3s+", "Q6s+", "J7s+", "T7s+", "97s+", "87s", "A4o+", "K8o+", "Q9o+", "J9o+", "T9o" };
            } else if(VPIP >= 25) {
                return new List<string>() { "66+", "A2s+", "K6s+", "Q8s+", "J8s+", "T8s+", "A7o+", "K9o+", "QTo+", "JTo" };
            } else if(VPIP >= 20) {
                return new List<string>() { "66+", "A4s+", "K8s+", "Q9s+", "J9s+", "T9s", "A9o+", "KTo+", "QTo+", "JTo" };
            } else if(VPIP >= 15) {
                return new List<string>() { "77+", "A7s+", "K9s+", "QTs+", "JTs", "ATo+", "KTo+", "QJo" };
            } else if(VPIP >= 10) {
                return new List<string>() { "88+", "A9s+", "KTs+", "QTs+", "AJo+", "KQo" };
            } else {
                return new List<string>() { "99+", "AJs+", "KQs", "AKo" };
            }
        }

        private int GetNumberOf(PlayerAction action, List<Turn> turns) {
            if(action != PlayerAction.Call || action != PlayerAction.Raise) {
                throw new ArgumentException("The action argument only supports 'PlayerAction.Call' and 'PlayerAction.Raise'.");
            }
            for(int i = turns[0].Id; i < turns.Count; i += 2) {
                if(turns[i].Action == action) {
                    return 1;
                }
            }
            return 0;
        }



        //public int GetCall(List<Turn> Turn) {
        //    int Input = 0, i = 0;

        //    if(Turn[0].Id == 0) {
        //        for(i = 0; i < Turn.Count; i += 2) {
        //            if(Turn[i].Action == PlayerAction.Call) {
        //                return ++Input;
        //            }
        //        }
        //    } else {
        //        for(i = 1; i < Turn.Count; i += 2) {
        //            if(Turn[i].Action == PlayerAction.Call) {
        //                return ++Input;
        //            }
        //        }

        //    }
        //    return 0;
        //}

        //public int GetRaise(List<Turn> Turn) {
        //    int input = 0, i = 0;

        //    if(Turn[0].Id == 0) {
        //        for(i = 0; i < Turn.Count; i += 2) {
        //            if(Turn[i].Action == PlayerAction.Raise) {
        //                return ++input;
        //            }
        //        }
        //    } else {
        //        for(i = 1; i < Turn.Count; i += 2) {
        //            if(Turn[i].Action == PlayerAction.Raise) {
        //                return ++input;
        //            }
        //        }

        //    }

        //    return 0;
        //}

    }
}
