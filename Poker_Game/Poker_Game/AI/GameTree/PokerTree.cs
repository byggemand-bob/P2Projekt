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

            WriteAll(Root);
        }


        private void WriteAll(Node node) {
            if(node.Children.Count != 0) {
                WriteAll(node.Children[0]);
                Console.WriteLine(node.Children[0].Action);
            } else {
                Console.WriteLine(node.Action);
            }

            
        }
        



    }
}
