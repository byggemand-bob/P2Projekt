using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Poker_Game.Game;

namespace Poker_Game.AI {
    class PotSizeCalculator {
        private readonly int _blindSize;

        public PotSizeCalculator(Settings settings) {
            _blindSize = settings.BlindSize;
        }


        public int GetPotsize(string path) {
            string[] actions = SeparatePath(path);
            int result = 3 * _blindSize;

            foreach(string action in actions) {
                result += ParseAction(action);
            }

            return result;
        }

        private int ParseAction(string action) {
            switch(action) {
                case "RE":
                    return 4 * _blindSize;
                case "R":
                    return 2 * _blindSize;
                case "C":
                    return _blindSize;
                default:
                    return 0;
            }
        }

        private string[] SeparatePath(string path) {
            return path.Split('-');
        }
    }
}
