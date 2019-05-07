using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;


namespace Poker_Game.AI
{
    class AIOpponent
    {
        public string Opponent { get; set; }
        public double PreCalls { get; set; }

        public double PreRaise { get; set; }

        public double Rounds { get; set; }

        public double VPIP { get; set; }

        public double PFR { get; set; }
        
        public PokerGame Game { get; set; }
      




        public void GetOpponent(string PlayerName)
        {
            VPIPReader Reader = new VPIPReader(PlayerName);

            if(Reader.HasExistingData() == true)
            {
                VPIPData data = Reader.ReadData();
                Opponent = data.PlayerName;
                PreRaise = data.NumberRaises;
                PreCalls = data.NumberCalls;
                Rounds = data.NumberOfHands;
                VPIP = Rounds / (PreCalls + PreRaise);
                PFR = Rounds / PreRaise;
            }
            else
            {
                Opponent = PlayerName;
                PreRaise = 0;
                PreCalls = 0;
                Rounds = 0;
                VPIP = Rounds / (PreCalls + PreRaise);
                PFR = Rounds / PreRaise;
            }


        }

        public double GetPFR()
        {
            return PFR;
        }

        public List<string> UpdateOpponent( List<Turn> Turns )
        {
            List<string> VPIP5 = new List<string>() { "99+", "AJs+", "KQs", "AKo" };
            List<string> VPIP10 = new List<string>() { "88+", "A9s+", "KTs+", "QTs+", "AJo+,KQo" };
            List<string> VPIP15 = new List<string>() { "77+", "A7s+", "K9s+", "QTs+", "JTs", "ATo+","KTo+", "QJo" };
            List<string> VPIP20 = new List<string>() { "66+", "A4s+", "K8s+", "Q9s+", "J9s+", "T9s","A9o+", "KTo+", "QTo+", "JTo" };
            List<string> VPIP25 = new List<string>() { "66+", "A2s+", "K6s+", "Q8s+", "J8s+", "T8s+", "A7o+", "K9o+", "QTo+", "JTo" };

            List<string> VPIP35 = new List<string>() { "55+", "A2s+", "K3s+", "Q6s+", "J7s+", "T7s+", "97s+", "87s", "A4o+", "K8o+", "Q9o+", "J9o+", "T9o" };
            List<string> VPIP50 = new List<string>() { "33+", "A2s+", "K2s+", "Q2s+", "J4s+", "T6s+", "96s+", "86s+", "76s", "65s", "A2o+", "K5o+", "Q7o+", "J7o+", "T8o+", "98o" };
            List<string> VPIP75 = new List<string>() { "22+", "A2s+", "K2s+", "Q2s+", "J2s+", "T2s+", "92s+", "83s+", "73s+", "63s+", "52s+", "43s", "A2o+", "K2o+", "Q2o+", "J4o+", "T6o+", "96o+"," 86o +", "75o+", "65o" };

            

            PreRaise += GetRaise(Turns);

            PreCalls += GetCall(Turns);

            Rounds += 1;

            VPIP = (PreCalls + PreRaise) / Rounds;

            PFR = PreRaise / Rounds;    

            if(Rounds < 50)
            {
                return VPIP25;
            }else if(VPIP >= 75)
            {
                return VPIP75;
            } else if (VPIP >= 50)
            {
                return VPIP50;
            } else if(VPIP >= 35)
            {
                return VPIP35;
            } else if(VPIP >= 25)
            {
                return VPIP25;
            } else if (VPIP >= 20)
            {
                return VPIP20;
            } else if(VPIP >= 15)
            {
                return VPIP15;
            } else if(VPIP >= 10)
            {
                return VPIP10;
            } else
            {
                return VPIP5;
            }

        }
        

        public int GetCall(List<Turn> Turn)
        {
            int Input = 0, i = 0;

           if(Turn[0].Id == 0)
            {
                for(i = 0; i < Turn.Count; i += 2)
                {
                    if(Turn[i].Action == PlayerAction.Call)
                    {
                        return ++Input;
                    }
                }
            }
            else
            {
                for (i = 1; i < Turn.Count; i += 2)
                {
                    if (Turn[i].Action == PlayerAction.Call)
                    {
                        return ++Input;
                    }
                }

            }


            return 0;
        }

        public int GetRaise(List<Turn> Turn)
        {
            int Input = 0, i = 0;

            if(Turn[0].Id == 0)
            {
                for (i = 0; i < Turn.Count; i += 2)
                {
                    if (Turn[i].Action == PlayerAction.Raise)
                    {
                        return ++Input;
                    }
                }
            }
            else
            {
                for (i = 1; i < Turn.Count; i += 2)
                {
                    if (Turn[i].Action == PlayerAction.Raise)
                    {
                        return ++Input;
                    }
                }

            }

            return 0;
        }
    }
}
