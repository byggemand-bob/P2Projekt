using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game {
    class Round {
        public List<Turn> Turns { get; set; }

        public Round() {
            Turns = new List<Turn>();
        }

        public void Start() {
            while(!IsFinished()) {

            }
        }

        private bool IsFinished() {

        }
    }

}
