using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Game.AI.GameTree {
    class PokerTree {
        private Node Root { get; set; }

        public PokerTree() {
            Root = new Node(null, String.Empty);
            PathConstructor ph = new PathConstructor();
            

            ph.ConstructPath(Root,"R-RE-C-R-RE-C-R-RE-C", 5.0);

            
        }
    }
}
