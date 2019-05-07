using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI
{
    class CalcEV
    {
        public Player players { get; set; }
        public Turn Turns { get; set; }

        public void CalcEv(Player player, Turn turns) {
            players = player;
            Turns = turns;
        }

        
    }
}
