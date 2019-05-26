using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class PotSizeCalculator {
        private readonly int _betSize;

        public PotSizeCalculator(Settings settings) {
            _betSize = settings.BetSize;
        }

        public int GetPotsize(string path) {
            string[] actions = SeparatePath(path);
            int result = _betSize + _betSize/2; // Big- and small-blind

            foreach(string action in actions) {
                result += ParseAction(action);
            }

            return result;
        }

        private int ParseAction(string action) {
            switch(action) {
                case "RE":
                    return 2 * _betSize;
                case "R":
                case "C":
                    return _betSize;
                default:
                    return 0;
            }
        }

        private string[] SeparatePath(string path) {
            return path.Split('-');
        }
    }
}
