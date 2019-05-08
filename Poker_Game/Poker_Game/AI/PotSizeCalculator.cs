using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.AI {
    class PotSizeCalculator {


        public PotSizeCalculator() {
            
        }


        public int GetPotsize(string path) {
            string[] actions = SeparatePath(path);
            int result = 0;

            foreach(string action in actions) {
                result += ParseAction(action);
            }

        }

        private int ParseAction(string action) {

        }

        private string[] SeparatePath(string path) {
            return path.Split('-');
        }

    }
}
