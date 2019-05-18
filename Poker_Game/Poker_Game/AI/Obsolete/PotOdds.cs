﻿using System.Collections.Generic;
using Poker_Game.Game;

namespace Poker_Game.AI.Obsolete {
    class PotOdds {
        public int Pot { get; set; }
        public List<Turn> Turns { get; set; }

        public Player Player { get; set; }

        public void potodds(List<Turn> turns, int pot, Player player) {
            Turns = turns;
            Pot = pot;
            Player = player;
        }

        public double CalcPotOdds(List<Turn> turns, int pot, Player player) {
            var potOdds = pot / player.CurrentBet;
            return potOdds;
        }
    }
}